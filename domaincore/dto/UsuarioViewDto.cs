using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domaincore.dto
{
    public class UsuarioViewDto : DtoBase
    {
        /// <summary>
        /// Guid para identificação da empresa
        /// </summary>
        [Key]
        public string? key { get; set; }
        /// <summary>
        /// Nome da empresa
        /// </summary>
        public string? value { get; private set; }
    }
}
