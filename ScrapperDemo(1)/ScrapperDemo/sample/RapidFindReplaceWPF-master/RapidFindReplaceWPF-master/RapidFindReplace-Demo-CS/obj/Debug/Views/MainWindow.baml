   M S B A M L   `   `   `  ����S  ORapidFindReplace-Demo-CS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:RapidFindReplace_Demo_CS.ViewModels#RapidFindReplace_Demo_CS.ViewModels  5   	   Z VKeyoti4.RapidFindReplace.WPF, Version=1.0.14.531, Culture=neutral, PublicKeyToken=nulloOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPFKeyoti.RapidFindReplace.WPF 5   	   /    )RapidFindReplace_Demo_CS.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @vm1clr-namespace:RapidFindReplace_Demo_CS.ViewModels     5   	   ]kOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPF     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   ���	#FFE3EBF1 � DataContext 5      =  7RapidFindReplace_Demo_CS.ViewModels.MainWindowViewModel  5   
   6#   .��5
      �  � RowDefinitions 5   
   �� 5      $��38 �6   6*   �� 5      �� 5      $��38 �6   6*   .+�5   
   �� $��0��6   $	��Top=�6   $&�� Available Find/Replace Examples:��66   $��18(�6a   $
��10,0q�6o   $��38��6}   �� 5   
   -   5        $��winList��5   p   $��1��6   $��	11,10,9,5q�6   ��6   �� *AvailableWindows+ �� SelectedItem 6H   �� *SelectedWindow+ � 	Resources 5         ProjectIcon �� 	UriSource��%8   &	        �� 5      $ ../Images/Window.png?�62   5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� #��[  6    $��38��6F   �� 5      $��39��6!   ._�5      �� $��Center=�6(   $��Segoe UI Symbol)�6�   $��14(�6�   ��6C   ��  �� Path$
 Name�4  .Keyoti.RapidFindReplace.WPF.ConverterInstances   CamelCaseConverter	 �� 	Converter#	 Z 6�   5      5      5      ��5!      �� 5"      
 �� 
TargetType"
 ��6   .�5#      -   5        5$      5&      �� 5'   
   -   5        $��10,0,0,0q�5'   &   $��2��68   $��33��6E   $	��Top=�6Q   $
��Left=�6i   $	��109��6�   .��6�   Launch Example5(      5*      5+      