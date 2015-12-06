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
        MainWindow _main;
        String newOrigin;
        public UCRestaurants(MainWindow _window, String origin)
        {
            InitializeComponent();
            _main = _window;
            newOrigin = origin;
        }

        private void distanceChecked(object sender, RoutedEventArgs e)
        {
            gridRestaurant.Children.RemoveRange(0, gridRestaurant.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;
            b.Click += btnHolySmokeBBQ_Click;

            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/holy-smoke-bbq.jpg", UriKind.Relative)));
            image.Stretch = Stretch.UniformToFill;
            b.Background = image;

            TextBlock textName = new TextBlock();
            textName.TextWrapping = TextWrapping.Wrap;
            textName.HorizontalAlignment = HorizontalAlignment.Right;
            textName.VerticalAlignment = VerticalAlignment.Bottom;
            textName.FontFamily = new FontFamily("Stencil");
            textName.FontSize = 13.333;
            textName.Margin = new Thickness(0, 130, 50, 0);
            textName.Foreground = Brushes.White;
            textName.Text = "Holy Smoke BBQ";

            b.Content = textName;


            Thickness margin = b.Margin;
            margin.Left = 42;
            margin.Top = 5;
            margin.Right = 42;
            margin.Bottom = 13;
            b.Margin = margin;

            Border border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.Height = 192;
            border.Width = 184;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder = border.Margin;
            marginBorder.Left = 38;
            marginBorder.Top = 8;
            marginBorder.Right = 0;
            marginBorder.Bottom = 0;
            border.Margin = marginBorder;

            TextBlock text1 = new TextBlock();
            text1.Text = "3.7KM              $";
            Thickness text1Margin = text1.Margin;
            text1Margin.Left = 80;
            text1Margin.Top = 10;
            text1Margin.Right = 74;
            text1Margin.Bottom = 0;
            text1.Margin = text1Margin;
            text1.HorizontalAlignment = HorizontalAlignment.Left;
            text1.VerticalAlignment = VerticalAlignment.Bottom;

            grid.Children.Add(b);
            grid.Children.Add(border);
            grid.Children.Add(text1);


            Grid grid2 = new Grid();
            Button b2 = new Button();
            b2.Width = 175;
            b2.Height = 175;
            b2.Click += btnNaina_Click;

            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/naina-kitchen.jpg", UriKind.Relative)));
            image2.Stretch = Stretch.UniformToFill;
            b2.Background = image2;

            TextBlock textName2 = new TextBlock();
            textName2.TextWrapping = TextWrapping.Wrap;
            textName2.HorizontalAlignment = HorizontalAlignment.Right;
            textName2.VerticalAlignment = VerticalAlignment.Bottom;
            textName2.FontFamily = new FontFamily("Stencil");
            textName2.FontSize = 13.333;
            textName2.Margin = new Thickness(0, 130, 50, 0);
            textName2.Foreground = Brushes.White;
            textName2.Text = "Naina's Kitchen";

            b2.Content = textName2;

            Thickness margin2 = b.Margin;
            margin2.Left = 42;
            margin2.Top = 5;
            margin2.Right = 42;
            margin2.Bottom = 13;
            b2.Margin = margin2;

            Border border2 = new Border();
            border2.BorderBrush = Brushes.Black;
            border2.BorderThickness = new Thickness(1);
            border2.Height = 192;
            border2.Width = 184;
            border2.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder2 = border.Margin;
            marginBorder2.Left = 38;
            marginBorder2.Top = 8;
            marginBorder2.Right = 0;
            marginBorder2.Bottom = 0;
            border2.Margin = marginBorder2;

            TextBlock text2 = new TextBlock();
            text2.Text = "5.6KM              $$";
            Thickness text2Margin = text2.Margin;
            text2Margin.Left = 80;
            text2Margin.Top = 10;
            text2Margin.Right = 74;
            text2Margin.Bottom = 0;
            text2.Margin = text1Margin;
            text2.HorizontalAlignment = HorizontalAlignment.Left;
            text2.VerticalAlignment = VerticalAlignment.Bottom;

            grid2.Children.Add(b2);
            grid2.Children.Add(border2);
            grid2.Children.Add(text2);


            Grid grid3 = new Grid();
            Button b3 = new Button();
            b3.Width = 175;
            b3.Height = 175;
            b3.Click += btnRawBar_Click;

            ImageBrush image3 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
            image3.Stretch = Stretch.UniformToFill;
            b3.Background = image3;

            TextBlock textName3 = new TextBlock();
            textName3.TextWrapping = TextWrapping.Wrap;
            textName3.HorizontalAlignment = HorizontalAlignment.Right;
            textName3.VerticalAlignment = VerticalAlignment.Bottom;
            textName3.FontFamily = new FontFamily("Stencil");
            textName3.FontSize = 13.333;
            textName3.Margin = new Thickness(0, 130, 50, 0);
            textName3.Foreground = Brushes.White;
            textName3.Text = "Raw Bar";

            b3.Content = textName3;

            Thickness margin3 = b3.Margin;
            margin3.Left = 42;
            margin3.Top = 5;
            margin3.Right = 42;
            margin3.Bottom = 13;
            b3.Margin = margin3;

            Border border3 = new Border();
            border3.BorderBrush = Brushes.Black;
            border3.BorderThickness = new Thickness(1);
            border3.Height = 192;
            border3.Width = 184;
            border3.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder3 = border3.Margin;
            marginBorder3.Left = 38;
            marginBorder3.Top = 8;
            marginBorder3.Right = 0;
            marginBorder3.Bottom = 0;
            border3.Margin = marginBorder3;

            TextBlock text3 = new TextBlock();
            text3.Text = "5.8KM              $$$";
            Thickness text3Margin = text3.Margin;
            text3Margin.Left = 80;
            text3Margin.Top = 10;
            text3Margin.Right = 74;
            text3Margin.Bottom = 0;
            text3.Margin = text3Margin;
            text3.HorizontalAlignment = HorizontalAlignment.Left;
            text3.VerticalAlignment = VerticalAlignment.Bottom;

            grid3.Children.Add(b3);
            grid3.Children.Add(border3);
            grid3.Children.Add(text3);


            Grid grid4 = new Grid();
            Button b4 = new Button();
            b4.Width = 175;
            b4.Height = 175;
            b4.Click += btnSaltlik_Click;

            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/saltlik.jpg", UriKind.Relative)));
            image4.Stretch = Stretch.UniformToFill;
            b4.Background = image4;

            TextBlock textName4 = new TextBlock();
            textName4.TextWrapping = TextWrapping.Wrap;
            textName4.HorizontalAlignment = HorizontalAlignment.Right;
            textName4.VerticalAlignment = VerticalAlignment.Bottom;
            textName4.FontFamily = new FontFamily("Stencil");
            textName4.FontSize = 13.333;
            textName4.Margin = new Thickness(0, 130, 50, 0);
            textName4.Foreground = Brushes.White;
            textName4.Text = "Saltlik";

            b4.Content = textName4;

            b4.Margin = new Thickness(42, 5, 42, 13);

            Border border4 = new Border();
            border4.BorderBrush = Brushes.Black;
            border4.BorderThickness = new Thickness(1);
            border4.Height = 192;
            border4.Width = 184;
            border4.HorizontalAlignment = HorizontalAlignment.Left;

            border4.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text4 = new TextBlock();
            text4.Text = "6.4KM              $$$$";
            Thickness text4Margin = text4.Margin;
            text4Margin.Left = 80;
            text4Margin.Top = 10;
            text4Margin.Right = 74;
            text4Margin.Bottom = 0;
            text4.Margin = text3Margin;
            text4.HorizontalAlignment = HorizontalAlignment.Left;
            text4.VerticalAlignment = VerticalAlignment.Bottom;

            grid4.Children.Add(b4);
            grid4.Children.Add(border4);
            grid4.Children.Add(text4);


            Grid grid5 = new Grid();
            Button b5 = new Button();
            b5.Width = 175;
            b5.Height = 175;
            b5.Click += btnRiverCafe_Click;

            ImageBrush image5 = new ImageBrush(new BitmapImage(new Uri("Images/hardy4.jpg", UriKind.Relative)));
            image5.Stretch = Stretch.UniformToFill;
            b5.Background = image5;

            TextBlock textName5 = new TextBlock();
            textName5.TextWrapping = TextWrapping.Wrap;
            textName5.HorizontalAlignment = HorizontalAlignment.Right;
            textName5.VerticalAlignment = VerticalAlignment.Bottom;
            textName5.FontFamily = new FontFamily("Stencil");
            textName5.FontSize = 13.333;
            textName5.Margin = new Thickness(0, 130, 50, 0);
            textName5.Foreground = Brushes.White;
            textName5.Text = "River Cafe";

            b5.Content = textName5;

            b5.Margin = new Thickness(42, 5, 42, 13);

            Border border5 = new Border();
            border5.BorderBrush = Brushes.Black;
            border5.BorderThickness = new Thickness(1);
            border5.Height = 192;
            border5.Width = 184;
            border5.HorizontalAlignment = HorizontalAlignment.Left;

            border5.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text5 = new TextBlock();
            text5.Text = "7.4KM              $$$$";
            text5.Margin = new Thickness(80, 10, 74, 0);
            text5.HorizontalAlignment = HorizontalAlignment.Left;
            text5.VerticalAlignment = VerticalAlignment.Bottom;

            grid5.Children.Add(b5);
            grid5.Children.Add(border5);
            grid5.Children.Add(text5);

            Grid grid6 = new Grid();
            Button b6 = new Button();
            b6.Width = 175;
            b6.Height = 175;
            b6.Click += btnHimalayan_Click;

            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/himalayan.jpg", UriKind.Relative)));
            image6.Stretch = Stretch.UniformToFill;
            b6.Background = image6;

            TextBlock textName6 = new TextBlock();
            textName6.TextWrapping = TextWrapping.Wrap;
            textName6.HorizontalAlignment = HorizontalAlignment.Right;
            textName6.VerticalAlignment = VerticalAlignment.Bottom;
            textName6.FontFamily = new FontFamily("Stencil");
            textName6.FontSize = 13.333;
            textName6.Margin = new Thickness(0, 130, 50, 0);
            textName6.Foreground = Brushes.White;
            textName6.Text = "Himalayan";

            b6.Content = textName6;

            b6.Margin = new Thickness(42, 5, 42, 13);

            Border border6 = new Border();
            border6.BorderBrush = Brushes.Black;
            border6.BorderThickness = new Thickness(1);
            border6.Height = 192;
            border6.Width = 184;
            border6.HorizontalAlignment = HorizontalAlignment.Left;

            border6.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text6 = new TextBlock();
            text6.Text = "9.5KM              $$";
            text6.Margin = new Thickness(80, 10, 74, 0);
            text6.HorizontalAlignment = HorizontalAlignment.Left;
            text6.VerticalAlignment = VerticalAlignment.Bottom;

            grid6.Children.Add(b6);
            grid6.Children.Add(border6);
            grid6.Children.Add(text6);


            Grid grid7 = new Grid();
            Button b7 = new Button();
            b7.Width = 175;
            b7.Height = 175;
            b7.Click += btnNotable_Click;

            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/picNotable.jpg", UriKind.Relative)));
            image7.Stretch = Stretch.UniformToFill;
            b7.Background = image7;

            TextBlock textName7 = new TextBlock();
            textName7.TextWrapping = TextWrapping.Wrap;
            textName7.HorizontalAlignment = HorizontalAlignment.Right;
            textName7.VerticalAlignment = VerticalAlignment.Bottom;
            textName7.FontFamily = new FontFamily("Stencil");
            textName7.FontSize = 13.333;
            textName7.Margin = new Thickness(0, 130, 50, 0);
            textName7.Foreground = Brushes.White;
            textName7.Text = "NOTaBLE";

            b7.Content = textName7;

            b7.Margin = new Thickness(42, 5, 42, 13);

            Border border7 = new Border();
            border7.BorderBrush = Brushes.Black;
            border7.BorderThickness = new Thickness(1);
            border7.Height = 192;
            border7.Width = 184;
            border7.HorizontalAlignment = HorizontalAlignment.Left;

            border7.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text7 = new TextBlock();
            text7.Text = "13.2KM              $$$$";
            text7.Margin = new Thickness(80, 10, 74, 0);
            text7.HorizontalAlignment = HorizontalAlignment.Left;
            text7.VerticalAlignment = VerticalAlignment.Bottom;

            grid7.Children.Add(b7);
            grid7.Children.Add(border7);
            grid7.Children.Add(text7);


            Grid grid8 = new Grid();
            Button b8 = new Button();
            b8.Width = 175;
            b8.Height = 175;
            b8.Click += btnCanadianBrewhouse_Click;

            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/canadian-brewhouse.jpg", UriKind.Relative)));
            image8.Stretch = Stretch.UniformToFill;
            b8.Background = image8;

            TextBlock textName8 = new TextBlock();
            textName8.TextWrapping = TextWrapping.Wrap;
            textName8.HorizontalAlignment = HorizontalAlignment.Right;
            textName8.VerticalAlignment = VerticalAlignment.Bottom;
            textName8.FontFamily = new FontFamily("Stencil");
            textName8.FontSize = 13.333;
            textName8.Margin = new Thickness(0, 130, 50, 0);
            textName8.Foreground = Brushes.White;
            textName8.Text = "Canadian Brewhouse";

            b8.Content = textName8;

            b8.Margin = new Thickness(42, 5, 42, 13);

            Border border8 = new Border();
            border8.BorderBrush = Brushes.Black;
            border8.BorderThickness = new Thickness(1);
            border8.Height = 192;
            border8.Width = 184;
            border8.HorizontalAlignment = HorizontalAlignment.Left;

            border8.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text8 = new TextBlock();
            text8.Text = "21.3KM              $$";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);

            Grid.SetRow(grid, 0);
            Grid.SetColumn(grid, 0);
            Grid.SetRow(grid2, 0);
            Grid.SetColumn(grid2, 1);
            Grid.SetRow(grid3, 0);
            Grid.SetColumn(grid3, 2);
            Grid.SetRow(grid4, 1);
            Grid.SetColumn(grid4, 0);
            Grid.SetRow(grid5, 1);
            Grid.SetColumn(grid5, 1);
            Grid.SetRow(grid6, 1);
            Grid.SetColumn(grid6, 2);
            Grid.SetRow(grid7, 2);
            Grid.SetColumn(grid7, 0);
            Grid.SetRow(grid8, 2);
            Grid.SetColumn(grid8, 1);

            gridRestaurant.Children.Add(grid);
            gridRestaurant.Children.Add(grid2);
            gridRestaurant.Children.Add(grid3);
            gridRestaurant.Children.Add(grid4);
            gridRestaurant.Children.Add(grid5);
            gridRestaurant.Children.Add(grid6);
            gridRestaurant.Children.Add(grid7);
            gridRestaurant.Children.Add(grid8);
        }

        private void btnRiverCafe_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "River Cafe";
            _ucInfo.txtBlockTitle.Text = "River Cafe";
            _ucInfo.txtBlockAddress.Text = "25 Princes Island Park SW, Calgary, AB T2P 0R1";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/hardy4.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"The River Cafe is a world class restaurant on Prince's Island Park, Calgary, Alberta, Canada. 

An extraordinary dining experience is to embark on a journey. We have created a beautiful place in an extraordinary setting and have tended to the details that make you feel at home: staff who care, chefs who are passionate about quality and the regional seasonal ingredients that bring to your palate a taste of place.";

            _ucInfo.txtBlockHours.Text = @"Mon - 11:00am to 10:00pm
Tues - 11:00am to 10:00pm
Wed - 11:00am to 10:00pm
Thurs - 11:00am to 10:00pm
Fri - 11:00am to 10:00pm
Sat - 10:00am to 10:00pm
Sun - 10:00am to 10:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnNotable_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "NOTaBLE";
            _ucInfo.txtBlockTitle.Text = "NOTaBLE";
            _ucInfo.txtBlockAddress.Text = "4611 Bowness Rd NW, Calgary, AB T3B0S4";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/picNotable.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"A new chapter in Calgary dining has begun. Slow down and savor the experience with us.

Cozy. Charming. Gourmet Casual. A comfortable “home” to foster a genuine love of great food with a family of passionate culinarians, passionate producers and exceptional service staff. The open kitchen invites you in. The rotisserie turns. Juices drip and sizzle. Sauce on the saucier station bubbles. The menu reflects our passion. A new burger on the menu every month. A selection of wines chosen with care. The Stilton cheesecake, a signature recipe you won’t find anywhere else, completes the experience. Come, relax and enjoy a fresh dining experience at NOtaBLE. We look forward to serving you. As the chef says, “Don’t think fine dining, think great food.”";

            _ucInfo.txtBlockHours.Text = @"Mon - Closed
Tues - 11:30am to 10:00pm
Wed - 11:30am to 10:00pm
Thurs - 11:30am to 10:00pm
Fri - 11:30am to 11:00pm
Sat - 11:00am to 11:00pm
Sun - 11:00am to 9:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnRawBar_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Raw Bar";
            _ucInfo.txtBlockTitle.Text = "Raw Bar";
            _ucInfo.txtBlockAddress.Text = "119 12 Avenue Southwest, Calgary, AB T2R 0G8";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"​Hotel Arts’ award-winning restaurant, Raw Bar recently received an extensive renovation and reopened with a Vietmodern theme and fresh new look. Raw Bar showcases a menu that celebrates Vietnamese heritage with some contemporary influences which we call Vietmodern. Order our well-liked Short Rib Steamed Buns and enjoy our chef-attended action station where a selection of fresh oysters are prepared. Vietmodern dishes are made to pair perfectly with our innovative cocktails. Save room for dessert prepared by our talented pastry team.";

            _ucInfo.txtBlockHours.Text = @"Mon - 4:00pm to 11:00pm
Tues - 4:00pm to 11:00pm
Wed - 4:00pm to 11:00pm
Thurs - 4:00pm to 11:00pm
Fri - 4:00pm to 12:00am
Sat - 4:00pm to 12:00am
Sun - Closed";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnHolySmokeBBQ_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Holy Smoke BBQ";
            _ucInfo.txtBlockTitle.Text = "Holy Smoke BBQ";
            _ucInfo.txtBlockAddress.Text = "4640 Manhattan Rd SE, Calgary, AB T2G 4B5";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/holy-smoke-bbq.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Brisket, ribs, pulled pork, smoked chicken, homemade sides and sauces. Come on in and feed your soul...";

            _ucInfo.txtBlockHours.Text = @"Mon - 10:00am to 8:00pm
Tues - 10:00am to 8:00pm
Wed - 10:00am to 8:00pm
Thurs - 10:00am to 8:00pm
Fri - 10:00am to 8:00pm
Sat - 11:00am to 4:00pm
Sun - Closed";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnCanadianBrewhouse_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Canadian Brewhouse";
            _ucInfo.txtBlockTitle.Text = "Canadian Brewhouse";
            _ucInfo.txtBlockAddress.Text = "9650 Harvest Hills Boulevard North, Calgary, AB T3K 0B3";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/canadian-brewhouse.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Welcome to The Canadian Brewhouse!

Let us introduce ourselves and get to know each other!

The Canadian Brewhouse started in Alberta in 2002 with one location and has grown to 17 locations, fourteen of them in Alberta, including; the Edmonton area, Grande Prairie, Lloydminster, Red Deer, Camrose, Fort McMurray, Calgary, Okotoks and Airdrie. Plus, we’ve opened locations in Regina and Saskatoon, Saskatchewan and Kelowna, British Columbia.

Our one-of-a-kind Canadian themed sports bar & grill has an extensive menu of appetizers, entrees, drinks and amazing specials every night of the week.

You’ll note our Canadian decor starts right when you walk up to our huge Inukshuk at our doors and continues throughout the restaurant in a “cheeky” Canadian fashion.

We promise, when you come to The Canadian Brewhouse, you’ll instantly feel at home, because our house is your house…only we have way more TVs! You won’t find a better selection of screens anywhere for the sports you love! We even provide tabletop speakers for those nights when multiple sports and teams are playing.

We also believe being part of a community means giving back. We’ve been raising funds for various charities through events and fundraisers for over 10 years. Charities like The Stollery Children’s Hospital Foundation, Breast Cancer Research, Prostate Cancer (Movember) and many local initiatives that are important to our neighbours in various communities.

Our house is your house, The Canadian Brewhouse";

            _ucInfo.txtBlockHours.Text = @"Mon - 11:00am to 2:00am
Tues - 11:00am to 2:00am
Wed - 11:00am to 2:00am
Thurs - 11:00am to 2:00am
Fri - 11:00am to 2:00am
Sat - 11:00am to 2:00am
Sun - 11:00am to 2:00am";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnHimalayan_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Himalayan";
            _ucInfo.txtBlockTitle.Text = "Himalayan";
            _ucInfo.txtBlockAddress.Text = "3218 17th Ave SW, Calgary, AB T3E0B3";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/himalayan.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"A popular indian cuisine restaurant located on 17 avenue, with some of the most culturally diverse restaurants in Calgary.";

            _ucInfo.txtBlockHours.Text = @"Mon - 5:00pm to 9:00pm
Tues - 5:00pm to 9:00pm
Wed - 5:00pm to 9:00pm
Thurs - 5:00pm to 9:00pm
Fri - 5:00pm to 10:00pm
Sat - 5:00pm to 10:00pm
Sun - 5:00pm to 9:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnSaltlik_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Saltlik";
            _ucInfo.txtBlockTitle.Text = "Saltlik";
            _ucInfo.txtBlockAddress.Text = "101 8 Ave SW, Calgary, AB T2G5J2";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/saltlik.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Welcome to Saltlik, the quintessential modern steakhouse.
Our menu of comfortable luxury will please not only the true steak lover, but has enough variety to satisfy any appetite. The quality ingredients we use shine through in every dish.
Where will you be joining us?";

            _ucInfo.txtBlockHours.Text = @"Mon - 11:00am to 11:00pm
Tues - 11:00am to 11:00pm
Wed - 11:00am to 11:00pm
Thurs - 11:00am to 11:00pm
Fri - 11:00am to 11:00pm
Sat - 5:00pm to 11:00pm
Sun - 5:00pm to 10:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnNaina_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);
            UCInfoScreen _ucInfo = new UCInfoScreen(_main, newOrigin);
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Green, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Green, _tabPage); };

            _ucInfo.btnRestaurantsNearby.Visibility = Visibility.Hidden;
            _tabPage.Header = "Naina's Kitchen";
            _ucInfo.txtBlockTitle.Text = "Naina's Kitchen";
            _ucInfo.txtBlockAddress.Text = "8, 2808 Ogden Road Southeast, Calgary, AB T2G 4R7";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/naina-kitchen.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Welcome to Naina's Kitchen

Think back to the times you visited Grandma's, remember the wonderful aromas that hit you as you came in the door. Your mouth would start to water and you couldn't wait to see what was coming. Comfort was the word.

That's exactly what we have created at Naina's - home-made meals using fresh ingredients. 

In our kitchen, everything is made from scratch - the fries and burgers, the mac'n cheese, the salads, the baked goods, and the list goes on. 

Comfort food at its best!! ";

            _ucInfo.txtBlockHours.Text = @"Mon - Closed
Tues - 11:00am to 3:00pm
Wed - 11:00am to 3:00pm
Thurs - 11:00am to 8:00pm
Fri - 11:00am to 8:00pm
Sat - 11:00am to 8:00pm
Sun - Closed";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void restPriceChecked_Checked(object sender, RoutedEventArgs e)
        {
            gridRestaurant.Children.RemoveRange(0, gridRestaurant.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;
            b.Click += btnHolySmokeBBQ_Click;

            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/holy-smoke-bbq.jpg", UriKind.Relative)));
            image.Stretch = Stretch.UniformToFill;
            b.Background = image;

            TextBlock textName = new TextBlock();
            textName.TextWrapping = TextWrapping.Wrap;
            textName.HorizontalAlignment = HorizontalAlignment.Right;
            textName.VerticalAlignment = VerticalAlignment.Bottom;
            textName.FontFamily = new FontFamily("Stencil");
            textName.FontSize = 13.333;
            textName.Margin = new Thickness(0, 130, 50, 0);
            textName.Foreground = Brushes.White;
            textName.Text = "Holy Smoke BBQ";

            b.Content = textName;

            Thickness margin = b.Margin;
            margin.Left = 42;
            margin.Top = 5;
            margin.Right = 42;
            margin.Bottom = 13;
            b.Margin = margin;

            Border border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            border.Height = 192;
            border.Width = 184;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder = border.Margin;
            marginBorder.Left = 38;
            marginBorder.Top = 8;
            marginBorder.Right = 0;
            marginBorder.Bottom = 0;
            border.Margin = marginBorder;

            TextBlock text1 = new TextBlock();
            text1.Text = "3.7KM              $";
            Thickness text1Margin = text1.Margin;
            text1Margin.Left = 80;
            text1Margin.Top = 10;
            text1Margin.Right = 74;
            text1Margin.Bottom = 0;
            text1.Margin = text1Margin;
            text1.HorizontalAlignment = HorizontalAlignment.Left;
            text1.VerticalAlignment = VerticalAlignment.Bottom;

            grid.Children.Add(b);
            grid.Children.Add(border);
            grid.Children.Add(text1);


            Grid grid2 = new Grid();
            Button b2 = new Button();
            b2.Width = 175;
            b2.Height = 175;
            b2.Click += btnNaina_Click;

            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/naina-kitchen.jpg", UriKind.Relative)));
            image2.Stretch = Stretch.UniformToFill;
            b2.Background = image2;

            TextBlock textName2 = new TextBlock();
            textName2.TextWrapping = TextWrapping.Wrap;
            textName2.HorizontalAlignment = HorizontalAlignment.Right;
            textName2.VerticalAlignment = VerticalAlignment.Bottom;
            textName2.FontFamily = new FontFamily("Stencil");
            textName2.FontSize = 13.333;
            textName2.Margin = new Thickness(0, 130, 50, 0);
            textName2.Foreground = Brushes.White;
            textName2.Text = "Naina's Kitchen";

            b2.Content = textName2;

            Thickness margin2 = b.Margin;
            margin2.Left = 42;
            margin2.Top = 5;
            margin2.Right = 42;
            margin2.Bottom = 13;
            b2.Margin = margin2;

            Border border2 = new Border();
            border2.BorderBrush = Brushes.Black;
            border2.BorderThickness = new Thickness(1);
            border2.Height = 192;
            border2.Width = 184;
            border2.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder2 = border.Margin;
            marginBorder2.Left = 38;
            marginBorder2.Top = 8;
            marginBorder2.Right = 0;
            marginBorder2.Bottom = 0;
            border2.Margin = marginBorder2;

            TextBlock text2 = new TextBlock();
            text2.Text = "5.6KM              $$";
            Thickness text2Margin = text2.Margin;
            text2Margin.Left = 80;
            text2Margin.Top = 10;
            text2Margin.Right = 74;
            text2Margin.Bottom = 0;
            text2.Margin = text1Margin;
            text2.HorizontalAlignment = HorizontalAlignment.Left;
            text2.VerticalAlignment = VerticalAlignment.Bottom;

            grid2.Children.Add(b2);
            grid2.Children.Add(border2);
            grid2.Children.Add(text2);


            Grid grid3 = new Grid();
            Button b3 = new Button();
            b3.Width = 175;
            b3.Height = 175;
            b3.Click += btnHimalayan_Click;

            ImageBrush image3 = new ImageBrush(new BitmapImage(new Uri("Images/himalayan.jpg", UriKind.Relative)));
            image3.Stretch = Stretch.UniformToFill;
            b3.Background = image3;

            TextBlock textName3 = new TextBlock();
            textName3.TextWrapping = TextWrapping.Wrap;
            textName3.HorizontalAlignment = HorizontalAlignment.Right;
            textName3.VerticalAlignment = VerticalAlignment.Bottom;
            textName3.FontFamily = new FontFamily("Stencil");
            textName3.FontSize = 13.333;
            textName3.Margin = new Thickness(0, 130, 50, 0);
            textName3.Foreground = Brushes.White;
            textName3.Text = "Himalayan";

            b3.Content = textName3;

            Thickness margin3 = b3.Margin;
            margin3.Left = 42;
            margin3.Top = 5;
            margin3.Right = 42;
            margin3.Bottom = 13;
            b3.Margin = margin3;

            Border border3 = new Border();
            border3.BorderBrush = Brushes.Black;
            border3.BorderThickness = new Thickness(1);
            border3.Height = 192;
            border3.Width = 184;
            border3.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness marginBorder3 = border3.Margin;
            marginBorder3.Left = 38;
            marginBorder3.Top = 8;
            marginBorder3.Right = 0;
            marginBorder3.Bottom = 0;
            border3.Margin = marginBorder3;

            TextBlock text3 = new TextBlock();
            text3.Text = "9.5KM              $$";
            Thickness text3Margin = text3.Margin;
            text3Margin.Left = 80;
            text3Margin.Top = 10;
            text3Margin.Right = 74;
            text3Margin.Bottom = 0;
            text3.Margin = text3Margin;
            text3.HorizontalAlignment = HorizontalAlignment.Left;
            text3.VerticalAlignment = VerticalAlignment.Bottom;

            grid3.Children.Add(b3);
            grid3.Children.Add(border3);
            grid3.Children.Add(text3);


            Grid grid4 = new Grid();
            Button b4 = new Button();
            b4.Width = 175;
            b4.Height = 175;
            b4.Click += btnCanadianBrewhouse_Click;

            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/canadian-brewhouse.jpg", UriKind.Relative)));
            image4.Stretch = Stretch.UniformToFill;
            b4.Background = image4;

            TextBlock textName4 = new TextBlock();
            textName4.TextWrapping = TextWrapping.Wrap;
            textName4.HorizontalAlignment = HorizontalAlignment.Right;
            textName4.VerticalAlignment = VerticalAlignment.Bottom;
            textName4.FontFamily = new FontFamily("Stencil");
            textName4.FontSize = 13.333;
            textName4.Margin = new Thickness(0, 130, 50, 0);
            textName4.Foreground = Brushes.White;
            textName4.Text = "Canadian Brewhouse";

            b4.Content = textName4;

            b4.Margin = new Thickness(42, 5, 42, 13);

            Border border4 = new Border();
            border4.BorderBrush = Brushes.Black;
            border4.BorderThickness = new Thickness(1);
            border4.Height = 192;
            border4.Width = 184;
            border4.HorizontalAlignment = HorizontalAlignment.Left;

            border4.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text4 = new TextBlock();
            text4.Text = "21.3KM              $$";
            Thickness text4Margin = text4.Margin;
            text4Margin.Left = 80;
            text4Margin.Top = 10;
            text4Margin.Right = 74;
            text4Margin.Bottom = 0;
            text4.Margin = text3Margin;
            text4.HorizontalAlignment = HorizontalAlignment.Left;
            text4.VerticalAlignment = VerticalAlignment.Bottom;

            grid4.Children.Add(b4);
            grid4.Children.Add(border4);
            grid4.Children.Add(text4);


            Grid grid5 = new Grid();
            Button b5 = new Button();
            b5.Width = 175;
            b5.Height = 175;
            b5.Click += btnRawBar_Click;

            ImageBrush image5 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
            image5.Stretch = Stretch.UniformToFill;
            b5.Background = image5;

            TextBlock textName5 = new TextBlock();
            textName5.TextWrapping = TextWrapping.Wrap;
            textName5.HorizontalAlignment = HorizontalAlignment.Right;
            textName5.VerticalAlignment = VerticalAlignment.Bottom;
            textName5.FontFamily = new FontFamily("Stencil");
            textName5.FontSize = 13.333;
            textName5.Margin = new Thickness(0, 130, 50, 0);
            textName5.Foreground = Brushes.White;
            textName5.Text = "Raw Bar";

            b5.Content = textName5;

            b5.Margin = new Thickness(42, 5, 42, 13);

            Border border5 = new Border();
            border5.BorderBrush = Brushes.Black;
            border5.BorderThickness = new Thickness(1);
            border5.Height = 192;
            border5.Width = 184;
            border5.HorizontalAlignment = HorizontalAlignment.Left;

            border5.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text5 = new TextBlock();
            text5.Text = "5.8KM              $$$";
            text5.Margin = new Thickness(80, 10, 74, 0);
            text5.HorizontalAlignment = HorizontalAlignment.Left;
            text5.VerticalAlignment = VerticalAlignment.Bottom;

            grid5.Children.Add(b5);
            grid5.Children.Add(border5);
            grid5.Children.Add(text5);

            Grid grid6 = new Grid();
            Button b6 = new Button();
            b6.Width = 175;
            b6.Height = 175;
            b6.Click += btnSaltlik_Click;

            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/saltlik.jpg", UriKind.Relative)));
            image6.Stretch = Stretch.UniformToFill;
            b6.Background = image6;

            TextBlock textName6 = new TextBlock();
            textName6.TextWrapping = TextWrapping.Wrap;
            textName6.HorizontalAlignment = HorizontalAlignment.Right;
            textName6.VerticalAlignment = VerticalAlignment.Bottom;
            textName6.FontFamily = new FontFamily("Stencil");
            textName6.FontSize = 13.333;
            textName6.Margin = new Thickness(0, 130, 50, 0);
            textName6.Foreground = Brushes.White;
            textName6.Text = "Saltlik";

            b6.Content = textName6;

            b6.Margin = new Thickness(42, 5, 42, 13);

            Border border6 = new Border();
            border6.BorderBrush = Brushes.Black;
            border6.BorderThickness = new Thickness(1);
            border6.Height = 192;
            border6.Width = 184;
            border6.HorizontalAlignment = HorizontalAlignment.Left;

            border6.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text6 = new TextBlock();
            text6.Text = "6.4KM              $$$$";
            text6.Margin = new Thickness(80, 10, 74, 0);
            text6.HorizontalAlignment = HorizontalAlignment.Left;
            text6.VerticalAlignment = VerticalAlignment.Bottom;

            grid6.Children.Add(b6);
            grid6.Children.Add(border6);
            grid6.Children.Add(text6);


            Grid grid7 = new Grid();
            Button b7 = new Button();
            b7.Width = 175;
            b7.Height = 175;
            b7.Click += btnRiverCafe_Click;

            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/hardy4.jpg", UriKind.Relative)));
            image7.Stretch = Stretch.UniformToFill;
            b7.Background = image7;

            TextBlock textName7 = new TextBlock();
            textName7.TextWrapping = TextWrapping.Wrap;
            textName7.HorizontalAlignment = HorizontalAlignment.Right;
            textName7.VerticalAlignment = VerticalAlignment.Bottom;
            textName7.FontFamily = new FontFamily("Stencil");
            textName7.FontSize = 13.333;
            textName7.Margin = new Thickness(0, 130, 50, 0);
            textName7.Foreground = Brushes.White;
            textName7.Text = "River Cafe";

            b7.Content = textName7;

            b7.Margin = new Thickness(42, 5, 42, 13);

            Border border7 = new Border();
            border7.BorderBrush = Brushes.Black;
            border7.BorderThickness = new Thickness(1);
            border7.Height = 192;
            border7.Width = 184;
            border7.HorizontalAlignment = HorizontalAlignment.Left;

            border7.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text7 = new TextBlock();
            text7.Text = "7.4KM              $$$$";
            text7.Margin = new Thickness(80, 10, 74, 0);
            text7.HorizontalAlignment = HorizontalAlignment.Left;
            text7.VerticalAlignment = VerticalAlignment.Bottom;

            grid7.Children.Add(b7);
            grid7.Children.Add(border7);
            grid7.Children.Add(text7);


            Grid grid8 = new Grid();
            Button b8 = new Button();
            b8.Width = 175;
            b8.Height = 175;
            b8.Click += btnNotable_Click;

            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/picNotable.jpg", UriKind.Relative)));
            image8.Stretch = Stretch.UniformToFill;
            b8.Background = image8;

            TextBlock textName8 = new TextBlock();
            textName8.TextWrapping = TextWrapping.Wrap;
            textName8.HorizontalAlignment = HorizontalAlignment.Right;
            textName8.VerticalAlignment = VerticalAlignment.Bottom;
            textName8.FontFamily = new FontFamily("Stencil");
            textName8.FontSize = 13.333;
            textName8.Margin = new Thickness(0, 130, 50, 0);
            textName8.Foreground = Brushes.White;
            textName8.Text = "NOTaBLE";

            b8.Content = textName8;

            b8.Margin = new Thickness(42, 5, 42, 13);

            Border border8 = new Border();
            border8.BorderBrush = Brushes.Black;
            border8.BorderThickness = new Thickness(1);
            border8.Height = 192;
            border8.Width = 184;
            border8.HorizontalAlignment = HorizontalAlignment.Left;

            border8.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text8 = new TextBlock();
            text8.Text = "13.2KM              $$$$";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);


            Grid.SetRow(grid, 0);
            Grid.SetColumn(grid, 0);
            Grid.SetRow(grid2, 0);
            Grid.SetColumn(grid2, 1);
            Grid.SetRow(grid3, 0);
            Grid.SetColumn(grid3, 2);
            Grid.SetRow(grid4, 1);
            Grid.SetColumn(grid4, 0);
            Grid.SetRow(grid5, 1);
            Grid.SetColumn(grid5, 1);
            Grid.SetRow(grid6, 1);
            Grid.SetColumn(grid6, 2);
            Grid.SetRow(grid7, 2);
            Grid.SetColumn(grid7, 0);
            Grid.SetRow(grid8, 2);
            Grid.SetColumn(grid8, 1);

            gridRestaurant.Children.Add(grid);
            gridRestaurant.Children.Add(grid2);
            gridRestaurant.Children.Add(grid3);
            gridRestaurant.Children.Add(grid4);
            gridRestaurant.Children.Add(grid5);
            gridRestaurant.Children.Add(grid6);
            gridRestaurant.Children.Add(grid7);
            gridRestaurant.Children.Add(grid8);
        }
    }
}
