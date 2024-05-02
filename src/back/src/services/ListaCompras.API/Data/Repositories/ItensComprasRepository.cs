using Dapper;
using ListaCompras.API.Data.Contexts;
using ListaCompras.API.Domain.Entities;
using ListaCompras.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Data.Repositories
{
    public class ItensComprasRepository : BaseRepository<ApplicationDbContext, ItensComprasEntity>, IITensComprasRepository
    {
        public ItensComprasRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ItensComprasEntity>> Listar()
        {
            var connection = _context.Database.GetDbConnection();

            string sql = @"SELECT 
                            C.id_categoria idCategoria,
                            C.descricao categoria,
                            P.id_produto idProduto,
                            P.descricao produto
                        FROM categorias C
                        INNER JOIN produtos P
                        ON C.id_categoria = P.id_categoria";

            var resultado = await connection.QueryAsync<ItensComprasEntity>(sql);

            return resultado;
        }
    }
}