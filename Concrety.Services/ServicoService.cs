﻿using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {
        public ServicoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}