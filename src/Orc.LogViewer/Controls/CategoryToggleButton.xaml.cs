﻿namespace Orc.LogViewer.Controls
{
    using System.Windows;
    using System.Windows.Media;
    using Converters;

    public partial class CategoryToggleButton
    {
        public CategoryToggleButton()
        {
            InitializeComponent();
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof(IsChecked), 
            typeof(bool), typeof(CategoryToggleButton), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public int EntryCount
        {
            get { return (int)GetValue(EntryCountProperty); }
            set { SetValue(EntryCountProperty, value); }
        }

        public static readonly DependencyProperty EntryCountProperty = DependencyProperty.Register(nameof(EntryCount), 
            typeof(int), typeof(CategoryToggleButton), new PropertyMetadata(0));


        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register(nameof(Category),
            typeof(string), typeof(CategoryToggleButton), new PropertyMetadata("", 
                (sender, args) => ((CategoryToggleButton)sender).OnCategoryChanged(args)));

        private void OnCategoryChanged(DependencyPropertyChangedEventArgs args)
        {
            var brushes = CategoryBorderBrushConverter.BrushCache;

            var newBrushName = args.NewValue as string;
            if (string.IsNullOrWhiteSpace(newBrushName))
            {
                return;
            }

            if (!brushes.TryGetValue(newBrushName, out var brush))
            {
                return;
            }

            var accentColor = brush.Color;
            var accentColor20 = Color.FromArgb(51, accentColor.R, accentColor.G, accentColor.B);
            var accentColor40 = Color.FromArgb(102, accentColor.R, accentColor.G, accentColor.B);
            var accentColor60 = Color.FromArgb(153, accentColor.R, accentColor.G, accentColor.B);

            var accentColorBrush = new SolidColorBrush(accentColor);
            var accentColorBrush20 = new SolidColorBrush(accentColor20);
            var accentColorBrush40 = new SolidColorBrush(accentColor40);
            var accentColorBrush60 = new SolidColorBrush(accentColor60);

            Resources.Add("Orc.Brushes.Control.Default.Border", accentColorBrush40);

            Resources.Add("Orc.Brushes.Control.MouseOver.Background", accentColorBrush20);
            Resources.Add("Orc.Brushes.Control.MouseOver.Border", accentColorBrush40);
            Resources.Add("Orc.Brushes.Control.Pressed.Background", accentColorBrush40);
            Resources.Add("Orc.Brushes.Control.Pressed.Border", accentColorBrush60);
            Resources.Add("Orc.Brushes.Control.Disabled.Background", accentColorBrush20);
            Resources.Add("Orc.Brushes.Control.Checked.Background", accentColorBrush);
            Resources.Add("Orc.Brushes.AccentColor20", accentColorBrush20);
            Resources.Add("Orc.Brushes.AccentColor40", accentColorBrush40);
        }

        public void Toggle()
        {
            ToggleButton.Toggle();
        }
    }
}
