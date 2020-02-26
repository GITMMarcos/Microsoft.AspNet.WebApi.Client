using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIClient.Models;

namespace WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44311/");

                var response = await client.GetAsync("/api/tarefa");
                var getAllTarefas = await response.Content.ReadAsAsync<IEnumerable<Tarefa>>();

            })
            .GetAwaiter()
            .GetResult();
        }
    }
}
