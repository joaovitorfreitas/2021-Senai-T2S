using Sp_Med_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Interfaces
{
    interface IMedico
    {
        List<Medico> Listar();

        Medico BuscarPor();

        void Cadastrar(Medico NovoMedico);

        void deletar(int id);
    }
}
