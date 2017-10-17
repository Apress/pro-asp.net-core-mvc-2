using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers {

    public class FormTagHelper : TagHelper {
        private IUrlHelperFactory urlHelperFactory;

        public FormTagHelper(IUrlHelperFactory factory) {
            urlHelperFactory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContextData { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public override void Process(TagHelperContext context,
                                     TagHelperOutput output) {

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContextData);

            output.Attributes.SetAttribute("action", urlHelper.Action(
                Action ??
                    ViewContextData.RouteData.Values["action"].ToString(),
                Controller ??
                    ViewContextData.RouteData.Values["controller"].ToString()));
        }
    }
}
