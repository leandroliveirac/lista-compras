using System;
using System.Collections;

namespace ListaCompras.API.Domain.Entities
{
    public class ListaComprasEntity : BaseEntity
    {
        public string Descricao { get; private set; } = string.Empty;

        public ICollection<ItensListaComprasEntity>? Itens { get; set; }
        public ListaComprasEntity() {}

        public ListaComprasEntity(int id) : base(id) {}

        public ListaComprasEntity(string descricao)
        {
            DefinirDescricao(descricao);
        }

        public void DefinirDescricao(string valor)
        {
            Descricao = string.IsNullOrEmpty(valor) ? $"MinhaLista_{DateTime.Now.ToString("yyyyMMddHHmmss")}" : valor;
        }

    }
}