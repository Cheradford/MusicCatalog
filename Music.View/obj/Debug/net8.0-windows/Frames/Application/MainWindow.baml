   M S B A M L   `   `   `  ����  
Music.View    Music.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� $
��True��6   .+�5   
   '  !HandyControl.Controls.ButtonGroup     Orientation$ Vertical=�6   $	��200��60   $��Center=�6?      ButtonGroupSolid#��[  5      .@�5      �� -   5        $%��Добавить артиста��5      60   �� 5      -   5        $��Добавить жанр��5      6-   �� 5      -   5        $!��Создать альбом��5      6.   �� 5      -   5        $!��Добавить песню��5      6.   �� 5      -   5        $%��Создать плейлист��5      60   5      � 5   
    � RowDefinitions 5      �� 5      $��* �6    6-   �� 5      $
��Auto �6    60   .+�5      &   HandyControl.Controls.TabControl  $��0��6   $��Stretch=�6)      IsScrollable$
 True��6G       CanBeClosedByMiddleButton$
 True��5      .@�5      #  HandyControl.Controls.TabItem  $��
Обзор��6      ShowCloseButton$
 True��6,   .��5      �� -   5         ��Name$ ReviewPanel��5   !   $��30q�66   .+�5      ��   TextBlockTitleBold#��[ 6$   $��
Жанры��6P   $
��Left=�6]   �� 5      -   5        $ Genres��5   %   67   �� 5      #��[ 6$   $��Альбомы��6P   $
��Left=�6_   (  "HandyControl.Controls.ScrollViewer  5          IsPenetrating$
 True��6*   .��5!      �� -   5        $ Albums��5!   B    �� Orientation$ 
Horizontal=�6)   6T   5"      5$      5%        5&      $��Вкладка 2��6   .��5'      �� $6��0Содержимое второй вкладки��6    5(      5)        HandyControl.Controls.Row  5*      $��1��6   .+�5+        HandyControl.Controls.Col  	   Span$	 4��6   .��5,      �� -	   5        .��5-      �� $��20��6    $��../../Media/Play.svg��6,   5.      5/        50      $	 16��6   .��51      �� 
 � Value$
 50Q�6    � Minimum$ 0Q�6(    � Maximum$	 100Q�64    �� SelectionStart$ 0Q�6B   $	��400��6U    �� IsSelectionRangeEnabled$
 True��52       �� Orientation$ 
Horizontal=�6<   53        54      $	 4��6   .��55      �� $
 50Q�6   $ 0Q�6(   $	 100Q�64   $ 0Q�6B   $	��100��6U   $
 True��56      $ 
Horizontal=�6<   57      58      59      5:      5;      