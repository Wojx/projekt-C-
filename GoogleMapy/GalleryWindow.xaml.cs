using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GoogleMapy
{
    /// <summary>
    /// Interaction logic for GalleryWindow.xaml
    /// </summary>
   


    public partial class GalleryWindow : Window {
        private BitmapImage[] photos;
        private int _actualPhoto = 0;
        public GalleryWindow(string[] url) {
            InitializeComponent();
            photos = new BitmapImage[url.Length];
            for (int i = 0; i < url.Length; i++) {
                Uri pictureUri = new Uri(url[i]);
                photos[i] = new BitmapImage(pictureUri);
            }
            galleryImage.Source = photos[_actualPhoto];
            countLabel.Content = $"{_actualPhoto+1}/{photos.Length}";
        }
        private void nextButton_Click(object sender, RoutedEventArgs e) {
            if (_actualPhoto + 1 < photos.Length) {
                _actualPhoto++;
                galleryImage.Source = photos[_actualPhoto];
                countLabel.Content = $"{_actualPhoto+1}/{photos.Length}";
            }
        }

        private void previousButton_Click(object sender, RoutedEventArgs e) {
            if (_actualPhoto > 0) {
                _actualPhoto--;
                galleryImage.Source = photos[_actualPhoto];
                countLabel.Content = $"{_actualPhoto+1}/{photos.Length}";
            }
        }
    }
}
