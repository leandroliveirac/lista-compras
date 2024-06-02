using ListaCompras.API.DTL.DTOs;

namespace ListaCompras.API.Domain.Interfaces.Services
{

    public interface IListaComprasService
    {
        IAsyncEnumerable<ListaCompraResponseDTO> Listar();
        IAsyncEnumerable<ItensListaCompraResponseDTO> ListarItens(int idLista);
        Task<int> Gerar(ListaComprasRequestDTO listaComprasRequest);
        Task<int> AdicionarItens(int idLista, int[] idsProdutos);
        Task<int> AtualizarDescricao(int idLista, string novaDescricao);
        Task<int> Excluir(int idLista);
        Task<int> ExluirItens(int idLista, int[] idsItens);
    }
}