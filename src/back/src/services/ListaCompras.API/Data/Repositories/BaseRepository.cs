using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Repositories
{
    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
    {
        protected readonly TContext _context;
        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> ListarAsync()
        {
            return await _context.Set<TEntity>()
                                    .AsNoTracking()
                                    .ToListAsync();
        }

    }
}