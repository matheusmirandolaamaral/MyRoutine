using MyRoutine.Models.Enums;

namespace MyRoutine.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Calories { get; set; }
        public MealType Type { get; set; }
        public Diet Diet { get; set; }
        public int DietId { get; set; }

        public Meal(int id, string name, string? description,int? calories, MealType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Calories = calories;
        }

        public Meal()
        {
        }
    }
}
