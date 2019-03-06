using Controle_Financeiro.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DespesasView.xaml
    /// </summary>
    public partial class DespesasView : Window
    {
        int Mes = 0;
        string Ano = "";
        NovaDespesaModel ndmodel = new NovaDespesaModel();

        public DespesasView()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mes = cmbMes.SelectedIndex;
            dataGridDespesas.ItemsSource = ndmodel.GetMonth(Mes, Ano);
        }

        private void cmbAno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbAno.SelectedIndex)
            {
                case 0:
                    Ano = "2019";
                    break;
                case 1:
                    Ano = "2020";
                    break;
                case 2:
                    Ano = "2021";
                    break;
                case 3:
                    Ano = "2022";
                    break;
                case 4:
                    Ano = "2023";
                    break;
                default:
                    break;
            }
            dataGridDespesas.ItemsSource = ndmodel.GetMonth(Mes, Ano);
        }
    }
}
