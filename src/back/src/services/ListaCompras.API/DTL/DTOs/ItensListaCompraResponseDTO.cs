namespace ListaCompras.API.DTL.DTOs
{
    public class ItensListaCompraResponseDTO
    {
        public int IdItem { get; set; }
        public int IdLista { get; set; }
        public string DescricaoLista { get; set; } = string.Empty;
        public int IdProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string DescricaoCategoria { get; set; } = string.Empty;
    }
}