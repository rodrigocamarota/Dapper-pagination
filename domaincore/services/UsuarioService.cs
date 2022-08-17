using domaincore.dto;
using domaincore.interfaces.services;
using domaincore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaincore.services
{
    public class UsuarioService : IUsuarioService
    {
        //private Erro Notificacao { get; } = new Erro();
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        /// <summary>
        /// Lista de empresas
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<UsuarioViewDto>> ListUsuariosByValueAsync(int pageNumber, int pageSize, string value_like, CancellationToken cancellationToken, bool trackChanges = false)
        {
            var usuario = await _usuarioRepo.ListUsuariosByValueAsync(pageNumber, pageSize, value_like, cancellationToken);
            return usuario;
        }
    }
}
