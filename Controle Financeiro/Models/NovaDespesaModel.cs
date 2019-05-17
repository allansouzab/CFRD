using Controle_Financeiro.Controls;
using Controle_Financeiro.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class NovaDespesaModel : ConnectionFactory
    {
        public int Id { get; set; }
        public int NumFatura { get; set; }
        public DateTime Data { get; set; }
        public string Fornecedor { get; set; }
        public string Descricao { get; set; }
        public string CentroCusto { get; set; }
        public string Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public bool Add(NovaDespesaModel nd)
        {
            try
            {
                string sql = "INSERT INTO Despesas(NumFatura, Data, Fornecedor, Descricao, CentroCusto, Valor, Mes, Ano, Usuario) VALUES (@NumFatura, @Data, @Fornecedor, @Descricao, @CentroCusto, @Valor, @Mes, @Ano, @Usuario)";
                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SQLiteParameter("@NumFatura", nd.NumFatura));
                cmd.Parameters.Add(new SQLiteParameter("@Data", nd.Data));
                cmd.Parameters.Add(new SQLiteParameter("@Fornecedor", nd.Fornecedor));
                cmd.Parameters.Add(new SQLiteParameter("@Descricao", nd.Descricao));
                cmd.Parameters.Add(new SQLiteParameter("@CentroCusto", nd.CentroCusto));
                cmd.Parameters.Add(new SQLiteParameter("@Valor", nd.Valor));
                cmd.Parameters.Add(new SQLiteParameter("@Mes", nd.Mes));
                cmd.Parameters.Add(new SQLiteParameter("@Ano", nd.Ano));
                cmd.Parameters.Add(new SQLiteParameter("@Usuario", Session.Usuario));
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

        public ObservableCollection<NovaDespesaModel> GetMonth(int Mes, string Ano)
        {
            try
            {
                ObservableCollection<NovaDespesaModel> _despesa = new ObservableCollection<NovaDespesaModel>();

                string sql = "SELECT * FROM Despesas WHERE Mes = @Mes AND Ano = @Ano AND Usuario = @Usuario";
                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SQLiteParameter("@Mes", Mes));
                cmd.Parameters.Add(new SQLiteParameter("@Ano", Ano));
                cmd.Parameters.Add(new SQLiteParameter("@Usuario", Session.Usuario));
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    DateTime data = Convert.ToDateTime(dr["Data"]);
                    string data2 = data.ToShortDateString();
                    data = Convert.ToDateTime(data2);

                    _despesa.Add(new NovaDespesaModel()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        NumFatura = Convert.ToInt32(dr["NumFatura"]),
                        Data = data,
                        Fornecedor = Convert.ToString(dr["Fornecedor"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        CentroCusto = Convert.ToString(dr["CentroCusto"]),
                        Valor = Convert.ToString(dr["Valor"])
                    });
                }
                FecharConexao();

                return _despesa;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(NovaDespesaModel nd)
        {
            try
            {
                string sql = "DELETE FROM Despesas WHERE Id = @Id";
                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SQLiteParameter("@Id", nd.Id));
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
