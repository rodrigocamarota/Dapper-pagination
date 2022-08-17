using domaincore.dto;
using domaincore.interfaces.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dapper_odata_example_backend.Controllers
{

    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuario;

        public UsuarioController(
                                    IUsuarioService usuario
                                   ) : base()
        {
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<IReadOnlyList<UsuarioViewDto>> Get(int pageNumber, int pageSize, string value_like)
        {
            return await _usuario.ListUsuariosByValueAsync(pageNumber, pageSize, value_like, HttpContext.RequestAborted);
        }
    }
}
