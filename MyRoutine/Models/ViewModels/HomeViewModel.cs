namespace MyRoutine.Models.ViewModels
{
    public class HomeViewModel
    {
        public Diet Diet { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public int? TotalCalories { get; set; }
        public DailyDiet DailyDiet { get; set; }
        public int? CountMeals { get; set; }
    }
}
