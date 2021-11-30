using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ventas.Classes
{
    class Usuario_Manager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<IEnumerable<Usuario>> TraerUsuarios()
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.url + "verUsuarios.php");
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Usuario>>(content);
            }
            return Enumerable.Empty<Usuario>();
        }
    }
}
