using System.Windows; // Ensure you have this namespace for WPF applications
using System.Windows.Controls; // For controls like TextBox, Button, etc.

namespace Foodle
{
    public partial class RegisterPage : Window
    {
        private bool isNextPageClicked = false; // Flag to track Next Page click

        public RegisterPage()
        {
            InitializeComponent();
        }

        // Back Button Click Event Handler
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page
            var registerPage = new MainWindow();
            registerPage.Show();
            this.Close();
        }

        // Forward Button Click Event Handler
        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if fields are valid before moving to the next page
            if (isNextPageClicked && AreFieldsValid())
            {
                var registerPart2 = new RegisterPart2(); // Navigate to RegisterPart2
                registerPart2.Show();
                this.Close(); // Close current window
            }
            else
            {
                MessageBox.Show("Please click Next Page");
            }
        }

        // Next Button Click Event Handler
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields first
            if (AreFieldsValid())
            {
                // Check password match separately
                if (IsPasswordMatching())
                {
                    ForwardButton.IsEnabled = true; // Enable Forward button if fields are valid
                    var registerPart2 = new RegisterPart2(); // Navigate to RegisterPart2
                    registerPart2.Show();
                    this.Close();
                }
                else
                {
                    // Show warning if passwords do not match
                    MessageBox.Show("Passwords do not match!");
                }
            }
            else
            {
                // Show warning if any required field is empty
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool AreFieldsValid()
        {
            string fullName = RegisterFullNameTextBox.Text;
            string username = RegisterUsernameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Password;

            // Check if any required fields are empty
            return !string.IsNullOrWhiteSpace(fullName) &&
                   !string.IsNullOrWhiteSpace(username) &&
                   !string.IsNullOrWhiteSpace(email) &&
                   !string.IsNullOrWhiteSpace(password);
        }

        private bool IsPasswordMatching()
        {
            string password = RegisterPasswordBox.Password;
            string rePassword = RegisterRePasswordBox.Password;

            // Check if passwords match
            return password == rePassword;
        }


        private void FullNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FullNamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void FullNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterFullNameTextBox.Text))
            {
                FullNamePlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterUsernameTextBox.Text))
            {
                UsernamePlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterEmailTextBox.Text))
            {
                EmailPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterPasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void RePasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RePasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void RePasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterRePasswordBox.Password))
            {
                RePasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}
