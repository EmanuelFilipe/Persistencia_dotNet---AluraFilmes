using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
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

                var ator = new Ator();
                ator.PrimeiroNome = "Tom";
                ator.UltimoNome = "Hanks";
                context.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

                context.Atores.Add(ator);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}