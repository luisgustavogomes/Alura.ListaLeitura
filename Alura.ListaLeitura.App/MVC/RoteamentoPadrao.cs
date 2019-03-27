﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetedo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";
            var tipo = Type.GetType(nomeCompleto);

            var metodo = tipo.GetMethods().Where(m => m.Name.ToLower() == nomeMetedo.ToLower()).First();
            var requestDelegate = (RequestDelegate) Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}