using Exercicios_Inlock_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Interfaces
{
    interface IEstudioRepository
    {
        List<estudioDomain> ListarEstudios();
    }
}
