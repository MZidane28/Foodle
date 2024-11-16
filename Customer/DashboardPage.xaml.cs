using System.Windows;
using System.Windows.Controls;
using Project_Foodle.Foodle;

namespace Project_Foodle.Customer
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            DashboardButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(DashboardButton);
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
                    default:
                        break;
                }
                NavigationService.RemoveBackEntry(); // Menghapus entry navigasi sebelumnya
            }
        }

        private void ResetButtonStyles()
        {
            DashboardButton.Style = (Style)FindResource("InactiveButtonStyle");
            OrdersButton.Style = (Style)FindResource("InactiveButtonStyle");
            MessagesButton.Style = (Style)FindResource("InactiveButtonStyle");
            SettingsButton.Style = (Style)FindResource("InactiveButtonStyle");
            AccountProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
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
    }
}
