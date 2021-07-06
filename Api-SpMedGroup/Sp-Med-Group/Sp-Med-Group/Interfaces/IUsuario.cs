using Sp_Med_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Interfaces
{
    interface IUsuario
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario novoUsuario);
    }
}
