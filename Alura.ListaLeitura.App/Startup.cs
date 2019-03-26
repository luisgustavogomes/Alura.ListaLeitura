using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
                
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosLogica.LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            var rotas = builder.Build();
            app.UseRouter(rotas);
        }

        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
        }

        //------------------------------------------------------------------//

        /// <summary>
        /// Na mão grande!!!
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public Task Roteamento(HttpContext context)
        //{
        //builder.MapRoute("Cadastro/Detalhes/{id}", ExibeDetalhes);
        //builder.MapRoute("Cadastro/NovoLivro/{Nome}/{Autor}", NovoLivroParaLer);
        //app.Run(builder.);//Quando criado na mão!!!

        //    var caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        { "/Livros/ParaLer", LivrosParaLer},
        //        { "/Livros/Lendo", LivrosLendo},
        //        { "/Livros/Lidos", LivrosLidos},
        //    };

        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        var metodo = caminhosAtendidos[context.Request.Path];
        //        return metodo.Invoke(context);
        //    }

        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho inexistente!!!");

        //}

        //public Task NovoLivroParaLer(HttpContext context)
        //{
        //    var livro = new Livro()
        //    {
        //        Titulo = context.GetRouteValue("Nome").ToString(),
        //        Autor = context.GetRouteValue("Autor").ToString()
        //    };
        //    var _repo = new LivroRepositorioCSV();
        //    _repo.Incluir(livro);
        //    return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        //}

        //public Task ExibeDetalhes(HttpContext context)
        //{
        //    var id = Convert.ToInt32(context.GetRouteValue("id"));
        //    var _repo = new LivroRepositorioCSV();
        //    var livro = _repo.Todos.First(l => l.Id == id);
        //    return context.Response.WriteAsync(livro.Detalhes());
        //}
    }
}