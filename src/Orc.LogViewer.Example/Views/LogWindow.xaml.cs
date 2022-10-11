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

        public LogWindow(LogWindowViewModel? viewModel)
            : base(viewModel, DataWindowMode.Custom)
        {
            InitializeComponent();

            _commandManagerWrapper = new CommandManagerWrapper(this);
        }
    }
}
