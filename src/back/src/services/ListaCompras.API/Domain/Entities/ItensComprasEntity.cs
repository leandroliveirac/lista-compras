namespace ListaCompras.API.Domain.Entities
{
    public sealed class ItensComprasEntity : BaseEntity
    {
        public ItensComprasEntity
        (
            int idCategoria, 
            string categoria, 
            int idProduto, 
            string produto           
        )
        {
            Id = new Random().Next(0,int.MaxValue);
            IdCategoria = idCategoria;
            Categoria = categoria;
            IdProduto = idProduto;
            Produto = produto;
            Quantidade = 0;
            ValorUnitario = 0;
            Periodo = DateTime.Now;
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime Periodo { get; set; }
        
    }
}