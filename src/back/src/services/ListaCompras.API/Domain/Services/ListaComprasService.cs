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
        public async Task<List<ListaCompraResponseDTO>?> ListarAsync()
        {
            var items = await _listaComprasRepository.ListarAsync();

            if (items is null) return null;

            List<ListaCompraResponseDTO> lista = new(items.Count());

            foreach (var item in items)
            {
                lista.Add(new ListaCompraResponseDTO{
                    Id = item.Id,
                    Nome = item.Descricao
                });
            }

            return lista;
        }

        public async Task<List<ItensListaCompraResponseDTO>?> ListarItensAsync(int idLista)
        {
            var items = await _listaComprasRepository.ListarItensAsync(idLista);

            if(items is null || !items.Any()) return null;

            List<ItensListaCompraResponseDTO> lista = new(items.Count());

            foreach (var item in items)
            {
                lista.Add(item);
            }

            return lista;
        }

        public async Task<int> GerarAsync(ListaComprasRequestDTO listaComprasRequest)
        {
            var idsProdutos = listaComprasRequest.IdsProdutos.ToArray();

            if(idsProdutos is null || idsProdutos.Length == 0) return 0;

            var existeProdutos = await _produtosRepository.ExisteAsync(idsProdutos);

            if(!existeProdutos) return 0;            

            var existeDescricao = await _listaComprasRepository.ExisteDescricaoAsync(listaComprasRequest.Nome);

            var descricao = existeDescricao ? string.Concat(listaComprasRequest.Nome,"-",Guid.NewGuid().ToString().Substring(0,8)) : listaComprasRequest.Nome;

            var listaCompras = new ListaComprasEntity(descricao);
            var r1 = await _listaComprasRepository.InserirAsync(listaCompras);       

            var r2 = await _itensListaCompraRepository.InserirAsync(ItensListaCompras(listaCompras.Id,listaComprasRequest.IdsProdutos.ToArray()));

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
        public async Task<int> AdicionarItensAsync(int idLista, int[] idsProdutos)
        {

            if(idsProdutos.Length <= 0) return 0;

            var existeProdutos = await _produtosRepository.ExisteAsync(idsProdutos);

            if(!existeProdutos) return 0;            

            var r2 = await AdicionarItensListaAsync(idLista,idsProdutos.Distinct().ToArray());

            return r2 > 0 ? 1 : 0;

        }

        public async Task<int> AtualizarDescricaoAsync(int idLista, string novaDescricao)
        {
            var lista = new ListaComprasEntity(idLista);
            lista.DefinirDescricao(novaDescricao);

            return await _listaComprasRepository.AtualizarAsync(lista);
        }

        public async Task<int> ExcluirAsync(int idLista)
        {
            return await _listaComprasRepository.ExcluirAsync(idLista);
        }

        public async Task<int> ExluirItensAsync(int idLista, int[] idsItens)
        {
            return await _itensListaCompraRepository.ExcluirItensAsync(idLista,idsItens);
        }

        private async Task<int> AdicionarItensListaAsync(int idLista, int [] idsProdustos)
        {
            var itens = await _itensListaCompraRepository.ObterPorIdListaAsync(idLista);

            if(itens is null) return 0;

            var novoProdutos = idsProdustos.ExceptBy(itens.Select(x => x.IdProduto),x => x);

            if(novoProdutos is null || !novoProdutos.Any()) return 0;

            return await _itensListaCompraRepository.InserirAsync(ItensListaCompras(idLista,idsProdustos));

        }        
    }
}