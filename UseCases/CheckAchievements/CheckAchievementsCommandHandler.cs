using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpClicker.Web.Domain;
using CSharpClicker.Web.Infrastructure.Abstractions;
using CSharpClicker.Web.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSharpClicker.Web.UseCases.CheckAchievements
{
    public class CheckAchievementsCommandHandler : IRequestHandler<CheckAchievementsCommand, AchievementsViewModel>
    {
        private IAppDbContext appDbContext;
        private readonly ICurrentUserAccessor currentUserAccessor;

        public CheckAchievementsCommandHandler(IAppDbContext dbContext, ICurrentUserAccessor currentUserAccessor)
        {
            this.appDbContext = dbContext;
            this.currentUserAccessor = currentUserAccessor;
        }

        public async Task<AchievementsViewModel> Handle(CheckAchievementsCommand request, CancellationToken cancellationToken)
        {
            var userId = currentUserAccessor.GetCurrentUserId();

            // Получаем все достижения
            var allAchievements = await appDbContext.Achievements.ToListAsync(cancellationToken);

            // Получаем данные пользователя
            var user = await appDbContext.ApplicationUsers
                .Include(u => u.UserBoosts) // Подключаем UserBoosts для получения всех бустов
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new Exception("Пользователь не найден");

            var userScore = user.RecordScore; // Получаем рекордный счёт пользователя
            var userBoostCount = user.UserBoosts.Count; // Количество бустов у пользователя

            // Проверяем выполнение достижений
            var completedAchievements = allAchievements
                .Where(a => IsAchievementCompleted(a, userScore, userBoostCount))
                .ToList();

            var uncompletedAchievements = allAchievements
                .Where(a => !IsAchievementCompleted(a, userScore, userBoostCount))
                .ToList();

            // Возвращаем список для отображения
            return new AchievementsViewModel
            {
                Achievements = allAchievements,
                UserAchievements = completedAchievements
                    .Select(a => new UserAchievement
                    {
                        UserId = userId,
                        AchievementId = a.Id,
                        Achievement = a,
                        UnlockedAt = DateTime.UtcNow // Это значение может быть не актуальным, но оно не используется для невыполненных достижений
                    })
                    .ToList()
            };
        }

        // Метод проверки выполнения достижения
        private bool IsAchievementCompleted(Achievement achievement, long userScore, int userBoostCount)
        {
            // Проверка на достижения, основанные на очках
            if (achievement.RequiredScore.HasValue && userScore < achievement.RequiredScore.Value)
            {
                return false;
            }

            // Проверка на достижения, основанные на количестве бустов
            if (achievement.RequiredBoostCount.HasValue && userBoostCount < achievement.RequiredBoostCount.Value)
            {
                return false;
            }

            return true;
        }
    }
}
