using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Navigation;
using System.Device.Location;
using System.Linq;

namespace GoogleMapy {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    //set DataBase contex
    public class ApplicationDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<FindTrack> Tracks { get; set; }
        public DbSet<TravelPoint> TravelPoints { get; set; }
    }

    public partial class MainWindow : Window {

        private GeoCoordinate coord;
        private GeoCoordinateWatcher watcher;
        private int zoomConst = 18;
        private double defaultLat = 52.237049;
        private double defaultLng = 21.017532;
        private User User = new User();
        private bool IsLogged = false;
        private ApplicationDbContext db = new ApplicationDbContext();
        private HTMLConnection ObjToConnect;

        public MainWindow() {
            InitializeComponent();
            watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            ObjToConnect = new HTMLConnection(db);
        }
        //create simple hash
        private string createHash(string rawString) {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(rawString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
        //load google maps html file
        private void GridLoaded(object sender, RoutedEventArgs e) {
            var sUrl = AppDomain.CurrentDomain.BaseDirectory + @"html\main_map.html";
            webBrowser.Navigate(new Uri(sUrl));
        }
        //set the init properties
        private void WebBrowser_OnLoadCompleted(object sender, NavigationEventArgs e) {
            webBrowser.ObjectForScripting = ObjToConnect;
            webBrowser.InvokeScript("initMap", defaultLat, defaultLng, zoomConst);
        }
        //find adress script
        private void searchButton_Click(object sender, RoutedEventArgs e) {
            webBrowser.InvokeScript("findAddress", searchTextBox.Text);
        }
        //try to find user localization
        private void findMeButton_Click(object sender, RoutedEventArgs e) {
            coord = watcher.Position.Location;
            if (!coord.IsUnknown) {
                webBrowser.InvokeScript("setMapCenter", coord.Latitude, coord.Longitude, zoomConst);
            }
            else {
                MessageBox.Show("Nie można odnaleźć Twojej lokalizacji!", "GoogleMapy", MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
        }
        //start navigation script
        private void startNavigationButton_Click(object sender, RoutedEventArgs e) {
            string travelMode = "";
            if (navigationComboBox.SelectedIndex == 0) {
                travelMode = "DRIVING";
            } else if (navigationComboBox.SelectedIndex == 1) {
                travelMode = "BICYCLING";
            } else if (navigationComboBox.SelectedIndex == 2) {
                travelMode = "TRANSIT";
            } else if (navigationComboBox.SelectedIndex == 3) {
                travelMode = "WALKING";
            }
            webBrowser.InvokeScript("findDirection", originTextBox.Text, destinationTextBox.Text, travelMode);

        }
        //login method
        private void loginButton_Click(object sender, RoutedEventArgs e) {
            string login = loginTextBox.Text;
            string passHash = createHash(passwordBox.Password);
            var query = db.Users
                          .FirstOrDefault(x => x.Login == login && x.PasswordHash == passHash);
            if (query != null) {
                User = query;
                db.SaveChanges();
                IsLogged = true;
                ObjToConnect.User = User;
                loginLabel.Content = "Zalogowano jako:\n" + loginTextBox.Text;
                loginTextBox.Visibility = Visibility.Hidden;
                passwordBox.Visibility = Visibility.Hidden;
                registerButton.Visibility = Visibility.Hidden;
                loginButton.Visibility = Visibility.Hidden;

                logoutButton.Visibility = Visibility.Visible;
            }
            else {
                MessageBox.Show("Zły login lub hasło!", "GoogleMapy", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //logout method
        private void logoutButton_Click(object sender, RoutedEventArgs e) {
            User = null;
            IsLogged = false;
            ObjToConnect.User = null;
            loginLabel.Content = "Logowanie: ";
            loginTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Visible;
            registerButton.Visibility = Visibility.Visible;
            loginButton.Visibility = Visibility.Visible;

            logoutButton.Visibility = Visibility.Hidden;
        }
        //register new user and save to db
        private void registerButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new RegisterWindow();
            if (dialog.ShowDialog() == true) {
                string login = dialog.loginTextBox.Text;
                string passwordHash = createHash(dialog.firstPasswordBox.Password);
                var query = db.Users
                          .FirstOrDefault(x => x.Login == login);
                if (query == null) {
                    var user = new User();
                    user.Login = login;
                    user.PasswordHash = passwordHash;
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Rejestracja przebiegła pomyślnie!", "GoogleMapy", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else {
                    MessageBox.Show("Nazwa użytkownika zajęta!", "GoogleMapy", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
           
        }
    }
}

