   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  5   	   ;"clr-namespace:Project.UserControlsProject.UserControls  5   	       Project.View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Project.View     5   	   1uc"clr-namespace:Project.UserControls     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   
   $��13(�5   
     � Title$  
MainWindow��5      $	��700��6   $
��1300��6(   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   	    � WindowStyle$
 None=�5   
    � AllowsTransparency$
 True��5   
    � WindowStartupLocation$ CenterScreen=�5   
    � 	Resources 5        	CloseMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  OpenMenu��%  &	       &	 �     �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ grdMenu��6�   .\�5        $	 0��6'   $	
 250Q�63     5      $	 0:0:0.3��6'   $
 0Q�69   5      5      �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ grdMenu��6�   .\�5        $	 0��6'   $
 0Q�63     5      $	 0:0:0.3��6'   $	
 250Q�69   5      5       5!      ��5#      �� 5$   
    �� ImageSource$_ YD:\PRN221\PROJECT_PRN221\Project_PRN221\Prn221_HE153685\Project\Project\Res\Light 010.png��6    j� Stretch$
 None=�6~    � Triggers 5'      :� 5(   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ btnCloseLVMenu��66   .[�5)      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5)      #��[ 6A   5*      :� 5+   
   $ ButtonBase.Click��6   $ btnOpenLVMenu��66   .[�5,      �� #��[ 6   5-       J� Clip 50      �� 51   
    �� Rect$ 0,0,1300,700�6    �� RadiusX$ 10Q�60    �� RadiusY$ 10Q�6=   -   5        	boGoc��52      .��54      �  � RowDefinitions 55   
   �� 56      $��26 �6   6*   �� 57      6   .+�5:   
   ,   &Project.UserControls.ControlBarManager  $��0,-3,0,3q�65   
 � Tag 6   �� *Title+��6G   �� *MinHeight_ucControlbar+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5<      � 5>   
   $��1��6   $��
0,10,0,-10q�6   .+�5?      � -   5         �Name$ GridBackground��5?       5@      �� 5A      $��30 �6$   62   �� 5B      6&   .+�5F      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ titleBar��5G   .   ���	#FFF4F4F4$��43��5F   F   $��0��6R   $��	0,-13,0,0q�5G   @   .��5H      �  � ColumnDefinitions 5I      �� 5J      $
��auto �6/   6>   �� 5K      $��1* �6/   6<   �� 5L      $	��210 �6/   6=   .+�5O      ��  �� Orientation$ 
Horizontal=�6%   $��0��6>   $��5 0 0 0 q�6N   .+�5Q      �� -   5         ��Name$ btnOpenLVMenu��5R   %   $��30��5Q   %   
������ $��0q�5R   U   $��0q�6i   .��5S   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Menu=�6:   
���   �$��30��6Y   $��30��6d   5T      5V      � 5X      $��1��6    5Y      �� 5Z   "   �� 5[   "   .+�5]      �� $	��Top=�6)   $��40,3,0,0q�6A   $��20(�5^   E   $��2��6S   ��6)   �� *
Title_Main+6S   5_      � 5`      $��2��6   .+�5b      '  !MaterialDesignThemes.Wpf.PopupBox  $��	 0 0 40 0q�66   $��Right=�6I      PopupContent. 5c   "   �� .@�5d   &   �� $��Hello World��62   �� 5e   &   $��
Nice Popup��62   �� 5f   &   $��Information��62   5g   #   5h      5i      5k      5m      � 5o      -   5        $ displayMain��5o      $��1��5p       5q      �� 5r      $	��21* �6+   �� 5s      $��1279* �6+   .+�5u      �� -   5          ��Name$  contenDisplayMain��5u   %   $
��auto��5v   )   $
��auto��5w   )   $��2��67   5x      5y      � 5{      -	   5        $ grdMenu��5      $	��250��5{      
�������$
��Left=�5|      $��-250,-6,0,0q�5}      ! J� RenderTransformOrigin$! 0.5,0.5&�5~      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       5�      �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      � $��0��6   $	��170��6$   .+�5�      � ���	#FF142C2F.+�5�      �� -
   5        $ btnDangXuat��5�   !   $��80��66   $��30��6A   $
��Left=�6M   $��0q�6h   
���k���$	��Top=�5�   !   $��11(�69   $��0q�6H   
������ 
�������.��5�      �� $��Đăng xuất��6(   ���	#FFE4EAF369   5�      A� 5�      -   5        " A�Name$" 	imgAvatar��5�   "   $	��130��65   $	��130��6A   $	��Top=�6N   $��0 10 0 0q�6f   ��5�      �� 5�   "   $_ YD:\PRN221\PROJECT_PRN221\Project_PRN221\Prn221_HE153685\Project\Project\Res\Light 010.png��6-   5�      � 5�      -   5        $ 	grdAvatar��5�      $	��130��62   $	��130��6>   $	��Top=�6L   $��0 10 0 0q�6d    5�      �� 5�   "   $ 0,0,130,130�64   $ 65Q�6G   $ 65Q�6T   .+�5�      �� -   5        # ��Name$# txblAvatarBinding��5�   (   �� 5�      -   5        $ 
btnThayAnh��5�   %   $��Bottom=�69   
�������$ J� Opacity$	$ 0.6Q�6g   $��0q�5�   %   $��30��69   ��5�   "   �� 5�   &   % �� 
TargetType"% ��6,   .�5�   *   �� & �� Property& � y�' �� Value$' Hidden=�6G   6X   ( �� Triggers( 5�   *   �� 5�   .   ) �� Binding) 6:   �� * �� ElementName$* txblAvatarBinding��+ �� Path$+ IsMouseOver�, �� Value, True6~   .a�5�   2   �� & � y�$' Visible=�6O   6a   5�   /   P� 5�   .   - P� Property- �@J�IsMouseOver. P� Value$
. True��6M   . �5�   2   �� & � y�$' Visible=�6O   6a   5�   /   5�   '   .��5�   "     $	$ 0.8Q�6:   $ CameraImage=�6H   
����  �$��20��6m   $��20��6x   5�      5�      �� 5�      -   5        $# 
txbHoTenNV��5�   $   $��18(�68   $��0 0 0 4q�6F   $��Center=�5�   $   $��Bottom=�6A   ���	#DDDFE9F7$��Oboto)�6�   ��6s   Z� 6�   5�      �� 5�      -   5        $ btnCloseLVMenu��5�      $��30��5�      $��40��6)   $	��Top=�64   $��Right=�6L   
������ $��0q�5�   N   $��0q�6b   .��5�        $ ChevronTripleLeft=�62   ���	#FFE2D7D7$��40��6b   $��30��6m   5�      5�      �� 5�      -   5        / ��Name$/ lisviewMenu��5�      $��1��5�      ���	#FF313131$��Champagne & Limousines)�6A   $��18(�6i   $��Hidden=�5�      $��Hidden=�5�      $
��True��5�      ��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     $��20��6U   $��20��6`   $��5q�6�   $��Center=�6�    6:   �� *	kind_Icon+��6l   �� *	foreColor+6�   �� 5�   "   $��10q�6B   ��6,   �� *name+6B   5�      5�      5�      5�      5�      5�      5�      