using ListaCompras.API.Domain.Entities;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IItensListaCompraRepository : IBaseRepository<ItensListaComprasEntity>
    {
        Task<IEnumerable<ItensListaComprasEntity>> ObterPorIdLista(int idLista);
        Task<int> Inserir(IEnumerable<ItensListaComprasEntity> itens);
        Task<int> ExcluirItens(int idLista, int[] idsItens);
        Task<int> ExcluirTodosItens(int idLista);
    }
}