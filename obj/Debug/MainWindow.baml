   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   E APSHelpEdit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PSHelpEdit.ControlsPSHelpEdit.Controls 5   	   'clr-namespace:PSHelpEdit
PSHelpEdit 5   	      PSHelpEdit.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   2ctls!clr-namespace:PSHelpEdit.Controls     5   	   *localclr-namespace:PSHelpEdit     5   	     � 
ResizeMode$  CanResizeWithGrip=�5
   	    � Title$ 
MainWindow��5   	   $	��550��5   	   $
��1024��5   	   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *	CmdLoaded+5      .��5      �  � RowDefinitions 5   
   �� 5      $��22 �6   �� 5      $��* �6   �� 5      $��22 �6   .+�5   
   o� -   5         o�Name$ 	_mainMenu��5      $��0��6   .@�5      m� $
��File��6   .@�5      m� $
��Open��6    m� Command 6)   �� *CmdFileOpen+m� 5       $	��New��6   m� 5!      $
��Save��6   m� 5"      $��Save as��6   �� 5#      m� 5$      $��Recent files��6   5%      5&      &   PSHelpEdit.Controls.CommandsCtrl  5(   
   -   5        	  Name$	 _commandsCtrl��5)      $��1��5(      
 � DataContext
 5*      �� *CommandsModel+�� 5+   
   $��2��6   .@�5,      �� .��5-      �� $��Loaded file:��6   $��Segoe UI)�5.      $��12(�5/      $��Regular"�50      51      �� 52      �� 53      .��54      �� $��Segoe UI)�55      $��12(�56      $��Regular"�57      ��54      ��  �� Path$ CurrentLoadedFileName�57      58      59      5:      5;      