using Sp_Med_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Interfaces
{
    interface IPaciente
    {
        List<Paciente> Listar();

        Paciente BuscarPorId(int id);

        void Cadastrar(Paciente novoPaciente);

        void deletar(int id);
    }
}
