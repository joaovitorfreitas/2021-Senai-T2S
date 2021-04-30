using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        
       HroadsContext ctx = new HroadsContext();

        public void AtualizarTipoHabilidade(int id, TipoHabilidade AtualizarTipoHabilidade)
        {
            TipoHabilidade TipoHabilidadeBuscada = ctx.TipoHabilidades.Find(id);


            if(AtualizarTipoHabilidade.NomeTipoHabilidade != null)
            {
                TipoHabilidadeBuscada.NomeTipoHabilidade = AtualizarTipoHabilidade.NomeTipoHabilidade; 
            }

            ctx.TipoHabilidades.Update(TipoHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarTipoHabilidade(int id)
        {
            return ctx.TipoHabilidades.Find(id);
        }

        public void CadastrarTipoHabilidade(TipoHabilidade CadastrarTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(CadastrarTipoHabilidade);

            ctx.SaveChanges();
        }

        public void DeletarTipoHabilidade(int id)
        {
            TipoHabilidade TipoHabilidadeBuscado = ctx.TipoHabilidades.Find(id);

            ctx.TipoHabilidades.Remove(TipoHabilidadeBuscado);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTipoHabilidade()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
