﻿#pragma checksum "..\..\..\..\Foodle\Dashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A447BE33D6F0D5BE47A760C18356FFEC2749F752"
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


namespace Project_Foodle.Foodle {
    
    
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ActiveHighlight;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DashboardButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrdersButton;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MessagesButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SettingsButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Foodle\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountProfileButton;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Foodle\Dashboard.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Project Foodle;V1.0.0.0;component/foodle/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Foodle\Dashboard.xaml"
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
            
            #line 61 "..\..\..\..\Foodle\Dashboard.xaml"
            this.DashboardButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrdersButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Foodle\Dashboard.xaml"
            this.OrdersButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MessagesButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\Foodle\Dashboard.xaml"
            this.MessagesButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SettingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Foodle\Dashboard.xaml"
            this.SettingsButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AccountProfileButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Foodle\Dashboard.xaml"
            this.AccountProfileButton.Click += new System.Windows.RoutedEventHandler(this.NavigateButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

