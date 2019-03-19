using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public LivroRepositorioCSV _repo { get; private set; }

        public Startup()
        {
            _repo = new LivroRepositorioCSV();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro/{Nome}/{Autor}", NovoLivroParaLer);
            var rotas = builder.Build();
            app.UseRouter(rotas);
            //app.Run(builder.);//Quando criado na mão!!!
        }

        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("Nome").ToString(),
                Autor = context.GetRouteValue("Autor").ToString()
            };
            _repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

        /// <summary>
        /// Na mão grande!!!
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Roteamento(HttpContext context)
        {
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                { "/Livros/ParaLer", LivrosParaLer},
                { "/Livros/Lendo", LivrosLendo},
                { "/Livros/Lidos", LivrosLidos},
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente!!!");

        }


    }
}