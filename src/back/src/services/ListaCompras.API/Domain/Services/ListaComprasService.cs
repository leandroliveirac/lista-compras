using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using ListaCompras.API.Domain.Interfaces.Services;
using ListaCompras.API.DTL.DTOs;

namespace ListaCompras.API.Domain.Services
{
    public class ListaComprasService : IListaComprasService
    {
        private readonly IListaComprasRepository _listaComprasRepository;
        private readonly IItensListaCompraRepository _itensListaCompraRepository;
        private readonly IProdutosRepository _produtosRepository;

        public ListaComprasService(IListaComprasRepository ListaComprasRepository, IItensListaCompraRepository itensListaCompraRepository, IProdutosRepository produtosRepository)
        {
            _listaComprasRepository = ListaComprasRepository;
            _itensListaCompraRepository = itensListaCompraRepository;
            _produtosRepository = produtosRepository;
        }
        public async IAsyncEnumerable<ListaCompraResponseDTO> Listar()
        {
            var items = await _listaComprasRepository.Listar();

            foreach (var item in items)
            {
                yield return new ListaCompraResponseDTO{
                    Id = item.Id,
                    Nome = item.Descricao
                };
            }            
        }

        public async IAsyncEnumerable<ItensListaCompraResponseDTO> ListarItens(int idLista)
        {
            var items = await _listaComprasRepository.ListarItens(idLista);

            foreach (var item in items)
            {
                yield return item;
            }
        }

        public async Task<int> Gerar(ListaComprasRequestDTO listaComprasRequest)
        {
            var idsProdutos = listaComprasRequest.IdsProdutos.ToArray();

            if(idsProdutos is null || idsProdutos.Length == 0) return 0;

            var existeProdutos = await _produtosRepository.Existe(idsProdutos);

            if(!existeProdutos) return 0;            

            var existeDescricao = await _listaComprasRepository.ExisteDescricao(listaComprasRequest.Nome);

            var descricao = existeDescricao ? string.Concat(listaComprasRequest.Nome,"-",Guid.NewGuid().ToString().Substring(0,8)) : listaComprasRequest.Nome;

            var listaCompras = new ListaComprasEntity(descricao);
            var r1 = await _listaComprasRepository.Inserir(listaCompras);       

            var r2 = await _itensListaCompraRepository.Inserir(ItensListaCompras(listaCompras.Id,listaComprasRequest.IdsProdutos.ToArray()));

            return r1 > 0 && r2 > 0 ? listaCompras.Id : 0;
        }

        private static IEnumerable<ItensListaComprasEntity>ItensListaCompras(int idLista, int[] idProdutos)
        {
            foreach (var item in idProdutos)
            {
                yield return new ItensListaComprasEntity{
                    IdListaCompras = idLista,
                    IdProduto = item
                };
            }
        }
        public async Task<int> AdicionarItens(int idLista, int[] idsProdutos)
        {

            if(idsProdutos.Length <= 0) return 0;

            var existeProdutos = await _produtosRepository.Existe(idsProdutos);

            if(!existeProdutos) return 0;            

            var r2 = await AdicionarItensLista(idLista,idsProdutos.Distinct().ToArray());

            return r2 > 0 ? 1 : 0;

        }

        public async Task<int> AtualizarDescricao(int idLista, string novaDescricao)
        {
            var lista = new ListaComprasEntity(idLista);
            lista.DefinirDescricao(novaDescricao);

            return await _listaComprasRepository.Atualizar(lista);
        }

        public async Task<int> Excluir(int idLista)
        {
            return await _listaComprasRepository.Excluir(idLista);
        }

        public async Task<int> ExluirItens(int idLista, int[] idsItens)
        {
            return await _itensListaCompraRepository.ExcluirItens(idLista,idsItens);
        }

        private async Task<int> AdicionarItensLista(int idLista, int [] idsProdustos)
        {
            var itens = await _itensListaCompraRepository.ObterPorIdLista(idLista);

            if(itens is null) return 0;

            var novoProdutos = idsProdustos.ExceptBy(itens.Select(x => x.IdProduto),x => x);

            if(novoProdutos is null || !novoProdutos.Any()) return 0;

            return await _itensListaCompraRepository.Inserir(ItensListaCompras(idLista,idsProdustos));

        }        
    }
}