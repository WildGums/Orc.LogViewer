// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.ViewModels
{
    using System;
    using System.Windows.Media;
    using Catel.Logging;
    using Catel.MVVM;

    public class AdvancedLogViewerViewModel : ViewModelBase
    {
        private Brush _accentColorBrushProperty;

        #region Constructors
        public AdvancedLogViewerViewModel()
        {
        }
        #endregion

        #region Properties
        public Type LogListenerType { get; set; }

        public bool IgnoreCatelLogging { get; set; }

        public bool ShowTypeNames { get; set; }

        public bool ShowFilterBox { get; set; }

        public LogEvent Level { get; set; }

        public Brush AccentColorBrush
        {
            get { return _accentColorBrushProperty; }
            set
            {
                if (_accentColorBrushProperty == value)
                {
                    return;
                }

                _accentColorBrushProperty = value;
                var accentColor = ((SolidColorBrush) AccentColorBrush).Color;
                accentColor.CreateAccentColorResourceDictionary();
                RaisePropertyChanged("AccentColorBrush");
            }
        }
        #endregion
    }
}