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
using System.Windows.Shapes;

namespace GoogleMapy {
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window {
        public RegisterWindow() {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, RoutedEventArgs e) {
            if (firstPasswordBox.Password == secondPasswordBox.Password) {
                DialogResult = true;
                Close();
            }
            else {
                MessageBox.Show("Hasła nie są identyczne", "GoogleMapy", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
            Close();
        }
    }
}
