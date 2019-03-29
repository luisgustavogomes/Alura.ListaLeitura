using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController : Controller
    {

        public string Incluir(Livro livro)
        {
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return "O Livro foi adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            //return new ViewResult { ViewName = "formulario" };
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }


        //public static Task ExibeFormulario(HttpContext context)
        //{
        //    return context.Response.WriteAsync(HtmlUtils.CarregaArquivoHtml("Formulario"));
        //}

        //public static Task IncluirExemploSemCoreMvc(HttpContext context)
        //{
        //    var livro = new Livro()
        //    {
        //        Titulo = context.Request.Form["tnome"].First(),
        //        Autor = context.Request.Form["tautor"].First()
        //    };
        //    var _repo = new LivroRepositorioCSV();
        //    _repo.Incluir(livro);
        //    return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        //}

    }
}
