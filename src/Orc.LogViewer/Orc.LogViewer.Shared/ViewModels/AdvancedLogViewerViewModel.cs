// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Catel.MVVM;

    public class AdvancedLogViewerViewModel : ViewModelBase
    {
        #region Constructors
        public AdvancedLogViewerViewModel()
        {
        }
        #endregion

        #region Properties
        public Type LogListenerType { get; set; }
        #endregion

    }
}