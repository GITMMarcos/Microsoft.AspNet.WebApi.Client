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
                // Adicionado o pacote Microsoft.AspNet.WebApi.Client
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44311/");

                // Realiza a requisição Get para a Rota Get da API remota.
                var response = await client.GetAsync("/api/tarefa");
                var getAllTarefas = await response.Content.ReadAsAsync<IEnumerable<Tarefa>>();

                // Realiza a requisição Post para a Rota Get da API remota.
                await client.PostAsJsonAsync("/api/tarefa/", new Tarefa() {
                    Id = 99,
                    Nome = "Criada via requisição app Console",
                    isFinalizado = true
                });

                // Realiza a requisição Put para a Rota Get da API remota.
                await client.PutAsJsonAsync("/api/tarefa/99", new Tarefa()
                {
                    Id = 99,
                    Nome = "Criada via requisição app Console - com alteração no nome",
                    isFinalizado = true
                });

                var retorno = await client.DeleteAsync("/api/tarefa/99");
                var status = await retorno.Content.ReadAsHttpResponseMessageAsync();
            })
            .GetAwaiter()
            .GetResult();
        }
    }
}
