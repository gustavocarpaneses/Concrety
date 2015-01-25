﻿using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IFornecedorService : IServiceBase<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> Obter();
    }
}
