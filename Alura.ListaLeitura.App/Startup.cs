using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        
        
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro/{Nome}/{Autor}", NovoLivroParaLer);
            builder.MapRoute("Cadastro/Detalhes/{id}", ExibeDetalhes);
            builder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = builder.Build();
            app.UseRouter(rotas);
            //app.Run(builder.);//Quando criado na mão!!!
        }

        public Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("tnome").ToString(),
                Autor = context.GetRouteValue("tautor").ToString()
            };
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        }

        public Task ExibeFormulario(HttpContext context)
        {
            var html =
                @"
                 <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8'  />
                    <meta http-equiv = 'X-UA-Compatible' content = 'IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale = 1'>
                </head>
                <body>
                    <form action='/Cadastro/Incluir' method='post'>
                        <p><label for='cnome'>Nome:</label><input type='text' name='tnome' id='cnome' size='20' maxlength='80' placeholder='Nome'/></p>
                        <p><label for='cautor'>Autor:</label><input type='text' name='tautor' id='cautor' size='20' maxlength='80' placeholder='Autor'/></p>
                    <input type='submit' value='Gravar'/>
                </form>
                </body>
                </html>";
            return context.Response.WriteAsync(html);
        }

        public Task ExibeDetalhes(HttpContext context)
        {
            var id = Convert.ToInt32(context.GetRouteValue("id"));
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
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
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
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