   M S B A M L   `   `   `  ����G  CScrapperDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ScrapperDemo.ViewModelScrapperDemo.ViewModel  5      "    ScrapperDemo.View.SearchData   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <HilightText$clr-namespace:ScrapperDemo.ViewModel     5      .��5	      � 
�������  � 	Resources  5
   
   3   -ScrapperDemo.ViewModel.StringToWordsConverter   StringToWordsConverter��%   &	          5      61   5       � RowDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   �� $��0,0,0,5q�6   $��2q�6"   
���  ��66   �� 5   
   $
��Auto=�6   $
��Auto=�6;   $��10,11,10,10q�6`   $
��1044��6u   $	��270��6�   .��5      0   *ScrapperDemo.ViewModel.SearchableTextBlock  -   5          Name$ HighlightTextBlock1��5   �   $
��Wrap=�6/   $��Stretch=�6C   $��Stretch=�6a    �� TextAlignment$ Justify=�6}   $
��1044��6�   $	��280��6�   ��. $
��Auto=�6�   $
��Auto=�6!     HighlightBackground
 �����   HighlightableText 6u  ��  �� ElementName$ txtbxSearchHTMLContent�� �� Path$
 Text� �� Mode$ TwoWay=�	   SearchWords	 5   $   �� $ CommaSeparatedWords��$
 Text�
 �� 	Converter#
 [  5      � 5   
   $��1��6   .+�5      �� $��Search Text:��6   $��88��6+   �� 5      -   5         ��Name$ CommaSeparatedWords��5      $	��390��63   $	��991��6B   $��26��6N   $��Search Content��6Z   5      � 5    
   $��2��6   .+�5!      �� -   5        $��BtnLoadSearchContent��5!      $��Load Search HTML Content��61   $��88,0,0,0q�6T   6f   �� 5"      -   5        $��txtbxSearchHTMLContent��5"      $��Search HTML Content��65   $y�Hidden=�6P   5#      �� 5$   
   $��2��6   $��	250,0,0,0q�6"   $��35��65   .+�5%      �� $8��2Select Analyze Number To Load Content For Search: ��6   $	��350��6Q   $��30��6]   $
��Left=�6j   $��0,0,0,0q�6�   �� 5&      -   5         ��Name$ cmbbxLoadplaintextfromdb��5&      $��290,-25,190,0q�69   $	��350��6P   $��25��6]    �� Text$6 0Select Analyze Number To Load Content For Search��6i   6�   �� 5'      -   5        $��ShowDiff��5'      $��	Show Diff��6%   $	��120��69   $��25��6E   $��580,-25,0,0q�6Q   $y�Hidden=�6}   5(      5)      5*      