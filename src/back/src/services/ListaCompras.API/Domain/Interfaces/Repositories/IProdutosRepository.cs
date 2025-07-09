using ListaCompras.API.Domain.Entities;

namespace ListaCompras.API.Domain.Interfaces.Repositories
{
    public interface IProdutosRepository : IBaseRepository<ProdutosEntity>
    {
        Task<bool> ExisteAsync(IEnumerable<int> ids);        
    }
}