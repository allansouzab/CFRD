using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
using Controle_Financeiro.Views;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controle_Financeiro.ViewModels
{
    public class ReceitaViewModel : ViewModelBase, IModalDialogViewModel
    {
        private NovaReceitaModel _dgSelectedItem;
        public NovaReceitaModel dgSelectedItem
        {
            get
            {
                return _dgSelectedItem;
            }

            set
            {
                this._dgSelectedItem = value;
            }
        }

        private int _cmbMesIndex;
        public int cmbMesIndex
        {
            get
            {
                if (_cmbMesIndex == 0)
                    return DateTime.Now.Month;
                return _cmbMesIndex;
            }

            set
            {
                this._cmbMesIndex = value;
            }
        }

        private int _cmbAnoIndex;
        public int cmbAnoIndex
        {
            get
            {
                return _cmbAnoIndex;
            }

            set
            {
                this._cmbAnoIndex = value;
            }
        }

        //private string _cmbAnoItem;
        //public string cmbAnoItem
        //{
        //    get
        //    {
        //        if (_cmbAnoItem == null)
        //            return "2019";
        //        return _cmbAnoItem;
        //    }

        //    set
        //    {
        //        this._cmbAnoItem = value;
        //    }
        //}

        private readonly IDialogService DialogService;

        public ReceitaViewModel()
        {
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public bool? DialogResult { get { return false; } }

        public ICommand NovaReceitaCommand { get { return new RelayCommand(NovaReceita, AlwaysTrue); } }
        public ICommand DeletarReceitaCommand { get { return new RelayCommand(DeletarReceita, AlwaysTrue); } }
        public ICommand RelatorioReceitaCommand { get { return new RelayCommand(RelatorioReceita, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        public void NovaReceita()
        {
            NovaReceitaViewModel dialog = new NovaReceitaViewModel();
            var result = DialogService.ShowDialog<NovaReceitaView>(this, dialog);
        }

        public void DeletarReceita()
        {
            var result = DialogService.ShowMessageBox(
                    this,
                    "Tem certeza que deseja excluir a linha selecionada?",
                    "",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question
                    );

            if (result == System.Windows.MessageBoxResult.Yes)
            {
                if (dgSelectedItem != null)
                {
                    NovaReceitaModel nr = new NovaReceitaModel();
                    if (nr.Delete(dgSelectedItem))
                    {
                        DialogService.ShowMessageBox(
                        this,
                        "Linha selecionada excluida com sucesso!",
                        "",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information
                        );
                    }
                    else
                    {
                        DialogService.ShowMessageBox(
                        this,
                        "Falha ao excluir a linha selecionada!",
                        "",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Error
                        );
                    }
                }
                else
                {
                    DialogService.ShowMessageBox(
                        this,
                        "Selecione uma linha para excluir!",
                        "",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Error
                        );
                }
            }
        }

        public void RelatorioReceita()
        {
            RelatorioViewModel relatorio = new RelatorioViewModel();

            var mesExtenso = DateTimeFormatInfo.CurrentInfo.GetMonthName(cmbMesIndex);
            mesExtenso = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);

            string Ano = "";
            switch (cmbAnoIndex)
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

            var result = DialogService.ShowMessageBox(
                    this,
                    "Tem certeza que deseja gerar o relatório para o mês e ano selecionados?",
                    "",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question
                    );

            if (result == System.Windows.MessageBoxResult.Yes)
            {
                if (relatorio.GerarRelatorio(cmbMesIndex, mesExtenso, Ano, "Receitas", 4))
                {
                    DialogService.ShowMessageBox(
                        this,
                        "Relatório mensal gerado com sucesso!",
                        "",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Information
                        );
                }
                else
                {
                    DialogService.ShowMessageBox(
                        this,
                        "Falha ao gerar relatório!",
                        "",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Error
                        );
                }
            }

        }

    }
}
