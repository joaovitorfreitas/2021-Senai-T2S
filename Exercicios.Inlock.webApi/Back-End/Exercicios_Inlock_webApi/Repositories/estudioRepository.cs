using Exercicios_Inlock_webApi.Domains;
using Exercicios_Inlock_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Repositories
{
    public class estudioRepository : IEstudioRepository
    {
        private string ConexaoString = "Data Source=DESKTOP-42FT3LN\\SQLEXPRESS; Initial Catalog=inlock_games_tarde; User Id=joao; pwd=1234j;";

        public List<estudioDomain> ListarEstudios()
        {
            List<estudioDomain> EstudioLista = new List<estudioDomain>();

            using (SqlConnection con = new SqlConnection(ConexaoString))
            {
                string queryEstudio = "select idEstudio,nomeEstudio from estudios";

                using (SqlCommand cmd = new SqlCommand(queryEstudio, con))
                {
                
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        estudioDomain itensEstudio = new estudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()

                        };

                        EstudioLista.Add(itensEstudio);
                    }

                    return EstudioLista;


                }

            }

        }
    }
}
