using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AluraFilmesContexto())
            {
                context.LogSQLToConsole();

                var filme = context.Filmes
                    .Include(f => f.Atores)
                    .ThenInclude(fa => fa.Ator)
                    .First();

                Console.WriteLine(filme);
                Console.WriteLine("Elenco: ");
                foreach (var item in filme.Atores)
                {
                    Console.WriteLine(item.Ator);
                    //var entidade = context.Entry(item);
                    //var filmId = entidade.Property("film_id").CurrentValue;
                    //var actorId = entidade.Property("actor_id").CurrentValue;
                    //var lastUpdate = entidade.Property("last_update").CurrentValue;
                    //Console.WriteLine($"Filme: {filmId}, Ator: {actorId}, LastUpdate: {lastUpdate}");
                }
            }

            Console.ReadKey();
        }
    }
}