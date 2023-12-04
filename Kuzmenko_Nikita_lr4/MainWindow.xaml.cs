using System.Windows;
using System.Windows.Controls;

namespace Kuzmenko_Nikita_lr4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            if (AllowOpenImage != null && (bool)AllowOpenImage.IsChecked)
            {
                if (sender is Button button && button.Content is Image originalImage)
                {
                    var imageWindow = new Window
                    {
                        Height = 720,
                        Width = 1280,
                        Content = new Image
                        {
                            Source = originalImage.Source,
                            Stretch = originalImage.Stretch
                        },
                        Title = originalImage.Source.ToString(),
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };

                    imageWindow.ShowDialog();
                }
            }
        }
    }
}
