using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure {

    public class BlockUsersRequirement : IAuthorizationRequirement {

        public BlockUsersRequirement(params string[] users) {
            BlockedUsers = users;
        }

        public string[] BlockedUsers { get; set; }
    }

    public class BlockUsersHandler : AuthorizationHandler<BlockUsersRequirement> {

        protected override Task HandleRequirementAsync(
                AuthorizationHandlerContext context,
                BlockUsersRequirement requirement) {

            if (context.User.Identity != null && context.User.Identity.Name != null
                && !requirement.BlockedUsers
                    .Any(user => user.Equals(context.User.Identity.Name,
                        StringComparison.OrdinalIgnoreCase))) {
                context.Succeed(requirement);
            } else {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
