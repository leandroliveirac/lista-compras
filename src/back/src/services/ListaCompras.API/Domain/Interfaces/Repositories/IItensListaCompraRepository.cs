using ListaCompras.API.Domain.Entities;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IItensListaCompraRepository : IBaseRepository<ItensListaComprasEntity>
    {
        Task<List<ItensListaComprasEntity>?> ObterPorIdListaAsync(int idLista);
        Task<int> InserirAsync(IEnumerable<ItensListaComprasEntity> itens);
        Task<int> ExcluirItensAsync(int idLista, int[] idsItens);
        Task<int> ExcluirTodosItensAsync(int idLista);
    }
}