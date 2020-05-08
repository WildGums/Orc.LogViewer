// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogWindowViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


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