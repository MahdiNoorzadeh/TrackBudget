using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrackBudget.Models;

namespace TrackBudget.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrackBudgetDbContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, TrackBudgetDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _dbcontext.expenses.ToList();
            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }
        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var expanseInDb = _dbcontext.expenses.SingleOrDefault(expanse => expanse.Id == id);
                return View(expanseInDb);
            }

            return View();
        }

        public IActionResult DeleteExpence(int id)
        {
            var expanseInDb = _dbcontext.expenses.SingleOrDefault(expanse => expanse.Id == id);
            _dbcontext.expenses.Remove(expanseInDb);
            _dbcontext.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense expense)
        {
            if(expense.Id == 0)
            {
                _dbcontext.expenses.Add(expense);
            }
            else
            {
                _dbcontext.expenses.Update(expense);
            }
            _dbcontext.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
