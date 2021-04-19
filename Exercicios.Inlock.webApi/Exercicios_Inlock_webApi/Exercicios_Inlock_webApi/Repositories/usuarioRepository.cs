using Exercicios_Inlock_webApi.Domains;
using Exercicios_Inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {
        private string ConexaoString = "Data Source=DESKTOP-42FT3LN\\SQLEXPRESS; Initial Catalog=inlock_games_tarde; User Id=joao; pwd=1234j;";

        public usuarioDomain Login(string email, string senha)
        {
            using(SqlConnection con = new SqlConnection(ConexaoString))
            {
                string queryLogin = "select idUsuario,email, senha, idTipoUsuario from usuarios where email = @email and senha = @senha";


                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();


                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioDomain LoginUsuario = new usuarioDomain
                        {

                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            senha = rdr["senha"].ToString(),
                            email = rdr["email"].ToString()


                        };

                        return LoginUsuario;
                    }

                    return null;





                }
            }
        }
    }
}
