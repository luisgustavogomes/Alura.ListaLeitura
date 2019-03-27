using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {

        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["tnome"].First(),
                Autor = context.Request.Form["tautor"].First()
            };
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("O Livro foi adicionado com sucesso");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            return context.Response.WriteAsync(HtmlUtils.CarregaArquivoHtml("Formulario"));
        }
    }
}
