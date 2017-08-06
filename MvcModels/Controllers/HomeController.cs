using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }
        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        public ViewResult DisplaySummary
            ([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))] AddressSummary summary)
        {
            return View(summary);
        }
    }
}
