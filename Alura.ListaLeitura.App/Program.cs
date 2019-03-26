using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();
            IWebHost webHost = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            webHost.Run();
        }
    }
}
