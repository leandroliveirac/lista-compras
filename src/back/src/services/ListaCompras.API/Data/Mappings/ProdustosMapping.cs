using ListaCompras.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaCompras.API.Data.Mappings
{
    public class ProdustosMapping : IEntityTypeConfiguration<ProdutosEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutosEntity> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("id_produto");
            builder.Property(x => x.CriadoEm).HasColumnName("create_time");
            builder.Property(x => x.Descricao).HasColumnName("descricao");
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria");
            
            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoria);
        }
    }
}