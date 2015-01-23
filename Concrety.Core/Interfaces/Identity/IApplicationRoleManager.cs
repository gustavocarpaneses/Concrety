using Concrety.Core.Entities.Identity;
using Concrety.Core.Entities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Identity
{
    public interface IApplicationRoleManager :IDisposable
    {
        Task<EntityResultBase> CreateAsync(ApplicationRole role);
        EntityResultBase Create(ApplicationRole role);
        Task<EntityResultBase> DeleteAsync(int roleId);
        Task<ApplicationRole> FindByIdAsync(int roleId);
        ApplicationRole FindByName(string roleName);
        Task<ApplicationRole> FindByNameAsync(string roleName);
        IEnumerable<ApplicationRole> GetRoles();
        Task<IEnumerable<ApplicationRole>> GetRolesAsync();
        Task<bool> RoleExistsAsync(string roleName);
        Task<EntityResultBase> UpdateAsync(int roleId, string roleName);
    }
}