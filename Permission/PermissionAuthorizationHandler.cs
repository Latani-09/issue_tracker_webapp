using Microsoft.AspNetCore.Authorization;

namespace Issue_tracker_webapp.Permission
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler() { }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                Console.WriteLine("no user found -----------");
                return;
            }

            Console.WriteLine(" user found -----------",context.User.ToString());
            var permissions = context.User.Claims.Where(x => x.Type == "Permission" &&
                                                                x.Value == requirement.Permission &&
                                                                x.Issuer == "LOCAL AUTHORITY");

            if (permissions.Any())
            {
                Console.WriteLine("permissions----------", requirement.ToString());
                context.Succeed(requirement);
                return;
            }
        }
    }
}
