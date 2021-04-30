using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();


        /// <summary>
        ///  Atualiza um Tipo de usuario 
        /// </summary>
        /// <param name="id">id do tipo de usuario atualizado</param>
        /// <param name="AtualizarTipoUsuario"> Propriedade passadas do tipo de usuario Atualizado </param>
        public void AtualizarTipoUsuario(int id, TipoUsuario AtualizarTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if(AtualizarTipoUsuario.NomeTipoUsuario != null)
            {
                TipoUsuarioBuscado.NomeTipoUsuario = AtualizarTipoUsuario.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            ctx.SaveChanges();

        }

        /// <summary>
        /// Buscar um tipo de usuario
        /// </summary>
        /// <param name="id">id do Tipo de usuario buscado</param>
        /// <returns>retorna um Tipo de usuario buscado </returns>
        public TipoUsuario BuscarTipoUsuario(int id)
        {
            return ctx.TipoUsuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="CadastrarTipoUsuario">Propriedades do tipo usuario a serem passadas</param>
        public void CadastrarTipoUsuario(TipoUsuario CadastrarTipoUsuario)
        {
            ctx.TipoUsuarios.Add(CadastrarTipoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Tipo de usuario
        /// </summary>
        /// <param name="id">Id do Tipo de usuario deletado</param>
        public void DeletarTipoUsuario(int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        ///  Lista Todos Tipo De Usuarios
        /// </summary>
        /// <returns> Retorna uma lista Tipo de usuarios</returns> 
        public List<TipoUsuario> ListarTipoUsuario()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
