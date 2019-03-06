using Controle_Financeiro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class NovaReceitaModel : ConnectionFactory
    {
        public int Id { get; set; }
        public int NumFatura { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public string Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public bool Add(NovaReceitaModel nr)
        {
            try
            {
                string sql = "INSERT INTO Receitas(NumFatura, Data, Cliente, Valor, Mes, Ano) VALUES (@NumFatura, @Data, @Cliente, @Valor, @Mes, @Ano)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@NumFatura", nr.NumFatura));
                cmd.Parameters.Add(new SqlParameter("@Data", nr.Data));
                cmd.Parameters.Add(new SqlParameter("@Cliente", nr.Cliente));
                cmd.Parameters.Add(new SqlParameter("@Valor", nr.Valor));
                cmd.Parameters.Add(new SqlParameter("@Mes", nr.Mes));
                cmd.Parameters.Add(new SqlParameter("@Ano", nr.Ano));
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public ObservableCollection<NovaReceitaModel> GetMonth(int Mes, string Ano)
        {
            try
            {
                ObservableCollection<NovaReceitaModel> _receita = new ObservableCollection<NovaReceitaModel>();

                string sql = "SELECT * FROM Receitas WHERE Mes = @Mes AND Ano = @Ano";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@Mes", Mes));
                cmd.Parameters.Add(new SqlParameter("@Ano", Ano));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    DateTime data = Convert.ToDateTime(dr["Data"]);
                    string data2 = data.ToShortDateString();
                    data = Convert.ToDateTime(data2);

                    _receita.Add(new NovaReceitaModel()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        NumFatura = Convert.ToInt32(dr["NumFatura"]),
                        Data = data,
                        Cliente = Convert.ToString(dr["Cliente"]),
                        Valor = Convert.ToString(dr["Valor"])
                    });
                }
                FecharConexao();

                return _receita;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(NovaReceitaModel nr)
        {
            try
            {
                string sql = "DELETE FROM Receitas WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@Id", nr.Id));
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }

        }
    }
}
