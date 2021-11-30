using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto_Ventas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (verifBD())
            {

            }
            else
            {
                cerrar();
            }
        }
        public async void cerrar()
        {
            await DisplayAlert("Mensaje", "Problemas de Conectividad. La aplicacion se va a cerrar", "OK");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private bool verifBD()
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                byte[] response = cliente.UploadValues(App.url + "conexion2.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
                //DisplayAlert("Mensaje", c, "OK");
                if (c.Equals("1")) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private async void C_Usuario(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Control_Usuario());
        }
        private async void R_Cliente(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Registro_Cliente());
        }
        private async void Pro_Inventario(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Producto_Inventario());
        }
        private async void Inventario(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Inventario());
        }

        private async void S_Adomicilio(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Servicio_Domicilio());
        }

        private async void R_Usuario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro_Usuario());
        }

        private async void Muestra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reporteria());
        }

    }
}
