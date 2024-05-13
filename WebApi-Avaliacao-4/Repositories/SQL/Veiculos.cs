using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
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


        [HttpGet]
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
                            veiculo.Opcionais = dr["Opcionais"].ToString();

                            veiculos.Add(veiculo);
                        }
                    }
                }
            }

            return veiculos;
        }



        [HttpGet]
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
                            veiculo.Opcionais = dr["Opcionais"].ToString();

                        }
                    }
                }
            }

            return veiculo;
        }


        [HttpGet]
        public List<Models.Veiculo> Select(string nome)
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo>();

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    cmd.CommandText = "select Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais from veiculos where nome like @Nome;";
                    cmd.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = $"%{nome}%"; 

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Models.Veiculo veiculo = new Models.Veiculo();

                            veiculo.Id = (int)dr["Id"];
                            veiculo.Marca = dr["Marca"].ToString();
                            veiculo.Nome = dr["Nome"].ToString();
                            veiculo.AnoModelo = (int)dr["AnoModelo"];
                            veiculo.DataFabricacao = (DateTime)dr["DataFabricacao"];
                            veiculo.Valor = (decimal)dr["Valor"];
                            veiculo.Opcionais = dr["Opcionais"].ToString();

                            veiculos.Add(veiculo);

                        }
                    }
                }
            }

            return veiculos;
        }



        [HttpPost]
        public bool Insert(Models.Veiculo veiculo)
        {

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    cmd.CommandText = "insert into veiculos (Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais) values (@marca, @nome, @anomodelo, @datafabricacao, @valor, @opcionais); select convert(int,SCOPE_IDENTITY());";
                    cmd.Parameters.Add(new SqlParameter("@marca", System.Data.SqlDbType.VarChar)).Value = veiculo.Marca;
                    cmd.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = veiculo.Nome;
                    cmd.Parameters.Add(new SqlParameter("@anomodelo", System.Data.SqlDbType.Int)).Value = veiculo.AnoModelo;
                    cmd.Parameters.Add(new SqlParameter("@datafabricacao", System.Data.SqlDbType.DateTime)).Value = veiculo.DataFabricacao;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = veiculo.Valor;
                    cmd.Parameters.Add(new SqlParameter("@opcionais", System.Data.SqlDbType.VarChar)).Value = veiculo.Opcionais;

                   veiculo.Id =(int) cmd.ExecuteScalar();

                }
            }


            return veiculo.Id != 0;
        }
    }



    

}

