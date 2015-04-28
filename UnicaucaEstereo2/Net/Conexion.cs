/*
 *Desarrollado por:
 * Hamilton Andrés Urbano Benavides
 * h.a.u.r1993@gmail.com
 * Diana Marcela Samboní
 * dianasamboni22@gmail.com
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Web.Http;

namespace UnicaucaEstereo2.Net
{
    public class Conexion<T>
    {
        List<T> data;
        public interface Iconexion
        {
            void loadDocuments(List<T> documents);
        }

        HttpClient client;
        const String url = "http://www.unicauca.edu.co/emisora/ConexionDBEmisora/index.php";
        

        public Conexion()
        {  
            client = new HttpClient();
        }

        public async void findAllDocuments(Iconexion iconexion)
        {
            HttpResponseMessage msg = await client.GetAsync(new Uri(url));
            String jsonArray = msg.Content.ToString();

            data = JsonConvert.DeserializeObject<List<T>>(jsonArray);
            iconexion.loadDocuments(data);
        }
    }
}
