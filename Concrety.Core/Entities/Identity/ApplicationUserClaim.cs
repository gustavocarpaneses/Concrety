﻿namespace Concrety.Core.Entities.Identity
{
    public class ApplicationUserClaim
    {
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
    }
}
