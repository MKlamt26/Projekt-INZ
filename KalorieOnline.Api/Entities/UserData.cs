namespace KalorieOnline.Api.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Activity { get; set; }
        public double DailyRequirementKcal { get; set; }
        public double DailyRequirementFat { get; set; }
        public double DailyRequirementProtein { get; set; }
        public double DailyRequirementCarbo { get; set; }
    }
}
