using Microsoft.AspNetCore.Hosting;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebHost webHost = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            webHost.Run();
        }
    }
}
