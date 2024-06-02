namespace ListaCompras.API.DTL.DTOs
{
    public class ProdutoDTO
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public CategoriaDTO Categoria { get; set; } = new();
    }
}