using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using ListaCompras.API.Domain.Interfaces.Services;

namespace ListaCompras.API.Domain.Services
{    
    public class ItensComprasService : IItensComprasService
    {
        private readonly IITensComprasRepository _iTensComprasRepository;

        public ItensComprasService(IITensComprasRepository iTensComprasRepository)
        {
            _iTensComprasRepository = iTensComprasRepository;
        }

        public async Task<IEnumerable<ItensComprasEntity>> Listar()
        {
            return await _iTensComprasRepository.Listar();
        }
    }
}