using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro_Usuario : ContentPage
    {
        public Registro_Usuario()
        {
            InitializeComponent();
        }
        private void ingresoUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtContra.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtRegistro.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtTipo.Text))
            {

            }
            else
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("pass", txtContra.Text);
                parametros.Add("fecha", txtRegistro.Text);
               
                parametros.Add("tipo",txtTipo.Text);
            

                byte[] response = cliente.UploadValues(App.url + "insertUser.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);

                if (c.Equals("1"))
                {
                    DisplayAlert("Informacion", "Usuario Guardado Satisfactoriamente", "OK");
                    txtNombre.Text = "";
                    txtContra.Text = "";
                    txtRegistro.Text = "";
                 
                    txtTipo.Text = "";
                 
                }
                else
                {
                    DisplayAlert("Informacion", "Error al Guardar Usuario", "OK");
                }
            }

        }
    }
}