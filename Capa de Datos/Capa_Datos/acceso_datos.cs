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

        // Entidad para almacenar la informacion basica de registro de cada usuario.
        public DataTable BuscarUsuario(string Correo)
        {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "SELECT Correo, Contraseña FROM Persona WHERE Correo = @Correo ";
            sql_command.Parameters[0].Value = Correo;


            table = method.ExecSearch(sql_command);
            return table;
        }
        public DataTable BuscarUsuarioTodo(string Correo)
        {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "SELECT * FROM Persona WHERE Correo = @Correo";
            sql_command.Parameters[0].Value = Correo;

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

        #region Entidad Cliente
        public DataTable BuscarCliente(string correo, string fecha) {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Fecha", SqlDbType.NVarChar);

            sql_command.CommandText = "SELECT * FROM Cliente where Correo = @Correo and FechaDatos = @Fecha";
            sql_command.Parameters[0].Value = correo;
            sql_command.Parameters[1].Value = fecha;


            table = method.ExecSearch(sql_command);
            return table;
        }

        public DataTable BuscarUltimoRegistro(string correo) {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "Select Max(FechaDatos) as UltimoRegistro from Cliente Where Correo = @Correo";
            sql_command.Parameters[0].Value = correo;


            table = method.ExecSearch(sql_command);
            return table;
        }

        public int AgregarDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha) {
            metodo_datos method = new metodo_datos();
            SqlCommand sql_command;

            int i;

            sql_command = method.GetCommand();



            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Peso", SqlDbType.Float);
            sql_command.Parameters.Add("@Altura", SqlDbType.Int);
            sql_command.Parameters.Add("@Edad", SqlDbType.Int);
            sql_command.Parameters.Add("@IMC", SqlDbType.Float);
            sql_command.Parameters.Add("@Agua", SqlDbType.Int);
            sql_command.Parameters.Add("@Fecha", SqlDbType.DateTime);


            sql_command.CommandText = "INSERT INTO Cliente Values(@Correo, @Peso, @Altura, @Edad, @IMC, @Agua, @Fecha)";

            sql_command.Parameters[0].Value = Correo;
            sql_command.Parameters[1].Value = Peso;
            sql_command.Parameters[2].Value = Altura;
            sql_command.Parameters[3].Value = Edad;
            sql_command.Parameters[4].Value = IMC;
            sql_command.Parameters[5].Value = Agua;
            sql_command.Parameters[6].Value = Fecha;


            i = method.ExecCommand(sql_command);
            return i;
        }
        public int ActualizarDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha)
        {
            metodo_datos method = new metodo_datos();
            SqlCommand sql_command;

            int i;

            sql_command = method.GetCommand();



            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Peso", SqlDbType.Float);
            sql_command.Parameters.Add("@Altura", SqlDbType.Int);
            sql_command.Parameters.Add("@Edad", SqlDbType.Int);
            sql_command.Parameters.Add("@IMC", SqlDbType.Float);
            sql_command.Parameters.Add("@Agua", SqlDbType.Int);
            sql_command.Parameters.Add("@Fecha", SqlDbType.DateTime);


            sql_command.CommandText = "UPDATE Cliente SET Peso = @Peso, Altura = @Altura, Edad = @Edad, IMC = @IMC, CantidadAgua = @Agua WHERE Correo = @Correo AND FechaDatos = @Fecha";

            sql_command.Parameters[0].Value = Correo;
            sql_command.Parameters[1].Value = Peso;
            sql_command.Parameters[2].Value = Altura;
            sql_command.Parameters[3].Value = Edad;
            sql_command.Parameters[4].Value = IMC;
            sql_command.Parameters[5].Value = Agua;
            sql_command.Parameters[6].Value = Fecha;


            i = method.ExecCommand(sql_command);
            return i;
        }

        #endregion

        #region Entidad Harris Ben
        public DataTable BuscarUltimoRegistroHarris(string correo)
        {
            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.CommandText = "Select Max(FechaHarris) as UltimoRegistro from HarrisBen Where Correo = @Correo";
            sql_command.Parameters[0].Value = correo;


            table = method.ExecSearch(sql_command);
            return table;
        }
        public DataTable BuscarRegistroHarris(string correo, string fecha)
        {

            metodo_datos method = new metodo_datos();
            DataTable table;
            SqlCommand sql_command;

            sql_command = method.GetCommand();

            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);
            sql_command.Parameters.Add("@Fecha", SqlDbType.NVarChar);

            sql_command.CommandText = "SELECT * FROM HarrisBen where Correo = @Correo and FechaHarris = @Fecha";
            sql_command.Parameters[0].Value = correo;
            sql_command.Parameters[1].Value = fecha;


            table = method.ExecSearch(sql_command);
            return table;
        }
        public int AgregarRegistroHarris(string FactorActividad,string TMB, string NivelCalorico, string fecha, string correo) {
            metodo_datos method = new metodo_datos();
            SqlCommand sql_command;

            int i;

            sql_command = method.GetCommand();



            sql_command.Parameters.Add("@FactorActividad", SqlDbType.Float);
            sql_command.Parameters.Add("@TMB", SqlDbType.Float);
            sql_command.Parameters.Add("@NivelCalorico", SqlDbType.Float);
            sql_command.Parameters.Add("@FechaHarris", SqlDbType.DateTime);
            sql_command.Parameters.Add("@Correo", SqlDbType.NVarChar);



            sql_command.CommandText = "INSERT INTO HarrisBen Values(@FactorActividad, @TMB, @NivelCalorico, @FechaHarris, @Correo)";

            sql_command.Parameters[0].Value = FactorActividad;
            sql_command.Parameters[1].Value = TMB;
            sql_command.Parameters[2].Value = NivelCalorico;
            sql_command.Parameters[3].Value = fecha;
            sql_command.Parameters[4].Value = correo;

            i = method.ExecCommand(sql_command);
            return i;
        }



        #endregion
    }
}

