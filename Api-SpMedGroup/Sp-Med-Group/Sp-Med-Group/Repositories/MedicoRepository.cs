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
    public class MedicoRepository : IMedico
    {
        SpMedGroup ctx = new SpMedGroup();

        public Medico BuscarPor()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico NovoMedico)
        {
            throw new NotImplementedException();
        }

        public void deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.Include(e => e.IdClinicaNavigation).Include(e => e.IdEspecialidadeNavigation).Include(e => e.IdUsuarioNavigation).ToList();
        }
    }
}
