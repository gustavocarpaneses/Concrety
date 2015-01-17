﻿using Concrety.Core.Entities.Identity;
using Concrety.Core.Entities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Identity
{
    public interface IApplicationRoleManager :IDisposable
    {
        Task<ApplicationIdentityResult> CreateAsync(ApplicationRole role);
        ApplicationIdentityResult Create(ApplicationRole role);
        Task<ApplicationIdentityResult> DeleteAsync(int roleId);
        Task<ApplicationRole> FindByIdAsync(int roleId);
        ApplicationRole FindByName(string roleName);
        Task<ApplicationRole> FindByNameAsync(string roleName);
        IEnumerable<ApplicationRole> GetRoles();
        Task<IEnumerable<ApplicationRole>> GetRolesAsync();
        Task<bool> RoleExistsAsync(string roleName);
        Task<ApplicationIdentityResult> UpdateAsync(int roleId, string roleName);
    }
}