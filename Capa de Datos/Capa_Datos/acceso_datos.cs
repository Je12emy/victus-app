using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class acceso_datos
    {
        #region Entidad Persona

        public DataTable BuscarUsuario(string Correo)
        {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "SELECT * FROM Persona WHERE Correo = @Correo ";
            sql_command.Parameters[0].Value = Correo;


            table = method.ExecSearch(sql_command);
            return table;
        }
        public DataTable BuscarUsuarioTodo()
        {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();


            sql_command.CommandText = "SELECT * FROM Persona";


            table = method.ExecSearch(sql_command);
            return table;
        }

        public int CrearUsuario(string correo, string cedula, string nombre, string apellido1, string apellido2, string genero, string contraseña)
        {
            metodo_datos method = new metodo_datos();
            SqlCommand sql_command;

            int i;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Cedula", SqlDbType.Int);
            sql_command.Parameters.Add("@Nombre", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Apellido1", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Apellido2", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Genero", SqlDbType.Bit);
            sql_command.Parameters.Add("@Contraseña", SqlDbType.NVarChar);

            sql_command.CommandText = "INSERT INTO Persona Values(@Correo,@Cedula,@Nombre,@Apellido1,@Apellido2,@Genero,@Contraseña)";

            sql_command.Parameters[0].Value = correo;
            sql_command.Parameters[1].Value = cedula;
            sql_command.Parameters[2].Value = nombre;
            sql_command.Parameters[3].Value = apellido1;
            sql_command.Parameters[4].Value = apellido2;
            sql_command.Parameters[5].Value = Convert.ToInt16(genero);
            sql_command.Parameters[6].Value = contraseña;

            i = method.ExecCommand(sql_command);
            return i;
        }

        public int CambiarContraseña(string Correo, string Contraseña)
        {
            metodo_datos method = new metodo_datos();
            int i;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("Contraseña", SqlDbType.NVarChar);
            sql_command.CommandText = "UPDATE Persona set Contraseña = @Contraseña WHERE Correo = @Correo";
            sql_command.Parameters[0].Value = Correo;
            sql_command.Parameters[0].Value = Contraseña;

            i = method.ExecCommand(sql_command);
            return i;
        }

        public int EliminarUsuario(string Correo)
        {
            metodo_datos method = new metodo_datos();
            int i;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "Delete from Persona Where Correo = @Correo";
            sql_command.Parameters[0].Value = Correo;

            i = method.ExecCommand(sql_command);
            return i;


        }

        #endregion
    }
}
