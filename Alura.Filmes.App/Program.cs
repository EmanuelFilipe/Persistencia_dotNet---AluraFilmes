﻿using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AluraFilmesContexto())
            {
                context.LogSQLToConsole();
                foreach (var ator in context.Atores)
                {
                    Console.WriteLine(ator);
                }
            }

            Console.ReadKey();
        }
    }
}