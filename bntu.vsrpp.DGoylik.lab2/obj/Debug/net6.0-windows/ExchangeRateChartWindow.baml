   M S B A M L   `   `   `  ����R  Nbntu.vsrpp.DGoylik.lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:bntu.vsrpp.DGoylik.lab2bntu.vsrpp.DGoylik.lab2  5   	   5    /bntu.vsrpp.DGoylik.lab2.ExchangeRateChartWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:bntu.vsrpp.DGoylik.lab2     5   	     � Title$  Exchange Rate Chart��5   	   $	��550��6%   $	��920��62    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $��35(�6!   $��
ExtraBlack"�6/   $��Center=�6G   
������Currency Exchange Rate Chart6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��10q�6;   .+�5      �� -   5         ��Name$ chart��5      $	��820��6$   $	��300��60   $��
40 -15 0 0q�6=   
�������6Q   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��0 0 0 0q�6   .+�5      �� $��25(�6   $
��Bold"�6*   
������DATE WITH MAX VALUE6i   �� 5      -   5         ��Name$ MaxTextBlock��5      $��25(�62   $
��Bold"�6@   
���"�"�$��Center=�6k   $��0 10 0 0q�6�   6�   5      �� 5      $��10 0 0 0q�6   .+�5      �� $��25(�6   $
��Bold"�6*   
�������DATE WITH MIN VALUE6h   �� 5      -   5        $ MinTextBlock��5      $��25(�62   $
��Bold"�6@   
����i��$��Center=�6g   $��0 10 0 0q�6�   6�   5      �� 5      $��7 0 0 0q�6   .+�5      �� $��25(�6   $
��Bold"�6*   
����ح�AVERAGE OF THE PERIOD6j   �� 5       -   5        $ AvgTextBlock��5       $��25(�62   $
��Bold"�6@   
�����_�$��Center=�6i   $��0 10 0 0q�6�   6�   5!      5"      5#      5$      