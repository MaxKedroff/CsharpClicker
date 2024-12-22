using CSharpClicker.Web.Domain;

namespace CSharpClicker.Web.ViewModels
{
    public class AchievementsViewModel
    {
        public List<Achievement> Achievements { get; set; } = new();
        public List<UserAchievement> UserAchievements { get; set; } = new();
    }
}
