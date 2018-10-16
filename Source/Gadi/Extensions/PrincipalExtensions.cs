using System.Linq;
using System.Security.Principal;
using Gadi.Common.Enum;

namespace Gadi.Extensions
{
    public static class PrincipalExtensions
    {
        public static bool IsInAllRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.All(r => principal.IsInRole(r));
        }

        public static bool IsInAnyRoles(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(r => principal.IsInRole(r));
        }

        public static bool IsSuperUser(this IPrincipal principal)
        {

            return principal.IsInRole(nameof(Role.SuperUser));
        }

        public static bool IsPersonnel(this IPrincipal principal)
        {
            return principal.IsInRole(nameof(Role.Personnel));
        }

        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(nameof(Role.Admin));
        }

        public static bool IsDrivingSchool(this IPrincipal principal)
        {
            return principal.IsInRole(nameof(Role.DrivingSchool));
        }

        public static bool IsUser(this IPrincipal principal)
        {
            return principal.IsInRole(nameof(Role.User));
        }

        public static bool IsSuperUserOrAdmin(this IPrincipal principal)
        {
            var roles = new string[] { Role.SuperUser.ToString(), Role.Admin.ToString() };
            return roles.Any(r => principal.IsInRole(r));
        }

        public static bool IsSuperUserOrAdminOrDrivingSchool(this IPrincipal principal)
        {
            var roles = new string[] { Role.SuperUser.ToString(), Role.Admin.ToString(), Role.DrivingSchool.ToString() };
            return roles.Any(r => principal.IsInRole(r));
        }

        public static bool IsSuperAdmin(this IPrincipal principal)
        {
            var roles = new string[] { Role.SuperUser.ToString() };
            return roles.Any(r => principal.IsInRole(r));
        }

    }
}