using CentraliaStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentraliaStore.Infrastructure
{
    public class DocumentAuthorizationHandler :
    AuthorizationHandler<SameAuthorRequirement, ApiKey>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       ApiKey resource)
        {
            if (context.User.Identity?.Name == resource.AppUser.UserName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class SameAuthorRequirement : IAuthorizationRequirement { }
}
