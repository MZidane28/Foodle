   M S B A M L   `   `   `  ����  Project Foodle+    %Project_Foodle.Driver.DriverDashboard   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Driver Dashboard��5      $
��1080��5      $
��1920��5       N� 
Background �#1C3132 � 	Resources 5	         PoppinsBold  PoppinsRegular  PoppinsSemiBold  PoppinsMedium  NavButtonStyle �� 
TargetType �� Property �� Value  ActiveButtonStyle �� BasedOn  InactiveButtonStyle��%  &	        &	 \     &	 �     &	 "    &	 �    7  &	 �    7  &	 F    7  *�5   
   HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�6o   *�5   
   NJpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins Regular)�6x   *�5   
   PLpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins SemiBold)�6{   *�5   
   LHpack://application:,,,/Resources/Fonts/Poppins-Medium.ttf#Poppins Medium)�6u   �� 5   
   " ��6'   .�5      ��  � ��
 �����6+   �� 5       � ��
 ���� 6+   �� 5       � ��8   6+   �� 5       � ��$ 28(�6)   �� 5       � ��$ Stretch=�64   �� 5       � ��$ 60��6'   �� 5       � ��$ 10q�6'   �� 5       � ��
 ���� 6,   5      �� 5   
   " ��6*   8   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   5       �� 5#   
   " ��6,   8   .�5$      ��  � ��
 ���� 6+   �� 5%       � ��
 �����6+   5&      5'      .��5)      � ���#0A3D40.+�5+   
   �� ���#0A3D40$	��398��6&    �� CornerRadius$ 0,0,20,0��62    �� Padding$ 10q�6J   $
��Left=�6W   ._�5,      � 	 � RowDefinitions	 5-      �� 5.      $
��Auto �6$   �� 5/      $��* �6$   .+�53      �� -   5        
 ��Name$
 ActiveHighlight��53      
������ $��60��55      $	��398��56      $	��Top=�57      $
��Left=�58      $y�	Collapsed=�59      �� 5;      $��1��6   .+�5=      �� $��Foodle��6    #��[  5>       $��48(�5?       ���#04944F$��0,60,0,0q�5A       $��Center=�5B       �� 5E      -   5         ��Name$ DriverDashboardButton��5E      $��Driver Dashboard��6<   #��[ 6W   $��20,60,20,10q�6�   �� 5F      -   5        $ DriverProfileButton��5F      $��Driver Profile��6:   #��[ 6S   6�   �� 5I      ���#D32F2F$ 10��62   $��10,350,10,10q�6D   $	��332��6Z   ._�5J      �� -   5        $��Log Out��5J   !   #��[ 5K      
�������$��54��5M      $��-5,0,0,0q�5N      5O      5P      5Q      5R      5S      � 5V   
   $��403,10,10,10q�6   .+�5X      �� 
�������$ 20��6(   $ 20q�6:   ._�5Y      �� $
��Auto=�6   .��5Z      �� -   5         ��Name$ DashboardStackPanel��5Z   !   .+�5[      �� $��Orders Overview��6$   #��[  5\   $   $��28(�5]   $   ���#4CAF50$��0,0,0,20q�5_   $   5`      5a      5b      5c      5d      5e      