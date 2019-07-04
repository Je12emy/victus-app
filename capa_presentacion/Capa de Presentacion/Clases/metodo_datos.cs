using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa_de_Presentacion
{
    class metodo_datos
    {
        // Get SQLCommand
        public SqlCommand GetCommand() {
            configuracion config = new configuracion();

            string ConnectionString = config.GetConnectionString();
            SqlConnection SQLConnection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            SQLConnection.ConnectionString = ConnectionString;
            Command = SQLConnection.CreateCommand();
            Command.CommandType = System.Data.CommandType.Text;

            return Command;
        }
        // Exec SQLCommand
        public int ExecCommand(SqlCommand command) {
            int i;
            try
            {
                command.Connection.Open();
                i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            finally {
                command.Connection.Close();
            }
        }
        // Exec Query
        public DataTable ExecSearch(SqlCommand command) {
            DataTable table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            try
            {
                command.Connection.Open();
                Adapter.SelectCommand = command;
                Adapter.Fill(table);

            }
            catch (Exception)
            {
                throw;
            }
            finally{
                command.Connection.Close();
            }
            return table;
        }

    }
}
