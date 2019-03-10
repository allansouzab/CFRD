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
    /// Interaction logic for NovaContaView.xaml
    /// </summary>
    public partial class NovaContaView : Window
    {
        public NovaContaView()
        {
            InitializeComponent();
        }

        private void txtSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).txtSenha = ((PasswordBox)sender).Password; }
        }

        private void txtConfirmarSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).txtConfirmarSenha = ((PasswordBox)sender).Password; }
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                var msg = ((dynamic)this.DataContext).CriarConta();

                if (msg.Equals("Usuário cadastrado com sucesso!"))
                {
                    MessageBox.Show(msg, "", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoginView login = new LoginView();
                    login.Show();
                    this.Close();
                }
                else if (msg.Equals("Erro ao cadastrar usuário!"))
                { MessageBox.Show(msg, "", MessageBoxButton.OK, MessageBoxImage.Error); }
                else if (msg.Equals("As senhas digitadas não conferem!"))
                { MessageBox.Show(msg, "", MessageBoxButton.OK, MessageBoxImage.Error); }
                else if (msg.Equals("O nome de usuário escolhido já existe. Tente novamente com outro nome de usuário!"))
                { MessageBox.Show(msg, "", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
