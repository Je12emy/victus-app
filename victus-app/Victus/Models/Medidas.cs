using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Capa_Logica;

namespace Victus.Models
{
    public class Medidas
    {
        public float BicepIzquierdo { get; set; }
        public float BicepDerecho { get; set; }
        public float Abdomen { get; set; }
        public float CuadricepIzquierdo { get; set; }
        public float CuadricepDerecho { get; set; }
        public float PantorrillaIzquierda { get; set; }
        public float PantorrillaDerecha { get; set; }

        // Metodos
        public int AgregarMedidas(string FechaMedida, string CorreoCliente, string BicepIzquierdo, string BicepDerecho, string Abdomen, string CuadricepIzquierdo, string CuadricepDerecho, string PantorrillaIzquierda, string PantorrillaDerecha)
        {
            Acceso_Logica Datos = new Acceso_Logica();
            int i;


            i = Datos.AgregarMedidas(FechaMedida, CorreoCliente, BicepIzquierdo, BicepDerecho, Abdomen, CuadricepIzquierdo, CuadricepDerecho, PantorrillaIzquierda, PantorrillaDerecha);
            return i;
        }
        public DataTable ObtenerUltimaMedida(string CorreoCliente)
        {
            Acceso_Logica Datos = new Acceso_Logica();
            DataTable table;

            table = Datos.ObtenerUltimaMedida(CorreoCliente);
            return table;
        }
        public DataTable ObtenerMedida(string CorreoCliente, string FechaDieta)
        {
            Acceso_Logica Datos = new Acceso_Logica();
            DataTable table;

            table = Datos.ObtenerMedida(CorreoCliente, FechaDieta);
            return table;
        }
        public DataTable ObtenerMedicionCompleta(string CodigoMedida)
        {
            Acceso_Logica Datos = new Acceso_Logica();
            DataTable table;


            table = Datos.ObtenerMedicionCompleta(CodigoMedida);
            return table;
        }
    }
}