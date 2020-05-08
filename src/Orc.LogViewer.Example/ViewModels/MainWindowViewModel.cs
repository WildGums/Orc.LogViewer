// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.ViewModels
{
    using System.Windows.Media;
    using Catel.MVVM;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors
        public MainWindowViewModel()
        {
            Title = "Orc.LogViewer example";
        }
        #endregion
    }
}