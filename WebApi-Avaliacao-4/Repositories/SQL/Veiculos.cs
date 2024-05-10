using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi_Avaliacao_4.Repositories.SQL
{
    public class Veiculos
    {

        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public Veiculos(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand() { Connection = conn };
;       }


        public List<Models.Veiculo> Select()
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo>();

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    cmd.CommandText = "select Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais from veiculos;";

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Models.Veiculo veiculo = new Models.Veiculo();

                            veiculo.Id = (int) dr["Id"];
                            veiculo.Marca = dr["Marca"].ToString();
                            veiculo.Nome = dr["Nome"].ToString();
                            veiculo.AnoModelo = (int) dr["AnoModelo"];
                            veiculo.DataFabricacao = (DateTime) dr["DataFabricacao"];
                            veiculo.Valor = (decimal)dr["Valor"];
                            veiculo.Opicionais = dr["Opcionais"].ToString();

                            veiculos.Add(veiculo);
                        }
                    }
                }
            }

            return veiculos;
        }


    }
}