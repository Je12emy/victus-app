﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;


namespace Capa_Logica
{
    public class Acceso_Logica
    {
        #region Entidad Persona

        public DataTable BuscarUsuario(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUsuario(Correo);
            return table;
        }
     

        public DataTable BuscarUsuarioTodo(string correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUsuarioTodo(correo);
            return table;
         
        }

        public int CrearUsuario(string Correo, string cedula, string nombre, string apellido1, string apellido2, string genero, string Contraseña)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            int bitgenero;

            if (genero == "True")
            {
                bitgenero = 1;

            }
            else
                bitgenero = 0;

            i = datos.CrearUsuario(Correo,cedula,nombre,apellido1,apellido2,Convert.ToString(bitgenero),Contraseña);
            return i;
        }

        public int CambiarContraseña(string Correo, string Contraseña)
        {
            acceso_datos datos = new acceso_datos(); 
            int i;
            i = datos.CambiarContraseña(Correo,Contraseña);
           
            return i;
        }

        public int EliminarUsuario(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            i = EliminarUsuario(Correo);
            return i;


        }

        #endregion

        #region Entidad Cliente
        public DataTable BuscarUltimoRegistro(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUltimoRegistro(Correo);
            return table;
        }


        public DataTable BuscarCliente(string Correo, string Fecha) {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarCliente(Correo, Fecha);
            return table;
        }
        public int CrearDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha) {
            acceso_datos datos = new acceso_datos();
            int i;

            i = datos.AgregarDatosCliente(Correo, Peso, Altura, Edad, IMC, Agua,Fecha);
            return i;
        }
        public int ModificarDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha)
        {
            acceso_datos datos = new acceso_datos();
            int i;

            i = datos.ActualizarDatosCliente(Correo, Peso, Altura, Edad, IMC, Agua, Fecha);
            return i;
        }


        #endregion

        #region Entidad HarrisBen
        public DataTable BuscarUltimoRegistroHarris(string correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUltimoRegistroHarris(correo);
            return table;
        }
        public DataTable BuscarRegistroHarris(string correo, string fecha)
        {
            acceso_datos datos = new acceso_datos();     
            DataTable table;
            table = datos.BuscarRegistroHarris(correo,fecha);
            return table;
        }
        public int AgregarRegistroHarris(string FactorActividad, string TMB, string NivelCalorico, string fecha, string correo)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            i = datos.AgregarRegistroHarris(FactorActividad,TMB,NivelCalorico,fecha,correo);
            return i;
        }
        #endregion
    }
}
