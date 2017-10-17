using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ControllersAndActions.Controllers {

    public class PocoController {

        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }

        public ViewResult Index() => new ViewResult() {
            ViewName = "Result",
            ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                           new ModelStateDictionary()) {
                Model = $"This is a POCO controller"
            }
        };

        public ViewResult Headers() =>
            new ViewResult() {
                ViewName = "DictionaryResult",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary()) {
                    Model = ControllerContext.HttpContext.Request.Headers
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
                }
            };
    }
}
