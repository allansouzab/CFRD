   M S B A M L   `   `   `  ����U  QControle Financeiro, Version=0.1.7076.24363, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Controle_Financeiro.ViewsControle_Financeiro.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   /    )Controle_Financeiro.Views.NovaReceitaView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Controle_Financeiro.Views     5   	   R NMvvmDialogs, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5   	   0sys&clr-namespace:System;assembly=mscorlib  5	   	   $  MvvmDialogs.DialogServiceViews    IsRegistered  .  � Title$ Nova Receita��5   	   $��422.561��6   $��364.269��6/    � WindowStartupLocation$ CenterScreen=�6?   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Cadastrar Receita��6   $
��Left=�6;   $��	92,10,0,0q�6V   $	��Top=�6i   $��20(�6�   �� 5   
   -   5        $ label1��5      $��Número de Fatura��6    $
��Left=�6;   $��	32,64,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ txtNumFatura��5      $
��Left=�6(   $��23��6C   $��	36,91,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��288��6�   ��6�   �� *	NumFatura+�� 5   
   -   5        $ label1_Copy��5      $
��Data��6%   $
��Left=�64   $��
32,125,0,0q�6O   $	��Top=�6c   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��
36,153,0,0q�6D   $	��Top=�6X   $	��288��6p      SelectedDate 6|   ��  �� Path$
 Data�	 �� Mode$	 TwoWay=�
 �� StringFormat$
 {0:dd-MM-yyyy}���� 5   
   -   5        $ label1_Copy1��5      $��Cliente��6&   $
��Left=�68   $��
34,191,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ 
txtCliente��5      $
��Left=�6&   $��23��6A   $��
36,218,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��288��6�   ��6�   �� *	Cliente+�� 5   
   -   5        $ label1_Copy2��5      $��Valor��6&   $
��Left=�66   $��
33,253,0,0q�6Q   $	��Top=�6e   �� 5   
   -	   5        $ txtValor��5      $
��Left=�6$   $��23��6?   $��
36,281,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��288��6�   ��6�   �� *Valor+�� 5   
   -
   5         ��Name$ btnCadastrarReceita��5      $��	Cadastrar��6.   $
��Left=�6B   $��
79,337,0,0q�6]   $	��Top=�6q   $	��100��6�   $��30��6�   $��14(�6�   ��6�   �� $ CadastrarCommand��� 5   
   -   5        $ 	btnFechar��5      $��Fechar��6$   $
��Left=�65   $��182,337,0,0q�6P   $	��Top=�6e   $��90��6}   $��30��6�   $��14(�6�   6�   5      5      