﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concrety.Core.Entities.Identity
{
    public class ApplicationClient
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
