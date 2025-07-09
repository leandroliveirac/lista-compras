using ListaCompras.API.Domain.Entities;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> ListarAsync();
    } 
}