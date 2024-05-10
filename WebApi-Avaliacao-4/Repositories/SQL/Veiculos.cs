using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi_Avaliacao_4.Models;

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



        public Models.Veiculo Select(int id)
        {
            Models.Veiculo veiculo = null;

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    cmd.CommandText = "select Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais from veiculos where Id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            veiculo = new Models.Veiculo();

                            veiculo.Id = (int)dr["Id"];
                            veiculo.Marca = dr["Marca"].ToString();
                            veiculo.Nome = dr["Nome"].ToString();
                            veiculo.AnoModelo = (int)dr["AnoModelo"];
                            veiculo.DataFabricacao = (DateTime)dr["DataFabricacao"];
                            veiculo.Valor = (decimal)dr["Valor"];
                            veiculo.Opicionais = dr["Opcionais"].ToString();

                        }
                    }
                }
            }

            return veiculo;
        }

    }
}