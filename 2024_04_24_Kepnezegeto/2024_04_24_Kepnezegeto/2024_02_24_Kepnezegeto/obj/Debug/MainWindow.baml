   M S B A M L   `   `   `  ����Q  M2024_02_24_Kepnezegeto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:_2024_02_24_Kepnezegeto_2024_02_24_Kepnezegeto  5   	   (    "_2024_02_24_Kepnezegeto.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:_2024_02_24_Kepnezegeto     5   	     � Title$$  Kép nézegető Krausz Márton��5   	   $	��750��6,   $
��1000��69    � 
ResizeMode$ NoResize=�5	   	    � 	Resources 5      *  $_2024_02_24_Kepnezegeto.CountConvert   	countConv,  &_2024_02_24_Kepnezegeto.ColorConverter  	colorConv 
 dtPict �� CornerRadius �� ElementName �� Path �� TextAlignment �� Mode  dtPict2 �� Orientation  pictTemplate��%r  &	        &	      &	 &     &	 �    &	       5   
   6     5   
   6   �� 5   
   .R�5      �� $��3q�6   
����  �$ 10��6=   ._�5      �� .+�5      �� $	��156��6�   $��5q�6�   ��6   �� *
FullName+��68   �� $\ VMeretesCsuszkaAzertKellEgyEkkoraNevMertEzzelFejezemKiMennyireSzeretemAWPFetAmiTízPer0��$ Value�6�   �� 5      $ Center=�6C   $
��Bold"�6Z   ��6    �� *Name+$ OneWay=�6Z   �� 5      $ Center=�6M   $��Medium"�6d   ��6    �� *LastAccessTime+$ OneWay=�6d   �� 5      $	��150��6G   $ Center=�6S   
������$
��Wrap=�6�   ��6    �� *
FullName+$ OneWay=�6�   5      5      5      �� 5   
   .R�5      �� $��3q�6   
����  �$ 10��6<   ._�5      �� $ 
Horizontal=�6   .+�5      �� $	��156��6�   $��5q�6�   ��6   �� *
FullName+��68   �� $\ VMeretesCsuszkaAzertKellEgyEkkoraNevMertEzzelFejezemKiMennyireSzeretemAWPFetAmiTízPer0��$ Value�6�   �� 5      .+�5      �� $ Center=�6G   $
��Bold"�6^   ��6$   �� *Name+$ OneWay=�6^   �� 5       $ Center=�6Q   ��6$   �� *LastAccessTime+$ OneWay=�6Q   �� 5!      $	��150��6K   $ Center=�6W   
������$
��Wrap=�6�   ��6$   �� *
FullName+$ OneWay=�6�   5"      5#      5$      5%      �� 5(   
   .R�5)      � 5*      5+      .��5.      ]� 
�������.+�5/   
   c� 
���z���$	��Top=�6*   $��26��6?   $	��Top=�6K   .@�50      �� -   5        $"��Sorbarendezés NÉV alapján��50      $��21��69   6E   �� 51      -   5        $$��Sorbarendezés DÁTUM alapján��51      $��21��6;   6G   �� 52      -   5        $��1. mód��52      $��21��6'   63   �� 53      -   5        $��2. mód��53      $��21��6'   63   �� 54      -   5        $��3. mód��54      $��21��6'   63   ]� 55      $
��10px��6   �� 56      $��- ��6   �� 57      -   5        	 ��Name$\	 VMeretesCsuszkaAzertKellEgyEkkoraNevMertEzzelFejezemKiMennyireSzeretemAWPFetAmiTízPer0��57   =   $	��148��6   
 � Minimum$	
 100Q�6!    � Maximum$	 250Q�6/   6=   �� 58      $�� +��6   ]� 59      $	��240��6   �� 5:      -   5         ��Name$ 	fel_balra��5:      $	��↑��6(   $��20(�64   $��30��6C   6O   ]� 5;      $��30��6   �� 5<      -   5        $ 	le_jobbra��5<      $	��↓��6(   $��20(�65   $��30��6C   6O   5=      �� 5>   
   $��Bottom=�6   $��26��6,   
���z���$	��Top=�6P   .@�5?      �� ��6   �� *Count+ �� 	Converter# [  5@      �� 5B   
   -	   5         ��Name$ lstBox3��5B      $��Center=�6#   $	��988��6@   #��[ 6d   #��[ 6�   $��Disabled=�5C      ��5B   L   ��  �� 
GroupStyle 5D      (  "System.Windows.Controls.GroupStyle  5E         HeaderTemplate 5F      �� 5G      .R�5H      �� $��2q�6%   
��� ���$ 10��6N   ._�5I   "   �� $
��Bold"�6B   $ Center=�6T   $��5q�6k   ��6,   �� *Name+6k   5J      5K      5M      5O      � 5Q   
   $��Center=�6   .+�5R      �� -
   5        $ lstBox2��5R      $	��900��6'   $��Disabled=�6K   $��Disabled=�6�   ��63   �� ��5S      �� 5T      .R�5U      $�  $� Orientation$ Vertical=�61   5V      ��5X      �� 5Y      .R�5Z      �� $��1q�6!   
�������$��5q�6M   $	��877��6X   ._�5[      �� #��[ 6C   ��6/   �� 6C   5\      5]       5_        5`       5a      �� 5b      .R�5c   "   �� $��2q�6)   
��� ���$ 10��6R   ._�5d   &   �� $
��Bold"�6F   $ Center=�6X   $��5q�6o   ��60   �� *Name+6o   5e   #   5f      5h      5j      5k      �� 5q   
   -   5        $ lstBox1��5q      $	��500��6#   $	��500��6/   $��Disabled=�6T   $��Disabled=�6�   ��6<   �� ��5r      �� 5s      .R�5t      $� $ Vertical=�6-   5u      ��5w      �� 5x      .R�5y      �� $��1q�6   
�������$��5q�6I   $	��470��6T   $	��490��6`   ._�5z      �� #��[ 6?   ��6+   �� 6?   5{      5|       5~        5       5�      �� 5�      .R�5�      �� $��2q�6%   
��� ���$ 10��6N   ._�5�   "   �� $
��Bold"�6B   $ Center=�6T   $��5q�6k   ��6,   �� *Name+6k   5�      5�      5�      5�      5�      5�      