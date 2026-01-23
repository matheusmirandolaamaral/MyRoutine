using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;

namespace MyRoutine.Services
{
    public class DailyDietService : IDailyDietService
    {
        private readonly MyRoutineContext _context;

        public DailyDietService(MyRoutineContext context)
        {
            _context = context;
        }

        public async Task<DailyDiet?> GetByDateAsync(DateTime date)
        {
            var today = date.Date;

            return await _context.DailyDiets.Include(d => d.Diet).FirstOrDefaultAsync(d => d.Date == today);
        }

        public async Task<DailyDiet> SetDietForTodayAsync(int dietId)
        {
            var today = DateTime.Today;

            var dailyDiet = await _context.DailyDiets.FirstOrDefaultAsync(x => x.Date == today);

            if(dailyDiet == null)
            {
                dailyDiet = new DailyDiet
                {
                    DietId = dietId,
                    Date = today
                };
                _context.DailyDiets.Add(dailyDiet);
            }
            else
            {
                dailyDiet.DietId = dietId;
                _context.DailyDiets.Update(dailyDiet);
            }
            await _context.SaveChangesAsync();
            return dailyDiet;


        }
    }
}
