using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Ventas.Classes;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inventario : ContentPage
    {
        public Inventario()
        {
            InitializeComponent();
            traerProducto();
        }
        private async void traerProducto()
        {
            try
            {
                Producto_Manager manager = new Producto_Manager();
                var res = await manager.TraerProductos();
                if (res != null)
                {
                    lstProducto.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void btnNavegador_Clicked(object sender, EventArgs e)
        {

            Browser.OpenAsync("https://proyectomovil2.000webhostapp.com/PoryectoMysql/pdf_produto.php", BrowserLaunchMode.SystemPreferred);


        }
    }
}
