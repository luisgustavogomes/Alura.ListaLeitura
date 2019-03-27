using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                       
        public string ParaLer() => CarregaLista(new LivroRepositorioCSV().ParaLer.Livros);

        public string Lendo() => CarregaLista(new LivroRepositorioCSV().Lendo.Livros);

        public string Lidos() => CarregaLista(new LivroRepositorioCSV().Lidos.Livros);

        /// <summary>
        ///  Exemplo de metodo utilizando AspNetCoreMvc (Não necessita de retorno Task, nem o HttpContext como parametro)
        /// </summary>
        /// <returns></returns>
        public string Teste() => "Nova funcionalidade implementada";


        public string Detalhes(int id)
        {
            return new LivroRepositorioCSV().Todos.First(l => l.Id == id).Detalhes();
        }




        //--------------------------------------------------------------------------//


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
