   M S B A M L   `   `   `  ����U  QControle Financeiro, Version=0.1.7076.24363, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Controle_Financeiro.ViewsControle_Financeiro.Views  5   	   2    ,Controle_Financeiro.Views.RelatorioGeralView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Controle_Financeiro.Views     5   	   R NMvvmDialogs, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5   	   $  MvvmDialogs.DialogServiceViews    IsRegistered  .  � Title$ Relatório Geral��5
   	   $	��200��6!   $	��400��6.    � WindowStartupLocation$ CenterOwner=�6:    � 
ResizeMode$ CanMinimize=�6^   .��5      � .+�5   
   �� -   5         ��Name$ cmbMes��5      $
��Left=�6#   $��	49,61,0,0q�6>   $	��Top=�6Q   $	��120��6i    �� SelectedIndex 6u   �� *cmbMesIndex+.@�5      �� {�.  .��6-   Selecione um mês6?   �� 5      .��6   	Janeiro6$   �� 5      .��6   	Fevereiro6&   �� 5      .��6   Março6"   �� 5      .��6   Abril6"   �� 5      .��6   Maio6!   �� 5      .��6   Junho6"   �� 5      .��6   Julho6"   �� 5      .��6   Agosto6#   �� 5      .��6   
Setembro6%   �� 5      .��6   	Outubro6$   �� 5      .��6   
Novembro6%   �� 5      .��6   
Dezembro6%   5      �� 5   
   -   5        $ cmbAno��5      $
��Left=�6#   $��
222,61,0,0q�6>   $	��Top=�6R   $	��120��6j    6v   �� *cmbAnoIndex+.@�5      �� .��6   20196!   �� 5      .��6   20206!   �� 5      .��6   20216!   �� 5      .��6   20226!   �� 5       .��6   20236!   5!      �� 5"   
   -   5         ��Name$ label��5"      $
��Mês��6   $
��Left=�6-   $��	44,29,0,0q�6H   $	��Top=�6[   $��16(�6s   �� 5#   
   -   5        $ label1��5#      $	��Ano��6    $
��Left=�6.   $��
218,29,0,0q�6I   $	��Top=�6]   $��16(�6u   �� 5$   
   -   5         ��Name$ 	btnEnviar��5$      $��Enviar��6$   $
��Left=�65   $��107,124,0,0q�6P   $	��Top=�6e   $��85��6}   $��30��6�   $��16(�6�   ��6�   �� *EnviarMesAnoCommand+�� 5%   
   -   5        $ 	btnFechar��5%      $��Fechar��6$   $
��Left=�65   $��211,124,0,0q�6P   $	��Top=�6e   $��85��6}   $��30��6�   $��16(�6�   6�   5'      5(      