using domaincore.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaincore.interfaces
{
    public interface IUsuarioRepository : IWriteRepository<UsuarioViewDto>
    {
        Task<IReadOnlyList<UsuarioViewDto>> ListUsuariosByValueAsync(int pageNumber, int pageSize, string value_like, CancellationToken cancellationToken);
    }
}
