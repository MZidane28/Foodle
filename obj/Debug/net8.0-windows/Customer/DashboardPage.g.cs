﻿#pragma checksum "..\..\..\..\Customer\DashboardPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "850F3BE8EB7EDBC9F830E0A7C96B5685765840E4"
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


namespace Project_Foodle.Customer {
    
    
    /// <summary>
    /// DashboardPage
    /// </summary>
    public partial class DashboardPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 53 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ActiveHighlight;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DashboardButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrdersButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountProfileButton;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DefaultAddressTextBlock;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ShippingAddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditAddressButton;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveAddressButton;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Customer\DashboardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ProductList;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\Customer\DashboardPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Project Foodle;component/customer/dashboardpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Customer\DashboardPage.xaml"
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
            this.DashboardButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\Customer\DashboardPage.xaml"
            this.DashboardButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrdersButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Customer\DashboardPage.xaml"
            this.OrdersButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AccountProfileButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\Customer\DashboardPage.xaml"
            this.AccountProfileButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 72 "..\..\..\..\Customer\DashboardPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DefaultAddressTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ShippingAddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.EditAddressButton = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\Customer\DashboardPage.xaml"
            this.EditAddressButton.Click += new System.Windows.RoutedEventHandler(this.EditAddress_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SaveAddressButton = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\Customer\DashboardPage.xaml"
            this.SaveAddressButton.Click += new System.Windows.RoutedEventHandler(this.SaveShippingAddress_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ProductList = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 14:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 137 "..\..\..\..\Customer\DashboardPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DecreaseQuantity_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 142 "..\..\..\..\Customer\DashboardPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IncreaseQuantity_Click);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 148 "..\..\..\..\Customer\DashboardPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BuyButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

