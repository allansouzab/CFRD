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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).txtSenha = ((PasswordBox)sender).Password; }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                var msg = ((dynamic)this.DataContext).Login();
                if (msg.Equals("Usuario existe"))
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();

                    this.Close();
                }
                else if(msg.Equals("Usuário não encontrado!"))
                { MessageBox.Show(msg, "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }

        }

        private void btnCriarConta_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NovaContaView nc = new NovaContaView();
            nc.Show();
            this.Close();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var email = txtEmail.Text.ToString();
        //    var senha = txtSenha.Password.ToString();

        //    if (email == "admin" && senha == "admin")
        //    {
        //        MainWindow mw = new MainWindow();
        //        mw.Show();

        //        this.Close();
        //    }
        //}
    }
}
