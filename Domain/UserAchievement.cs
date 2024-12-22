using System.Numerics;

namespace CSharpClicker.Web.Domain
{
    public class UserAchievement
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; } = null!;

        public DateTime UnlockedAt { get; set; } = DateTime.UtcNow;
    }
}
