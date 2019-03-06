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
    /// Interaction logic for ReceitasView.xaml
    /// </summary>
    public partial class ReceitasView : Window
    {
        int Mes = 0;
        string Ano = "";
        NovaReceitaModel nrmodel = new NovaReceitaModel();

        public ReceitasView()
        {
            InitializeComponent();
            //cmbAno.SelectedIndex = 0;
            //cmbMes.SelectedIndex = (DateTime.Now.Month);
            //Mes = cmbMes.SelectedIndex;
            //Ano = cmbAno.SelectedItem.ToString();
            //dataGridReceitas.ItemsSource = nrmodel.GetMonth(Mes, Ano);
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mes = cmbMes.SelectedIndex;
            dataGridReceitas.ItemsSource = nrmodel.GetMonth(Mes, Ano);
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
            dataGridReceitas.ItemsSource = nrmodel.GetMonth(Mes, Ano);
        }
    }
}
