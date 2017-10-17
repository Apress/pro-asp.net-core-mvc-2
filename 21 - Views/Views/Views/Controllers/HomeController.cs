using System;
using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers {

    public class HomeController : Controller {

        public ViewResult Index() =>
            View("MyView", new string[] { "Apple", "Orange", "Pear" });

        public ViewResult List() => View();
    }
}
