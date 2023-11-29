using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using Newtonsoft.Json;
using System.Web;



namespace Mecanismo.Dao.DaoEnderecos
{
    public class CepsDao
    {
        public Ceps BuscarCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Ceps cepData = JsonConvert.DeserializeObject<Ceps>(json);
                return cepData;
            }
        }

    }
}
