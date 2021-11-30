using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Ventas.Classes
{
    class Producto
    {
        
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }

        public string descripcionProducto { get; set; }
        public int cantidadProducto { get; set; }
        public double precioCosto { get; set; }
        public double precioVenta { get; set; }
        public string fechaRegistro { get; set; }

      
    }
}
