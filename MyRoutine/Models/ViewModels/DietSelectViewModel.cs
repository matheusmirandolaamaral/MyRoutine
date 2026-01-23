namespace MyRoutine.Models.ViewModels
{
    public class DietSelectViewModel
    {
        public List<DietIndexViewModel> Diets { get; set; } = new();
        public bool SelectMode { get; set; }
    }
}
