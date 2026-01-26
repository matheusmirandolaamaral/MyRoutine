namespace MyRoutine.Models.ViewModels
{
    public class MealSelectViewModel
    {
        public int DailyDietId { get; set; }
        public List<int> SelectMeals { get; set; } = new();
    }
}
