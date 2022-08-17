using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaincore.interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        //
        // Summary:
        //     Adiciona a entidade no contexto.
        //
        // Parameters:
        //   entity:
        //     Entidade que será adicioanda
        //
        // Returns:
        //     Entity
        Task<decimal> AddAsync(T entity, CancellationToken cancellationToken);

        //
        // Summary:
        //     Exclui a entidade do contexto.
        //
        // Parameters:
        //   id:
        //     Chave-primaria do objeto
        //
        //   cancellationToken:
        //     Token de cancelamento da ação.
        //
        // Returns:
        //     Task
        Task DeleteAsync(object[] id, CancellationToken cancellationToken);

        //
        // Summary:
        //     Adiciona a entidade no contexto.
        //
        // Parameters:
        //   entity:
        //     Entidade que será adicioanda
        //
        // Returns:
        //     Entity
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
