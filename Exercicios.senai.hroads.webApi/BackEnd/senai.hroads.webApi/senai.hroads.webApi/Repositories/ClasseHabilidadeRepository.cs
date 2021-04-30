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
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarClasseHabilidade(int id, ClasseHabilidade AtualizarClasseHabilidade)
        {
            ClasseHabilidade ClasseHabilidadeBuscada = ctx.ClasseHabilidades.Find(id);

            if (AtualizarClasseHabilidade.IdClasse != null && AtualizarClasseHabilidade.IdHabilidade != null)
            {
                ClasseHabilidadeBuscada.IdClasse = AtualizarClasseHabilidade.IdClasse;
                ClasseHabilidadeBuscada.IdHabilidade = AtualizarClasseHabilidade.IdHabilidade;
            }

            ctx.ClasseHabilidades.Update(ClasseHabilidadeBuscada);

            ctx.SaveChanges();
        }

        public ClasseHabilidade BuscarClasseHabilidade(int id)
        {
            return ctx.ClasseHabilidades.Include(d => d.IdClasseNavigation).Include(d => d.IdHabilidadeNavigation).FirstOrDefault(d => d.IdClasseHabilidade == id);
        }

        public void CadastrarClasseHabilidade(ClasseHabilidade CadastrarClasseHabilidade)
        {
            ctx.ClasseHabilidades.Add(CadastrarClasseHabilidade);

            ctx.SaveChanges();
        }

        public void DeletarClasseHabilidade(int id)
        {
            ClasseHabilidade ClasseBuscada = ctx.ClasseHabilidades.Find(id);

            ctx.ClasseHabilidades.Remove(ClasseBuscada);

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListarClasseHabilidade()
        {
            return ctx.ClasseHabilidades.Include(d => d.IdClasseNavigation).Include(d => d.IdHabilidadeNavigation).ToList();
        }
    }
}
