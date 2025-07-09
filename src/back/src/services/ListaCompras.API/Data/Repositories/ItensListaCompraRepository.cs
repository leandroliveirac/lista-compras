using ListaCompras.API.Data.Contexts;
using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Repositories
{
    public class ItensListaCompraRepository : BaseRepository<ApplicationDbContext, ItensListaComprasEntity>, IItensListaCompraRepository
    {
        public ItensListaCompraRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ItensListaComprasEntity>?> ObterPorIdListaAsync(int idLista)
        {
            return await _context.ItensListaCompras
                            .Where(x => x.IdListaCompras == idLista)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<List<ItensListaComprasEntity>?> ObterPorIdsAsync(int idLista, int[] idsItens)
        {
            return await QueryObterPorIdsAsync(idLista, idsItens)
                            .AsNoTracking()
                            .ToListAsync();
        }
        public async Task<int> InserirAsync(IEnumerable<ItensListaComprasEntity> itens)
        {
            await _context.ItensListaCompras.AddRangeAsync(itens);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> ExcluirItensAsync(int idLista, int[] idsItens)
        {
            var itens = QueryObterPorIdsAsync(idLista, idsItens).AsEnumerable();

            _context.ItensListaCompras.RemoveRange(itens);

            return await _context.SaveChangesAsync();
        }

        private IQueryable<ItensListaComprasEntity> QueryObterPorIdsAsync(int idLista, int[] idsItens)
        {
            return _context.ItensListaCompras                            
                            .Where(x => x.IdListaCompras == idLista 
                                        && idsItens.Contains(x.Id));
        }

        public async Task<int> ExcluirTodosItensAsync(int idLista)
        {
            var itens = _context.ItensListaCompras.Where(x => x.IdListaCompras == idLista).AsEnumerable();

            _context.ItensListaCompras.RemoveRange(itens);

            return await _context.SaveChangesAsync();
        }
    }
}