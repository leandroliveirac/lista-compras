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

        public override async Task<IEnumerable<ProdutosEntity>> Listar()
        {
            return _context.Produtos.AsNoTracking().AsEnumerable();
        }

        public async Task<bool> Existe(IEnumerable<int> ids)
        {
            int quant = await ObterPorIds(ids).CountAsync();

            return quant == ids.Count();
        }

        private IQueryable<ProdutosEntity> ObterPorIds(IEnumerable<int> ids)
        {
            return _context.Produtos
                    .AsNoTracking()
                    .Where(x => ids.Contains(x.Id));
        }
    }
}