using MyRoutine.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyRoutine.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateInitial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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