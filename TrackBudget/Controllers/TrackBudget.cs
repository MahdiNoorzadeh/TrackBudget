using Microsoft.AspNetCore.Mvc;

namespace TrackBudget.Controllers
{
    public class TrackBudget : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
