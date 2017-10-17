using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.DependencyInjection;

namespace ConventionsAndConstraints.Infrastructure {

    public class UserAgentAttribute : Attribute, IActionConstraintFactory {
        private string substring;

        public UserAgentAttribute(string sub) {
            substring = sub;
        }

        public IActionConstraint CreateInstance(IServiceProvider services) {
            return new UserAgentConstraint(services.GetService<UserAgentComparer>(),
                substring);
        }

        public bool IsReusable => false;

        private class UserAgentConstraint : IActionConstraint {
            private UserAgentComparer comparer;
            private string substring;

            public UserAgentConstraint(UserAgentComparer comp, string sub) {
                comparer = comp;
                substring = sub.ToLower();
            }

            public int Order { get; set; } = 0;

            public bool Accept(ActionConstraintContext context) {
                return comparer.ContainsString(context.RouteContext
                        .HttpContext.Request, substring)
                    || context.Candidates.Count() == 1;
            }
        }
    }
}
