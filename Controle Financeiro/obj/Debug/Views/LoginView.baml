   M S B A M L   `   `   `  ����U  QControle Financeiro, Version=0.1.7076.24363, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Controle_Financeiro.ViewsControle_Financeiro.Views  5   	   O,clr-namespace:Controle_Financeiro.ViewModelsControle_Financeiro.ViewModels  5   	   )    #Controle_Financeiro.Views.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Controle_Financeiro.Views     5   	   AlocalVMs,clr-namespace:Controle_Financeiro.ViewModels     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Login do sistema��5
   	   $	��540��6"   $	��350��6/    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	    � DataContext 5      3  -Controle_Financeiro.ViewModels.LoginViewModel  5   
   .��5      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #DCDCDC��6   � 5      $ #C0C0C0��6    � Offset$ 1Q�6/   � 5      $ #808080��6   $ 0.546Q�6/   5      5      �� 5   
   $	��280��6   $	��240��6    $��Bottom=�6-   $
��0,80q�6H   	 �� RadiusY$	 10��6V   
 �� RadiusX$
 10��6c   
������� J� Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5#      � 5$   
   $��Bottom=�6   $��35,80q�6*   $	��240��69   .+�5%      �� $��LOGIN��6   $��Center=�6$   $	��Top=�6A   $��5q�6Y   
�������$��18(�6v   �� 5&      $��Center=�6   $��15q�64   .+�5'      �� -   5         ��Name$ 
txtUsuario��5'      $
��0,10q�6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USUÁRIO��6<    %  !MaterialDesignFloatingHintTextBox#��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   ��6�   �� *
txtLogin+G� 5(      -   5         G�Name$ txtSenha��5(      $
��0,10q�60   $ SENHA��6>    ) %MaterialDesignFloatingHintPasswordBox#��[ 6e   $��Champagne & Limousines)�6�   $��18(�6�   6�   5)      5*      �� 5+   
   -   5         ��Name$ btnLogin��5+      $	��100��6#   $
��Left=�6/   $��Bottom=�6J   $��	64,0,0,60q�6e   $��LOGIN��6x   6�   �� 5,   
   -   5        $ btnSair��5,      $	��100��6"   $��Right=�6.   $��Bottom=�6J   $��0,0,62.4,60q�6e   $
��SAIR��6z   6�   �� 5.   
   -   5         ��Name$ btnCriarConta��5.      $��CRIAR NOVA CONTA��6+   $��Center=�6C   $��Bottom=�6`   $��25q�6{   
������� � Cursor$
 Hand��6�   6�   �� 5/   
   $"��Resources/lovesnacks_new.png��6   $	��200��66   $	��200��6B   $	��Top=�6O   $��75,10,75.4,0q�6g   50      51      