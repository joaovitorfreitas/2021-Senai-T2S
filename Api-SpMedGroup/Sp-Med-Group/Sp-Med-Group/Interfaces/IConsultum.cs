using Sp_Med_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Interfaces
{
    interface IConsultum
    {
        void Cadastrar(Consultum novaConsulta);


        void MudarSituacao(int id, string status);

        List<Consultum> ListarConsultaMedicos(int id);

        List<Consultum> ListarConsultaPacientes(int id);

        List<Consultum> ListarTodos();

        void MudarDescricao(int id, Consultum status);

        Consultum BuscarConsultaMedicos(int idConsulta, int idMedico);

        Consultum BuscarConsultaPacientes(int idConsulta, int idPacientes);
    }
}
