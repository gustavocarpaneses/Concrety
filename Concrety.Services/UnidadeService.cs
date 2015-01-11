﻿using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Concrety.Services
{
    public class UnidadeService : ServiceBase<Unidade>, IUnidadeService
    {

        private IRepositoryBase<Unidade> _unidadeRepository;

        public UnidadeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unidadeRepository = UnitOfWork.Repository<Unidade>();
        }
        
        public async Task<IEnumerable<Unidade>> GetByIdNivel(int idNivel)
        {
            var query = _unidadeRepository.GetByIdNivel(idNivel);
            return await Task.Factory.StartNew(() => { return query; });
        }

    }
}