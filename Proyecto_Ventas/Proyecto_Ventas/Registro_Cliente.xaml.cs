using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net;
using Xamarin.Forms.Maps;

namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro_Cliente : ContentPage
    {

        public double longitud;
        public double latitud;


        public Registro_Cliente()
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

    
        private async void Ingreso_Cliente(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtNombre.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtIngreso.Text))
            {

            }
            else
            {


    
                

                WebClient cliente = new WebClient();

              

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("latitud", latitud.ToString());
                parametros.Add("longitud", longitud.ToString());
                parametros.Add("fecha", txtIngreso.Text);

                byte[] response = cliente.UploadValues(App.url + "insertCliente.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);

                if (c.Equals("1"))
                {
                    DisplayAlert("Informacion", "Cliente Guardado Satisfactoriamente", "OK");
                    
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                  
                    txtIngreso.Text = "";
                }
                else
                {
                    DisplayAlert("Informacion", "Error al Guardar Cliente", "OK");
                }
            }

        }

        private void btncliente_Clicked(object sender, EventArgs e)
        {

            Browser.OpenAsync("https://proyectomovil2.000webhostapp.com/PoryectoMysql/pdf_cliente.php", BrowserLaunchMode.SystemPreferred);

        }

        private void btnInfo_Clicked(object sender, EventArgs e)
        {

            var fecha = DateTime.Now.ToString("f");
            var marca = DeviceInfo.Manufacturer;
            var modelo = DeviceInfo.Model;
            var nombre = DeviceInfo.Name;
            var plataforma = DeviceInfo.Platform;
            var version = DeviceInfo.VersionString;
            var idioma = DeviceInfo.Idiom;
            var dispositivo = DeviceInfo.DeviceType;



            lblInfo.Text = String.Format("Marca: {0}" +
                                       "\nModelo: {1} " +
                                       "\nNombre: {2} " +
                                       "\nSistema OP: {3} " +
                                       "\nFecha: {4}", marca, modelo, nombre, plataforma, fecha);


        }

    }
}