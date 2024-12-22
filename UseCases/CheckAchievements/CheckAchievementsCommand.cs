using CSharpClicker.Web.ViewModels;
using MediatR;

namespace CSharpClicker.Web.UseCases.CheckAchievements
{
    public record CheckAchievementsCommand : IRequest<AchievementsViewModel>;

}
