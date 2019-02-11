using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModels
{
    public class MainWindowViewModel
    {
        IController _controller;
        public RelayCommand HomeCommand { get; private set; }
        public RelayCommand ReceitasCommand { get; private set; }
        public RelayCommand DespesasCommand { get; private set; }
        public RelayCommand RelatorioCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand CadUserCommand { get; private set; }
        public RelayCommand LogsCommand { get; private set; }

        public MainWindowViewModel(IController controller)
        {
            this._controller = controller;
            HomeCommand = new RelayCommand(Home);
            ReceitasCommand = new RelayCommand(Receitas);
            DespesasCommand = new RelayCommand(Despesas);
            RelatorioCommand = new RelayCommand(Relatorio);
            CloseCommand = new RelayCommand(Close);
            CadUserCommand = new RelayCommand(CadUser);
            LogsCommand = new RelayCommand(Logs);
        }

        public void Home()
        {
            MessageBox.Show("Este botão irá navegar para a tela principal.", "CFRD");
        }

        public void Receitas()
        {
            MessageBox.Show("Este botão irá navegar para a tela de consulta e cadastro de novas receitas para o mês vigente ou consulta de meses anteriores.", "CFRD");
        }

        public void Despesas()
        {
            MessageBox.Show("Este botão irá navegar para a tela de consulta e cadastro de novas despesas para o mês vigente ou consulta de meses anteriores.", "CFRD");
        }

        public void Relatorio()
        {
            MessageBox.Show("Este botão irá navegar para a tela de consulta do relatório geral do mês selecionado, onde poderá ter todas todas as receitas e despesas e seus totais, além do cálculo para verificar se o mês foi positivo ou negativo. \n\nPara a exportação do relatório poderá ser escolhido pelo usuário como PDF ou uma planilha Excel.", "CFRD");
        }

        public void CadUser()
        {
            MessageBox.Show("Este botão irá navegar para a tela de cadastro de novos usuários, onde poderá ser cadastrada qualquer pessoa fisica ou juridica para utilização do aplicativo conforme autorização do usuário principal (Proprietário LoveSnacks).", "CFRD");
        }

        public void Logs()
        {
            MessageBox.Show("Este botão irá navegar para a tela de acompanhamento dos logs do usuário, isto é, botões e funções utilizadas ao decorrer do tempo.", "CFRD");
        }

        public void Close()
        {
            Application.Current.Shutdown();
        }
    }
}
