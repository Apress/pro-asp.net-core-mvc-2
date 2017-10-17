using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers {

    [HtmlTargetElement("label", Attributes = "helper-for")]
    [HtmlTargetElement("input", Attributes = "helper-for")]
    public class LabelAndInputTagHelper : TagHelper {

        public ModelExpression HelperFor { get; set; }

        public override void Process(TagHelperContext context,
                                     TagHelperOutput output) {

            if (output.TagName == "label") {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.Append(HelperFor.Name);
                output.Attributes.SetAttribute("for", HelperFor.Name);

            } else if (output.TagName == "input") {
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.SetAttribute("name", HelperFor.Name);
                output.Attributes.SetAttribute("class", "form-control");
                if (HelperFor.Metadata.ModelType == typeof(int?)) {
                    output.Attributes.SetAttribute("type", "number");
                }
            }
        }
    }
}
