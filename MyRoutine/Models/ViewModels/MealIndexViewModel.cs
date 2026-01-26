namespace MyRoutine.Models.ViewModels
{
    public class MealIndexViewModel
    {
        public Diet Diet { get; set; }

        public ICollection<Meal> Meals { get; set; }
        public List<int> SelectMeals { get; set; } 

        public int? TotalCalories { get; set; }
    }
}
