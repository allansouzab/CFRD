using Controle_Financeiro.Utils;
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
    public class RelatorioGeralViewModel : ViewModelBase, IModalDialogViewModel
    {
        private readonly IDialogService DialogService;
        public bool? DialogResult { get { return false; } }

        public RelatorioGeralViewModel()
        {
            this.DialogService = new MvvmDialogs.DialogService();
        }

        public ICommand EnviarMesAnoCommand { get { return new RelayCommand(EnviarMesAno, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

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

        public void EnviarMesAno()
        {
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

            RelatorioViewModel relatorio = new RelatorioViewModel();
            if(relatorio.GerarRelatorioGeral(cmbMesIndex, mesExtenso, Ano, "Relatório Geral"))
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
