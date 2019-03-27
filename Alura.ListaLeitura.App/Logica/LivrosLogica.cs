using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
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
                       

        public static Task ParaLer(HttpContext context)
        {
            return context.Response.WriteAsync(CarregaLista(new LivroRepositorioCSV().ParaLer.Livros));
        }

        public static Task Lendo(HttpContext context)
        {
            return context.Response.WriteAsync(CarregaLista(new LivroRepositorioCSV().Lendo.Livros));
        }

        public static Task Lidos(HttpContext context)
        {
            return context.Response.WriteAsync(CarregaLista(new LivroRepositorioCSV().Lidos.Livros));
        }

        public static Task Teste(HttpContext context)
        {
            return context.Response.WriteAsync("Nova funcionalidade implementada");
        }

    }
}
