﻿#pragma checksum "..\..\..\View\LoadHTMLContentToSQL.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F6536A2C0BEF981555E8D1C3FCBB12A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace ScrapperDemo.View {
    
    
    /// <summary>
    /// LoadHTMLContentToSQL
    /// </summary>
    public partial class LoadHTMLContentToSQL : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CombxHTMLfilenames;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoadFolder;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDefaultLoadFolder;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnShowHTMLContent;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoadHTMLContentToDB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\LoadHTMLContentToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbxShowhtmlcontent;
        
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
            System.Uri resourceLocater = new System.Uri("/ScrapperDemo;component/view/loadhtmlcontenttosql.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\LoadHTMLContentToSQL.xaml"
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
            this.CombxHTMLfilenames = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.BtnLoadFolder = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\View\LoadHTMLContentToSQL.xaml"
            this.BtnLoadFolder.Click += new System.Windows.RoutedEventHandler(this.BtnLoadFolder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnDefaultLoadFolder = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\View\LoadHTMLContentToSQL.xaml"
            this.BtnDefaultLoadFolder.Click += new System.Windows.RoutedEventHandler(this.BtnDefaultLoadFolder_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnShowHTMLContent = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\View\LoadHTMLContentToSQL.xaml"
            this.BtnShowHTMLContent.Click += new System.Windows.RoutedEventHandler(this.BtnShowHTMLContent_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnLoadHTMLContentToDB = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\View\LoadHTMLContentToSQL.xaml"
            this.BtnLoadHTMLContentToDB.Click += new System.Windows.RoutedEventHandler(this.BtnLoadHTMLContentToDB_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtbxShowhtmlcontent = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

