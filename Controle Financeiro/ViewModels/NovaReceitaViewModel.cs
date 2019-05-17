using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
using Controle_Financeiro.Views;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controle_Financeiro.ViewModels
{
    class NovaReceitaViewModel : ViewModelBase, IModalDialogViewModel
    {
        private readonly IDialogService DialogService;

        private int _NumFatura;
        public int NumFatura
        {
            get { return _NumFatura; }

            set
            {
                this._NumFatura = value;
            }
        }
        private DateTime _Data;
        public DateTime Data
        {
            get
            {
                if (_Data == DateTime.MinValue)
                    return DateTime.Now;

                return _Data;
            }

            set
            {
                this._Data = value;
            }
        }

        private string _Cliente;
        public string Cliente
        {
            get { return _Cliente; }

            set
            {
                this._Cliente = value;
            }
        }

        private string _Valor;
        public string Valor
        {
            get { return _Valor; }

            set
            {
                this._Valor = value;
            }
        }

        private int _Mes;
        public int Mes
        {
            get { return _Mes; }

            set
            {
                this._Mes = value;
            }
        }

        public NovaReceitaViewModel()
        {
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public bool? DialogResult { get { return false; } }

        public ICommand CadastrarCommand { get { return new RelayCommand(Cadastrar, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        public void Cadastrar()
        {
            //DateTime data = DateTime.Parse(Data);
            string data = Convert.ToDateTime(Data).ToString("dd/MM/yyyy HH:mm:ss");
            //data = Convert.ToDateTime(data2);

            NovaReceitaModel nr = new NovaReceitaModel();
            nr.NumFatura = NumFatura;
            nr.Data = Convert.ToDateTime(data);
            nr.Cliente = Cliente;
            nr.Valor = Valor;
            nr.Mes = Convert.ToInt32(data.Substring(3, 2));
            nr.Ano = Convert.ToInt32(data.Substring(6, 4));
            if (Cliente != null && !Cliente.Equals("") && Valor != null && !Valor.Equals(""))
            {
                if (Regex.IsMatch(Valor.Substring(1, Valor.Length - 1), @"^\d"))
                {
                    if (nr.Add(nr))
                    {
                        var result = DialogService.ShowMessageBox(this, 
                            "Nova receita para o mês incluida com sucesso!", 
                            "", 
                            System.Windows.MessageBoxButton.OK, 
                            System.Windows.MessageBoxImage.Information
                            );
                    }
                    else
                    {
                        var result = DialogService.ShowMessageBox(
                            this, 
                            "Nova receita não incluída!", 
                            "", 
                            System.Windows.MessageBoxButton.OK, 
                            System.Windows.MessageBoxImage.Error
                            );
                    }
                }
                else
                {
                    var result = DialogService.ShowMessageBox(
                        this, 
                        "O campo Valor precisa ser numérico!", 
                        "", 
                        System.Windows.MessageBoxButton.OK, 
                        System.Windows.MessageBoxImage.Error
                        );
                }
            }
            else
            {
                var result = DialogService.ShowMessageBox(
                    this, 
                    "Todos os campos devem ser preenchidos!", 
                    "", 
                    System.Windows.MessageBoxButton.OK, 
                    System.Windows.MessageBoxImage.Error
                    );
            }

        }
    }
}
