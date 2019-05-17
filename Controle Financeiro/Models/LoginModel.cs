using Controle_Financeiro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
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
                SQLiteCommand cmd = new SQLiteCommand(sql);
                cmd.Connection = AbreConexao();
                cmd.Parameters.Add(new SQLiteParameter("@Usuario", lg.usuario));
                cmd.Parameters.Add(new SQLiteParameter("@Senha", lg.senha));
                SQLiteDataReader dr = cmd.ExecuteReader();
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
