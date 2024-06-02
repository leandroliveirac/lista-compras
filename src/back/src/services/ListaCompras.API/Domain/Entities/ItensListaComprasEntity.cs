namespace ListaCompras.API.Domain.Entities
{
    public class ItensListaComprasEntity : BaseEntity
    {
        public int IdListaCompras { get; set; }

        public int IdProduto { get; set; }

        public ListaComprasEntity? ListaCompras { get; set; }
    }
}