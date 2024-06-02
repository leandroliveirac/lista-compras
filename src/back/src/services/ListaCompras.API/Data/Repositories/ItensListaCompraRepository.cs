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

        public async Task<IEnumerable<ItensListaComprasEntity>> ObterPorIdLista(int idLista)
        {
            return _context.ItensListaCompras
                            .Where(x => x.IdListaCompras == idLista)
                            .AsNoTracking()
                            .AsEnumerable();
        }

        public async Task<IEnumerable<ItensListaComprasEntity>> ObterPorIds(int idLista, int[] idsItens)
        {
            return QueryObterPorIds(idLista, idsItens)
                            .AsNoTracking()
                            .AsEnumerable();
        }
        public async Task<int> Inserir(IEnumerable<ItensListaComprasEntity> itens)
        {
            await _context.ItensListaCompras.AddRangeAsync(itens);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> ExcluirItens(int idLista, int[] idsItens)
        {
            var itens = QueryObterPorIds(idLista, idsItens).AsEnumerable();

            _context.ItensListaCompras.RemoveRange(itens);

            return await _context.SaveChangesAsync();
        }

        private IQueryable<ItensListaComprasEntity> QueryObterPorIds(int idLista, int[] idsItens)
        {
            return _context.ItensListaCompras                            
                            .Where(x => x.IdListaCompras == idLista 
                                        && idsItens.Contains(x.Id));
        }

        public async Task<int> ExcluirTodosItens(int idLista)
        {
            var itens = _context.ItensListaCompras.Where(x => x.IdListaCompras == idLista).AsEnumerable();

            _context.ItensListaCompras.RemoveRange(itens);

            return await _context.SaveChangesAsync();
        }
    }
}