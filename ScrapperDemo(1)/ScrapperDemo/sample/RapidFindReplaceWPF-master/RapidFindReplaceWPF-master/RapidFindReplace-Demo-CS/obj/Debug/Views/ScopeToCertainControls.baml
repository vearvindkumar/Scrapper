   M S B A M L   `   `   `  ����Z  VKeyoti4.RapidFindReplace.WPF, Version=1.0.14.531, Culture=neutral, PublicKeyToken=nulloOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPFKeyoti.RapidFindReplace.WPF  5   	    RapidFindReplace-Demo-CS;   5RapidFindReplace_Demo_CS.Views.ScopeToCertainControls   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   lRapidFindReplaceOclr-namespace:Keyoti.RapidFindReplace.WPF;assembly=Keyoti4.RapidFindReplace.WPF     5   	     � Title$  ScopeToCertainControls��5   	   $	��373��6(   $	��913��65    � 
ResizeMode$ NoResize=�6A   .��5      � .+�5   
   o� $��22��6   $	��Top=�6   .@�5      m� $��_Tools��6   .@�5	      m� $��_Find...��6    m� Command$
 Find��6-   5
      5      >   8Keyoti.RapidFindReplace.WPF.RapidFindReplacePopupControl  5   
   �� 5   
   $��0,22,0,0q�6   .��6"   (&Controls on this side will be searched6J   �� 5   
   $��0,54,512,161q�6   9   3Keyoti.RapidFindReplace.WPF.RapidFindReplaceControl   
IsFindable$
 TrueX�6,   $
��Auto=�6g   . �5      /� .T�5      J� .*�6   $"This RichTextBox will be searched.6@   J� 5      .*�6   ��If no element in a Window is marked with RapidFindReplace:RapidFindReplaceControl.IsFindable (true or false), then all controls are searched, unless explicitly marked with RapidFindReplace:RapidFindReplaceControl.IsFindable="False".6  J� 5      .*�6   ��If any element is marked RapidFindReplace:RapidFindReplaceControl.IsFindable="True", then it and it's children will be searched, unless explicitly marked with RapidFindReplace:RapidFindReplaceControl.IsFindable="False"6�   5      5      �� 5   
   
����  �$��1q�6$   $��0,187,512,0q�68   ._�5      � $
 TrueX�6   .+�5      ��  �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6/   $��	0,0,0,102q�6C   .��6W   RPThis textbox is in a grid that is marked IsFindable="true" and will be searched.6�   �� 5       . $
 Wrap=�6/   $��0,59,0,0q�6C   .��6V   WUThis textbox is also in a grid that is marked IsFindable="true" and will be searched.5      5      5       �� 5$   
   $��
400,22,0,0q�6   .��6$   ,*Controls on this side will NOT be searched6P   �� 5%   
   $��400,54,12,161q�6   . �5&      /� .T�5'      J� .*�6   (&This RichTextBox will NOT be searched.6D   5(      5)      �� 5,   
   
����  �$��1q�6$   $��400,187,12,0q�68   ._�5-      � .+�5/      ��  . $
 Wrap=�6/   $��	0,0,0,102q�6C   .��6W   ZXThis textbox is in a grid that is NOT marked IsFindable="true" and will not be searched.6�   �� 50       . $
 Wrap=�6/   $��0,59,0,0q�6C   .��6V   \ZThis textbox is also in a grid that is not marked IsFindable="true" and won't be searched.6�   51      52      53      54      