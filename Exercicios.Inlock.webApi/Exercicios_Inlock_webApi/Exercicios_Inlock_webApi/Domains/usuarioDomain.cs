using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Domains
{
    public class usuarioDomain
    {
        public int idUsuario { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public int idTipoUsuario { get; set; }
    }
}
