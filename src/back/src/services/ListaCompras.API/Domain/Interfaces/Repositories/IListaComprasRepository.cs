using ListaCompras.API.Domain.Entities;
using ListaCompras.API.DTL.DTOs;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IListaComprasRepository : IBaseRepository<ListaComprasEntity>
    {
        Task<IEnumerable<ItensListaCompraResponseDTO>> ListarItens(int idLista);
        Task<bool> ExisteDescricao(string descricao);
        Task<int> Inserir(ListaComprasEntity listaCompras);
        Task<int>Atualizar(ListaComprasEntity listaCompras);
        Task<int> Excluir(int id);
    }
}