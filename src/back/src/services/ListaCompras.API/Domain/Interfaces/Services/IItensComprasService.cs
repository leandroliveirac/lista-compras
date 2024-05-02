using ListaCompras.API.Domain.Entities;

namespace ListaCompras.API.Domain.Interfaces.Services
{
    public interface IItensComprasService
    {
        Task<IEnumerable<ItensComprasEntity>> Listar();
    }
}