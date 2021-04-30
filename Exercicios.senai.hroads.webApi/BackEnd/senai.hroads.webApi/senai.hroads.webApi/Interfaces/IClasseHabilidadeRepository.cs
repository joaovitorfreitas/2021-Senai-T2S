using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClasseHabilidade> ListarClasseHabilidade();

        ClasseHabilidade BuscarClasseHabilidade(int id);

        void AtualizarClasseHabilidade(int id, ClasseHabilidade AtualizarClasseHabilidade);

        void CadastrarClasseHabilidade(ClasseHabilidade CadastrarClasseHabilidade);

        void DeletarClasseHabilidade(int id);
    }
}
