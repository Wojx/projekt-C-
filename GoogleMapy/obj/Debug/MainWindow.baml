   M S B A M L   `   `   `  ����E  AGoogleMapy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoogleMapy
GoogleMapy  5   	       GoogleMapy.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GoogleMapy     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Google Mapy��5	   	   $	��700��6   $
��1024��6*   .��5
      � -   5        .+�5   
   (  "System.Windows.Controls.WebBrowser  -   5          Name$ 
webBrowser��5      $
��Left=�6)   $	��649��6D   $��
157,10,0,0q�6Q   $	��Top=�6e   $	��849��6}   6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��	10,62,0,0q�6F   $	��Top=�6Y   $��22��6q   $	��136��6}   $y�Visible=�6�   �� 5   
   -   5         ��Name$ 
loginLabel��5      $��
Logowanie:��6$   $
��Left=�69   $��10,8,0,0q�6T   $	��Top=�6f   $	��136��6~   $y�Visible=�6�   �� 5   
   -   5         ��Name$ loginTextBox��5      $
��Left=�6(   $��23��6C   $��	10,34,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��136��6�   $y�Visible=�6�   �� 5   
   -   5         ��Name$ loginButton��5      $��Zaloguj��6&   $
��Left=�68   $��	84,89,0,0q�6S   $	��Top=�6f   $��62��6~   $y�Visible=�6�   �� 5   
   -   5        $ registerButton��5      $��Zarejestruj��6)   $
��Left=�6?   $��	10,89,0,0q�6Z   $	��Top=�6m   $��62��6�   $y�Visible=�6�   6�   �� 5   
   -   5        $ logoutButton��5      $��Wyloguj��6'   $
��Left=�69   $��	10,57,0,0q�6T   $	��Top=�6g   $��75��6   $y�Hidden=�6�   �� 5   
   -	   5        $ searchTextBox��5      $
��Left=�6)   $��23��6D   $��
10,137,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��136��6�   �� 5   
   -
   5        $ searchButton��5      $��Szukaj��6'   $
��Left=�68   $��
71,165,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ label��5      $��Punkt początkowy:��6   $
��Left=�6;   $��
10,193,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ originTextBox��5      $
��Left=�6)   $��23��6D   $��
10,224,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��136��6�   �� 5   
   -   5        $ label1��5      $��Punkt docelowy:��6    $
��Left=�6:   $��
10,247,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ destinationTextBox��5      $
��Left=�6.   $��23��6I   $��
10,273,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��136��6�   �� 5   
   -   5        $ label2��5      $��Tryb podróży:��6    $
��Left=�68   $��
10,296,0,0q�6S   $	��Top=�6g   �� 5   
   -   5         ��Name$ navigationComboBox��5      $
��Left=�6/   $��
10,322,0,0q�6J   $	��Top=�6^   $	��136��6v   .@�5      �� 	 �� 
IsSelected	 . .��6-   	Samochód67   �� 5      .��6   Rower6"   �� 5      .��6   Transport publiczny60   �� 5      .��6   Pieszo6#   5       �� 5!   
   -   5        $ startNavigationButton��5!      $��Wyznacz trasę��60   $
��Left=�6H   $��
58,349,0,0q�6c   $	��Top=�6w   $��88��6�   6�   �� 5"   
   -   5        $ findMeButton��5"      $��Znajdź mnie��6'   $
��Left=�6=   $��
58,374,0,0q�6X   $	��Top=�6l   $��88��6�   6�   5$      5%      