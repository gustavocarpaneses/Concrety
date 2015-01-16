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
        
        public async Task<IEnumerable<Nivel>> ObterNiveisDeServico(int idMacroServico)
        {
            var query = _repository.ObterNiveisDeServico(
                _servicoRepository.GetQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });

        }

        public async Task<IEnumerable<Nivel>> ObterNiveisDeVerificacaoDeMaterial(int idMacroServico)
        {
            var query = _repository.ObterNiveisDeVerificacaoDeMaterial(
                _fichaVerificacaoMaterialRepository.GetQuery(),
                idMacroServico);

            return await Task.Factory.StartNew(() => { return query; });
        }


        public async Task<IEnumerable<Nivel>> ObterNiveisSuperiores(int idNivel)
        {
            var niveis = new List<Nivel>();

            var nivel = await _repository.GetByIdAsync(idNivel);

            do
            {
                niveis.Add(nivel);
                nivel = nivel.NivelPai;
            } while (nivel != null);

            return niveis.Reverse<Nivel>();
        }
    }
}
