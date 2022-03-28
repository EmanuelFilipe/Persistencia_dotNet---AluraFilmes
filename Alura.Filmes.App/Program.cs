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
                contexto.LogSQLToConsole();

                var filme = new Filme
                {
                    Titulo = "Senhor dos Aneis",
                    Duracao = 120,
                    AnoLancamento = "200",
                    Classificacao = "Anything",
                    IdiomaFalado = contexto.Idiomas.First()
                };

                contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                Console.ReadKey();

            }
        }
    }
}
