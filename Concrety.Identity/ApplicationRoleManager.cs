﻿using Concrety.Core.Entities.Identity;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Identity;
using Concrety.Identity.Extensions;
using Concrety.Identity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Identity
{
    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : IApplicationRoleManager
    {
        private readonly RoleManager<ApplicationIdentityRole, int> _roleManager;
        private bool _disposed;

        public ApplicationRoleManager(RoleManager<ApplicationIdentityRole, int> roleManager)
        {
            _roleManager = roleManager;
        }

        public virtual async Task<EntityResultBase> CreateAsync(ApplicationRole role)
        {
            var identityRole = role.ToIdentityRole();
            var identityResult = await _roleManager.CreateAsync(identityRole).ConfigureAwait(false);
            role.CopyIdentityRoleProperties(identityRole);
            return identityResult.ToEntityResultBase();
        }

        public EntityResultBase Create(ApplicationRole role)
        {
            var identityRole = role.ToIdentityRole();
            var identityResult = _roleManager.Create(identityRole);
            role.CopyIdentityRoleProperties(identityRole);
            return identityResult.ToEntityResultBase();
        }

        public virtual async Task<EntityResultBase> DeleteAsync(int roleId)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId).ConfigureAwait(false);
            if (identityRole == null)
            {
                return new EntityResultBase(new[] { "Invalid role Id" }, false);
            }
            var identityResult = await _roleManager.DeleteAsync(identityRole).ConfigureAwait(false);
            return identityResult.ToEntityResultBase();
        }

        public virtual async Task<ApplicationRole> FindByIdAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId).ConfigureAwait(false);
            return role.ToApplicationRole();
        }
        public virtual ApplicationRole FindByName(string roleName)
        {
            var role = _roleManager.FindByName(roleName);
            return role.ToApplicationRole();
        }

        public virtual async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName).ConfigureAwait(false);
            return role.ToApplicationRole();
        }

        public virtual IEnumerable<ApplicationRole> GetRoles()
        {
            return _roleManager.Roles.ToList().ToApplicationRoleList();
        }

        public virtual async Task<IEnumerable<ApplicationRole>> GetRolesAsync()
        {
            var applicationRoles = await _roleManager.Roles.ToListAsync().ConfigureAwait(false);
            return applicationRoles.ToApplicationRoleList();
        }

        public virtual async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName).ConfigureAwait(false);
        }

        public virtual async Task<EntityResultBase> UpdateAsync(int roleId, string roleName)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId).ConfigureAwait(false);
            if (identityRole == null)
            {
                return new EntityResultBase(new[] { "Invalid role Id" }, false);
            }
            identityRole.Name = roleName;
            var identityResult = await _roleManager.UpdateAsync(identityRole).ConfigureAwait(false);
            return identityResult.ToEntityResultBase();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
