﻿using System;
using System.IO;

namespace Alura.ListaLeitura.App.HTML
{
    public class HtmlUtils
    {
        public static string CarregaArquivoHtml(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}