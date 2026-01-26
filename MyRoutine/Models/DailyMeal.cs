namespace MyRoutine.Models
{
    public class DailyMeal
    {
        public int Id { get; set; }
        public int DailyDietId { get; set; }
        public int MealId { get; set; }
        public DailyDiet DailyDiet { get; set; }
        public Meal Meal { get; set; }

    }
}
