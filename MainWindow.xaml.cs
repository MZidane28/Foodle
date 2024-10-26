using System.Windows;
using System.Windows.Media;

namespace Foodle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmailTextBox.Foreground = Brushes.Gray; // Set initial color for email textbox
            PasswordPlaceholder.Visibility = Visibility.Visible; // Ensure password placeholder is visible
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login button clicked!");
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage(); // Create a new instance of RegisterPage
            registerPage.Show(); // Show the RegisterPage
            this.Close(); // Optional: Close the MainWindow if you don't want it open
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Closes the application
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlaceholder.Visibility = Visibility.Collapsed; // Hide placeholder when textbox is focused
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailPlaceholder.Visibility = Visibility.Visible; // Show placeholder if textbox is empty
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "")
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed; // Hide placeholder when focused
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible; // Show placeholder if empty
            }
        }

        private void EmailTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle text changes if necessary
        }
    }
}
