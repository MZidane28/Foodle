   M S B A M L   `   `   `  ����   Project Foodle)    #Project_Foodle.Foodle.RegisterPage1   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Register��$
��1080��$
��1920�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources    PoppinsBold  PoppinsRegular  PoppinsSemiBold  DropShadowStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius	   Color
   ShadowDepth   Opacity �� 
TargetType �� CornerRadius ��Name��%r  &	        &	 N     &	 �     &	 �     '�� B    'G� <    *�HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�*�FBpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins)�*�PLpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins SemiBold)��� " ��.���  �@J�Effect   $ 20Q�$	 Black��$
 10Q�$	 0.5Q��� " ��.���  � ��
 �������  � ��
 ���� ��  � ��$ 2q���  � ��$ 10q���  � ��$ 20(���  � ��$ 0,5,0,20q���  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $ PART_ContentHost���� " G�.���  � ��
 �������  � ��
 ���� ��  � ��$ 2q���  � ��$ 10q���  � ��$ 20(���  � ��$ 0,5,0,20q���  � �� �� " G�.R��� #��z��#��z��#��z��$ 15��._��� $ PART_ContentHost��.��� ���#1C3132.+�� $��Center=�$��Center=�$	��876��$
��1728�� � ColumnDefinitions �� $��3* ��� $��2* �.+��� $��0�����#0A3D40$ 30�� �� Padding$ 80q�$��2��._��� .+��� #��[  
�������$��40(�$
��Bold"� �� TextAlignment$
 Left=��� $�Welcome to �� �� $�Foodle��#��[  ���#04944F�� $��Delicious Food,��#��[  
�������$��40(�$
��Bold"�$��	0,200,0,0q��� $��Reduce Waste,��#��[  
�������$��40(�$
��Bold"�$��0,0,0,40q��� $��Around The World.��#��[  
�������$��40(�$
��Bold"�$��
0,-40,0,40q��� ���#04944F$ 30��$��2��$��	568,0,0,0q�._��� $	��Top=�$��Center=�$
��1160��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��0,80,0,0q�.+��� #��[  
�������$��32(�$
��Bold"�$��	0,0,490,0q��� $�Register Your Account���� -   ���#0A3D40$ 50��$��50��$��50��$��0,0,10,0q� � Cursor$
 Hand��._�F� "���� ������ � ��� Zb�����@x}	
�������$	��Top=�$
��Left=� J� RenderTransformOrigin$ 
0.01,0.412&�$��35,0,0,0q��� -    ��Name$ ForwardButton�����#0A3D40$ 50��$��50��$��50��$
 Hand��._�F� "������j ��� ���j  Zb�@x}@x}	
�������$	��Top=�$��Center=�$ 
0.01,0.412&��� $	��967��$��
0, 30,0,40q�.+��� $��	Full Name��#��[  
�������$��20(�$
��Bold"�� .+��� -    ��Name$ RegisterFullNameTextBox��$��55���� -   $��FullNamePlaceholder��$��Enter your Full Name�����#C9C9C9$��20(�$	��Top=�$��	24,19,0,0q� J� IsHitTestVisible$ False��$y�Visible=��� $��Username��#��[  
�������$��20(�$
��Bold"�� .+��� -   $ RegisterUsernameTextBox��$��55���� -   $��UsernamePlaceholder��$��Enter your Username�����#C9C9C9$��20(�$	��Top=�$��
24,19,-6,0q�$ False��$y�Visible=��� $��Email��#��[  
�������$��20(�$
��Bold"�� .+��� -   $ RegisterEmailTextBox��$��55���� -   $��EmailPlaceholder��$��Enter your Email�����#C9C9C9$��20(�$	��Top=�$��	24,19,0,0q�$ False��$y�Visible=��� $��Password��#��[  
�������$��20(�$
��Bold"�� .+�G� -	    G�Name$ RegisterPasswordBox��$��55���� -
   $��PasswordPlaceholder��$��Enter your Password�����#C9C9C9$��20(�$	��Top=�$��	24,19,0,0q�$ False��$y�Visible=��� $��Re-type Password��#��[  
�������$��20(�$
��Bold"�� .+�G� -   $ RegisterRePasswordBox��$��55���� -   $��RePasswordPlaceholder��$��Re-enter your Password�����#C9C9C9$��20(�$	��Top=�$��	24,19,0,0q�$ False��$y�Visible=��� $6��0By signing up, you agree to our Terms of Service��#��[ 
�������$��14(�$��Regular"�$��0,50,0,0q��� $ 15�����#0A3D40$��0,-75,-650,30q�$ 10q�$��46��$	��310��._��� -   $��	NEXT PAGE��
�������$��22(�$
��Bold"�#��[  $
 Hand��$ Center=�$��	0,0,0,-10q�