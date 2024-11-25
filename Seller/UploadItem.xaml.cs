using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Npgsql;
using Project_Foodle.Foodle;
using Project_Foodle.Services;
using System.IO;

namespace Project_Foodle.Seller
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }
            return false;
        }
    }

    public partial class UploadItem : Page
    {
        private NpgsqlConnection conn;
        private string connString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        private readonly CloudinaryService cloudinaryService;

        public UploadItem()
        {
            InitializeComponent();
            SellerCenterButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(SellerCenterButton);

            // Initialize Cloudinary Service
            cloudinaryService = new CloudinaryService();

            // Initialize database connection
            conn = new NpgsqlConnection(connString);
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                switch (clickedButton.Content.ToString())
                {
                    case "Seller Center":
                        NavigationService.Navigate(new SellerCenter());
                        break;
                    case "Manage Order":
                        NavigationService.Navigate(new ManageOrder());
                        break;
                    case "Messages":
                        NavigationService.Navigate(new MessagesPage());
                        break;
                    case "Settings":
                        NavigationService.Navigate(new SettingsPage());
                        break;
                    case "Seller Profile":
                        NavigationService.Navigate(new SellerProfile());
                        break;
                    default:
                        break;
                }
                NavigationService.RemoveBackEntry();
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Yakin ingin melakukan log out?",
                "Konfirmasi Log Out",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Buka LoginPage sebagai Window
                var loginWindow = new LoginPage(); // LoginPage adalah Window
                loginWindow.Show();

                // Tutup window saat ini
                Window.GetWindow(this)?.Close();
            }
        }

        private void ResetButtonStyles()
        {
            SellerCenterButton.Style = (Style)FindResource("InactiveButtonStyle");
            ManageOrderButton.Style = (Style)FindResource("InactiveButtonStyle");
            SellerProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
        }

        private void SetHighlightPosition(Button button)
        {
            if (button != null)
            {
                ActiveHighlight.Visibility = Visibility.Visible;
                double buttonPositionY = button.TranslatePoint(new Point(0, 0), this).Y;
                Canvas.SetTop(ActiveHighlight, buttonPositionY);
            }
            else
            {
                ActiveHighlight.Visibility = Visibility.Collapsed;
            }
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                ItemImagePreview.Source = bitmap;
            }
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string itemName = ItemNameTextBox.Text;
            string itemPrice = ItemPriceTextBox.Text;
            string itemStock = ItemStockTextBox.Text;
            string itemCategory = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string itemImagePath = ItemImagePreview.Source?.ToString();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(itemPrice) || string.IsNullOrEmpty(itemStock) || string.IsNullOrEmpty(itemCategory))
            {
                MessageBox.Show("Please fill all fields before submitting.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string username = Application.Current.Properties["LoggedUser"] as string;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("User not logged in. Please log in first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string cloudinaryImageUrl = string.Empty;
                if (!string.IsNullOrEmpty(itemImagePath))
                {
                    string imageFilePath = new Uri(itemImagePath).LocalPath;
                    string fileName = System.IO.Path.GetFileName(imageFilePath);

                    // Validasi file path sebelum mengunggah
                    if (!File.Exists(imageFilePath))
                    {
                        MessageBox.Show($"File not found: {imageFilePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    cloudinaryImageUrl = cloudinaryService.UploadImage(imageFilePath);
                }

                conn.Open();
                string query = "INSERT INTO products (name, price, stock, category, image_path, username) VALUES (@name, @price, @stock, @category, @image_path, @username)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("name", itemName);
                    cmd.Parameters.AddWithValue("price", int.Parse(itemPrice));
                    cmd.Parameters.AddWithValue("stock", int.Parse(itemStock));
                    cmd.Parameters.AddWithValue("category", itemCategory);
                    cmd.Parameters.AddWithValue("image_path", cloudinaryImageUrl ?? string.Empty);
                    cmd.Parameters.AddWithValue("username", username);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Item successfully uploaded!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}