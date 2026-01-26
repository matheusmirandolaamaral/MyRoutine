using MyRoutine.Controllers;
using System.Reflection.Metadata.Ecma335;

namespace MyRoutine.Models
{
    public class DailyDiet
    {
        public int Id { get; set; }
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public DateTime Date { get; set; }
        public ICollection<DailyMeal> DailyMeals { get; set; } = new List<DailyMeal>();
    }
}
