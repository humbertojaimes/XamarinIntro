using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinIntro
{
    public class ApiClients
    {
        static HttpClient client = new HttpClient();
        const string url = "http://tallerxamarin.azurewebsites.net/api/Client";


        public static async Task<List<Client>> GetClients()
        {
            List<Client> clients = null;

            using (var response = await client.GetAsync(url))
            {
                var content = await response.Content.ReadAsStringAsync();
                clients = JsonConvert.DeserializeObject<List<Client>>(content);
            }


            return clients;
        }
    }
}
