namespace Orc.LogViewer.Examples.ViewModels
{
    using Catel.MVVM;

    public class LogWindowViewModel : ViewModelBase
    {
        public LogWindowViewModel()
        {
        }

        public override string Title
        {
            get { return "Log window"; }
        }
    }
}
