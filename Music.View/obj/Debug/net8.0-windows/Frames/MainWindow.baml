   M S B A M L   `   `   `  ����  
Music.View    Music.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      ]� $
��True��6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $Q��KЭто пользовательский элемент управления��6   �� 5      .+�5      �� $!��Добавить песню��6   �� 5      $%��Создать плейлист��6   �� 5      $!��Создать альбом��6   �� 5      $-��'Добавить исполнителя��6   �� 5      $%��Добавить артиста��6   5      5      � 5       � RowDefinitions 5      �� 5       $��* �6$   61   �� 5!      $
��Auto �6$   64   .+�5#      �� $��0��6   $��Stretch=�6*   .@�5$      �� $��Вкладка 1��6   .��5%      �� .+�5&   "   �� $6��0Содержимое первой вкладки��6-   �� 5'   "   $C��=Содержимое первой первой вкладки��6-   5(      5)      �� 5*      $��Вкладка 2��6   .��5+      �� $6��0Содержимое второй вкладки��6(   5,      5-      � 5.      $��1��6    � ColumnDefinitions 5/      �� 50      $
��Auto �6+   6:   �� 51      $��* �6+   67   �� 52      $
��Auto �6+   6:   .+�54      �� $��0��6   $
��Play��6-   6>   �� 55      $��1��6    � Value$ 50Q�6-    � Minimum$ 0Q�68   	 � Maximum$		 100Q�6D   
 �� SelectionStart$
 0Q�6R   $	��50%��6e    �� IsSelectionRangeEnabled$
 True��56       �� Orientation$ 
Horizontal=�6<   �� 57      $��2��6   $ 50Q�6-   $ 0Q�68   $		 100Q�6D   $
 0Q�6R   $	��100��6e   $
 True��58   ,   $ 
Horizontal=�6K   59      5:      5?      5@      