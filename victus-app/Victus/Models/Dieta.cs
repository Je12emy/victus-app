using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Logica;
using System.Data;

namespace Victus.Models
{
    public class Dieta
    {
        public string objetivo { get; set; }

        // Metodos
        #region Entidad Dieta
        public int AgregarDieta(string CorreoCliente, string FechaDieta, string CodigoHarris, string Objetivo)
        {

            Acceso_Logica DatosDieta = new Acceso_Logica();
            int i;

            i = DatosDieta.AgregarDieta(CorreoCliente, FechaDieta, CodigoHarris, Objetivo);
            return i;
        }
        public DataTable ObtenerUltimaDieta(string CorreoCliente)
        {
            Acceso_Logica DatosDieta = new Acceso_Logica();
            DataTable table;

            table = DatosDieta.ObtenerUltimaDieta(CorreoCliente);
            return table;
        }
        public DataTable ObtenerDieta(string CorreoCliente, string FechaDieta)
        {
            Acceso_Logica DatosDieta = new Acceso_Logica();
            DataTable table;

            table = DatosDieta.ObtenerDieta(CorreoCliente, FechaDieta);
            return table;
        }

        #endregion

        #region Entidad-DietaRelacion
        public int AgregarRelacion(string CodigoDieta, string CodigoAlimento)
        {
            Acceso_Logica DatosDieta = new Acceso_Logica();
            int i;

            i = DatosDieta.AgregarRelacion(CodigoDieta, CodigoAlimento);
            return i;
        }
        #endregion

        #region Entidad Catalogo Alimentos
        public DataTable ObtenerCatalogoAlimentos()
        {
            Acceso_Logica DatosDieta = new Acceso_Logica(); ;
            DataTable table;


            table = DatosDieta.ObtenerCatalogoAlimentos();
            return table;
        }
        public DataTable ObtenerDietaCompleta(string CorreoCliente, string CodigoDieta)
        {
            Acceso_Logica DatosDieta = new Acceso_Logica();
            DataTable table;

            table = DatosDieta.ObtenerDietaCompleta(CorreoCliente, CodigoDieta);
            return table;
        }
        #endregion
    }
}