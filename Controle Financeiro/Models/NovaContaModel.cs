using Controle_Financeiro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    class NovaContaModel : ConnectionFactory
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public bool Add(NovaContaModel nc)
        {
            try
            {
                string sql = "INSERT INTO Usuarios(Usuario, Senha) VALUES (@Usuario, @Senha)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@Usuario", nc.usuario));
                cmd.Parameters.Add(new SqlParameter("@Senha", nc.senha));
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

        public bool GetExistsUser(NovaContaModel nc)
        {
            try
            {
                string sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@Usuario", nc.usuario));
                SqlDataReader dr = cmd.ExecuteReader();
                int rows = 0;
                while (dr.Read())
                {
                    rows++;
                }

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
