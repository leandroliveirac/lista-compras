namespace ListaCompras.API.DTL.DTOs
{
    public class ListaComprasRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public IEnumerable<int> IdsProdutos { get; set; } = Enumerable.Empty<int>();
    }
}