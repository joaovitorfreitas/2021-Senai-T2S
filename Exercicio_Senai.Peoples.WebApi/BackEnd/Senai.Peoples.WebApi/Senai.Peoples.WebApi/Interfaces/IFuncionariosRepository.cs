using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IFuncionariosRepository
    {
        List<FuncionariosDomain> Listar();

        FuncionariosDomain Buscarporid(int id);

        FuncionariosDomain BuscarporNome(string nome);

        void Deletar(int id);

        void Atualizar(int id, FuncionariosDomain funcionario);

        void Inserir(FuncionariosDomain novoFuncionario);

    }
}
