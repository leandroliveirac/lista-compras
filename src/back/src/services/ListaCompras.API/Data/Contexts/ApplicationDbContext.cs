using ListaCompras.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<ItemsComprasEntity> itemsCompras { get; set; }
        public DbSet<CategoriasEntity> Categorias { get; set; }
        public DbSet<ProdutosEntity> Produtos { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}