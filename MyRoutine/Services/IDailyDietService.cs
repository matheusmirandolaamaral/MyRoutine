using MyRoutine.Models;

namespace MyRoutine.Services
{
    public interface IDailyDietService
    {
        Task<DailyDiet?> GetByDateAsync(DateTime date);
        Task<DailyDiet> SetDietForTodayAsync(int dietId);
    }
}
