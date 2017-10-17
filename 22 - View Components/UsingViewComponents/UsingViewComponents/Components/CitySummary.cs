using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UsingViewComponents.Components {

    public class CitySummary : ViewComponent {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo) {
            repository = repo;
        }

        public IViewComponentResult Invoke(bool showList) {
            if (showList) {
                return View("CityList", repository.Cities);
            } else {
                return View(new CityViewModel {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(c => c.Population)
                });
            }
        }
    }
}
