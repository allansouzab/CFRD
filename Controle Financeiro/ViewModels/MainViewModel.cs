﻿using MvvmDialogs;
using log4net;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Input;
using System.Xml.Linq;
using Controle_Financeiro.Views;
using Controle_Financeiro.Utils;

namespace Controle_Financeiro.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Parameters
        private readonly IDialogService DialogService;
        #endregion

        #region Constructors
        public MainViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
        }

        #endregion

        #region Methods

        #endregion

        #region Commands
        public RelayCommand<object> SampleCmdWithArgument { get { return new RelayCommand<object>(OnSampleCmdWithArgument); } }

        public ICommand SaveAsCmd { get { return new RelayCommand(OnSaveAsTest, AlwaysFalse); } }
        public ICommand SaveCmd { get { return new RelayCommand(OnSaveTest, AlwaysFalse); } }
        public ICommand NewCmd { get { return new RelayCommand(OnNewTest, AlwaysFalse); } }
        public ICommand OpenCmd { get { return new RelayCommand(OnOpenTest, AlwaysFalse); } }
        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, AlwaysTrue); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, AlwaysTrue); } }

        public ICommand ReceitasCommand { get { return new RelayCommand(Receitas, AlwaysTrue); } }
        public ICommand DespesasCommand { get { return new RelayCommand(Despesas, AlwaysTrue); } }
        public ICommand RelatorioCommand { get { return new RelayCommand(Relatorios, AlwaysTrue); } }
        public ICommand CloseCommand { get { return new RelayCommand(Fechar, AlwaysTrue); } }
        public ICommand CadUserCommand { get { return new RelayCommand(CadUser, AlwaysTrue); } }
        
        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        private void Receitas()
        {
            ReceitaViewModel dialog = new ReceitaViewModel();
            var result = DialogService.ShowDialog<ReceitasView>(this, dialog);
        }

        private void Despesas()
        {
            DespesaViewModel dialog = new DespesaViewModel();
            var result = DialogService.ShowDialog<DespesasView>(this, dialog);
        }

        private void Relatorios()
        {
            //RelatorioViewModel relatorio = new RelatorioViewModel();
            //relatorio.GerarRelatorioGeral(3, "Março", "2019", "Relatório Geral");

            RelatorioGeralViewModel dialog = new RelatorioGeralViewModel();
            var result = DialogService.ShowDialog<RelatorioGeralView>(this, dialog);
        }

        private void Fechar()
        {
            //System.Windows.Application.Current.MainWindow.Close();
        }

        private void CadUser()
        {

        }

        private void OnSampleCmdWithArgument(object obj)
        {
            // TODO
        }

        private void OnSaveAsTest()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "Save As",
                Filter = "Sample (.xml)|*.xml",
                CheckFileExists = false,
                OverwritePrompt = true
            };

            bool? success = DialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                // Do something
                Log.Info("Saving file: " + settings.FileName);
            }
        }
        private void OnSaveTest()
        {
            // TODO
        }
        private void OnNewTest()
        {
            // TODO
        }
        private void OnOpenTest()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "Open",
                Filter = "Sample (.xml)|*.xml",
                CheckFileExists = false
            };

            bool? success = DialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                // Do something
                Log.Info("Opening file: " + settings.FileName);
            }
        }
        private void OnShowAboutDialog()
        {
            Log.Info("Opening About dialog");
            AboutViewModel dialog = new AboutViewModel();
            var result = DialogService.ShowDialog<About>(this, dialog);
        }
        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
        #endregion

        #region Events

        #endregion
    }
}
