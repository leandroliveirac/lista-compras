namespace ListaCompras.API.Domain.Entities
{
    public class ProdutosEntity : BaseEntity
    {
        public ProdutosEntity(int id ,string descricao, int idCategoria) : base(id)
        {
            Descricao = descricao;
            IdCategoria = idCategoria;
        }

        public string Descricao { get; set; } = string.Empty;
        public int IdCategoria { get; set; }


    }
}