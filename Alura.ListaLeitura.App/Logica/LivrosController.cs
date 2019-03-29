using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> Livros { get; set; }

        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoHtml = HtmlUtils.CarregaArquivoHtml("Lista");
            return conteudoHtml.Replace("#NOVO-ITEM#", "");
        }

        public IActionResult ParaLer()
        {
            ViewBag.Livros = new LivroRepositorioCSV().ParaLer.Livros;
            return View("Lista");

        }

        public IActionResult Lendo()
        {
            ViewBag.Livros = new LivroRepositorioCSV().Lendo.Livros;
            return View("Lista");
        }

        public IActionResult Lidos()
        {
            ViewBag.Livros = new LivroRepositorioCSV().Lidos.Livros;
            return View("Lista");
        }

        public string Teste() => "Nova funcionalidade implementada";


        public string Detalhes(int id)
        {
            return new LivroRepositorioCSV().Todos.First(l => l.Id == id).Detalhes();
        }
                     

        /// <summary>
        /// Exemplo de criação de metodo utilizando requestDelegate 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public static Task Teste(HttpContext context)
        //{
        //    return context.Response.WriteAsync("Nova funcionalidade implementada");
        //}

    }
}
