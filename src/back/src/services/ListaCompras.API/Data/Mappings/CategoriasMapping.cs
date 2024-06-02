using ListaCompras.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaCompras.API.Data.Mappings
{
    public class CategoriasMapping : IEntityTypeConfiguration<CategoriasEntity>
    {public void Configure(EntityTypeBuilder<CategoriasEntity> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id_categoria");
            builder.Property(x => x.CriadoEm).HasColumnName("create_time");
            builder.Property(x => x.Descricao).HasColumnName("descricao");

            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.Id);
        }
        
    }
}