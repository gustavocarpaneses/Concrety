﻿using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;

namespace Concrety.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        public FornecedorService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
