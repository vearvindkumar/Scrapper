   M S B A M L   `   `   `  ����H  DHighlightText, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HighlightTextHighlightText  5   	       HighlightText.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:HighlightText     5   	     � Title$  Searchable TextBlock��5   	   $	��250��6&   $	��425��63   .��5      �  � 	Resources 5   
   *   $HighlightText.StringToWordsConverter   StringToWordsConverter��%   &	          5	      6+   5
       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   '   !HighlightText.SearchableTextBlock  -   5          Name$ HighlightTextBlock1��5   $      HighlightBackground
 � ���   HighlightableText 6_   ��  �� ElementName$ TextString1�� �� Path$
 Text� �� Mode$ TwoWay=�	   SearchWords	 5   $   �� $ CommaSeparatedWords��$
 Text�
 �� 	Converter#
 [  � 5   
   $��1��6   .+�5      �� $��Search Words��6   �� 5      -   5        $��CommaSeparatedWords��5      $	��200��61   5      � 5   
   $��2��6   .+�5      �� $��String��6   �� 5      -   5        $��TextString1��5      $	��200��6)   $��Test me��68   5      5      5      