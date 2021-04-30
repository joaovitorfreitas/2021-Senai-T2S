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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarHabilidade(int id, Habilidade AtualizarHabilidade)
        {
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            if(AtualizarHabilidade.NomeHabilidade != null && AtualizarHabilidade.IdTipoHabilidade != null)
            {
                HabilidadeBuscada.NomeHabilidade = AtualizarHabilidade.NomeHabilidade;
                HabilidadeBuscada.IdTipoHabilidade = AtualizarHabilidade.IdTipoHabilidade; 
            }

            ctx.Habilidades.Update(HabilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarHabilidade(int id)
        {
            return ctx.Habilidades.Include(d => d.IdTipoHabilidadeNavigation).FirstOrDefault(d => d.IdHabilidade == id);
        }

        public void CadastrarHabilidade(Habilidade CadastrarHabilidade)
        {
            ctx.Habilidades.Add(CadastrarHabilidade);

            ctx.SaveChanges();
        }

        public void DeletarHabilidade(int id)
        {
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(HabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarHabilidade()
        {
            return ctx.Habilidades.Include(d => d.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
