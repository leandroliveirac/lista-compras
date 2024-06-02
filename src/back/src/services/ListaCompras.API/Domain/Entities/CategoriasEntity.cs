namespace ListaCompras.API.Domain.Entities
{
    public sealed class CategoriasEntity : BaseEntity
    {
        public CategoriasEntity(int id, string descricao) : base(id)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; } = string.Empty;

        public ICollection<ProdutosEntity>? Produtos { get; set; }
    }
}