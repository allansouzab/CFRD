using Controle_Financeiro.Models;
using Controle_Financeiro.Utils;
using Controle_Financeiro.Views;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controle_Financeiro.ViewModels
{
    public class DespesaViewModel : ViewModelBase, IModalDialogViewModel
    {
        private NovaDespesaModel _dgSelectedItem;
        public NovaDespesaModel dgSelectedItem
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

        private readonly IDialogService DialogService;
        public bool? DialogResult { get { return false; } }

        public DespesaViewModel()
        {
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public ICommand NovaDespesaCommand { get { return new RelayCommand(NovaDespesa, AlwaysTrue); } }
        public ICommand DeletarDespesaCommand { get { return new RelayCommand(DeletarDespesa, AlwaysTrue); } }
        public ICommand RelatorioDespesaCommand { get { return new RelayCommand(RelatorioDespesa, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        public void NovaDespesa()
        {
            NovaDespesaViewModel dialog = new NovaDespesaViewModel();
            var result = DialogService.ShowDialog<NovaDespesaView>(this, dialog);
        }

        public void DeletarDespesa()
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
                    NovaDespesaModel nd = new NovaDespesaModel();
                    if (nd.Delete(dgSelectedItem))
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

        public void RelatorioDespesa()
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
                if (relatorio.GerarRelatorio(cmbMesIndex, mesExtenso, Ano, "Despesas", 6))
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
