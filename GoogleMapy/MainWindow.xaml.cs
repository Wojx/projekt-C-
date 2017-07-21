using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace GoogleMapy {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
  

    public partial class MainWindow : Window {

        private GeoCoordinate coord;
        private int zoomConst = 18;

        public static bool isDialogShow = false;
        public MainWindow() {
            InitializeComponent();

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            coord = watcher.Position.Location;
           
        }

        //load google maps html file
        private void GridLoaded(object sender, RoutedEventArgs e) {
            var sURL = AppDomain.CurrentDomain.BaseDirectory + @"html\main_map.html";
            Uri uri = new Uri(sURL);
            webBrowser.Navigate(uri);
           
        }
        //set the init properties
        //connection c# -> JS
        private void WebBrowser_OnLoadCompleted(object sender, NavigationEventArgs e) {
            webBrowser.ObjectForScripting = new HTMLConnection();
            if (coord.IsUnknown != true) {
                webBrowser.InvokeScript("initMap", coord.Latitude, coord.Longitude, zoomConst);
            }
            else {
                webBrowser.InvokeScript("initMap", -25.363, 131.044, zoomConst);
            }
        }
        //login method
        private void loginButton_Click(object sender, RoutedEventArgs e) {
            loginLabel.Content = "Zalogowano jako:\n" + loginBox.Text;
            loginBox.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Hidden;
            registerButton.Visibility = Visibility.Hidden;
            loginButton.Visibility = Visibility.Hidden;

            logoutButton.Visibility = Visibility.Visible;
        }

        //logout method
        private void logoutButton_Click(object sender, RoutedEventArgs e) {
            loginLabel.Content = "Logowanie: ";
            loginBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Visible;
            registerButton.Visibility = Visibility.Visible;
            loginButton.Visibility = Visibility.Visible;

            logoutButton.Visibility = Visibility.Hidden;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e) {
            webBrowser.InvokeScript("findAddress", searchTextBox.Text);
        }

        //connection JS -> c#
        //conversion JS array of photosUrl to C# array
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [ComVisible(true)]
        public class HTMLConnection {
            public void ShowGallery(int length, string JStab) {
                string[] URLphotos = JStab.Split(',');
                if (length > 0) {
                    GalleryWindow dialog = new GalleryWindow(URLphotos);
                    dialog.Show();
                }
            }
        }
    }
}
