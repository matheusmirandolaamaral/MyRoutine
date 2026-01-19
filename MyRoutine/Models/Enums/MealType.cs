using System.ComponentModel.DataAnnotations;

namespace MyRoutine.Models.Enums
{
    public enum MealType
    {
        [Display(Name ="Café da manhã")]
        Breakfast,
        [Display(Name = "Lanche da manhã")]
        MorningSnack,
        [Display(Name = "Almoço")]
        Lunch,
        [Display(Name = "Lanche da tarde")]
        AfternoonSnack,
        [Display(Name = "Janta")]
        Dinner
    }
}
