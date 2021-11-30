using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Ventas.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Control_Usuario : ContentPage
    {
        public Control_Usuario()
        {
            InitializeComponent();
            traerUsuario();
        }
        private async void traerUsuario()
        {
            try
            {
                Usuario_Manager manager = new Usuario_Manager();
                var res = await manager.TraerUsuarios();
                if (res != null)
                {
                    lstUsuario.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }
    }
}