using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
using Controle_Financeiro.Views;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controle_Financeiro.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string _txtSenha;
        public string txtSenha
        {
            get
            {
                return _txtSenha;
            }

            set
            {
                this._txtSenha = value;
            }
        }

        private string _txtLogin;
        public string txtLogin
        {
            get
            {
                return _txtLogin;
            }

            set
            {
                this._txtLogin = value;
            }
        }

        private readonly IDialogService DialogService;

        public LoginViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public string Login()
        {
            var login = txtLogin;
            var senha = MD5Hash.md5(txtSenha);

            LoginModel lg = new LoginModel();
            lg.usuario = login;
            lg.senha = senha;
            if (lg.GetUser(lg))
            {
                Session.Usuario = login;
                return "Usuario existe";
            }
            else { return "Usuário não encontrado!"; }
        }
    }
}
