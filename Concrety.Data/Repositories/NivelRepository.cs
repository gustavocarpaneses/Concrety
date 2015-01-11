using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Context;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Concrety.Data.Repositories
{
    public class NivelRepository : RepositoryBase<Nivel>, INivelRepository
    {
        public NivelRepository(IEntitiesContext context, IUser<int> user)
            : base(context, user)
        {
        }

        public async Task<IEnumerable<Nivel>> GetNiveisServico(int idMacroServico)
        {
            var query = from n in _dbEntitySet
                        join s in _context.Set<Servico>() on n.Id equals s.IdNivel
                        where 
                            n.IdMacroServico == idMacroServico && 
                            s.Ativo && !s.Excluido &&
                            n.Ativo && !n.Excluido
                        select n;

            return await query
                .GroupBy(n => n.Id)
                .Select(g => g.First())
                .ToListAsync();
        }

        public async Task<IEnumerable<Nivel>> GetNiveisVerificacaoMaterial(int idMacroServico)
        {
            var query = from n in _dbEntitySet
                        join fvm in _context.Set<FichaVerificacaoMaterial>() on n.Id equals fvm.IdNivel
                        where 
                            n.IdMacroServico == idMacroServico &&
                            fvm.Ativo && !fvm.Excluido &&
                            n.Ativo && !n.Excluido
                        select n;

            return await query
                .GroupBy(n => n.Id)
                .Select(g => g.First())
                .ToListAsync();
        }
    }
}


