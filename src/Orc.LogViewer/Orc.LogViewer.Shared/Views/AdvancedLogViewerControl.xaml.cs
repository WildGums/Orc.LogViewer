// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerControl.xaml.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security;
    using System.Windows;
    using Catel.MVVM.Views;
    using Controls.Logging;

    /// <summary>
    /// Interaction logic for AdvancedLogViewerControl.xaml.
    /// </summary>
    public partial class AdvancedLogViewerControl
    {
        private void ClearLog_OnClick(object sender, RoutedEventArgs e)
        {
            LogViewerControl.Clear();
        }

        private void CopyLog_OnClick(object sender, RoutedEventArgs e)
        {
             LogViewerControl.CopyToClipboard();
        }

        private void OpenInEditor_OnClick(object sender, RoutedEventArgs e)
        {
            var path = string.Empty;
            try
            {
                path = Path.GetTempPath();
            }
            catch (SecurityException)
            {
                return;
            }
            var filePath = CreateLogFile(path);
            Process.Start(filePath);
        }

        private string CreateLogFile(string path)
        {
            var filePath = Path.Combine(path, "log.txt");
            File.WriteAllText(filePath, GetLog());
            return filePath;
        }

        private string GetLog()
        {
            LogViewerControl.CopyToClipboard();

            var dataObject = Clipboard.GetDataObject();
            if (dataObject == null)
            {
                return string.Empty;
            }

            return dataObject.GetData(DataFormats.Text).ToString();
        }

        #region Properties
        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public Type LogListenerType
        {
            get { return (Type) GetValue(LogListenerTypeProperty); }
            set { SetValue(LogListenerTypeProperty, value); }
        }

        public static readonly DependencyProperty LogListenerTypeProperty = DependencyProperty.Register("LogListenerType", typeof (Type),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(typeof (LogViewerLogListener), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Constructors
        static AdvancedLogViewerControl()
        {
            typeof (AdvancedLogViewerControl).AutoDetectViewPropertiesToSubscribe();
        }

        public AdvancedLogViewerControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}