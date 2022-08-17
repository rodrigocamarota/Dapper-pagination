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
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        /// <summary>
        /// Construtor do repositório 
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados</param>
        public UsuarioRepository(DapperContext context) : base(context) { }

        public Task<decimal> AddAsync(UsuarioViewDto entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object[] id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UsuarioViewDto entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<UsuarioViewDto>> ListUsuariosByValueAsync(int pageNumber, int pageSize, string value_like, CancellationToken cancellationToken)
        {
            string search = string.Empty;

            if (!string.IsNullOrEmpty(value_like))
            {
                search = @$" AND sNmUsuario LIKE '%{value_like}%' ";
            }

            string processQuery = $@"select u.sCdUsuario AS [key], u.sNmUsuario AS [value] 
                                       from USUARIO u WITH(NOLOCK)
                                      order by sNmUsuario ";

            using var connection = _context.CreateConnection();
            var lista = await base.QueryWithPaginationAsync<UsuarioViewDto>(pageNumber, pageSize, processQuery, cancellationToken);
            
            return (IReadOnlyList<UsuarioViewDto>)lista.AsEnumerable();
        }
    }
}
