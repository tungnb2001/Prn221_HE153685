﻿#pragma checksum "..\..\..\..\View\Add_UpdateSupplier.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5AED9A59E1F906D118834EB622B7E09CE06159EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Project.View;
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


namespace Project.View {
    
    
    /// <summary>
    /// Add_UpdateSupplier
    /// </summary>
    public partial class Add_UpdateSupplier : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbTitle;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSupplierName;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbContactName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPhone;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbEmail;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\View\Add_UpdateSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbAddress;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project;component/view/add_updatesupplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Add_UpdateSupplier.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txbSupplierName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbContactName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 98 "..\..\..\..\View\Add_UpdateSupplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_Sua);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 105 "..\..\..\..\View\Add_UpdateSupplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_Them);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 123 "..\..\..\..\View\Add_UpdateSupplier.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_Huy);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
