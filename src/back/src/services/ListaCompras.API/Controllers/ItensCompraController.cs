using ListaCompras.API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensCompraController : ControllerBase
    {
        private readonly IItensComprasService _ItensComprasService;

        public ItensCompraController(IItensComprasService ItensComprasService)
        {
            _ItensComprasService = ItensComprasService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await _ItensComprasService.Listar();
            return Ok(lista);
        }
    }
}