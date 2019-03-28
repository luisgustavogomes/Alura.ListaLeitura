using Alura.ListaLeitura.App.Views;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {

        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoHtml = HtmlUtils.CarregaArquivoHtml("Lista");
            foreach (var livro in livros)
            {
                conteudoHtml = conteudoHtml.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            return conteudoHtml.Replace("#NOVO-ITEM#", "");
        }

        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV().ParaLer.Livros;
            var html = new ViewResult { ViewName = "lista" };
            return html;

        }


        public string Lendo() => CarregaLista(new LivroRepositorioCSV().Lendo.Livros);

        public string Lidos() => CarregaLista(new LivroRepositorioCSV().Lidos.Livros);

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
