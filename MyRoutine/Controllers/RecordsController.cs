using Microsoft.AspNetCore.Mvc;
using MyRoutine.Models;

namespace MyRoutine.Controllers
{
    public class RecordsController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

       
    }
}
