using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers {

    public class ExampleController : Controller {

        public StatusCodeResult Index() => NotFound();
    }
}
