using System;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Components {

    public class TimeViewComponent : ViewComponent {

        public IViewComponentResult Invoke() {
            return View(DateTime.Now);
        }
    }
}
