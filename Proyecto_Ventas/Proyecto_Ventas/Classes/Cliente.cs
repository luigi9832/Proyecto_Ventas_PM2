using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Ventas.Classes
{
    class Cliente
    {
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }

        public string telefono { get; set; }
        public string direccion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        
        public string fechaIngreso { get; set; } 
    }
}
