using System.Collections;
using System.Collections.Generic;
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

        public IActionResult Index([FromQuery] int? id)
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

        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) =>
            View(addresses ?? new List<AddressSummary>());

        public string HeaderAccept([FromHeader]string accept) => $"Header: {accept}";

        public string HeaderAcceptLanguage([FromHeader(Name = "Accept-Language")] string accept)
            => $"Header: {accept}";
    }
}
