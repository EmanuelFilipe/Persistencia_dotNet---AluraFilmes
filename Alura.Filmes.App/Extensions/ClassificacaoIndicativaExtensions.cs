using Alura.Filmes.App.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {
        public static string ParaString(this ClassificacaoIndicativa valor)
        {
            Dictionary<string, ClassificacaoIndicativa> map = ListaClassificacoesIndicativas();

            return map.First(x => x.Value == valor).Key;
        }

        public static ClassificacaoIndicativa ParaValor(this string texto)
        {
            Dictionary<string, ClassificacaoIndicativa> map = ListaClassificacoesIndicativas();

            return map.First(x => x.Key == texto).Value;
        }

        private static Dictionary<string, ClassificacaoIndicativa> ListaClassificacoesIndicativas()
        {
            return new Dictionary<string, ClassificacaoIndicativa>
            {
                { "G", ClassificacaoIndicativa.Livre },
                { "PG", ClassificacaoIndicativa.MaioresQue10 },
                { "PG-13", ClassificacaoIndicativa.MaioresQue13 },
                { "R", ClassificacaoIndicativa.MaioresQue14 },
                { "NC-17", ClassificacaoIndicativa.MaioresQue18 },
            };
        }
    }
}
