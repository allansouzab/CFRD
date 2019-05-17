using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.Report
{
    public class DadosRelatorioReceitas
    {
        public int NumFatura { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public string Valor { get; set; }
        public string MesExtenso { get; set; }
        public string Ano { get; set; }
    }
}
