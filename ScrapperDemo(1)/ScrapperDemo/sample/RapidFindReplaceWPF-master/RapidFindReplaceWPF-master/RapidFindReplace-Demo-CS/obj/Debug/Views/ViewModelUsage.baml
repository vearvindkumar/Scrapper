   M S B A M L   `   `   `  ����Z  VKeyoti4.RapidFindReplace.WPF, Version=1.0.14.531, Culture=neutral, PublicKeyToken=nulloOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPFKeyoti.RapidFindReplace.WPF  5   	    RapidFindReplace-Demo-CS3   -RapidFindReplace_Demo_CS.Views.ViewModelUsage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   lRapidFindReplaceOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPF     5   	     � Title$  ViewModelUsage��5   	   $	��317��6    $	��500��6-   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5	      $��0* �6   .+�5   
   >� $��32��6   $	��Top=�6"   $
��Left=�6:   $	��155��6U    � DataContext 5      B   <Keyoti.RapidFindReplace.WPF.RapidFindReplaceControlViewModel  5          BodyHighlightAdornerBrush 5      �� 5       �� Color$ Yellow��6*    �� Opacity$ .3Q�69      BodyHighlightAdornerPen 5      >� 5       >� Brush
 �OO/� >� 	Thickness$ .9Q�64   5      .��5      �� $��0��6   	 �� Orientation$	 
Horizontal=�6'   $
��Left=�6@   .+�5      �� -   5        
 ��Name$
 _searchTextBox��5   V   9   3Keyoti.RapidFindReplace.WPF.RapidFindReplaceControl   
IsFindable$ falseX�6   $	��100��6�   $��2q�6  ��6n   �� *Query+4   .Keyoti.RapidFindReplace.WPF.ConverterInstances   QueryConverter �� 	Converter# Z  �� UpdateSourceTrigger$ PropertyChanged=�.��6+  5      �� 5      -   5         ��Name$ _searchButton��5      $
��Find��6l   ��60   �� *ActualHeight+ �� ElementName$ _searchTextBox����6{   �� *FindTextCommand+��6�   �� $ _searchTextBox�� �� Path$
 Text�5      5      5      �� 5   
   $��0,37,0,2q�6   $
��Auto=�6(   $
 trueX�6X   . �5      /� .T�5      J� .*�6   ��On this Window the RapidFindReplace controls are not used at all - instead the control's ViewModel class (RapidFindReplaceControlViewModel) is used directly.6�   J� 5       .*�6   ��The TextBox is bound to the Query DependencyProperty in RapidFindReplaceControlViewModel, a KeyUp handler is used to trigger as-you-type finds and the Button fires the FindTextCommand in the view model.6�   J� 5!      .*�6   ljThis style of usage allows lower level access and the opportunity to build a Find/Replace UI from scratch.6�   J� 5"      .*�6   kiThe RapidFindReplaceControlViewModel declaration also sets some brush style properties by way of example.6�   5#      5$      �� 5%   
   -   5         ��Name$	 cb1��5%   @   $��Find as you type.��6    d� 	IsChecked$
 TrueY�6/   $
��Left=�6M   $��
155,10,0,0q�6h   $	��Top=�6|   5&      5'      