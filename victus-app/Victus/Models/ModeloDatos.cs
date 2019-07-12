using System;
using System.Collections.Generic;
using System.Linq;
using Capa_Logica;

namespace Victus.Models
{
    public class ModeloDatos
    {
        public Cliente DatosCliente { get; set; } = new Cliente();
        public Persona DatosPersona { get; set; } = new Persona();
    }
}