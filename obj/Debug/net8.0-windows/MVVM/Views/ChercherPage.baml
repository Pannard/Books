   M S B A M L   `   `   `  ����@  <Books, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Books.MVVM.ViewsBooks.MVVM.Views  5      'clr-namespace:Books.MVVM
Books.MVVM  64   e aSyncfusion.SfSkinManager.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89iLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPFSyncfusion.SfSkinManager 5
      #    Books.MVVM.Views.ChercherPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Books.MVVM.Views     5      /
Convertersclr-namespace:Books.MVVM     64   ^ ZSyncfusion.SfGrid.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_ [Syncfusion.SfInput.Wpf, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89^	 ZSyncfusion.Shared.WPF, Version=28.2.12.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf    	 6`   gsyncfusionskinLclr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF    	 5
        N� Title$  ChercherPage��5	      ,  &Syncfusion.SfSkinManager.SfSkinManager   VisualStyle$ 
FluentDark=�5       � 	Resources 5      *  $Books.MVVM.BooleanToYesOrNoConverter   BooleanToYesOrNoConverter��%   &	          5   
   6/   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� $��Ajouter��6   $��0��6#   $��1��60   $��20��6@   $	��100��6L   $��Right=�6X   $��0 0 10 0q�6t   ��6�   �� *OnClickSearch+�� 5!   
   $��0��6   $��0��6a   $��2��6q   $��20��6�   $	��350��6�   $
��Left=�6�   $��10 0 0 0q�6�   ��6   �� *BooksFilter+ �� UpdateSourceTrigger$ PropertyChanged=�6�   (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  5$   
   -   5        $��AllBooks��5$   4      ColumnSizer$
 Star=�6    $��1��6D   $��2��6Q   (  "Syncfusion.UI.Xaml.Grid.SfGridBase   AutoGenerateColumns$ False��6b   $��0��6~   $��2��6�   $��	10 0 10 0q�6�      
IsReadOnly$
 True��6  	   ItemsSource	 6�   �� *Books+
   SelectedItem
 6�   �� *SelectedBook+ �� Mode$ TwoWay=�   Columns 5&      ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Titre��6,      MappingName$ Titre��6?     5'      $ Auteur��6,   $ Auteur��6@     5(      $ Genre��6,   $ Genre��6?     5)      $ Edition��6,   $ Edition��6A      DetailsViewDefinition 5-      4  .Syncfusion.UI.Xaml.Grid.TemplateViewDefinition  5Q      5S      5T      5U      