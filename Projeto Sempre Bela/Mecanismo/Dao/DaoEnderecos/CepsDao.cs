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

            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";

                using (WebClient client = new WebClient())
                {
                    // Especifica a codificação UTF-8
                    client.Encoding = System.Text.Encoding.UTF8;

                    // Faz a solicitação à API ViaCEP
                    string json = client.DownloadString(url);

                    // Verifica se o retorno da API indica um erro
                    if (!json.Contains("erro"))
                    {
                        // Deserializa o JSON para um objeto Ceps
                        Ceps cepData = JsonConvert.DeserializeObject<Ceps>(json);
                        return cepData;
                    }
                    else
                    {
                        // Trata o caso em que o CEP não foi encontrado
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trata exceções, por exemplo, falha na comunicação com a API
                Console.WriteLine($"Erro ao buscar CEP: {ex.Message}");
                return null;
            }


            //    string url = $"https://viacep.com.br/ws/{cep}/json/";

            //    using (WebClient client = new WebClient())
            //    {
            //        string json = client.DownloadString(url);
            //        Ceps cepData = JsonConvert.DeserializeObject<Ceps>(json);
            //        return cepData;
            //    }
        }


}
}
