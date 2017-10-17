using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers {

    public class HomeController : Controller {

        public ViewResult Index() =>
            View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder" });
    }
}
