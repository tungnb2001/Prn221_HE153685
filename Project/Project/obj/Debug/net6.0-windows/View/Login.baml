   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  5   	       Project.View.Login   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Project.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Login��5   	   $	��500��6   $	��900��6$   
���   � � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ 	btn_Close��5   (   $��65��6   $��60��6   $��Right=�5      $	��Top=�61   
������ $��0q�5       � ToolTip$ Close��6)    J� Clip 5      �� 5      	 �� Rect$	 	0,0,65,50�6$   
 �� RadiusX$
 20Q�65    �� RadiusY$ 20Q�6B   5      .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseOctagonOutline=�6&   $��35��6A   $��35��5   *   
������� J� Opacity$	 0.7Q�5   =   5      #  MaterialDesignThemes.Wpf.Card  5!   
   $	��238��6   $	��325��6*   ���#FFFFFF$	��Top=�5"      $
��Left=�66   $��
100 80 0 0q�5#       5%      �� 5&      $	 0,0,238,325�6$   $
 10Q�67   $ 10Q�6D   5'      .��5*      � .+�5+      �� $��49��6   $
��Bold"�6(   $��30(�6:   ���#0056FC$
��Left=�5,      $	��Top=�67   $��	44,31,0,0q�6O   Đăng Nhập6m     5-      $ Account=�6*   $
��Left=�69   $	��Top=�6T   $��19��5.   *   $��19��66   $��
20,114,0,0q�5/   *     50      $
 Lock=�6*   $
��Left=�66   $	��Top=�6Q   $��19��51   *   $��19��66   $��
20,160,0,0q�52   *   �� 53      -   5         ��Name$ 
tbUsername��53      $��
55 107 0 0q�60   $��26��6D   $	��130��6P   $
��Left=�54      $	��Top=�68   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��55      G� 57      -   5         G�Name$ 
tbPassword��57   #   $ Mật khẩu��58       $
��Left=�59      $	��Top=�6:   $��
55,154,0,0q�5:      $��26��63   $	��130��6?   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5;      �� 5=      -   5        $��28��5=      $	��106��6%   ���#0056FC$��Center=�5>      $	��Top=�66   $��	0,204,0,0q�5?      
�������$��Login��6?    5@      �� 5A      $	 
0,0,107,28�6,   $
 10Q�6>   $ 10Q�6K   5B      5E      5F      5G      5H      5I      