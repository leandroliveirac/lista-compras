using System.Data.Common;
using Dapper;
using ListaCompras.API.Data.Contexts;
using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using ListaCompras.API.DTL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Repositories
{
    public class ListaComprasRepository : BaseRepository<ApplicationDbContext, ListaComprasEntity>, IListaComprasRepository
    {
        private readonly DbConnection _connection; 
        public ListaComprasRepository(ApplicationDbContext context) : base(context)
        {
            _connection = _context.Database.GetDbConnection();
        }        

        public override async Task<IEnumerable<ListaComprasEntity>> Listar()
        {
            string sql = @"SELECT 
                            id_lista_compras Id, 
                            descricao Descricao
                        FROM listaCompras";
            return await _connection.QueryAsync<ListaComprasEntity>(sql);
        }

        public async Task<IEnumerable<ItensListaCompraResponseDTO>> ListarItens(int idLista)
        {
            string sql = @"select 
                                ic.id_itens_lista_compras IdItem
                                ,lc.id_lista_compras IdLista
                                ,lc.descricao DescricaoLista
                                ,p.id_produto IdProduto
                                ,p.descricao DescricaoProduto
                                ,c.id_categoria IdCategoria
                                ,c.descricao DescricaoCategoria
                            from itensListaCompras ic
                            inner join listaCompras lc
                            on ic.id_lista_compras = lc.id_lista_compras
                            inner join produtos p
                            on ic.id_produto = p.id_produto
                            inner join categorias c
                            on p.id_categoria = c.id_categoria
                            where ic.id_lista_compras = @ID_LISTA";

            var param = new {ID_LISTA = idLista};


            return await _connection.QueryAsync<ItensListaCompraResponseDTO>(sql,param);

        }

        public async Task<int> Inserir(ListaComprasEntity listaCompras)
        {
            await _context.ListaCompras.AddAsync(listaCompras);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Atualizar(ListaComprasEntity listaCompras)
        {
            _context.ListaCompras.Update(listaCompras);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Excluir(int id)
        {
            var obj = await ObterPorId(id).FirstOrDefaultAsync();

            if(obj is not null) _context.ListaCompras.Remove(obj);

           return await _context.SaveChangesAsync();
        }
        
        private IQueryable<ListaComprasEntity> ObterPorId(int id)
        {
            return _context.ListaCompras.Include(x => x.Itens)
                                .Where(l => l.Id == id);
        }

        public async Task<bool> ExisteDescricao(string descricao)
        {
            return await _context.ListaCompras.AnyAsync(x => x.Descricao.Equals(descricao));
        }
    }
}