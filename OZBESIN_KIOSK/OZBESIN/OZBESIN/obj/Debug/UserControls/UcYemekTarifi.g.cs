﻿#pragma checksum "..\..\..\UserControls\UcYemekTarifi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BF76642FE6F9861F85314012D91544244AC05130DBE66679A4A979FF005FAC2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using OZBESIN.UserControls;
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


namespace OZBESIN.UserControls {
    
    
    /// <summary>
    /// UcYemekTarifi
    /// </summary>
    public partial class UcYemekTarifi : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserControls\UcYemekTarifi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridyemek;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\UserControls\UcYemekTarifi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl1;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\UserControls\UcYemekTarifi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bordergrid;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\UserControls\UcYemekTarifi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PrintImage;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\..\UserControls\UcYemekTarifi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mail;
        
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
            System.Uri resourceLocater = new System.Uri("/OZBESIN;component/usercontrols/ucyemektarifi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UcYemekTarifi.xaml"
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
            
            #line 8 "..\..\..\UserControls\UcYemekTarifi.xaml"
            ((OZBESIN.UserControls.UcYemekTarifi)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridyemek = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 126 "..\..\..\UserControls\UcYemekTarifi.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TabControl1 = ((System.Windows.Controls.TabControl)(target));
            return;
            case 5:
            this.bordergrid = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.PrintImage = ((System.Windows.Controls.Image)(target));
            
            #line 211 "..\..\..\UserControls\UcYemekTarifi.xaml"
            this.PrintImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.PrintImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mail = ((System.Windows.Controls.Image)(target));
            
            #line 213 "..\..\..\UserControls\UcYemekTarifi.xaml"
            this.mail.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.mail_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
