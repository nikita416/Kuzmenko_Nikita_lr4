using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Kuzmenko_Nikita_lr4
{
    /// <summary>
    /// Логика взаимодействия для Kuzmenko_Nikita_Login.xaml
    /// </summary>
    public partial class Kuzmenko_Nikita_Login : Window
    {
        public Kuzmenko_Nikita_Login()
        {
            InitializeComponent();
        }
        private void CleanFields_Clicked(object sender, RoutedEventArgs e)
        {
            CleanFields();
        }
        private void CleanFields()
        {
            LoginField.Text = string.Empty;
            PasswordField.Password = string.Empty;
        }
        private void Login_MouseEnter(object sender, MouseEventArgs mouseEventArgs)
        {
            if (sender is Button)
            {
                var button = (Button)sender;
                button.Background = new SolidColorBrush(Colors.Violet);
                button.Foreground = new SolidColorBrush(Colors.LightBlue);
            }
        }
        private void Login_MouseLeave(object sender, MouseEventArgs mouseEventArgs)
        {
            if (sender is Button)
            {
                var button = (Button)sender;
                button.Background = new SolidColorBrush(Colors.BlueViolet);
                button.Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            if (IsLoginValid(LoginField.Text) && IsPasswordValid(PasswordField.Password))
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                CleanFields();
                MessageBox.Show("Некоректні дані.");
            }
        }
        private bool IsLoginValid(string login)
        {
            string phonePattern = @"^\+358\d{9}$"; 
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$"; 

            return !string.IsNullOrWhiteSpace(login) && (Regex.IsMatch(login, phonePattern)
                || Regex.IsMatch(login, emailPattern));
        }

        private bool IsPasswordValid(string password)
        {
            string passwordPattern = @"^(?=[A-Z])(?=(?:[^0-9]*[0-9]){3})\S{6,}$";
            return !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, passwordPattern);
        }
    }
}