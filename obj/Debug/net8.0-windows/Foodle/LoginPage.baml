   M S B A M L   `   `   `  ����  Project Foodle%    Project_Foodle.Foodle.LoginPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $
��1080��6   $
��1920��6%    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5	         PoppinsBold  PoppinsRegular  PoppinsSemiBold  DropShadowStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius	   Color
   ShadowDepth   Opacity��%�  &	        &	 \     &	 �     &	     *�5   
   HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�6o   *�5   
   FBpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins)�6p   *�5   
   GCpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins)�6r   �� 5   
   " ��6(   .�5      ��  �@J�Effect 5        5      $ 20Q�6'   $	 Black��67   $
 10Q�6E   $	 0.5Q�6V   5      5      5      .��5      � ���#1C3132.+�5   
   � $��Center=�6   $��Center=�6*   $	��876��6G   $
��1728��6T    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��2* �6#   .+�5#      �� $��0��6   ���#0A3D40 �� CornerRadius$ 30��6:   $��2��6L   #��[ 6`   ._�5$      �� $	��Top=�6   $
��Left=�65   $��	80,74,0,0q�6P   $	��881��6c   $	��733��6o   .+�5%      �� #��[  6    
�������$��40(�6]   $
��Bold"�6k    �� TextAlignment$
 Left=�6}   �� 5&      $�
Welcome to��6    �� 5'      $�Foodle��6   #��[  6    ���#04944F6J   5(      �� 5*      $��Tasty Meals, Big Savings��6    #��[  6@   
�������$��55(�6}   $
��Bold"�6�   $��	0,200,0,0q�6�   �� 5+      $��All in One Application��6    #��[  6>   
�������$��55(�6{   $
��Bold"�6�   $��0,0,0,40q�6�   �� 5-      $A��;We’ve created the smartest way to trade your surplus food��6    #��[ 6a   ���#A5A5A5$��20(�6�   $��SemiBold"�6�   $��	0,-25,0,0q�6�   �� 5.      $S��Mby creating the smartest way to sell, buy, or deliver all in one application.��6    #��[ 6u   ���#A5A5A5$��20(�6�   $��SemiBold"�6�   $��0,0,0,40q�6�   �� 50      $-��'Trade. Enjoy. Save. Start From Rp10.000��6    #��[  6O   ���#04944F$��22(�6�   $
��Bold"�6�   $��	0,100,0,0q�6�   51      52      �� 57      $��1��6   ���#04944F$ 30��6:    �� Padding$ 80q�6L   $��0,0,0,0q�6Y   ._�58      �� $��Center=�6   $��Center=�68   $	��500��6U   $	��768��6a   .+�59      �� $��Login to Your Account and��6    #��[ 5:       
�������$��24(�5;   3   $��0,80,0,0q�5<       $
 Left=�5=       �� 5>      $"��Discover Amazing Food Deals!��6    #��[  5?       
�������$��24(�5@   3   $��0,0,0,40q�5A       $
 Left=�5B       $
��Bold"�5C       �� 5E      $��Email / Username��6    #��[ 5F       
�������$��20(�5G   3   �� 5I      $ 15��6   
�������$��0,5,0,30q�6B   ._�5J      �  5K      �� 5L   "   $	��13* �63   �� 5M   "   $
��487* �63    � RowDefinitions 5O      �� 5P   "   $��6* �60   �� 5Q   "   $	��49* �60   .+�5T      �� -   5         ��Name$ EmailTextBox��5T   &   $	��477��5U   "   $��55��5V   "   $��10q�5W   "   $��20(�5X   "   
������ 
������ $��	12,0,11,0q�5\   E   $��2��6X   $��2��6i   �� 5^      -   5         ��Name$ EmailPlaceholder��5^   (   $"��Enter your Email or Username��5_   $   #��[ 5`   $   $��20(�5a   $   ���#C9C9C9$	��Top=�5c   $   $��11,6,0,0q�5d   $    J� IsHitTestVisible$ False��5e   $   $��1��6=   $��1��6J   5g      5h      �� 5j      $��Password��6    #��[ 5k      
�������$��20(�5l   #   �� 5m      $ 15��6   
�������$��0,5,0,30q�6B   ._�5n      � .+�5o      G� -   5         G�Name$ PasswordBox��5o   *   $��55��5p   "   $��10q�5q   "   $��18(�5r   "   
���   �
������  G� Password$  ��5u   "   $��	10,0,16,0q�5w   D   �� 5x      -   5        $ PasswordPlaceholder��5x   (   $��Enter your Password��5y       #��[ 5z       $��20(�5{       ���#C9C9C9$��Center=�5}       $��24,0,0,0q�5~       $ False��5       5�      5�      �� 5�      $ 15��6   ���#0A3D40$��	0,10,0,30q�6D   $ 10q�6W   $��46��6d   ._�5�      �� -   5        $��LOGIN��5�   $   $	��472��5�   $   $��30��5�   $   
�������$��22(�5�   $   $
��Bold"�5�   $   #��[  5�   $    � Cursor$
 Hand��5�   $   $ Center=�5�   $   5�   $   5�      �� 5�      $6��0By signing in, you agree to our Terms of Service��6    #��[ 5�       
�������$��14(�5�       $
��Wrap=�5�       $ Center=�5�       $��	0,-20,0,0q�5�       �� 5�       �� Orientation$ 
Horizontal=�6!   $��Center=�5�   !   $��	0,100,0,0q�5�   !   .+�5�      �� $��Don't have an account? ��6$   #��[ 5�   $   
�������$��18(�5�   7   �� 5�      -   5        $��Register here.��5�   $   #��[  5�   $   
�������$��18(�5�   $   $
 Hand��5�   $   $
��Bold"�5�   $   5�   $   5�      5�      5�      5�       � 5�   
   -   5          �Name$ 	MainFrame��5�        � NavigationUIVisibility$ Hidden=�6#   5�      5�      