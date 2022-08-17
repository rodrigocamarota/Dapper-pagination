using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Dapper_odata_example_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Cache de memória
        /// </summary>
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Valores de contexto
        /// </summary>
        protected ContextValues Context { get; set; } = new ContextValues();

        /// <summary>
        /// Construtor sem parametro
        /// </summary>
        public BaseController() { }

        /// <summary>
        /// Construtor com parametro
        /// </summary>
        /// <param name="provider">Provider</param>
        public BaseController(IServiceProvider provider)
        {
            _memoryCache = provider.GetRequiredService<IMemoryCache>();
        }


        /// <summary>
        /// Faz o controle do cache
        /// </summary>
        /// <typeparam name="T">Tipo de retorno</typeparam>
        /// <param name="id">Id que irá guardar o cache</param>
        /// <param name="funcAsync">Método para ser executado</param>
        /// <returns>Retorna o tipo T requerido</returns>
        public async Task<T> CacheControl<T>(string id, Func<Task<T>> funcAsync) where T : class
        {
            var retornoReal = await funcAsync();
            _memoryCache.Set(id, retornoReal, DateTimeOffset.Now.AddMinutes(30));
            return retornoReal;
        }
    }
}
