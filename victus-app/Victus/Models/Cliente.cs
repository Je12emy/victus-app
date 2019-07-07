using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Capa_Logica;

namespace Victus.Models
{
    public class Cliente
    {
        public string Correo { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string Edad { get; set; }
        public string IMC { get; set; }
        public string Agua { get; set; }

        // Metodos
        Acceso_Logica datos = new Acceso_Logica();
        public DataTable ObtenerUltimoRegistro(string Correo) {          
            DataTable fecha;

            fecha = datos.BuscarUltimoRegistro(Correo);

            return fecha;
        }
        public DataTable ObtenerDatosUsuario(string Correo, string Fecha) {
            DataTable Registro;

            Registro = datos.BuscarCliente(Correo, Fecha);

            return Registro;
        }
        public int AgregarDatosUsuario(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha) {
            int i;

            i = datos.CrearDatosCliente(Correo, Peso, Altura, Edad, IMC,Agua, Fecha);

            return i;
        }
        public int ModificarDatosUsuario(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha) {
            int i;

            i = datos.ModificarDatosCliente(Correo, Peso, Altura, Edad, IMC, Agua, Fecha);

            return i;
        }

    }
}