using Controle_Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NovaReceitaView.xaml
    /// </summary>
    public partial class NovaReceitaView : Window
    {
        public NovaReceitaView()
        {
            InitializeComponent();
        }

        Double valor;

        private void txtValor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtValor.Text.Equals("") && Regex.IsMatch(txtValor.Text, @"^\d"))
            {
                valor = Double.Parse(txtValor.Text);
                txtValor.Text = valor.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            }
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            //ReceitasView rv = new ReceitasView();
            //NovaReceitaModel nrmodel = new NovaReceitaModel();

            //string data = datePicker.SelectedDate.ToString();
            //string Mes = data.Substring(3, 2);
            //string Ano = data.Substring(6, 4);

            //int Mes = rv.cmbMes.SelectedIndex;
            //string Ano = "";
            //switch (rv.cmbAno.SelectedIndex)
            //{
            //    case 0:
            //        Ano = "2019";
            //        break;
            //    case 1:
            //        Ano = "2020";
            //        break;
            //    case 2:
            //        Ano = "2021";
            //        break;
            //    case 3:
            //        Ano = "2022";
            //        break;
            //    case 4:
            //        Ano = "2023";
            //        break;
            //    default:
            //        break;
            //}

            //rv.dataGridReceitas.ItemsSource = nrmodel.GetMonth(Convert.ToInt32(Mes), Ano);
            this.Close();
        }
    }
}
