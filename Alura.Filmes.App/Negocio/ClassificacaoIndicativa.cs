using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    public enum ClassificacaoIndicativa
    {
        [Description("G")]
        Livre,          // G

        [Description("PG")]
        MaioresQue10,   // PG
        MaioresQue13,   // PG-13
        MaioresQue14,   // R
        MaioresQue18    // NC-17
    }
}
