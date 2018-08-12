using System;
using System.Threading.Tasks;
using Gadi.Business.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Authorization;

namespace Gadi.Models.Authorization.Handlers
{
    public class PermissionsAuthorizationHandler : AuthorizationHandler<PermissionsRequirement>
    {
        private readonly IAuthorizationBusinessService _authorizationBusinessService;

        public PermissionsAuthorizationHandler(IAuthorizationBusinessService authorizationBusinessService)
        {
            if (authorizationBusinessService == null)
                throw new ArgumentNullException(nameof(authorizationBusinessService));

            _authorizationBusinessService = authorizationBusinessService;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsRequirement requirement)
        {
            // no user authorized. 
            if (context.User == null)
            {
                context.Fail();                
                return;
            }

            var hasPermission = await _authorizationBusinessService.UserHasPermissions(context.User.Identity.GetUserId(), requirement.Permissions);
            if (hasPermission)
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
            return;
        }
    }
}