using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Users.Models;

namespace Users.Infrastructure {

    public class DocumentAuthorizationRequirement : IAuthorizationRequirement {
        public bool AllowAuthors { get; set; }
        public bool AllowEditors { get; set; }
    }

    public class DocumentAuthorizationHandler
        : AuthorizationHandler<DocumentAuthorizationRequirement> {

        protected override Task HandleRequirementAsync(
                AuthorizationHandlerContext context,
                DocumentAuthorizationRequirement requirement) {
            ProtectedDocument doc = context.Resource as ProtectedDocument;
            string user = context.User.Identity.Name;
            StringComparison compare = StringComparison.OrdinalIgnoreCase;
            if (doc != null && user != null &&
                (requirement.AllowAuthors && doc.Author.Equals(user, compare))
                || (requirement.AllowEditors && doc.Editor.Equals(user, compare))) {
                context.Succeed(requirement);
            } else {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
