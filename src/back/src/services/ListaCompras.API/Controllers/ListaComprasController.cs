using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using ListaCompras.API.Domain.Interfaces.Services;
using ListaCompras.API.DTL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompras.API.Controllers
{
    [ApiController]
    [Route("api/lista-compras")]
     [Produces(MediaTypeNames.Application.Json)]
    public class ListaComprasController : ControllerBase
    {
        private readonly IListaComprasService _listaComprasService;

        public ListaComprasController(IListaComprasService listaComprasService)
        {
            _listaComprasService = listaComprasService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var itens = await _listaComprasService.ListarAsync();

            return itens is null ? NotFound() : Ok(itens);
        }

        [HttpGet("{idLista:int}/listar-itens")]
        public async Task<IActionResult> ListarItens(int idLista)
        {
            var itens = await _listaComprasService.ListarItensAsync(idLista);

            return itens is null ? NotFound() : Ok(itens);
        }

        [HttpPost]
        public async Task<IActionResult> Gerar([FromBody] ListaComprasRequestDTO listaComprasRequest)
        {
            var retorno = await _listaComprasService.GerarAsync(listaComprasRequest);
            
            return retorno > 0? Ok(new {idLista = retorno}) : BadRequest();
        }

        [HttpPost("{idLista}/adicionar-itens")]
        public async Task<IActionResult> AdicionarItens(int idLista, [FromBody, Required] int[] idsProdutos)
        {
            var retorno = await _listaComprasService.AdicionarItensAsync(idLista,idsProdutos);
            
            return retorno > 0? Ok() : BadRequest();
        }

        [HttpPut("{idLista}/atualizar-descricao")]
        public async Task<IActionResult> AtualizarDescricao(int idLista, [FromBody, Required] string NovaDescricao)
        {
            var retorno = await _listaComprasService.AtualizarDescricaoAsync(idLista, NovaDescricao);

            return retorno > 0? Ok() : BadRequest();
        }

        [HttpDelete("{idLista}")]
        public async Task<IActionResult> Excluir(int idLista)
        {
            var retorno = await _listaComprasService.ExcluirAsync(idLista);
            
            return retorno > 0? Ok() : BadRequest();
        }

        [HttpDelete("{idLista}/excluir-itens")]
        public async Task<IActionResult> Excluir(int idLista,[FromBody, Required] int[] idsItens)
        {
            var retorno = await _listaComprasService.ExluirItensAsync(idLista,idsItens);
            
            return retorno > 0? Ok() : BadRequest();
        }
    }
}