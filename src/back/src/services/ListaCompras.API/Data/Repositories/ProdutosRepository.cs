using ListaCompras.API.Data.Contexts;
using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Repositories
{
    public class ProdutosRepository : BaseRepository<ApplicationDbContext, ProdutosEntity>, IProdutosRepository
    {
        public ProdutosRepository(ApplicationDbContext context) : base(context)
        {
        }

        // public override async Task<IEnumerable<ProdutosEntity>> ListarAsync()
        // {
        //     return await _context.Produtos.AsNoTracking().ToListAsync();
        // }

        public async Task<bool> ExisteAsync(IEnumerable<int> ids)
        {
            int quant = await ObterPorIdsAsync(ids).CountAsync();

            return quant == ids.Count();
        }

        private IQueryable<ProdutosEntity> ObterPorIdsAsync(IEnumerable<int> ids)
        {
            return _context.Produtos
                    .AsNoTracking()
                    .Where(x => ids.Contains(x.Id));
        }
    }
}