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
                    Titulo = "Matrix",
                    Duracao = 120,
                    AnoLancamento = "1999",
                    Classificacao = ClassificacaoIndicativa.MaioresQue14,
                    IdiomaFalado = contexto.Idiomas.First()
                };

                contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                var filmInserted = contexto.Filmes.First(f => f.Titulo == "Matrix");
                Console.WriteLine(filmInserted.Classificacao);

                Console.ReadKey();

            }
        }
    }
}
