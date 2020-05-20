namespace Orc.LogViewer.Controls
{
    using System.Windows;

    public partial class CategoryPresenter
    {
        public CategoryPresenter()
        {
            InitializeComponent();
        }

        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register(nameof(Category), 
            typeof(string), typeof(CategoryPresenter), new PropertyMetadata(""));
    }
}
