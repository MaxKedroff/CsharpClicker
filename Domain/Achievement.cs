namespace CSharpClicker.Web.Domain
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? RequiredScore { get; set; } // Нужное количество очков
        public int? RequiredBoostCount { get; set; } // Нужное количество бустов
    }
}
