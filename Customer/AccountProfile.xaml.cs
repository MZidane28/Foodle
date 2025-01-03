﻿using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Foodle;
using Project_Foodle.Seller;
using Project_Foodle.Driver;

namespace Project_Foodle.Customer
{
    public partial class AccountProfile : Page
    {
        private NpgsqlConnection conn;
        private string connString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public AccountProfile()
        {
            InitializeComponent();
            AccountProfileButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(AccountProfileButton);
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string userEmailOrUsername = App.LoggedInEmailorUsername;
                string query = "SELECT id, fullname, username, useremail, userpassword, phone, country, address, gender, dob FROM useraccount WHERE useremail = @Email OR username = @Username";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                    command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameTextBlock.Text = reader["fullname"]?.ToString() ?? "No Name";
                            CustomerIDTextBlock.Text = reader["id"] != DBNull.Value ? $"ID {reader["id"]} • {reader["username"]}" : "No ID";
                            EmailTextBox.Text = reader["useremail"]?.ToString() ?? "No Email";
                            PhoneTextBox.Text = reader["phone"]?.ToString() ?? "No Phone";
                            GenderTextBox.Text = reader["gender"]?.ToString() ?? "No Gender";
                            DobTextBox.Text = reader["dob"]?.ToString() ?? "No DOB";
                            PasswordTextBox.Text = string.IsNullOrEmpty(reader["userpassword"]?.ToString())
                                ? "No Password"
                                : new string('*', Math.Min(reader["userpassword"].ToString().Length, 12));
                        }
                        else
                        {
                            MessageBox.Show("User not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        // Handler untuk tombol Edit dan Save
        private void EmailEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(EmailTextBox);
        private void PhoneEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(PhoneTextBox);
        private void GenderEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(GenderTextBox);
        private void DobEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(DobTextBox);

        private void EmailSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("useremail", EmailTextBox.Text);
        private void PhoneSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("phone", PhoneTextBox.Text);
        private void GenderSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("gender", GenderTextBox.Text);
        private void DobSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("dob", DobTextBox.Text);

        private void PasswordEditButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(PasswordTextBox);
        }

        private void PasswordSaveButton_Click(object sender, RoutedEventArgs e)
        {
            string rawPassword = PasswordTextBox.Text;
            if (string.IsNullOrEmpty(rawPassword))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            string hashedPassword = HashPassword(rawPassword);
            SaveFieldToDatabase("userpassword", hashedPassword);
            ToggleEditMode(PasswordTextBox);
        }

        // Mengaktifkan atau menonaktifkan mode edit
        private void ToggleEditMode(TextBox textBox)
        {
            textBox.IsReadOnly = !textBox.IsReadOnly;
            textBox.Background = textBox.IsReadOnly
    ? System.Windows.Media.Brushes.Transparent
    : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
        }

        // Menyimpan data ke database
        private void SaveFieldToDatabase(string columnName, string newValue)
        {
            if (string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show($"{columnName} cannot be empty.");
                return;
            }

            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string userEmailOrUsername = App.LoggedInEmailorUsername;
                string query = $"UPDATE useraccount SET {columnName} = @NewValue WHERE useremail = @Email OR username = @Username";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@NewValue", newValue);
                    command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                    command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{columnName} updated successfully.");
                        ResetFieldBackground(columnName);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the field.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        // Fungsi hashing password
        private string HashPassword(string password)
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

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            if (sender is Button clickedButton)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                switch (clickedButton.Content.ToString())
                {
                    case "Dashboard":
                        NavigationService.Navigate(new DashboardPage());
                        break;
                    case "Orders":
                        NavigationService.Navigate(new OrdersPage());
                        break;
                    case "Messages":
                        NavigationService.Navigate(new MessagesPage());
                        break;
                    case "Settings":
                        NavigationService.Navigate(new SettingsPage());
                        break;
                    case "Account Profile":
                        NavigationService.Navigate(new AccountProfile());
                        break;
                }

                NavigationService.RemoveBackEntry();
            }
        }

        private void ResetButtonStyles()
        {
            DashboardButton.Style = (Style)FindResource("InactiveButtonStyle");
            OrdersButton.Style = (Style)FindResource("InactiveButtonStyle");
            AccountProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
        }

        private void SetHighlightPosition(Button button)
        {
            if (button != null)
            {
                ActiveHighlight.Visibility = Visibility.Visible;
                double buttonPositionY = button.TranslatePoint(new Point(0, 0), this).Y;
                Debug.WriteLine($"Button Position Y: {buttonPositionY}");
                Canvas.SetTop(ActiveHighlight, buttonPositionY);
            }
            else
            {
                ActiveHighlight.Visibility = Visibility.Collapsed;
            }
        }

        private void ResetFieldBackground(string columnName)
        {
            // Konversi string warna semula (#04944F) ke Color
            System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#04944F");

            if (columnName == "useremail")
                EmailTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "phone")
                PhoneTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "gender")
                GenderTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "dob")
                DobTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "userpassword")
                PasswordTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
        }

        private void MoveToSellerButton_Click(object sender, RoutedEventArgs e)
        {
            // Pindah ke halaman SellerCenter
            NavigationService.Navigate(new SellerCenter());
        }

        private void MoveToDriverButton_Click(object sender, RoutedEventArgs e)
        {
            // Pindah ke halaman SellerCenter
            NavigationService.Navigate(new DriverDashboard());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // Handle navigation event if necessary
        }
    }
}