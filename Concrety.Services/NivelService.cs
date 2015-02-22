using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Core.Queries;
using Concrety.Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class NivelService : ServiceBase<Nivel>, INivelService
    {

        private IRepositoryBase<Nivel> _repository;
        private IRepositoryBase<Servico> _servicoRepository;
        private IRepositoryBase<FichaVerificacaoMaterial> _fichaVerificacaoMaterialRepository;

        public NivelService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = UnitOfWork.Repository<Nivel>();
            _servicoRepository = UnitOfWork.Repository<Servico>();
            _fichaVerificacaoMaterialRepository = UnitOfWork.Repository<FichaVerificacaoMaterial>();
        }
        
        public async Task<IEnumerable<Nivel>> ObterNiveisDeServicoAsync(int idMacroServico)
        {
            var query = _repository.ObterNiveisDeServico(
                _servicoRepository.ObterQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });

        }

        public async Task<IEnumerable<Nivel>> ObterNiveisDeVerificacaoDeMaterialAsync(int idMacroServico)
        {
            var query = _repository.ObterNiveisDeVerificacaoDeMaterial(
                _fichaVerificacaoMaterialRepository.ObterQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });
        }


        public async Task<IEnumerable<Nivel>> ObterNiveisSuperioresAsync(int idNivel)
        {
            var niveis = new List<Nivel>();

            var nivel = await _repository.ObterPeloIdAsync(idNivel);

            do
            {
                niveis.Add(nivel);
                nivel = nivel.NivelPai;
            } while (nivel != null);

            return niveis.Reverse<Nivel>();
        }
    }
}
