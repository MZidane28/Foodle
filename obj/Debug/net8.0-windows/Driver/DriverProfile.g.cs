﻿#pragma checksum "..\..\..\..\Driver\DriverProfile.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4456C4FDF6B3CFA7DBE386C26B76741D49D8FC46"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Project_Foodle.Driver {
    
    
    /// <summary>
    /// DriverProfile
    /// </summary>
    public partial class DriverProfile : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ActiveHighlight;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DriverDashboardButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DriverProfileButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CustomerIDTextBlock;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GenderTextBox;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DobTextBox;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\..\Driver\DriverProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project Foodle;component/driver/driverprofile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Driver\DriverProfile.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ActiveHighlight = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.DriverDashboardButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Driver\DriverProfile.xaml"
            this.DriverDashboardButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DriverProfileButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Driver\DriverProfile.xaml"
            this.DriverProfileButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.CustomerIDTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 98 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmailEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 99 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmailSaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 111 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PhoneEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 112 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PhoneSaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.GenderTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 124 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenderEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 125 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenderSaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.DobTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            
            #line 137 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DobEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 138 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DobSaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            
            #line 150 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PasswordEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 151 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PasswordSaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 156 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MoveToCustomerButton_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 157 "..\..\..\..\Driver\DriverProfile.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MoveToSellerButton_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 164 "..\..\..\..\Driver\DriverProfile.xaml"
            this.MainFrame.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.MainFrame_Navigated);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

