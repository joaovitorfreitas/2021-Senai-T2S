using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarUsuario(int id, Usuario AtualizarUsuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (AtualizarUsuario.Email != null && AtualizarUsuario.Senha != null && AtualizarUsuario.IdTipoUsuario != null)
            {
                usuarioBuscado.Email = AtualizarUsuario.Email;
                usuarioBuscado.Senha = AtualizarUsuario.Senha;
                usuarioBuscado.IdTipoUsuario = AtualizarUsuario.IdTipoUsuario;
            }

            ctx.Usuarios.Add(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarUsuario(int id)
        {
            return ctx.Usuarios.Include(d => d.IdTipoUsuarioNavigation).FirstOrDefault(d => d.IdUsuario == id);
        }

        public void CadastrarUsuario(Usuario CadastrarUsuario)
        {
            ctx.Usuarios.Add(CadastrarUsuario);

            ctx.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuario()
        {
            return ctx.Usuarios.Include(d => d.IdTipoUsuarioNavigation).ToList();

        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
