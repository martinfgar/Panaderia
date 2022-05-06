
using System.Net;
using System.Text.Json;
namespace Repo {
    public class Luz
    {
        public float price { get; set; }

    }
    public static class PrecioLuz
    {

        public static float obtenerPrecioLuz()
        {
            try
            {
                var json = new WebClient().DownloadString("https://api.preciodelaluz.org/v1/prices/min?zone=PCB");
                var data = JsonSerializer.Deserialize<Luz>(json);
                return data.price;
            }
            catch
            {
                return 230;
            }

        }
    }
}

