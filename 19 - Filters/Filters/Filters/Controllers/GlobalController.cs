using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers {

    public class GlobalController : Controller {

        public ViewResult Index() => View("Message",
            "This is the global controller");
    }
}
