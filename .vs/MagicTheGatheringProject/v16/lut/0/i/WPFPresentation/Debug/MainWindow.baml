   M S B A M L   `   `   `  ����J  FWPFPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFPresentationWPFPresentation  5   	        WPFPresentation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPFPresentation     5   	   -   5          �Name$  frmMainWindow��5   	    � Title$ 
MTG Helper��5	   	   $	��900��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�66    � WindowState$ 	Maximized=�6[   .��5
      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6   .+�5   
   o� $��0��6   $��	20px, 0pxq�6   .@�5      m� -   5         m�Name$ mnuFile��5      $
��File��6(   .@�5      m� -   5        $ mnuExit��5      $
��Exit��6,   6<   5      m� 5      -   5        $ mnuEdit��5      $
��Edit��6(   .@�5      m� -   5        $ mnuPreferences��5      $��Preferences��63   6J   5      m� 5      -   5        $ mnuHelp��5      $
��Help��6(   .@�5      m� -   5        $ mnuAbout��5      $��About��6-   6>   5      5      � 5   
   $��1��6    5      �� 5        � ColumnDefinitions 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5,      �� -   5         ��Name$ btnLogin��5,   w   $��0px 0px 0px 0pxq�6   $��100px��6.   $
��25px��6<   $��5��6J   $��0��6Z   $��Login��6g    �� 	IsDefault . $��Center=�5-      60   �� 5/      -	   5        $ btnHome��5/   ^   $��30px 20px 30px 20pxq�6   $��0��62   $��1��6B   $
��Home��6O   6^   �� 50      -
   5        $ 
btnMyCards��50   _   $��30px 20px 30px 20pxq�6   $��1��62   $��1��6B   $��Cards��6O   6_   �� 51      -   5        $ 
btnMyDecks��51   _   $��30px 20px 30px 20pxq�6   $��2��62   $��1��6B   $��Decks��6O   6_   �� 52      -   5        $ btnMyMatches��52   a   $��30px 20px 30px 20pxq�6   $��3��62   $��1��6B   $��Matches��6O   6a   �� 53      -   5        $ btnWishlist��53   b   $��30px 20px 30px 20pxq�6   $��4��62   $��1��6B   $��Wishlist��6O   6b   55      � 56   
   $��2��6   .+�57      �� .+�58      &   System.Windows.Controls.DataGrid  59      5:      �� 5<   
   $��5��6   .@�5=      �� -   5        	 ��Name$	 
staMessage��5=      $)��#Welcome. Please log in to continue.��60   $��	20px, 0pxq�6^   5>      5?      5@      