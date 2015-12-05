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

namespace _481kiosk
{
    /// <summary>
    /// Interaction logic for UC_Restaurants.xaml
    /// </summary>
    public partial class UCRestaurants : UserControl
    {
        public UCRestaurants(MainWindow _window)
        {
            InitializeComponent();
        }

        private void distanceChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
            gridRestaurant.Children.RemoveRange(1, gridRestaurant.Children.Count - 1);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;

            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            Uri uri = new Uri("picRaw.jpg");
            bitmapImage.UriSource = uri;
            img.Source = bitmapImage;
            ImageBrush image = new ImageBrush(img.Source);

            TransformGroup transGroup = new TransformGroup();
            transGroup.Children.Add(new ScaleTransform(0.5, 0.5));
            transGroup.Children.Add(new SkewTransform(0.5, 0.5));
            transGroup.Children.Add(new RotateTransform(0, 0.5, 0.5));
            transGroup.Children.Add(new TranslateTransform());

            image.RelativeTransform = transGroup;
            b.Background = image;

         

            grid.Children.Add(b);
            gridRestaurant.Children.Add(grid);


        }


    }
}
