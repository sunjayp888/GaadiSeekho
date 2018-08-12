using System.Collections.Generic;
using System.Threading.Tasks;
using Gadi.Data.Entities;

namespace Gadi.Data.Interfaces
{
    public interface IAuthorizationDataService : IGadiDataService
    {
        Task CreateUserPermissions(string userId, IEnumerable<string> permissionIds);

        Task<IEnumerable<AspNetRole>> RetrieveUserRoleByUserIdAsync(string userId);
        Task<IEnumerable<AspNetPermission>> RetrieveUserPermissions(string userId);
        Task<IEnumerable<AspNetPermission>> RetrieveRolePermissions(string roleId);
        Task<AspNetUser> RetrieveAspNetUser(string userId);
        //Task<Personnel> RetrieveUserPersonnel(string userId, int personnelId);

        Task<bool> UpdateUser(AspNetUser user);

        Task<bool> DeleteUser(string userId);
        
    }
}
