using ListaCompras.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaCompras.API.Data.Mappings
{
    public class ItensListaCompraMapping : IEntityTypeConfiguration<ItensListaComprasEntity>
    {
        public void Configure(EntityTypeBuilder<ItensListaComprasEntity> builder)
        {
            builder.ToTable("itensListaCompras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id_itens_lista_compras");
            builder.Property(x => x.CriadoEm).HasColumnName("create_time");
            builder.Property(x => x.IdListaCompras).HasColumnName("id_lista_compras");
            builder.Property(x => x.IdProduto).HasColumnName("id_produto");

            builder.HasOne(x => x.ListaCompras)
                    .WithMany(p => p.Itens)
                    .HasForeignKey(x => x.IdListaCompras)
                    .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}