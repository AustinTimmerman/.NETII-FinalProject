   M S B A M L   `   `   `  ����J  FWPFPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFPresentationWPFPresentation  5   	        WPFPresentation.CardDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPFPresentation     5   	     � Title$  
CardDetail��5   	   $	��800��6   $	��650��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � ShowInTaskbar .  ���	#FF5691BB.��5	      � .+�5
   
   � -   5         �Name$ grdOneCardDetail��5
   &   $y�	Collapsed=�6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $	��350 �6    �� 5      �� 5      $��50 �6    �� 5      $��20 �6    �� 5      $��20 �6    �� 5       � ColumnDefinitions 5      �� 5      .+�5      �� -   5         ��Name$ lblCardName��5      $��0��6)   $��0��66   $��Card Name Here��6F   $��26(�6_   $��Center=�6m   
�������6�   �� 5      -   5         ��Name$ imgCardImage��5      $��1��6*   $��0��67   �� 5      -   5        	 ��Name$	 txtCardDescription��5      $��2��64   $��10q�6A   $��0��6M   $
��Wrap=�6]   $����Partner with Zndrsplt, Eye of Wisdom. At the beginning of combat on your turn, flip a coin until you lose a flip. Whenever a player wins a coin flip, double Okaun's power and toughness until end of turn.Partner with Zndrsplt, Eye of Wisdom. At the beginning of combat on your turn, flip a coin until you lose a flip. Whenever a player wins a coin flip, double Okaun's power and toughness until end of turn.��6q   
�������6  � 5      $��3��6    5      �� 5      �� 5      �� 5      �� 5        5"      �� 5#      �� 5$      .+�5&      �� $��0��6   $��0��6%   $��Rarity��65   $��Center=�6F   $
��Bold"�6y   
���������6c   Z� 6�   �� 5'      $��0��6   $��1��6%   $��	Mana Cost��65   $��Center=�6I   $
��Bold"�6f   
�������6x   �� 5(      $��0��6   $��2��6%   $��Color��65   $��Center=�6E   $
��Bold"�6b   
�������6t   �� 5)      $��0��6   $��4��6%   $��	Card Type��65   $��Center=�6I   $
��Bold"�6f   
�������6x   �� 5+      -   5        $ lblCardRarity��5+      $��1��6/   $��0��6<   $
��Rare��6L   $��Center=�6[   
�������6x   �� 5,      -   5        $ lblCardManaCost��5,      $��1��61   $��1��6>   $��5��6N   $��Center=�6Z   
�������6w   �� 5-      -   5        $ lblCardColor��5-      $��1��6.   $��2��6;   $	��Red��6K   $��Center=�6Y   
�������6v   �� 5.      -   5        $ lblCardType��5.      $��1��6-   $��3��6:   $��Legendary Creature��6J   $��Center=�6g   
�������6�   5/      �� 50      -	   5        
 ��Name$
 chkOneCardOwned��50      $��4��60   $��Owned��6=    d� 	IsChecked$
 TrueY�6M   $��Bottom=�6^   $��5 0 0 0q�6y   
�������6�   �� 51      -
   5        $
 chkOneCardWishlisted��51      $��5��65   $��
Wishlisted��6B   $��Bottom=�6W   $��5 0 0 0q�6r   
�������6�   �� 53      -   5         ��Name$ btnOneCardSave��53      $
��Save��6-   $��0��6<   $��6��6L   $��40��6Y   $��80��6e   $��Center=�6p   $��	0 0 100 0q�6�   {�.  6�   �� 54      -   5        $ btnOneCardCloseCancel��54      $��Close��64   $��1��6D   $��6��6T   $��40��6a   $��80��6m   $��Center=�6x   $��	100 0 0 0q�6�   6�   �� 55      -   5        $ btnOneCardAddToDeck��55      $��Add to Deck��62   $��1��6H   $��6��6X   $��Right=�6e   $	��100��6�   $��50��6�   $��5q�6�   6�   56      � 57   
   -   5        $ grdTwoCardDetail��57      $y�Visible=�6)    58      �� 59      $��50 �6    �� 5:      $	��350 �6    �� 5;      �� 5<      $��50 �6    �� 5=      $��20 �6    �� 5>      $��20 �6    �� 5?       5A      �� 5B      �� 5C      .+�5E      �� -   5        $ lblPrimaryCardName��5E      $��0��60   $��0��6=   $��Card Name Here��6M   $��26(�6f   $��Center=�6t   
�������6�   �� 5F      -   5        $ lblSecondaryCardName��5F      $��0��62   $��1��6?   $��Card Name Here��6O   $��26(�6h   $��Center=�6v   
�������6�   �� 5G      -   5        $ imgPrimaryCardImage��5G      $��1��61   $��0��6>   �� 5H      -   5        $ imgSecondaryCardImage��5H      $��1��63   $��1��6@   �� 5I      $��2��6   .��5J      �� -   5        $	 txtPrimaryCardDescription��5J      $��2��6?   $��10q�6L   $��0��6X   $
��Wrap=�6h   $����Partner with Zndrsplt, Eye of Wisdom. At the beginning of combat on your turn, flip a coin until you lose a flip. Whenever a player wins a coin flip, double Okaun's power and toughness until end of turn.Partner with Zndrsplt, Eye of Wisdom. At the beginning of combat on your turn, flip a coin until you lose a flip. Whenever a player wins a coin flip, double Okaun's power and toughness until end of turn.��6|   
�������6  5K      �� 5M      $��2��6   $��1��6(   .��5N      �� -   5        $!	 txtSecondaryCardDescription��5N      $��2��6A   $��10q�6N   $��1��6Z   $
��Wrap=�6j   $����Partner with Zndrsplt, Eye of Wisdom. At the beginning of combat on your turn, flip a coin until you lose a flip. Whenever a player wins a coin flip, double Okaun's power and toughness until end of turn.��6~   
�������6Q  5O      � 5P      $��3��6    5Q      �� 5R      $��50 �6'   �� 5S      $��70 �6'   �� 5T      $��60 �6'   �� 5U       5W      �� 5X      �� 5Y      .+�5[      �� $��0��6   $��0��6%   $��Rarity��65   $��Center=�6F   $
��Bold"�6y   
���������6c   Z� 6�   �� 5\      $��0��6   $��1��6%   $��	Mana Cost��65   $
��Left=�6I   $
��Bold"�6d   
�������6v   �� 5]      $��0��6   $��2��6%   $��Color��65   $��Center=�6E   $
��Bold"�6b   
�������6t   �� 5^      $��0��6   $��4��6%   $��	Card Type��65   $��Center=�6I   $
��Bold"�6f   
�������6x   �� 5`      -   5        $ lblPrimaryCardRarity��5`      $��1��66   $��0��6C   $
��Rare��6S   $��Center=�6b   
�������6   �� 5a      -   5        $ lblPrimaryCardManaCost��5a      $��1��68   $��1��6E   $��5��6U   $��Center=�6a   
�������6~   �� 5b      -   5        $ lblPrimaryCardColor��5b      $��1��65   $��2��6B   $	��Red��6R   $��Center=�6`   
�������6}   �� 5c      -   5        $ lblPrimaryCardType��5c      $��1��64   $��3��6A   $��Legendary Creature��6Q   $��Center=�6n   
�������6�   5d      � 5f      $��3��6   $��1��6     5g      �� 5h      $��50 �6'   �� 5i      $��70 �6'   �� 5j      $��60 �6'   �� 5k       5m      �� 5n      �� 5o      .+�5r      �� $��0��6   $��0��6%   $��Rarity��65   $��Center=�6F   $
��Bold"�6y   
���������6c   Z� 6�   �� 5s      $��0��6   $��1��6%   $��	Mana Cost��65   $
��Left=�6I   $
��Bold"�6d   
�������6v   �� 5t      $��0��6   $��2��6%   $��Color��65   $��Center=�6E   $
��Bold"�6b   
�������6t   �� 5u      $��0��6   $��4��6%   $��	Card Type��65   $��Center=�6I   $
��Bold"�6f   
�������6x   �� 5w      -   5        $ lblSecondaryCardRarity��5w      $��1��68   $��0��6E   $
��Rare��6U   $��Center=�6d   
�������6�   �� 5x      -   5        $ lblSecondaryCardManaCost��5x      $��1��6:   $��1��6G   $��5��6W   $��Center=�6c   
�������6�   �� 5y      -   5        $ lblSecondaryCardColor��5y      $��1��67   $��2��6D   $	��Red��6T   $��Center=�6b   
�������6   �� 5z      -   5        $ lblSecondaryCardType��5z      $��1��66   $��3��6C   $��Legendary Creature��6S   $��Center=�6p   
�������6�   5{      �� 5|      -   5        $
 chkTwoCardOwned��5|      $��4��60   $��Owned��6=   $
 TrueY�6M   $��Bottom=�6^   
�������6�   �� 5}      -   5        $
 chkTwoCardWishlisted��5}      $��5��65   $��
Wishlisted��6B   $��Bottom=�6W   
�������6�   �� 5      -   5        $ btnTwoCardSave��5      $
��Save��6-   $��0��6<   $��6��6L   $��40��6Y   $��80��6e   $��Right=�6p   $��0 0 10 0q�6�   {�.  6�   �� 5�      -    5        $ btnTwoCardCloseCancel��5�      $��Close��64   $��1��6D   $��6��6T   $��40��6a   $��80��6m   $
��Left=�6x   $��10 0 0 0q�6�   6�   �� 5�      -!   5        $ btnTwoCardAddToDeck��5�      $��Add to Deck��62   $��1��6H   $��6��6X   $��Right=�6e   $	��100��6�   $��50��6�   $��5q�6�   6�   5�      5�      5�      