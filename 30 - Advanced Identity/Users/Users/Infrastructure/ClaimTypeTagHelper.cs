using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Users.Infrastructure {

    [HtmlTargetElement("td", Attributes = "identity-claim-type")]
    public class ClaimTypeTagHelper : TagHelper {

        [HtmlAttributeName("identity-claim-type")]
        public string ClaimType { get; set; }

        public override void Process(TagHelperContext context,
                                     TagHelperOutput output) {
            bool foundType = false;
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach (FieldInfo field in fields) {
                if (field.GetValue(null).ToString() == ClaimType) {
                    output.Content.SetContent(field.Name);
                    foundType = true;
                }
            }
            if (!foundType) {
                output.Content.SetContent(ClaimType.Split('/', '.').Last());
            }
        }
    }
}
