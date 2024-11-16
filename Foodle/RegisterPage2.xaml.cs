using Npgsql;
using System;
using System.Text;
using System.Windows;
using System.Security.Cryptography;

namespace Project_Foodle.Foodle
{
    public partial class RegisterPage2 : Window
    {
        //tambah sini
        private string fullName, username, email, password, repassword;

        // Static fields to persist data across instances of RegisterPage2
        private static string phoneNumber = string.Empty;
        private static string country = string.Empty;
        private static string address = string.Empty;
        private static string gender = string.Empty;
        private static string dob = string.Empty;

        public RegisterPage2(string fullName, string username, string email, string password, string repassword)
        {
            InitializeComponent();

            this.fullName = fullName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.repassword = repassword;

            // Load existing data into text fields
            RegisterPhoneNumber.Text = phoneNumber;
            RegisterCountry.Text = country;
            RegisterAddress.Text = address;
            RegisterGender.Text = gender;
            RegisterDOB.Text = dob;

            PhoneNumberPlaceholder.Visibility = string.IsNullOrWhiteSpace(RegisterPhoneNumber.Text) ? Visibility.Visible : Visibility.Collapsed;
            CountryPlaceholder.Visibility = string.IsNullOrWhiteSpace(RegisterCountry.Text) ? Visibility.Visible : Visibility.Collapsed;
            AddressPlaceholder.Visibility = string.IsNullOrWhiteSpace(RegisterAddress.Text) ? Visibility.Visible : Visibility.Collapsed;
            GenderPlaceholder.Visibility = string.IsNullOrWhiteSpace(RegisterGender.Text) ? Visibility.Visible : Visibility.Collapsed;
            DOBPlaceholder.Visibility = string.IsNullOrWhiteSpace(RegisterDOB.Text) ? Visibility.Visible : Visibility.Collapsed;

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreFieldsValid())
            {
                if (RegisterUser())
                {
                    MessageBox.Show("Registration Success!");
                    var mainPage = new LoginPage();
                    mainPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to register user.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(RegisterPhoneNumber.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterCountry.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterAddress.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterGender.Text) &&
                   !string.IsNullOrWhiteSpace(RegisterDOB.Text);
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

        private bool RegisterUser()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "INSERT INTO useraccount (fullname, username, useremail, userpassword, " +
                                 "phone, country, address, gender, dob) VALUES (@FullName, @Username, @Email, " +
                                 "@Password, @Phone, @Country, @Address, @Gender, @DOB)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("FullName", fullName);
                        cmd.Parameters.AddWithValue("Username", username);
                        cmd.Parameters.AddWithValue("Email", email);
                        cmd.Parameters.AddWithValue("Password", HashPassword(password));  // Hash the password
                        cmd.Parameters.AddWithValue("Phone", RegisterPhoneNumber.Text);
                        cmd.Parameters.AddWithValue("Country", RegisterCountry.Text);
                        cmd.Parameters.AddWithValue("Address", RegisterAddress.Text);
                        cmd.Parameters.AddWithValue("Gender", RegisterGender.Text);
                        cmd.Parameters.AddWithValue("DOB", RegisterDOB.Text);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Store data before navigating back to RegisterPage1
            phoneNumber = RegisterPhoneNumber.Text;
            country = RegisterCountry.Text;
            address = RegisterAddress.Text;
            gender = RegisterGender.Text;
            dob = RegisterDOB.Text;

            var registerPage1 = new RegisterPage1(fullName, username, email, password, repassword);
            registerPage1.Show();
            this.Close();
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
