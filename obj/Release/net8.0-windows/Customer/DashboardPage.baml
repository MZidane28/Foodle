   M S B A M L   `   `   `  ����   Project Foodle+    %Project_Foodle.Customer.DashboardPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  	Dashboard��$
��1080��$
��1920�� N� 
Background �#1C3132 � 	Resources    PoppinsBold  PoppinsRegular  PoppinsSemiBold  PoppinsMedium  NavButtonStyle �� 
TargetType �� Property �� Value  ActiveButtonStyle �� BasedOn  InactiveButtonStyle��%�  &	        &	 N     &	 �     &	 �     &	 J    7  &	     7  &	 T    7  *�HDpack://application:,,,/Resources/Fonts/Poppins-Bold.ttf#Poppins Bold)�*�NJpack://application:,,,/Resources/Fonts/Poppins-Regular.ttf#Poppins Regular)�*�PLpack://application:,,,/Resources/Fonts/Poppins-SemiBold.ttf#Poppins SemiBold)�*�LHpack://application:,,,/Resources/Fonts/Poppins-Medium.ttf#Poppins Medium)��� " ��.���  � ��
 �������  � ��
 ���� ��  � ��8   ��  � ��$ 28(���  � ��$ Stretch=���  � ��$ 60����  � ��$ 10q���  � ��
 ���� �� " ��8   .���  � �� �#4CAF50��  � ��
 ������� " ��8   .���  � ��
 ���� ��  � ��
 �����.��� ���#0A3D40.+��� ���#0A3D40$	��398�� �� CornerRadius$ 0,0,20,0�� �� Padding$ 10q�$
��Left=�._�� 	 � RowDefinitions	 �� $
��Auto ��� $��* �.+��� -   
 ��Name$
 ActiveHighlight��
������ $��60��$	��398��$	��Top=�$
��Left=�$y�	Collapsed=��� $��1��.+��� $��Foodle��#��[  $��48(����#04944F$��0,60,0,0q�$��Center=��� -    ��Name$ DashboardButton��$��	Dashboard��#��[ $��20,60,20,10q��� -   $ OrdersButton��$��Orders��#��[ �� -   $ AccountProfileButton��$��Account Profile��#��[ �� ���#D32F2F$ 10��$��10,350,10,10q�$	��332��._��� -   $��Log Out��#��[ 
�������$��54��$��-5,0,0,0q�� $��403,10,10,10q�.+��� 
�������$ 20��$ 20q�._�� 	 �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ Vertical=�$
��0,10q�.+��� $��Alamat Default:��#��[ $��20(�$
��10,0q��� -   $
 DefaultAddressTextBlock��#��[ $��18(�$
��10,5q��� $��Alamat Pengiriman:��#��[ $��20(�$��
10,20,10,0q��� $ 
Horizontal=�$
��10,0q�.+��� -    ��Name$ ShippingAddressTextBox��$	��600��$��40��#��[ $��18(�$
��10,0q� �� 
IsReadOnly$
 True���� -   $ EditAddressButton��$
��Edit��$	��100��$
��10,0q����� " ��# [ .���  � �� �#4CAF50 �� Triggers P�  P� Property � �� P� Value$
 True��. ���  � �� �#D32F2F�� -	   $ SaveAddressButton��$
��Save��#��[ $	��100��$
��10,0q�${�False���� $��1��$
��Auto=�.���� -
    ��Name$ ProductList������ .R��� $��10q�$ 15q����#F5F5F5$ 10��._��� $ Vertical=�.+��� #��[  $��20(����#0A3D40���� *Name+�� #��[ $��16(����#04944F���� *Price+ �� StringFormat$ Harga: Rp {0:N0}���� #��[ $��16(����#0A3D40���� *Stock+$ 	Stok: {0}���� $	��100��$	��100��$��	0,10,0,10q����� *	ImagePath+�� #��[ $��16(����#0A3D40���� *
Username+�� $ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� -   $��-��#��[ $��40������ �� $��40��$��Center=� �� TextAlignment$ Center=�#��[ ���� *SelectedQuantity+�� -   $��+��#��[ $��40������ �� -   $	��Buy��#��[ $	��100��$��0,10,0,0q�
 � Tag �� *ID+ � -     �Name$ 	MainFrame��$��2��  � NavigationUIVisibility$ Hidden=�
�������$
��Auto��