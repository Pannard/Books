   M S B A M L   `   `   `  ����@  <Books, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Books.MVVM.ViewsBooks.MVVM.Views  5   	   'clr-namespace:Books.MVVM
Books.MVVM  66   e aSyncfusion.SfSkinManager.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89iLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPFSyncfusion.SfSkinManager 5   	       Books.MVVM.Views.HomePage   5      ^ ZSyncfusion.SfGrid.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.SfInput.Wpf, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89^ ZSyncfusion.Shared.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R	 NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml   	  5   	   0localclr-namespace:Books.MVVM.Views   	  5   	   /
Convertersclr-namespace:Books.MVVM   	  66   gsyncfusionskinLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF   	  5   	     � Title$  Library��5   	   $	��450��6   $	��800��6&   ,  &Syncfusion.SfSkinManager.SfSkinManager   VisualStyle$ 
FluentDark=�5   	    � 	Resources 5      *  $Books.MVVM.BooleanToYesOrNoConverter   BooleanToYesOrNoConverter��%   &	          5	   
   6/   5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��0��6V   $��2��6f   $��Center=�6z   .+�5      �� -   5        $��Chercher��5      $
��Auto��6(   $��30��65   $��	0,0,200,0q�6B   6U   �� 5      -   5        $��Bibliothèques��5      $
��Auto��6-   $��30��6:   6F   5       � 5   
   -   5          �Name$
 Page��5   +   $��0��69   $��2��6F   $��0��6W   $��2��6g     � NavigationUIVisibility$ Hidden=�6{   5       5!      