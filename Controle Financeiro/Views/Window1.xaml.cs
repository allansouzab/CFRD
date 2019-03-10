using Controle_Financeiro.Models;
using Controle_Financeiro.Report;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Controle_Financeiro.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            NovaReceitaModel nrmodel = new NovaReceitaModel();
            var dados = nrmodel.GetMonth(3, "2019");
            var relatorioList = new List<DadosRelatorioReceitas>();

            foreach(var d in dados)
            {
                var sValor = d.Valor.Substring(1, d.Valor.Length - 1);
                var sMesExtenso = "Março";
                var sAno = "2019";
                relatorioList.Add(new DadosRelatorioReceitas() { NumFatura = d.NumFatura, Data = d.Data, Cliente = d.Cliente, Valor = sValor, MesExtenso = sMesExtenso, Ano = sAno });
            }

            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", relatorioList);
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "Controle_Financeiro.RelatorioReceitas.rdlc";

            ReportViewer.RefreshReport();
        }
    }
}
