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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarPersonagem(int id, Personagem AtPersonagem)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(id);

            if(AtPersonagem.IdClasse != null && AtPersonagem.Nome != null && AtPersonagem.CapacidadeMaximaMana.ToString() != null && AtPersonagem.CapacidadeMaximaVida.ToString() != null && AtPersonagem.DataDeAtualizacao.ToString() != null && AtPersonagem.DataDeCriacao.ToString() != null)
            {
                PersonagemBuscado.IdClasse = AtPersonagem.IdClasse;
                PersonagemBuscado.Nome = AtPersonagem.Nome;
                PersonagemBuscado.CapacidadeMaximaMana = AtPersonagem.CapacidadeMaximaMana;
                PersonagemBuscado.CapacidadeMaximaVida = AtPersonagem.CapacidadeMaximaVida;
                PersonagemBuscado.DataDeAtualizacao = AtPersonagem.DataDeAtualizacao;
                PersonagemBuscado.DataDeCriacao = AtPersonagem.DataDeCriacao;
            }

            ctx.Personagems.Update(PersonagemBuscado);

            ctx.SaveChanges();

        }

        public Personagem BuscarPersonagem(int id)
        {
            return ctx.Personagems.Include(d => d.IdClasseNavigation).FirstOrDefault(d => d.IdClasse == id);
        }

        public void CadastrarPersonagem(Personagem NovoPersonagem)
        {
            ctx.Personagems.Add(NovoPersonagem);

            ctx.SaveChanges();
        }

        public void DeletarPersonagem(int id)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(id);

            ctx.Personagems.Remove(PersonagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> ListarPersonagens()
        {
            return ctx.Personagems.Include(d => d.IdClasseNavigation).ToList();
        }
    }
}
