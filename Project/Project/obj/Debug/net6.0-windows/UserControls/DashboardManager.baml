   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project.UserControlsProject.UserControls  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      +    %Project.UserControls.DashboardManager   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Project.UserControls     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      
�������.��5      �   � RowDefinitions  5   
   �� 5      $��1* �6   6*   �� 5      $
��2.5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      #  MaterialDesignThemes.Wpf.Card  ���	#FFFEC007$��Center=�69   $	��320��5   "   $	��150��6.   $��60 0 0 0q�6;   .��5      �   5      �� 5      $
��1.5* �6(   �� 5      $��1* �6(   .+�5      �� $6��0Tổng số tiền của tất cả sản phẩm��6    $
��Left=�6H   $��	20,20,0,0q�5      $
��Wrap=�6/   $��0��6C   $	��Top=�5      $��25(�64   
�������6B   �� 5      -   5         ��Name$ txbTotalMoney��5       $��1��67   $
��Left=�6E   $��20,0.8,0,4.8q�5      $
��Wrap=�62   $��Center=�6F   $��24(�6a   $
��Bold"�5      
�������6.   � 5       $��50��6   $��50��6&   $��Right=�62   $	��Top=�6N   $��	0,20,20,0q�6f   5"      5#      5$        5%      
����  �$��Center=�64   $	��320��5&   "   $	��150��6.   $��90 0 0 0q�6;   .��5'      �   5(      �� 5)      $
��1.5* �6(   �� 5*      $��1* �6(   .+�5,      �� $%��Tổng tiền bán sản phẩm��6    $
��Left=�6>   $��	20,20,0,0q�5-      $
��Wrap=�6/   $��0��6C   $	��Top=�5.      $��25(�64   
�������6B   �� 5/      -   5        $ txbOrder��5/       $��1��62   $
��Left=�6@   $��20,0.8,0,4.8q�50      $
��Wrap=�62   $��Center=�6F   $��24(�6a   $
��Bold"�51      
�������6.   � 52      $��50��6   $��50��6&   $��Right=�62   $	��Top=�6N   $��	0,20,20,0q�6f   54      55      56      �� 57      -   5         ��Name$ cmbYear��57      $	��350��6(   $��
20 110 0 0q�64     58      
�������$��50��6:   $��32��6E   $��
50 110 0 0q�6Q   .��59      �   5:      �� 5;      $
��Auto �6(   .+�5=      �� -   5        $
��Auto��5=   2   $
��Auto��6@      MaterialDesignToolButton#���   6M   .��5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ RefreshCircle=�62   5?      5@      5A      5C      5D      � 5E   
   $��1��6   .+�5F      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6S   $��0,0,0,32q�6j      Series 6!   �� *SeriesCollection+ �� Mode$ TwoWay=�   AxisX 5H        LiveCharts.Wpf.Axis  	   Labels	 6    �� *Labels+5J      5K      5N      5O      