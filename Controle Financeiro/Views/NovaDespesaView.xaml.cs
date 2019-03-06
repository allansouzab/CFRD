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
    /// Interaction logic for NovaDespesaView.xaml
    /// </summary>
    public partial class NovaDespesaView : Window
    {
        public NovaDespesaView()
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
            this.Close();
        }
    }
}
