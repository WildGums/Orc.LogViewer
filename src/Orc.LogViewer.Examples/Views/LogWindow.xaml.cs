// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogWindow.xaml.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.Views
{
    using Catel.Windows;
    using ViewModels;

    public partial class LogWindow
    {
        public LogWindow()
            : this(null)
        {
        }

        public LogWindow(LogWindowViewModel viewModel)
            : base(viewModel, DataWindowMode.Custom)
        {
            InitializeComponent();
        }
    }
}