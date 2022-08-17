namespace Dapper_odata_example_backend.Controllers
{
    public class ContextValues
    {
        /// <summary>Propriedade com id da empresa</summary>
        public long CompanyId { get; set; }

        /// <summary>Propriedade com tenant do ambiente</summary>
        public string TenantId { get; set; }
    }
}
