namespace ListaCompras.API.DTL.DTOs
{
    public class ExcluirItensListaCompraDTO
    {
        public int IdLista { get; set; }
        public IEnumerable<int> IdsItens { get; set; } = [];
    }
}