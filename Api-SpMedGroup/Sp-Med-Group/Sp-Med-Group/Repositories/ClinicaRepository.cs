using Sp_Med_Group.Contexts;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Repositories
{   
    

    public class ClinicaRepository : IClinica
    {
        SpMedGroup ctx = new SpMedGroup();

        public Clinica BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
