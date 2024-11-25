using System.Configuration;
using System.Data;
using System.Windows;

namespace Project_Foodle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string LoggedInEmailorUsername { get; set; }

        public App()
        {
            InitializeComponent();
        }
    }


}
