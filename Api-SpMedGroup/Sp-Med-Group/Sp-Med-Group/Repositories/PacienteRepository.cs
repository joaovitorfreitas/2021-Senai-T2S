using Microsoft.EntityFrameworkCore;
using Sp_Med_Group.Contexts;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Repositories
{
    public class PacienteRepository : IPaciente
    {
        
        SpMedGroup ctx = new SpMedGroup();

        public Paciente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        public void deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.Include(c => c.IdUsuarioNavigation).ToList();
        }
    }
}
