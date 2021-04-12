using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string conexaoBanco = "Data Source=DESKTOP-42FT3LN\\SQLEXPRESS; initial catalog=T_Peoples; user Id=joao; pwd=1234j;";

        public void Atualizar(int id, FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE idFuncionarios = @IDFUNCIONARIOS";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@IDFUNCIONARIOS", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public FuncionariosDomain Buscarporid(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string querySelectId = "SELECT idFuncionarios, Nome, Sobrenome FROM Funcionarios WHERE idFuncionarios = @IDFUNCIONARIO";

                con.Open();

                SqlDataReader Datardr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {

                    cmd.Parameters.AddWithValue("@IDFUNCIONARIO", id);

                    Datardr = cmd.ExecuteReader();

                    if(Datardr.Read())
                    {
                        FuncionariosDomain funcionarioBuscado = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(Datardr["idFuncionarios"]),
                            Nome = Datardr["Nome"].ToString(),
                            Sobrenome = Datardr["Sobrenome"].ToString()
                        };

                        return funcionarioBuscado;
                    }

                    return null;

                    
                }
            }
        }

        public FuncionariosDomain BuscarporNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string querySelectId = "SELECT idFuncionarios, Nome, Sobrenome FROM Funcionarios WHERE Nome = @NOMEFUNCIONARIO";

                con.Open();

                SqlDataReader Datardr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {

                    cmd.Parameters.AddWithValue("@NOMEFUNCIONARIO", nome);

                    Datardr = cmd.ExecuteReader();

                    if (Datardr.Read())
                    {
                        FuncionariosDomain funcionarioBuscado = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(Datardr["idFuncionarios"]),
                            Nome = Datardr["Nome"].ToString(),
                            Sobrenome = Datardr["Sobrenome"].ToString()
                        };

                        return funcionarioBuscado;
                    }

                    return null;


                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionarios = @IDFUNCIONARIOS";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IDFUNCIONARIOS", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(FuncionariosDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> listaFuncionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(conexaoBanco))
            {
                string querySelectAll = "SELECT idFuncionarios, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader Datardr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    Datardr = cmd.ExecuteReader();

                    while (Datardr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain()
                        {
                            idFuncionarios = Convert.ToInt32(Datardr["idFuncionarios"]),
                            Nome = Datardr["Nome"].ToString(),
                            Sobrenome = Datardr["Sobrenome"].ToString()
                        };

                        listaFuncionarios.Add(funcionarios);
                    }
                        return listaFuncionarios;

                }

               
            }


        }
    }
}
