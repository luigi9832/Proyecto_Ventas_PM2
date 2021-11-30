using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Ventas.Classes
{
    class Reporteria
    {
        public int idVenta { get; set; }
        public string nombreCliente { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
        public double isv { get; set; }
        public double total { get; set; }
        public string fechaVenta { get; set; }

    }
}
