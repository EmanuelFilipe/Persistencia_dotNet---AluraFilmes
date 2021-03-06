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
            using (var contexto = new AluraFilmesContexto())
            {
                //contexto.LogSQLToConsole();
                //var atoresMaisAtuantes = contexto.Atores
                //    .Include(a => a.Filmografia)
                //    .OrderByDescending(a => a.Filmografia.Count)
                //    .Take(5);

                var sql = @"select a.* from actor a
                            inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id";

                var atoresMaisAtuantes = contexto.Atores
                                                 .FromSql(sql)
                                                 .Include(a => a.Filmografia);

                foreach (var ator in atoresMaisAtuantes)
                {
                    System.Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                }

                Console.ReadKey();
            }
        }
    }
}
