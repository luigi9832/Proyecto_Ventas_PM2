using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Ventas
{
    public partial class App : Application
    {
        public static string url;
        public App()
        {
            InitializeComponent();
            url = "https://proyectomovil2.000webhostapp.com/PoryectoMysql/";

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
