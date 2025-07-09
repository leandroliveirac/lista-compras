using ListaCompras.API.Domain.Entities;
using ListaCompras.API.DTL.DTOs;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IListaComprasRepository : IBaseRepository<ListaComprasEntity>
    {
        Task<IEnumerable<ItensListaCompraResponseDTO>> ListarItensAsync(int idLista);
        Task<bool> ExisteDescricaoAsync(string descricao);
        Task<int> InserirAsync(ListaComprasEntity listaCompras);
        Task<int>AtualizarAsync(ListaComprasEntity listaCompras);
        Task<int> ExcluirAsync(int id);
    }
}