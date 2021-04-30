using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarClasse(int id, Classe AtualizarClasse)
        {
            Classe ClassesBuscada = ctx.Classes.Find(id);

            if(AtualizarClasse.NomeDaClasse != null)
            {
                ClassesBuscada.NomeDaClasse = AtualizarClasse.NomeDaClasse;
            }

            ctx.Classes.Update(ClassesBuscada);

            ctx.SaveChanges();
        }

        public Classe BuscarClasse(int id)
        {
            return ctx.Classes.Find(id);
        }

        public void CadastrarClasse(Classe CadastrarClasse)
        {
            ctx.Classes.Add(CadastrarClasse);

            ctx.SaveChanges();
        }

        public void DeletarClasse(int id)
        {
            Classe ClasseBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(ClasseBuscada);

        }

        public List<Classe> ListarClasses()
        {
            return ctx.Classes.ToList();
        }
    }
}
