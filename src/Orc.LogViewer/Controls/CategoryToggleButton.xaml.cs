namespace Orc.LogViewer.Controls
{
    using System.Windows;

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
            typeof(string), typeof(CategoryToggleButton), new PropertyMetadata(""));


        public void Toggle()
        {
            ToggleButton.Toggle();
        }
    }
}
