using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Ventas.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Producto_Inventario : ContentPage
    {
        public Producto_Inventario()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {

            }else if (string.IsNullOrEmpty(txtCosto.Text))
            {

            }else if (string.IsNullOrEmpty(txtVenta.Text))
            {

            }else if (string.IsNullOrEmpty(txtCantidad.Text))
            {

            }else if (string.IsNullOrEmpty(txtIngreso.Text))
            {

            }
            else
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("descripcion", txtDescripcion.Text);
                parametros.Add("cantidad", txtCantidad.Text);
                parametros.Add("precio", txtCosto.Text);
                parametros.Add("preciov", txtVenta.Text);
                parametros.Add("fecha", txtIngreso.Text);

                byte[] response = cliente.UploadValues(App.url+"insertProducto.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
               
                if (c.Equals("1"))
                {
                    DisplayAlert("Informacion", "Producto Guardado Satisfactoriamente", "OK");
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtCantidad.Text = "";
                    txtCosto.Text = "";
                    txtVenta.Text = "";
                    txtIngreso.Text = "";
                }
                else
                {
                    DisplayAlert("Informacion", "Error al Guardar Producto", "OK");
                }
            }

        }



    }
}