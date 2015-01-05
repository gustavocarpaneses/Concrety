using Concrety.Core.Entities.Base;
using Concrety.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Concrety.Core.Entities.Identity
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            Claims = new List<ApplicationUserClaim>();
            Roles = new List<ApplicationUserRole>();
            Logins = new List<ApplicationUserLogin>();
            Empreendimentos = new List<Empreendimento>();
        }
        public virtual int AccessFailedCount { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; private set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual int Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; private set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual ICollection<ApplicationUserRole> Roles { get; private set; }
        public virtual string SecurityStamp { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
        public virtual ICollection<Empreendimento> Empreendimentos { get; set; }
    }
}
