   M S B A M L   `   `   `  ����  Project Foodle(    "Project_Foodle.Customer.BuyProduct   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  
BuyProduct��5      $
��1080��5      $
��1080��5       N� 
Background
 ����� � 	Resources 5	         PoppinsBold  PoppinsRegular  PoppinsSemiBold  PoppinsMedium  NavButtonStyle �� 
TargetType �� Property �� Value  ActiveButtonStyle �� BasedOn��%�  &	        &	 \     &	 �     &	 "    &	 �    7  &	 �    7  *�5   
   HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�6o   *�5   
   NJpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins Regular)�6x   *�5   
   PLpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins SemiBold)�6{   *�5   
   LHpack://application:,,,/Resources/Fonts/Poppins-Medium.ttf#Poppins Medium)�6u   �� 5   
   " ��6'   .�5      ��  � ��
 �����6+   �� 5       � ��
 ���� 6+   �� 5       � ��8   6+   �� 5       � ��$ 28(�6)   �� 5       � ��$ Stretch=�64   �� 5       � ��$ 60��6'   �� 5       � ��$ 10q�6'   �� 5       � ��
 ���� 6,   5      �� 5   
   " ��6*   8   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   5       5!      .��5#      � 
�������.+�5$   
   � $��0,0,20,0q�6   .+�5%      �� 
������� �� CornerRadius$ 20��6(    �� Padding$ 20q�6:   ._�5&      �� .+�5(      �� $��Product Details��6    #��[  67   $��28(�6a   ���#0A3D40$��0,0,0,20q�6�   �� 5+      $��Product ID:��6    #��[ 63   $��20(�6a   ���#0A3D406o   �� 5,      -   5        	 ��Name$	 ProductIDTextBlock��5,       #��[ 6<   $��18(�6i   ���#0A3D40$��0,5,0,10q�6�   �� 5.      $��Name:��6    #��[ 6-   $��20(�6[   ���#0A3D406i   �� 5/      -   5        $	 ProductNameTextBlock��5/       #��[ 6>   $��18(�6k   ���#0A3D40$��0,5,0,10q�6�   �� 51      $��	Category:��6    #��[ 61   $��20(�6_   ���#0A3D406m   �� 52      -   5        $	 ProductCategoryTextBlock��52       #��[ 6B   $��18(�6o   ���#0A3D40$��0,5,0,10q�6�   �� 54      $��Price:��6    #��[ 6.   $��20(�6\   ���#0A3D406j   �� 55      -   5        $	 ProductPriceTextBlock��55       #��[ 6?   $��18(�6l   ���#0A3D40$��0,5,0,10q�6�   �� 57      $��Stock Available:��6    #��[ 68   $��20(�6f   ���#0A3D406t   �� 58      -   5        $	 ProductStockTextBlock��58       #��[ 6?   $��18(�6l   ���#0A3D40$��0,5,0,20q�6�   �� 5;      $��Total Amount:��6    #��[ 65   $��20(�6c   ���#0A3D406q   �� 5<      -   5        $	 TotalAmountTextBlock��5<       #��[ 6>   $��18(�6k   ���#4CAF50$��0,5,0,20q�6�   �� 5?      $��Payment Method:��6    #��[ 67   $��20(�6e   ���#0A3D406s   �� 5@      -   5        
 ��Name$
 PaymentMethodComboBox��5@      $��0,5,0,20q�6>   #��[ 6P   $��18(�6}   .@�5A      �� $
��Cash��6'    �� 
IsSelected$
 True��66   �� 5B      $��Transfer��6'   5C      �� 5F      -   5         ��Name$ ProductImage��5F      $	��200��62   $��	0,20,0,20q�6?   �� 5I      -	   5        $��Purchase��5I      #��[ 60   $	��200��6[   $��50��6g   $��Center=�6s   6�   5J      5K      5L      5M      5N      