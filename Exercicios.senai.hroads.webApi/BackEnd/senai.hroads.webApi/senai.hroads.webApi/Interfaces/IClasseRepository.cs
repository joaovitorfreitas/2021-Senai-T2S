using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> ListarClasses();

        Classe BuscarClasse(int id);

        void AtualizarClasse(int id, Classe AtualizarClasse);

        void CadastrarClasse(Classe CadastrarClasse);

        void DeletarClasse(int id);
    }
}
