using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
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
    public class NovaDespesaViewModel : ViewModelBase, IModalDialogViewModel
    {
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

        private string _Fornecedor;
        public string Fornecedor
        {
            get { return _Fornecedor; }

            set
            {
                this._Fornecedor = value;
            }
        }

        private string _Descricao;
        public string Descricao
        {
            get { return _Descricao; }

            set
            {
                this._Descricao = value;
            }
        }

        private string _CentroCusto;
        public string CentroCusto
        {
            get { return _CentroCusto; }

            set
            {
                this._CentroCusto = value;
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

        private readonly IDialogService DialogService;
        public bool? DialogResult { get { return false; } }

        public NovaDespesaViewModel()
        {
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public ICommand CadastrarCommand { get { return new RelayCommand(Cadastrar, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        public void Cadastrar()
        {
            string data = Convert.ToDateTime(Data).ToString("dd/MM/yyyy HH:mm:ss");

            NovaDespesaModel nd = new NovaDespesaModel();
            nd.NumFatura = NumFatura;
            nd.Data = Convert.ToDateTime(data);
            nd.Fornecedor = Fornecedor;
            nd.Descricao = Descricao;
            nd.CentroCusto = CentroCusto;
            nd.Valor = Valor;
            nd.Mes = Convert.ToInt32(data.Substring(3, 2));
            nd.Ano = Convert.ToInt32(data.Substring(6, 4));

            if (Fornecedor != null && !Fornecedor.Equals("") && Descricao != null && !Descricao.Equals("") && CentroCusto != null && !CentroCusto.Equals("") && Valor != null && !Valor.Equals(""))
            {
                if (Regex.IsMatch(Valor.Substring(1, Valor.Length - 1), @"^\d"))
                {
                    if (nd.Add(nd))
                    {
                        var result = DialogService.ShowMessageBox(this,
                            "Nova despesa para o mês incluida com sucesso!",
                            "",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Information
                            );
                    }
                    else
                    {
                        var result = DialogService.ShowMessageBox(
                            this,
                            "Nova despesa não incluída!",
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
