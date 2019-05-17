using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.ViewModels
{
    public class NovaContaViewModel : ViewModelBase
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

        private string _txtConfirmarSenha;
        public string txtConfirmarSenha
        {
            get
            {
                return _txtConfirmarSenha;
            }

            set
            {
                this._txtConfirmarSenha = value;
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

        public string CriarConta()
        {
            var login = txtLogin;
            var senha = MD5Hash.md5(txtSenha);
            var confirmarSenha = MD5Hash.md5(txtConfirmarSenha);

            if (senha.Equals(confirmarSenha))
            {
                NovaContaModel nc = new NovaContaModel();
                nc.usuario = login;
                nc.senha = senha;
                if (!nc.GetExistsUser(nc))
                {
                    if (nc.Add(nc))
                    { return "Usuário cadastrado com sucesso!"; }
                    else { return "Erro ao cadastrar usuário!"; }
                }
                else
                {
                    return "O nome de usuário escolhido já existe. Tente novamente com outro nome de usuário!";
                }
            }
            else
            { return "As senhas digitadas não conferem!"; }
        }
    }
}
