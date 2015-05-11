// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogWindowViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
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