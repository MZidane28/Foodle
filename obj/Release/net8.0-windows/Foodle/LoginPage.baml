   M S B A M L   `   `   `  ����   Project Foodle%    Project_Foodle.Foodle.LoginPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Login��$
��1080��$
��1920�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources    PoppinsBold  PoppinsRegular  PoppinsSemiBold  DropShadowStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius	   Color
   ShadowDepth   Opacity��%a  &	        &	 N     &	 �     &	 �     *�HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�*�FBpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins)�*�GCpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins)��� " ��.���  �@J�Effect   $ 20Q�$	 Black��$
 10Q�$	 0.5Q�.��� ���#1C3132.+�� $��Center=�$��Center=�$	��876��$
��1728�� � ColumnDefinitions �� $��3* ��� $��2* �.+��� $��0�����#0A3D40 �� CornerRadius$ 30��$��2��#��[ ._��� $	��Top=�$
��Left=�$��	80,74,0,0q�$	��881��$	��733��.+��� #��[  
�������$��40(�$
��Bold"� �� TextAlignment$
 Left=��� $�
Welcome to�� �� $�Foodle��#��[  ���#04944F�� $��Tasty Meals, Big Savings��#��[  
�������$��55(�$
��Bold"�$��	0,200,0,0q��� $��All in One Application��#��[  
�������$��55(�$
��Bold"�$��0,0,0,40q��� $A��;We’ve created the smartest way to trade your surplus food��#��[ ���#A5A5A5$��20(�$��SemiBold"�$��	0,-25,0,0q��� $S��Mby creating the smartest way to sell, buy, or deliver all in one application.��#��[ ���#A5A5A5$��20(�$��SemiBold"�$��0,0,0,40q��� $-��'Trade. Enjoy. Save. Start From Rp10.000��#��[  ���#04944F$��22(�$
��Bold"�$��	0,100,0,0q��� $��1�����#04944F$ 30�� �� Padding$ 80q�$��0,0,0,0q�._��� $��Center=�$��Center=�$	��500��$	��768��.+��� $��Login to Your Account and��#��[ 
�������$��24(�$��0,80,0,0q�$
 Left=��� $"��Discover Amazing Food Deals!��#��[  
�������$��24(�$��0,0,0,40q�$
 Left=�$
��Bold"��� $��Email / Username��#��[ 
�������$��20(��� $ 15��
�������$��0,5,0,30q�._��  �� $	��13* ��� $
��487* � � RowDefinitions �� $��6* ��� $	��49* �.+��� -    ��Name$ EmailTextBox��$	��477��$��55��$��10q�$��20(�
������ 
������ $��	12,0,11,0q�$��2��$��2���� -    ��Name$ EmailPlaceholder��$"��Enter your Email or Username��#��[ $��20(����#C9C9C9$	��Top=�$��11,6,0,0q� J� IsHitTestVisible$ False��$��1��$��1���� $��Password��#��[ 
�������$��20(��� $ 15��
�������$��0,5,0,30q�._�� .+�G� -    G�Name$ PasswordBox��$��55��$��10q�$��18(�
���   �
������  G� Password$  ��$��	10,0,16,0q��� -   $ PasswordPlaceholder��$��Enter your Password��#��[ $��20(����#C9C9C9$��Center=�$��24,0,0,0q�$ False���� $ 15�����#0A3D40$��	0,10,0,30q�$ 10q�$��46��._��� -   $��LOGIN��$	��472��$��30��
�������$��22(�$
��Bold"�#��[   � Cursor$
 Hand��$ Center=��� $6��0By signing in, you agree to our Terms of Service��#��[ 
�������$��14(�$
��Wrap=�$ Center=�$��	0,-20,0,0q���  �� Orientation$ 
Horizontal=�$��Center=�$��	0,100,0,0q�.+��� $��Don't have an account? ��#��[ 
�������$��18(��� -   $��Register here.��#��[  
�������$��18(�$
 Hand��$
��Bold"� � -     �Name$ 	MainFrame��  � NavigationUIVisibility$ Hidden=�