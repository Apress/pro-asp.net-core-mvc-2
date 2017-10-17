using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers {

    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller {
        private ICityRepository repository;

        public CityController(ICityRepository repo) {
            repository = repo;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity) {
            repository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() => new ViewViewComponentResult() {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData,
                repository.Cities)
        };
    }
}
