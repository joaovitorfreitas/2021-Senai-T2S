using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Domains
{
    public class jogoDomain
    {
        public int idJogo { get; set; }

        public string nomeJogo { get; set; }

        public string descricaoJogo { get; set; }

        public DateTime dataLancamento { get; set; }

        public double valor { get; set; }

        public int idEstudio { get; set; }


    }
}
