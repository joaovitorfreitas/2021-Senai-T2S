using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> ListarPersonagens();

        Personagem BuscarPersonagem(int id);

        void DeletarPersonagem(int id);

        void CadastrarPersonagem(Personagem NovoPersonagem);

        void AtualizarPersonagem(int id, Personagem AtPersonagem);


    }
}
