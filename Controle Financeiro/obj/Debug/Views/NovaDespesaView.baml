   M S B A M L   `   `   `  ����U  QControle Financeiro, Version=0.1.7076.24363, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Controle_Financeiro.ViewsControle_Financeiro.Views  5   	   /    )Controle_Financeiro.Views.NovaDespesaView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Controle_Financeiro.Views     5   	   R NMvvmDialogs, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5   	   $  MvvmDialogs.DialogServiceViews    IsRegistered  .  � Title$ Nova Despesa��5
   	   $��552.961��6   $��364.269��6/    � WindowStartupLocation$ CenterScreen=�6?   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Cadastrar Despesa��6   $
��Left=�6;   $��	92,10,0,0q�6V   $	��Top=�6i   $��20(�6�   �� 5   
   -   5        $ label1��5      $��Número de Fatura��6    $
��Left=�6;   $��	32,60,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ txtNumFatura��5      $
��Left=�6(   $��23��6C   $��	36,91,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��288��6�   ��6�   �� *	NumFatura+�� 5   
   -   5        $ label1_Copy��5      $
��Data��6%   $
��Left=�64   $��
32,125,0,0q�6O   $	��Top=�6c   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��
36,153,0,0q�6D   $	��Top=�6X   $	��288��6p      SelectedDate 6|   ��  �� Path$
 Data�	 �� Mode$	 TwoWay=�
 �� StringFormat$
 {0:dd-MM-yyyy}���� 5   
   -   5        $ label1_Copy1��5      $��
Fornecedor��6&   $
��Left=�6;   $��
32,191,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ txtFornecedor��5      $
��Left=�6)   $��23��6D   $��
36,222,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��288��6�   ��6�   �� *
Fornecedor+�� 5   
   -   5        $ label1_Copy2��5      $��Descrição��6&   $
��Left=�6:   $��
32,260,0,0q�6U   $	��Top=�6i   �� 5   
   -	   5        $ txtDescricao��5      $
��Left=�6(   $��23��6C   $��
36,291,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��288��6�   ��6�   �� *	Descricao+�� 5   
   -
   5        $ label1_Copy3��5      $��Centro de Custo��6&   $
��Left=�6@   $��
32,328,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $ txtCentroCusto��5      $
��Left=�6*   $��23��6E   $��
36,359,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��288��6�   ��6�   �� *CentroCusto+�� 5   
   -   5        $ label1_Copy4��5      $��Valor��6&   $
��Left=�66   $��
36,395,0,0q�6Q   $	��Top=�6e   �� 5   
   -   5        $ txtValor��5      $
��Left=�6$   $��23��6?   $��
36,421,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��288��6�   ��6�   �� *Valor+�� 5   
   -   5         ��Name$ btnCadastrarReceita��5      $��	Cadastrar��6.   $
��Left=�6B   $��
77,471,0,0q�6]   $	��Top=�6q   $	��100��6�   $��30��6�   $��14(�6�   ��6�   �� $ CadastrarCommand��� 5   
   -   5        $ 	btnFechar��5      $��Fechar��6$   $
��Left=�65   $��180,471,0,0q�6P   $	��Top=�6e   $��90��6}   $��30��6�   $��14(�6�   6�   5      5      