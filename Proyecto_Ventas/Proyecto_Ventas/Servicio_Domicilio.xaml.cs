using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Servicio_Domicilio : ContentPage
    {
        double latitud;
        double longitud;
        public Servicio_Domicilio()
        {
            InitializeComponent();
            llenado();
        }

        public async void llenado()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var prueba = args.Position;


                        latitud = prueba.Latitude;
                        longitud = prueba.Longitude;
                    };
                }
            }
        }

        private void btnservicio_Clicked(object sender, EventArgs e)
        {

            Browser.OpenAsync("https://proyectomovil2.000webhostapp.com/PoryectoMysql/pdf_adomicilio.php", BrowserLaunchMode.SystemPreferred);

        }

        private async void mostrarMapa(object sender, EventArgs e)
        {
            MapLaunchOptions option = new MapLaunchOptions { Name = "Casa Cliente" };
            await Xamarin.Essentials.Map.OpenAsync(latitud, longitud, option);
        }
    }
}