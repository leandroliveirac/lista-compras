using ListaCompras.API.DTL.DTOs;

namespace ListaCompras.API.Domain.Interfaces.Services
{

    public interface IListaComprasService
    {
        Task<List<ListaCompraResponseDTO>?> ListarAsync();
        Task<List<ItensListaCompraResponseDTO>?> ListarItensAsync(int idLista);
        Task<int> GerarAsync(ListaComprasRequestDTO listaComprasRequest);
        Task<int> AdicionarItensAsync(int idLista, int[] idsProdutos);
        Task<int> AtualizarDescricaoAsync(int idLista, string novaDescricao);
        Task<int> ExcluirAsync(int idLista);
        Task<int> ExluirItensAsync(int idLista, int[] idsItens);
    }
}