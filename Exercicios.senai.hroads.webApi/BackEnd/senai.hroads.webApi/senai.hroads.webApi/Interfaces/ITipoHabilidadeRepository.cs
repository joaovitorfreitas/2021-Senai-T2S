using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> ListarTipoHabilidade();

        TipoHabilidade BuscarTipoHabilidade(int id);

        void AtualizarTipoHabilidade(int id, TipoHabilidade AtualizarTipoHabilidade);

        void CadastrarTipoHabilidade(TipoHabilidade CadastrarTipoHabilidade);

        void DeletarTipoHabilidade(int id);
    }
}
