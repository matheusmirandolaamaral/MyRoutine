namespace MyRoutine.Models.ViewModels
{
    public class DietDetailsViewModel
    {
        public Diet Diet { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public int? TotalCalories { get; set; }
    }
}
