using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class NivelService : ServiceBase<Nivel>, INivelService
    {

        private readonly INivelRepository _nivelRepository;

        public NivelService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _nivelRepository = (INivelRepository)unitOfWork.Repository<Nivel>();
        }
        
        public Task<IEnumerable<Nivel>> GetNiveisServico(int idMacroServico)
        {
            return _nivelRepository.GetNiveisServico(idMacroServico);
        }

        public Task<IEnumerable<Nivel>> GetNiveisVerificacaoMaterial(int idMacroServico)
        {
            return _nivelRepository.GetNiveisVerificacaoMaterial(idMacroServico);
        }
    }
}
