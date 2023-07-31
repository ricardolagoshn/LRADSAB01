using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace LRADSAB01.Controllers
{
    public static class AlumnosController
    {
        public async static Task<Models.Msg> CreateAlumn(Models.Alumnos alumn)
        {
            Models.Msg msg = new Models.Msg();
            String jsonObject = JsonConvert.SerializeObject(alumn);

            StringContent contenido = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = null;

                response = await client.PostAsync("http://192.168.0.10/labrad/AlumnCreate.php", contenido);

                if (response.IsSuccessStatusCode) 
                {
                    var resultado = await response.Content.ReadAsStringAsync();
                    msg = JsonConvert.DeserializeObject<Models.Msg>(resultado);
                }   
            }

            return msg;
        }
    }
}
