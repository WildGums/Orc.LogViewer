// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogWindow.xaml.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.Views
{
    using Catel.MVVM;
    using Catel.Windows;
    using ViewModels;

    public partial class LogWindow
    {
        private readonly CommandManagerWrapper _commandManagerWrapper;

        public LogWindow()
            : this(null)
        {
        }

        public LogWindow(LogWindowViewModel viewModel)
            : base(viewModel, DataWindowMode.Custom)
        {
            InitializeComponent();

            _commandManagerWrapper = new CommandManagerWrapper(this);
        }
    }
}