using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers {

    public class HomeController : Controller {
        private IRepository repository;

        public HomeController(IRepository repo) {
            repository = repo;
        }

        public IActionResult Index([FromQuery] int? id) {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null) {
                return View(person);
            } else {
                return NotFound();
            }
        }

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Person Body([FromBody]Person model) => model;
    }
}