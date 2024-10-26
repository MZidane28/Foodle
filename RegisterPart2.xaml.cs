using System.Windows; // Ensure you have this namespace for WPF applications
using System.Windows.Controls; // For controls like TextBox, Button, etc.

namespace Foodle
{
    public partial class RegisterPart2 : Window
    {
        private bool isNextPageClicked = false; // Flag to track Next Page click

        public RegisterPart2()
        {
            InitializeComponent();
        }

        // Back Button Click Event Handler
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page
            var registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        // Registration Button Click Event Handler
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields first
            if (AreFieldsValid())
            {
                    var registerPart2 = new MainWindow();
                    registerPart2.Show();
                    this.Close();

                MessageBox.Show("Registration Success!");
            }
            else
            {
                // Show warning if any required field is empty
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool AreFieldsValid()
        {
            string fullName = RegisterPhoneNumber.Text;
            string username = RegisterCountry.Text;
            string email = RegisterAddress.Text;
            string password = RegisterGender.Text;
            string dob = RegisterDOB.Text;

            // Check if any required fields are empty
            return !string.IsNullOrWhiteSpace(fullName) &&
                   !string.IsNullOrWhiteSpace(username) &&
                   !string.IsNullOrWhiteSpace(email) &&
                   !string.IsNullOrWhiteSpace(password) &&
                   !string.IsNullOrWhiteSpace(dob);
        }

        private void PhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            PhoneNumberPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterPhoneNumber.Text))
            {
                PhoneNumberPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Country_GotFocus(object sender, RoutedEventArgs e)
        {
            CountryPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void Country_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterCountry.Text))
            {
                CountryPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Address_GotFocus(object sender, RoutedEventArgs e)
        {
            AddressPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterAddress.Text))
            {
                AddressPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Gender_GotFocus(object sender, RoutedEventArgs e)
        {
            GenderPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void Gender_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterGender.Text))
            {
                GenderPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void DOB_GotFocus(object sender, RoutedEventArgs e)
        {
            DOBPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void DOB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegisterDOB.Text))
            {
                DOBPlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}
