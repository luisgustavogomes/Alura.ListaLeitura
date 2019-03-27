using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
            service.AddMvc();
        }
                
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }


        // rota utilizando classe RoteamentoPadrao
        //var builder = new RouteBuilder(app);
        //builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);
        //app.UseRouter(builder.Build());

        // ROTA INDICANDO PATH
        //builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
        //builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
        //builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
        //builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
        //builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);

        //------------------------------------------------------------------//

        /// <summary>
        /// Na mão grande!!! ROTA COM TEMPLATES 
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