using Dapper;
using domaincore.dto;
using domaincore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repository
{
    public class Repository : IRepository
    {
        protected DapperContext _context;

        /// <summary>
        /// Construtor do repositório
        /// </summary>
        /// <param name="con">Conexão com o banco de dados</param>
        protected Repository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> QueryWithPaginationAsync<T>(int pageNumber, int pageSize, string processQuery, CancellationToken cancellationToken)
        {
            return await QueryWithPaginationAsync<T>(pageNumber, pageSize, processQuery, new DynamicParameters(), cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryWithPaginationAsync<T>(int pageNumber, int pageSize, string processQuery, DynamicParameters parameters, CancellationToken cancellationToken)
        {
            int maxPagSize = 50;
            pageSize = (pageSize > 0 && pageSize <= maxPagSize) ? pageSize : maxPagSize;

            int skip = (pageNumber - 1) * pageSize;
            int take = pageSize;

            parameters.Add("@Skip", skip);
            parameters.Add("@Take", take);

            processQuery += " OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

            using var connection = _context.CreateConnection();
            var lista = await connection.QueryAsync<T>(new CommandDefinition(processQuery, parameters, cancellationToken: cancellationToken));

            return (IReadOnlyList<T>)lista.AsEnumerable();
        }
    }
}
