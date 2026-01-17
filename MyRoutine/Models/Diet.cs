using MyRoutine.Models.Enums;

namespace MyRoutine.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime? DateFinal { get; set; }
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

        public Diet()
        {
        }

        public Diet(int id, string name, DateTime dateInitial, DateTime? dateFinal)
        {
            Id = id;
            Name = name;
            DateInitial = dateInitial;
            DateFinal = dateFinal;
        }

        public void AddMeal(Meal meal)
        {
            Meals.Add(meal);
        }
    }
}