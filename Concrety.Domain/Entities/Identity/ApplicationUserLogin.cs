﻿namespace Concrety.Domain.Entities.Identity
{
    public class ApplicationUserLogin
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual int UserId { get; set; }
    }
}
