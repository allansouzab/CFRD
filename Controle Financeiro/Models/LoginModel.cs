using Controle_Financeiro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class LoginModel : ConnectionFactory
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public bool GetUser(LoginModel lg)
        {
            try
            {
                string sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Senha = @Senha";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SqlParameter("@Usuario", lg.usuario));
                cmd.Parameters.Add(new SqlParameter("@Senha", lg.senha));
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
