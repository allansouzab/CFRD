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
using ViewModels;
using Views;

namespace CFRD
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            //IController controller = new Controller();
            //LoginViewModel vm = new LoginViewModel(controller);
            //DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text.ToString();
            var senha = txtSenha.Password.ToString();

            if(email == "admin" && senha == "admin")
            {
                MainWindow mw = new MainWindow();
                mw.Show();

                this.Close();
            }
        }
    }
}
