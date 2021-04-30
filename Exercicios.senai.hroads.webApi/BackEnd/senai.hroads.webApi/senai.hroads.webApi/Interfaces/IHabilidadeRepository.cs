using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> ListarHabilidade();

        Habilidade BuscarHabilidade(int id);

        void AtualizarHabilidade(int id, Habilidade AtualizarHabilidade);

        void CadastrarHabilidade(Habilidade CadastrarHabilidade);

        void DeletarHabilidade(int id);
    }
}
