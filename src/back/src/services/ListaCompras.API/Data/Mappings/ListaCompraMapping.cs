using ListaCompras.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaCompras.API.Data.Mappings
{
    public class ListaCompraMapping : IEntityTypeConfiguration<ListaComprasEntity>
    {
        public void Configure(EntityTypeBuilder<ListaComprasEntity> builder)
        {
            builder.ToTable("listaCompras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id_lista_compras");
            builder.Property(x => x.Descricao).HasColumnName("descricao");
            builder.Property(x => x.CriadoEm).HasColumnName("create_time");
            
            builder.HasMany(x => x.Itens)
                .WithOne(c => c.ListaCompras)
                .HasForeignKey(x => x.IdListaCompras)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}