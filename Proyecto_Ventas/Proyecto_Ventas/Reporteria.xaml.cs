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
    public partial class Reporteria : ContentPage
    {
        public Reporteria()
        {
            InitializeComponent();
            traerReporte();
        }

        private async void traerReporte()
        {
            try
            {
                Reporteria_Manager manager = new Reporteria_Manager();
                var res = await manager.TraerReporteria();
                if (res != null)
                {
                    lstReporteria.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }

        private void btncompras_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://proyectomovil2.000webhostapp.com/PoryectoMysql/pdf_compras.php", BrowserLaunchMode.SystemPreferred);

        }

    }
}