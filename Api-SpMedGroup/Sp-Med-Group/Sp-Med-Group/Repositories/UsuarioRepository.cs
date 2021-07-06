using Sp_Med_Group.Contexts;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Repositories
{

    public class UsuarioRepository : IUsuario
    {
        SpMedGroup ctx = new SpMedGroup();

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        }
    }
}
