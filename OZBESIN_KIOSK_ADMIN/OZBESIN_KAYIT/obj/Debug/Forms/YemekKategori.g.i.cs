﻿#pragma checksum "..\..\..\Forms\YemekKategori.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2A6F8215C7B234ACC7E84F3DF4CE299D1A148C0B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using OZBESIN_KAYIT.Forms;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace OZBESIN_KAYIT.Forms {
    
    
    /// <summary>
    /// YemekKategori
    /// </summary>
    public partial class YemekKategori : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Forms\YemekKategori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Aramatxt;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Forms\YemekKategori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid katgrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Forms\YemekKategori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YemekKategoriIDtxt;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Forms\YemekKategori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YemekKategoriAdtxt;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Forms\YemekKategori.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OZBESIN_KAYIT;component/forms/yemekkategori.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\YemekKategori.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Forms\YemekKategori.xaml"
            ((OZBESIN_KAYIT.Forms.YemekKategori)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\..\Forms\YemekKategori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Kaydetbtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\..\Forms\YemekKategori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Silbtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\..\Forms\YemekKategori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Yenibtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\..\Forms\YemekKategori.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Guncelbtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Aramatxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\Forms\YemekKategori.xaml"
            this.Aramatxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Aramatxt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.katgrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.YemekKategoriIDtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.YemekKategoriAdtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.datagrd = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\..\Forms\YemekKategori.xaml"
            this.datagrd.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listKategori_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

