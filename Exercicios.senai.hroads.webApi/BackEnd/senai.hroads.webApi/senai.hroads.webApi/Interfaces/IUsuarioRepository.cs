using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuario();

        Usuario BuscarUsuario(int id);

        Usuario Login(string email, string senha);

        void AtualizarUsuario(int id, Usuario AtualizarUsuario);

        void CadastrarUsuario(Usuario CadastrarUsuario);

        void DeletarUsuario(int id);
    }
}
