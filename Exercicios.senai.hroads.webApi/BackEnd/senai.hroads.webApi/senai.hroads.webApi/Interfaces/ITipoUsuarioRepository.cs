using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    /// <summary>
    /// Interface onde definimos do Tipo Usúario 
    /// </summary>
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTipoUsuario();

        TipoUsuario BuscarTipoUsuario(int id);

        void AtualizarTipoUsuario(int id, TipoUsuario AtualizarTipoUsuario);

        void CadastrarTipoUsuario(TipoUsuario CadastrarTipoUsuario);

        void DeletarTipoUsuario(int id);
    }
}
