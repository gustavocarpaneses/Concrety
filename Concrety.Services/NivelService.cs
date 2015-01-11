using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Concrety.Services
{
    public class NivelService : ServiceBase<Nivel>, INivelService
    {

        private IRepositoryBase<Nivel> _nivelRepository;
        private IRepositoryBase<Servico> _servicoRepository;
        private IRepositoryBase<FichaVerificacaoMaterial> _fichaVerificacaoMaterialRepository;

        public NivelService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _nivelRepository = UnitOfWork.Repository<Nivel>();
            _servicoRepository = UnitOfWork.Repository<Servico>();
            _fichaVerificacaoMaterialRepository = UnitOfWork.Repository<FichaVerificacaoMaterial>();
        }
        
        public async Task<IEnumerable<Nivel>> GetNiveisServico(int idMacroServico)
        {
            var query = _nivelRepository.GetNiveisServico(
                _servicoRepository.GetQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });

        }

        public async Task<IEnumerable<Nivel>> GetNiveisVerificacaoMaterial(int idMacroServico)
        {
            var query = _nivelRepository.GetNiveisVerificacaoMaterial(
                _fichaVerificacaoMaterialRepository.GetQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });
        }
    }
}
