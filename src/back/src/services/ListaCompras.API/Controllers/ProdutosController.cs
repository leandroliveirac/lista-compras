using ListaCompras.API.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompras.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await _produtosRepository.ListarAsync();

            return Ok(result);
        }
    }
}