// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowView.xaml.cs" company="WildGums">
//   Copyright (c) 2008 - 2014 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.Views
{
    using System;
    using System.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView
    {
        #region Constructors
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        #endregion
    }
}