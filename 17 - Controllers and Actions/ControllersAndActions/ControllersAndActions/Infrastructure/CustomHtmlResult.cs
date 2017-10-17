using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ControllersAndActions.Infrastructure {

    public class CustomHtmlResult : IActionResult {

        public string Content { get; set; }

        public Task ExecuteResultAsync(ActionContext context) {
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes(Content);
            return context.HttpContext.Response.Body.WriteAsync(content,
                0, content.Length);
        }
    }
}
