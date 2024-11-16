using Npgsql;
using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace Project_Foodle.Foodle
{
    public partial class RegisterPage1 : Window
    {
        // Make isNextButtonClicked static to persist across instances
        private static bool isNextButtonClicked = false;
        //tambah sini


        // Default constructor
        public RegisterPage1()
        {
            InitializeComponent();
        }

        // Constructor that receives data including repassword from RegisterPage2
        public RegisterPage1(string fullName, string username, string email, string password, string repassword)
        {
            InitializeComponent();

            // Fill fields with existing data
            RegisterFullNameTextBox.Text = fullName;
            RegisterUsernameTextBox.Text = username;
            RegisterEmailTextBox.Text = email;
            RegisterPasswordBox.Password = password;
            RegisterRePasswordBox.Password = repassword;

            FullNamePlaceholder.Visibility = string.IsNullOrWhiteSpace(fullName) ? Visibility.Visible : Visibility.Collapsed;
            UsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(username) ? Visibility.Visible : Visibility.Collapsed;
            EmailPlaceholder.Visibility = string.IsNullOrWhiteSpace(email) ? Visibility.Visible : Visibility.Collapsed;
            PasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(password) ? Visibility.Visible : Visibility.Collapsed;
            RePasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(repassword) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Back Button Click Event Handler (navigate to the Login page)
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        // Forward Button Click Event Handler (Navigate to RegisterPage2 only if NextButton was clicked)
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isNextButtonClicked)
            {
                MessageBox.Show("Please click the Next button first.");
                return;
            }

            var registerPage2 = new RegisterPage2(
                RegisterFullNameTextBox.Text,
                RegisterUsernameTextBox.Text,
                RegisterEmailTextBox.Text,
                RegisterPasswordBox.Password,
                RegisterRePasswordBox.Password); // Pass repassword to RegisterPage2
            registerPage2.Show();
            this.Close();
        }

        // Next Button Click Event Handler (Navigate to RegisterPage2 with validation)
        public void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields and password match before moving forward
            if (AreFieldsValid() && IsPasswordMatching())
            {
                isNextButtonClicked = true;  // Set static variable to true
                var registerPage2 = new RegisterPage2(
                    RegisterFullNameTextBox.Text,
                    RegisterUsernameTextBox.Text,
                    RegisterEmailTextBox.Text,
                    RegisterPasswordBox.Password,
                    RegisterRePasswordBox.Password); // Pass repassword to RegisterPage2

                registerPage2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please ensure all fields are filled and passwords match.");
            }
        }

        // Validate that all required fields are filled
        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(RegisterFullNameTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterUsernameTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterEmailTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterPasswordBox.Password) &&
                   !string.IsNullOrWhiteSpace(RegisterRePasswordBox.Password);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Check if passwords match
        private bool IsPasswordMatching()
        {
            return RegisterPasswordBox.Password == RegisterRePasswordBox.Password;
        }

        // Focus event handlers for placeholders (to show/hide placeholders as user types)
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
