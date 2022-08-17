using domaincore.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaincore.interfaces.services
{
    public interface IUsuarioService
    {
        Task<IReadOnlyList<UsuarioViewDto>> ListUsuariosByValueAsync(int pageNumber, int pageSize, string value_like, CancellationToken cancellationToken, bool trackChanges = false);
    }
}
