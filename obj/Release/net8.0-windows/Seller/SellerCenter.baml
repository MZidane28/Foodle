   M S B A M L   `   `   `  ����   Project Foodle(    "Project_Foodle.Seller.SellerCenter   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  SellerCenter��$
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
��Left=�$y�	Collapsed=��� $��1��.+��� $��Foodle��#��[  $��48(����#04944F$��0,60,0,0q�$��Center=��� -    ��Name$ SellerCenterButton��$��Seller Center��#��[ $��20,60,20,10q��� -   $ ManageOrderButton��$��Manage Order��#��[ �� -   $ SellerProfileButton��$��Seller Profile��#��[ �� ���#D32F2F$ 10��$��10,350,10,10q�$	��332��._��� -   $��Log Out��#��[ 
�������$��54��$��-5,0,0,0q�� $��403,10,10,10q�.+��� 
�������$ 20��$ 20q�._�� 	 �� $
��Auto ��� $��* �.+��� $��0��$��20,10,20,10q�$��Center=�.+��� $��Total Items:��#��[ $��32(����#1C3132$��0,0,0,10q��� -   $
 TotalItemsText��$��0��#��[  $��48(����#4CAF50�� $��0��$��Center=�$��Center=�.+��� -   $ UploadItemButton��$��Upload New Item��#��[ $	��300��$��60���� -    ��Name$ ActiveItemsListView��$��1��$��20,10,20,10q� �� View �� .P��� $��Image�� �� Width$	 100�� �� CellTemplate �� .R��� $��80��$��80��$��UniformToFill=����� *	ImagePath+�� $
��Name��$	 200�� �� .R��� ���� *Name+{��� *	IsEditing+�� $��Price��$	 100�� �� .R��� ���� *Price+{��� *	IsEditing+�� $��Stock��$	 100�� �� .R��� ���� *Stock+{��� *	IsEditing+�� $��Actions��$	 320�� �� .R���  �� Orientation$ 
Horizontal=�$��Center=�$��5,0,5,0q�.+��� -	   $
��Edit��#��[ $��70��
 � Tag �� �� -
   $
��Save��#��[ $��70�� �� {��� *	IsEditing+�� -   $��Delete��#��[ $	��100�� ��  � -     �Name$ 	MainFrame��  � NavigationUIVisibility$ Hidden=�