using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Controls
{
    public class ConnectionFactory
    {
        private string _strConnection;
        private SQLiteConnection _conn;
        private SQLiteCommand _comandoSQL;


        public static String ConnectionString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["myDBConnectionString"].ConnectionString; }
        }

        public SQLiteConnection AbreConexao()
        {
            try
            {
                _strConnection = ConnectionString;
                _conn = new SQLiteConnection();
                _conn.ConnectionString = _strConnection;
                _conn.Open();
                return _conn;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FecharConexao()
        {
            try
            {
                _strConnection = ConnectionString;
                _conn = new SQLiteConnection(_strConnection);
                _conn.Close();

                if (_conn.State == System.Data.ConnectionState.Closed)
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
        }

    }
}
