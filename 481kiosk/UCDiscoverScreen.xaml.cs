using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for UCDiscoverScreen.xaml
    /// </summary>
    public partial class UCDiscoverScreen : UserControl
    {
        private Dictionary<string, List<Events>> eventListing;
        private MainWindow _main;
        public int month;
        public UCDiscoverScreen(MainWindow _source)
        {
            _main = _source;
            InitializeComponent();

            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            List<Events> decEvents1 = new List<Events>();
            decEvents1.Add(new Events("Inside", "Inside is a play about modern life. Daniel MacIvor adapted the play with University of Calgary students", "Images/inside.jpg", "210 University Ct. N.W\nReeve Theatre",
                "Tuesday 7:30 p.m\nWednesday 7:30 p.m\nThursday 7:30 p.m\nFriday 7:30 p.m\nSaturday 7:30 p.m\nSunday 2 p.m"));
            decEvents1.Add(new Events("Jewish Book Festival", "Browse hundreds of books at the annual Jewish Book Festival", "Images/jewish_book_event.jpeg", "1607 90 Ave. S.W\nJewish Centre Calgary",
                "Sunday 10 a.m. to 8:30 p.m\nMonday 10 a.m.to 8:30 p.m\nTuesday 10 a.m.to 8:30 p.m\nWednesday 10 a.m.to 8:30 p.m\nThursday 10 a.m.to 8:30 p.m\nFriday 10 a.m.to 4 p.m\nSaturday 6 p.m.to 8:30 p.m."));
            eventListing = new Dictionary<String, List<Events>>();
            eventListing.Add("12/1/2015", decEvents1);
            eventListing.Add("12/2/2015", decEvents1);
            eventListing.Add("12/3/2015", decEvents1);
            eventListing.Add("12/4/2015", decEvents1);
            eventListing.Add("12/5/2015", decEvents1);

            List <Events> novEvents = new List<Events>();
            novEvents.Add(new Events("Calgary Flames", "Calgary flames face off against the league leading team Chicago Blackhawks", "Images/Calgary-Flames.jpg", "555 Saddledome Rise SE\n T2G 2W1", "Saturday 7 p.m - 10 p.m"));
            novEvents.Add(new Events("Illuminasia", "Exotic lantern festival from different parts of asia", "Images/illuminasia.jpg", "1300 Zoo Rd NE\nT2E 7V6", "All week 7 pm"));
            novEvents.Add(new Events("Calgary Stampede", "Famous cowboy festival for all ages", "Images/stampede_logo.png", "1410 Olympic Way SE\nT2G 2W1", "7 a.m. to 12 p.m"));
            eventListing.Add("11/25/2015", novEvents);

            setupCalendar();
        }

        private void Selection_Change(object sender, SelectionChangedEventArgs e)
        {
            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.


            setupCalendar();
            DateTime day = calendar1.SelectedDate.Value;

            if (eventListing.ContainsKey(day.Date.ToShortDateString()))
            {
                buttonStackpanel.Children.Clear();
                List<Events> tempEventListing = eventListing[day.Date.ToShortDateString()];
                int count = tempEventListing.Count();
                //For loop to create a list of buttons depending on how many events there are
                for (int i = 0; i < count; i++)
                {

                    DockPanel grid = new DockPanel();
                    Button b = new Button();
                    b.Tag = tempEventListing[i];
                    b.Click += event_Click;
                    b.Content = grid;
                    StackPanel stackpanel = new StackPanel();
                    b.HorizontalContentAlignment = HorizontalAlignment.Left;
                    grid.LastChildFill = true;

                    Image eventImage = new Image();
                    BitmapImage bitmap = new BitmapImage();
                    eventImage.Source = new BitmapImage(new Uri(tempEventListing[i].getImg(), UriKind.Relative));
                    eventImage.Width = 150;
                    eventImage.Height = 100;
                    eventImage.Stretch = Stretch.Fill;
                    eventImage.StretchDirection = StretchDirection.Both;
                    stackpanel.Margin = new Thickness(10, 0, 0, 0);


                    TextBlock eventName = new TextBlock();
                    eventName.FontWeight = FontWeights.Bold;
                    eventName.FontSize = 16;
                    eventName.FontStyle = FontStyles.Italic;
                    eventName.Text = tempEventListing[i].getName();

                    TextBlock eventDesc = new TextBlock();
                    eventDesc.Text = day.Date.ToShortDateString() + "\n" + tempEventListing[i].getDescription();
                    eventDesc.TextWrapping = TextWrapping.Wrap;

                    stackpanel.Children.Add(eventName);
                    stackpanel.Children.Add(eventDesc);
                    grid.Children.Add(eventImage);
                    grid.Children.Add(stackpanel);

                    buttonStackpanel.Children.Add(b);
                }
            }
            else
            {
                buttonStackpanel.Children.Clear();
            }
        }

        void event_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _main.resetTab(_main.tabControl.SelectedIndex);


            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            Events temp = (Events)button.Tag;
            //Input all information regarding attraction
            _tabPage.Header = temp.getName();
            _ucInfo.txtBlockTitle.Text = temp.getName();
            _ucInfo.txtBlockAddress.Text = temp.getAddress();
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri(temp.getImg(), UriKind.Relative));

            //Project user control onto the new tab's content, and set it as the new selected tab
            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnCalgaryTower_Click(object sender, RoutedEventArgs e)
        {
            //Call main window's reset tab function to remove excess starting from this tab
            _main.resetTab(_main.tabControl.SelectedIndex);

            //Instantiate user control and tab to be displayed
            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();


            //Input all information regarding attraction
            _tabPage.Header = "Calgary Tower";
            _ucInfo.txtBlockTitle.Text = "Calgary Tower";
            _ucInfo.txtBlockAddress.Text = "101 9 Ave SW, Calgary, AB T2P 1J9";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/calgary-tower.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Start your Calgary adventure 525 feet in the air! Rising from the downtown core, the Calgary Tower is a must-see for any visitor. On the observation deck, experience a 360° panoramic view of the bustling city, the foothills and the majestic Rocky Mountains. Stand on the amazing glass floor for a birds-eye view of the streets below.

Multimedia tours are provided to each guest who visits the Calgary Tower! This informative and inspiring tour is free with admission and is available in four languages: English, French, Mandarin, and German.

This award-winning tour begins at the base of the Tower with an interesting perspective on the elevator ride to the top. Once at the Observation Deck, the guide provides you with a panoramic view of the city which matches the views from our windows. Certain landmarks are highlighted and by touching these buildings on your screen, you will be provided with information and interesting facts.";

            _ucInfo.txtBlockHours.Text = @"Mon - 9:00am to 9:00pm
Tues - 9:00am to 9:00pm
Wed - 9:00am to 9:00pm
Thurs - 9:00am to 9:00pm
Fri - 9:00am to 9:00pm
Sat - 9:00am to 9:00pm
Sun - 9:00am to 9:00pm

*Hours extend to 10:00 p.m. from July to August";
              //Project user control onto the new tab's content, and set it as the new selected tab
              _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnGlenbowMuseum_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Glenbow Museum";
            _ucInfo.txtBlockTitle.Text = "Glenbow Museum";
            _ucInfo.txtBlockAddress.Text = "130 9 Ave SE, Calgary, AB T2G 0P3";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/glenbow-museum.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Glenbow's vision is for more people to experience art and culture more often. In February of 2014, Glenbow announced its new direction - to provide visitors with a new kind of art museum experience. Glenbow showcases world-renowned travelling and permanent exhibitions that are meaningful to many diverse groups in our community, boasts the largest art collection in Western Canada and provides access and care to our collections.

Glenbow also tells the story of Southern Alberta and the West to thousands of visitors to our city each year through permanent exhibitions on our third floor.

Last year, 120,000 guests passed through Glenbow's doors, including more than 63,000 school children who took part in our School Programs and Chevron Museum School. Glenbow's Library and Archives is Canada's largest non-governmental archival repository. It is a major research centre for historians, writers, students, genealogists, filmmakers and media.

The Glenbow Shop offers visitors a unique retail experience while providing a viable revenue stream for the institution. Glenbow also serves as a rental facility for many corporate and private functions, offering a 210-seat theatre, meeting rooms and three gallery floors as event space.";


            _ucInfo.txtBlockHours.Text = @"Mon - Closed
Tues - 9:00am to 5:00pm
Wed - 9:00am to 5:00pm
Thurs - 9:00am to 5:00pm
Fri - 9:00am to 5:00pm
Sat - 9:00am to 5:00pm
Sun - 12:00pm to 5:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void expEvents_Expanded(object sender, RoutedEventArgs e)
        {
            expAttractions.IsExpanded = false;
            expRestaurants.IsExpanded = false;
        }

        private void expRestaurants_Expanded(object sender, RoutedEventArgs e)
        {
            expAttractions.IsExpanded = false;
            expEvents.IsExpanded = false;
        }

        private void rdoDistance_Checked(object sender, RoutedEventArgs e)
        {
            grdAttractions.Children.RemoveRange(0, grdAttractions.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;
            b.Click += btnCalgaryTower_Click;

            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/calgary-tower.jpg", UriKind.Relative)));
            b.Background = image;
            image.Stretch = Stretch.UniformToFill;

            TextBlock textName = new TextBlock();
            textName.TextWrapping = TextWrapping.Wrap;
            textName.HorizontalAlignment = HorizontalAlignment.Right;
            textName.VerticalAlignment = VerticalAlignment.Bottom;
            textName.FontFamily = new FontFamily("Stencil");
            textName.FontSize = 13.333;
            textName.Margin = new Thickness(0, 130, 50, 0);
            textName.Foreground = Brushes.White;
            textName.Text = "Calgary Tower";

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
            text1.Text = "5.9KM              $$";
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
            b2.Click += btnGlenbowMuseum_Click;

            //GLENBOW MUSEUM BUTTON
            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/glenbow-museum.jpg", UriKind.Relative)));
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
            textName2.Text = "Glenbow Museum";

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
            text2.Text = "6.4KM              $$$";
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
            b3.Click += btnTelusSpark_Click;

            //TELUS SPARK BUTTON
            ImageBrush image3 = new ImageBrush(new BitmapImage(new Uri("Images/telus-spark.jpg", UriKind.Relative)));
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
            textName3.Text = "Telus Spark";

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
            text3.Text = "9.2KM              $$";
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
            b4.Click += btnBowHabitat_Click;

            //BOW HABITAT STATION BUTTON
            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/bow-habitat-station.jpg", UriKind.Relative)));
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
            textName4.Text = "Bow Habitat Station";

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
            text4.Text = "11.5KM              $";
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
            b5.Click += btnCalgaryZoo_Click;

            //CALGARY ZOO BUTTON
            ImageBrush image5 = new ImageBrush(new BitmapImage(new Uri("Images/calgary-zoo.jpg", UriKind.Relative)));
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
            textName5.Text = "Calgary Zoo";

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
            text5.Text = "8.0KM              $$$";
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
            b6.Click += btnCanadaOlympicPark_Click;

            //CANADA OLYMPIC PARK BUTTON
            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/c-o-p.jpg", UriKind.Relative)));
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
            textName6.Text = "Canada Olympic Park";

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
            text6.Text = "18.4KM              $$$";
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
            b7.Click += btnCanadaSportsHOF_Click;

            //CANADA SPORTS HALL OF FAME BUTTON
            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/canada-sports-hof.jpg", UriKind.Relative)));
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
            textName7.Text = "Canada's Sports Hall of Fame";

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
            text7.Text = "18.8KM              $$";
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
            b8.Click += btnAeroSpaceMuseum_Click;

            //AERO SPACE MUSEUM
            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/aero-space-museum.jpg", UriKind.Relative)));
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
            textName8.Text = "Aero Space Museum";

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
            text8.Text = "19.1KM              $";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);



            Grid grid9 = new Grid();
            Button b9 = new Button();
            b9.Width = 175;
            b9.Height = 175;
            b9.Click += btnCalawayPark_Click;

            //CALAWAY PARK BUTTON
            ImageBrush image9 = new ImageBrush(new BitmapImage(new Uri("Images/calaway-park.jpg", UriKind.Relative)));
            image9.Stretch = Stretch.UniformToFill;
            b9.Background = image9;

            TextBlock textName9 = new TextBlock();
            textName9.TextWrapping = TextWrapping.Wrap;
            textName9.HorizontalAlignment = HorizontalAlignment.Right;
            textName9.VerticalAlignment = VerticalAlignment.Bottom;
            textName9.FontFamily = new FontFamily("Stencil");
            textName9.FontSize = 13.333;
            textName9.Margin = new Thickness(0, 130, 50, 0);
            textName9.Foreground = Brushes.White;
            textName9.Text = "Calaway Park";

            b9.Content = textName9;

            b9.Margin = new Thickness(42, 5, 42, 13);

            Border border9 = new Border();
            border9.BorderBrush = Brushes.Black;
            border9.BorderThickness = new Thickness(1);
            border9.Height = 192;
            border9.Width = 184;
            border9.HorizontalAlignment = HorizontalAlignment.Left;

            border9.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text9 = new TextBlock();
            text9.Text = "28.5KM              $$$$";
            text9.Margin = new Thickness(80, 10, 74, 0);
            text9.HorizontalAlignment = HorizontalAlignment.Left;
            text9.VerticalAlignment = VerticalAlignment.Bottom;

            grid9.Children.Add(b9);
            grid9.Children.Add(border9);
            grid9.Children.Add(text9);

            Grid.SetRow(grid, 0);
            Grid.SetColumn(grid, 0);
            Grid.SetRow(grid2, 0);
            Grid.SetColumn(grid2, 1);
            Grid.SetRow(grid5, 0);
            Grid.SetColumn(grid5, 2);
            Grid.SetRow(grid3, 1);
            Grid.SetColumn(grid3, 0);
            Grid.SetRow(grid4, 1);
            Grid.SetColumn(grid4, 1);
            Grid.SetRow(grid6, 1);
            Grid.SetColumn(grid6, 2);
            Grid.SetRow(grid7, 2);
            Grid.SetColumn(grid7, 0);
            Grid.SetRow(grid8, 2);
            Grid.SetColumn(grid8, 1);
            Grid.SetRow(grid9, 2);
            Grid.SetColumn(grid9, 2);

            
            grdAttractions.Children.Add(grid);
            grdAttractions.Children.Add(grid2);
            grdAttractions.Children.Add(grid3);
            grdAttractions.Children.Add(grid4);
            grdAttractions.Children.Add(grid5);
            grdAttractions.Children.Add(grid6);
            grdAttractions.Children.Add(grid7);
            grdAttractions.Children.Add(grid8);
            grdAttractions.Children.Add(grid9);
        }

        private void btnCalgaryZoo_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Calgary Zoo";
            _ucInfo.txtBlockTitle.Text = "Calgary Zoo";
            _ucInfo.txtBlockAddress.Text = "1300 Zoo Rd NE, Calgary, AB T2E 7V6";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/calgary-zoo.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Animatronic Dinosaurs are Back!

Watch for triceratops grazing among the bushes, then look up to see fearsome T-Rex’s banana-sized teeth ready to tear into his next meal. Don’t run! You haven’t actually travelled back in time – it just feels like it.

This March, The Calgary Zoo is bringing back Dinosaurs Alive, the animatronic dinosaur exhibit previously seen in 2010. Following the refurbishment of the Prehistoric Park, the zoo will introduce 17 dinosaur models into the park to add to the current collection.

These realistic, fleshy models have special engineering to help them move in a true fashion. All of the creatures vocalize and some can even be controlled through the touch of a button by a curious visitor.

Come and see for yourself what Alberta might have looked like when dinosaurs reigned supreme.";

            _ucInfo.txtBlockHours.Text = @"Mon - 9:00am to 5:00pm
Tues - 9:00am to 5:00pm
Wed - 9:00am to 5:00pm
Thurs - 9:00am to 5:00pm
Fri - 9:00am to 5:00pm
Sat - 9:00am to 5:00pm
Sun - 9:00am to 5:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnTelusSpark_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Telus Spark";
            _ucInfo.txtBlockTitle.Text = "Telus Spark";
            _ucInfo.txtBlockAddress.Text = "220 St Georges Dr NE, Calgary, AB T2E 5T2";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/telus-spark.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"TELUS Spark is Canada's first new purpose-built Science Centre in over 25 years and a place for people of all ages and abilities to embrace the exploration and discovery of science, technology and art in new and amazing ways.

Discover for yourself what makes the world around us so undeniably incredible by exploring over 150 exhibits, programs and demonstrations across Galleries, Calgary's only HD Digital Dome Theatre, travelling exhibitions, an Outdoor Park, and more.

Ignite your curiosity in the thrilling overlap of science, art and technology.";

            _ucInfo.txtBlockHours.Text = @"Mon - 10:00am to 4:00pm
Tues - 10:00am to 4:00pm
Wed - 10:00am to 4:00pm
Thurs - 10:00am to 4:00pm
Fri - 10:00am to 4:00pm
Sat - 10:00am to 5:00pm
Sun - 10:00am to 4:00pm

*Adult Night every second Thursday of the month, 6:00pm to 10:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnCanadaSportsHOF_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Canada's Sports Hall of Fame";
            _ucInfo.txtBlockTitle.Text = "Canada's Sports Hall of Fame";
            _ucInfo.txtBlockAddress.Text = "169 Canada Olympic Road SW, Calgary, AB T3B 6B7";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/canada-sports-hof.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Canada’s Sports Hall of Fame is an international award-winning facility with over 40,000 square feet of inspiring experiences. Located at WinSport, Canada’s Sports Hall of Fame features 12 galleries, more than 52 hands-on interactive experiences and a collection of more than 95,000 artefacts. It is a place of honour for the 605 inducted sport legends and the 65 sports they represent. Our mission is to share the stories of the achievements of our inducted Honoured Members so that we can inspire all Canadians to be the best they can be in all aspects of life. Spanning nearly 150 years of Canadian sport history, there is something fun, educational and inspiring for people of all ages.";

            _ucInfo.txtBlockHours.Text = @"Mon - 10:00am to 5:00pm
Tues - 10:00am to 5:00pm
Wed - 10:00am to 5:00pm
Thurs - 10:00am to 5:00pm
Fri - 10:00am to 5:00pm
Sat - 10:00am to 5:00pm
Sun - 10:00am to 5:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnAeroSpaceMuseum_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Aero Space Museum";
            _ucInfo.txtBlockTitle.Text = "Aero Space Museum";
            _ucInfo.txtBlockAddress.Text = "4629 McCall Way NE, Calgary, AB T2E 8A5";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/aero-space-museum.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Who doesn’t wish they could fly? Discover Canada’s aviation adventure and enjoy seeing aircraft up close while hearing the roar of a modern jet overhead. Everything from Canada’s first powered aircraft to the majestic “Queen of the Sky” Lancaster are on display in a historic Second World War drill hall and outdoor hangar.";

            _ucInfo.txtBlockHours.Text = @"Mon - 9:00am to 4:00pm
Tues - 10:00am to 4:00pm
Wed - 10:00am to 4:00pm
Thurs - 10:00am to 4:00pm
Fri - 10:00am to 4:00pm
Sat - 10:00am to 4:00pm
Sun - 10:00am to 4:00pm";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnCanadaOlympicPark_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Canada Olympic Park";
            _ucInfo.txtBlockTitle.Text = "Canada Olympic Park";
            _ucInfo.txtBlockAddress.Text = "88 Canada Olympic Road SW, Calgary, AB T3B 5R5";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/c-o-p.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Come out and play at WinSport, Calgary’s year-round playground and site of the 1988 Winter Olympic Games. In summer, kids can explore the Activity Centre featuring a 30 foot climbing wall and EuroBungy. The whole gang can hit the greens of our 18-hole mini-golf course while the more adventurous might want to take on the Adrenaline Combo—a Canadian Signature Experience that combines North America’s fastest zipline and Summer Bobsleigh. Winter brings us back to our Olympic roots as we transform into ski and snowboard central with hill tickets starting at $10.";
            _ucInfo.txtBlockHours.Text = @"Mon - 8:00am to 9:00pm
Tues - 8:00am to 9:00pm
Wed - 8:00am to 9:00pm
Thurs - 8:00am to 9:00pm
Fri - 8:00am to 9:00pm
Sat - 8:00am to 9:00pm
Sun - 8:00am to 9:00pm

*Times vary per building";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnCalawayPark_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Calaway Park";
            _ucInfo.txtBlockTitle.Text = "Calaway Park";
            _ucInfo.txtBlockAddress.Text = "245033 Range Rd 33, Calgary, AB T3Z 2E9";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/calaway-park.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"32 Family-friendly rides! High-energy entertainment! Tempting treats! Calaway Park has something for everyone!
 
As Western Canada’s Largest Outdoor Family Amusement Park, Calaway Park has been offering affordable, family- friendly fun and entertainment for over three decades.
 
Ever since our award-winning theme park first opened its doors in 1982, Calaway Park has built on our well-deserved reputation for excellence by offering the best attractions, no less than 32 rides designed for thrill-seekers of all ages and beautifully choreographed, high-energy entertainment.
 
Factor in Calaway Park’s one-pay gate, which include unlimited rides, attractions, must-see Calaway Live shows and unparalleled street performers such as stilt walkers, jugglers and clowns, not to mention lots of free parking – and it’s easy to see why families of all sizes venture out to Calaway Park’s stunning location in the shadow of the Rocky Mountains to enjoy a day full of safe, family fun.";

            _ucInfo.txtBlockHours.Text = @"Mon - Closed
Tues - Closed
Wed - Closed
Thurs - Closed
Fri - Closed
Sat - 10:00am to 7:00pm
Sun - 10:00am to 7:00pm

*Closed Weekdays from May 21 to June 21
**Open from May 2016 to October 2016";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnBowHabitat_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            UCInfoScreen _ucInfo = new UCInfoScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Bow Habitat Station";
            _ucInfo.txtBlockTitle.Text = "Bow Habitat Station";
            _ucInfo.txtBlockAddress.Text = "1440 17a St SE, Calgary, AB T2G 4T9";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/bow-habitat-station.jpg", UriKind.Relative));
            _ucInfo.txtDescription.Text = @"Investigate, explore and discover Alberta’s fish, wildlife, water and aquatic ecosystems. Explore hands-on exhibits in our Discovery Centre, feed the fish on a tour of our Fish Hatchery, go fishing in our Trout Pond, and take a stroll along the trails in our Interpretive Wetland.

There is fun for the whole family at Bow Habitat Station!

Located minutes east of downtown in the vibrant community of Inglewood, Bow Habitat Station offers a unique learning experience that’s sure to be a splash. The facility is for all ages and is completely wheelchair accessible. Free parking is available.";

            _ucInfo.txtBlockHours.Text = @"Mon - Closed
Tues - Closed
Wed - 10:00am to 4:00pm
Thurs - 10:00am to 4:00pm
Fri - 10:00am to 4:00pm
Sat - 10:00am to 4:00pm
Sun - 10:00am to 4:00pm

*Interpretive Wetland open from 5:00am to 11:00pm
**10:00am to 8:00pm on third Thursday every month";

            _tabPage.Content = _ucInfo;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void restDistanceChecked(object sender, RoutedEventArgs e)
        {
            gridRestaurant.Children.RemoveRange(0, gridRestaurant.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;

            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName.Text = "Calgary Tower";

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
            text1.Text = "7.4KM              $$$$";
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

            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName2.Text = "Calgary Tower";

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
            text2.Text = "13.2KM              $$$$";
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
            textName3.Text = "Calgary Tower";

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
            text3.Text = "14.1KM              $$$";
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

            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName4.Text = "Calgary Tower";

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
            text4.Text = "14.5KM              $$$";
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
            textName5.Text = "Calgary Tower";

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
            text5.Text = "16KM              $";
            text5.Margin = new Thickness(80, 10, 74, 0);
            text5.HorizontalAlignment = HorizontalAlignment.Left;
            text5.VerticalAlignment = VerticalAlignment.Bottom;

            grid5.Children.Add(b5);
            grid5.Children.Add(border5);
            grid5.Children.Add(text5);

            Grid grid6= new Grid();
            Button b6= new Button();
            b6.Width = 175;
            b6.Height = 175;

            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName6.Text = "Calgary Tower";

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
            text6.Text = "17.2KM              $";
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

            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName7.Text = "Calgary Tower";

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
            text7.Text = "17.9KM              $";
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

            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName8.Text = "Calgary Tower";

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
            text8.Text = "19.5KM              $$$$";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);



            Grid grid9 = new Grid();
            Button b9 = new Button();
            b9.Width = 175;
            b9.Height = 175;

            ImageBrush image9 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
            image9.Stretch = Stretch.UniformToFill;
            b9.Background = image8;

            TextBlock textName9 = new TextBlock();
            textName9.TextWrapping = TextWrapping.Wrap;
            textName9.HorizontalAlignment = HorizontalAlignment.Right;
            textName9.VerticalAlignment = VerticalAlignment.Bottom;
            textName9.FontFamily = new FontFamily("Stencil");
            textName9.FontSize = 13.333;
            textName9.Margin = new Thickness(0, 130, 50, 0);
            textName9.Foreground = Brushes.White;
            textName9.Text = "Calgary Tower";

            b9.Content = textName9;

            b9.Margin = new Thickness(42, 5, 42, 13);

            Border border9 = new Border();
            border9.BorderBrush = Brushes.Black;
            border9.BorderThickness = new Thickness(1);
            border9.Height = 192;
            border9.Width = 184;
            border9.HorizontalAlignment = HorizontalAlignment.Left;

            border9.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text9 = new TextBlock();
            text9.Text = "22.2KM              $$";
            text9.Margin = new Thickness(80, 10, 74, 0);
            text9.HorizontalAlignment = HorizontalAlignment.Left;
            text9.VerticalAlignment = VerticalAlignment.Bottom;

            grid9.Children.Add(b9);
            grid9.Children.Add(border9);
            grid9.Children.Add(text9);

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
            Grid.SetRow(grid9, 2);
            Grid.SetColumn(grid9, 2);

            gridRestaurant.Children.Add(grid);
            gridRestaurant.Children.Add(grid2);
            gridRestaurant.Children.Add(grid3);
            gridRestaurant.Children.Add(grid4);
            gridRestaurant.Children.Add(grid5);
            gridRestaurant.Children.Add(grid6);
            gridRestaurant.Children.Add(grid7);
            gridRestaurant.Children.Add(grid8);
            gridRestaurant.Children.Add(grid9);
        }

        private void restPriceChecked(object sender, RoutedEventArgs e)
        {
            gridRestaurant.Children.RemoveRange(0, gridRestaurant.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;

            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName.Text = "Calgary Tower";

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
            text1.Text = "7.4KM              $";
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

            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName2.Text = "Calgary Tower";

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
            text2.Text = "6.2KM              $";
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
            textName3.Text = "Calgary Tower";

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
            text3.Text = "1.2KM              $$";
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

            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName4.Text = "Calgary Tower";

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
            text4.Text = "3.2KM              $$";
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
            textName5.Text = "Calgary Tower";

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
            text5.Text = "14.2KM              $$$";
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

            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName6.Text = "Calgary Tower";

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
            text6.Text = "5.5KM              $$$";
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

            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName7.Text = "Calgary Tower";

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
            text7.Text = "17.9KM              $$$$";
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

            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
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
            textName8.Text = "Calgary Tower";

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
            text8.Text = "2.5KM              $$$$";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);



            Grid grid9 = new Grid();
            Button b9 = new Button();
            b9.Width = 175;
            b9.Height = 175;

            ImageBrush image9 = new ImageBrush(new BitmapImage(new Uri("Images/picRaw.jpg", UriKind.Relative)));
            image9.Stretch = Stretch.UniformToFill;
            b9.Background = image8;

            TextBlock textName9 = new TextBlock();
            textName9.TextWrapping = TextWrapping.Wrap;
            textName9.HorizontalAlignment = HorizontalAlignment.Right;
            textName9.VerticalAlignment = VerticalAlignment.Bottom;
            textName9.FontFamily = new FontFamily("Stencil");
            textName9.FontSize = 13.333;
            textName9.Margin = new Thickness(0, 130, 50, 0);
            textName9.Foreground = Brushes.White;
            textName9.Text = "Calgary Tower";

            b9.Content = textName9;

            b9.Margin = new Thickness(42, 5, 42, 13);

            Border border9 = new Border();
            border9.BorderBrush = Brushes.Black;
            border9.BorderThickness = new Thickness(1);
            border9.Height = 192;
            border9.Width = 184;
            border9.HorizontalAlignment = HorizontalAlignment.Left;

            border9.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text9 = new TextBlock();
            text9.Text = "15.2KM              $$$$";
            text9.Margin = new Thickness(80, 10, 74, 0);
            text9.HorizontalAlignment = HorizontalAlignment.Left;
            text9.VerticalAlignment = VerticalAlignment.Bottom;

            grid9.Children.Add(b9);
            grid9.Children.Add(border9);
            grid9.Children.Add(text9);

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
            Grid.SetRow(grid9, 2);
            Grid.SetColumn(grid9, 2);

            gridRestaurant.Children.Add(grid);
            gridRestaurant.Children.Add(grid2);
            gridRestaurant.Children.Add(grid3);
            gridRestaurant.Children.Add(grid4);
            gridRestaurant.Children.Add(grid5);
            gridRestaurant.Children.Add(grid6);
            gridRestaurant.Children.Add(grid7);
            gridRestaurant.Children.Add(grid8);
            gridRestaurant.Children.Add(grid9);
        }

        private void rdoPrice_Checked(object sender, RoutedEventArgs e)
        {
            grdAttractions.Children.RemoveRange(0, grdAttractions.Children.Count);
            Grid grid = new Grid();
            Button b = new Button();
            b.Width = 175;
            b.Height = 175;
            b.Click += btnBowHabitat_Click;

            //BOW HABITAT BUTTON
            ImageBrush image = new ImageBrush(new BitmapImage(new Uri("Images/bow-habitat-station.jpg", UriKind.Relative)));
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
            textName.Text = "Bow Habitat";

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
            text1.Text = "11.5KM              $";
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
            b2.Click += btnAeroSpaceMuseum_Click;

            //AERO SPACE MUSEUM BUTTON
            ImageBrush image2 = new ImageBrush(new BitmapImage(new Uri("Images/aero-space-museum.jpg", UriKind.Relative)));
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
            textName2.Text = "Aero Space Museum";

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
            text2.Text = "19.1KM              $";
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
            b3.Click += btnCalgaryTower_Click;

            //CALGARY TOWER BUTTON
            ImageBrush image3 = new ImageBrush(new BitmapImage(new Uri("Images/calgary-tower.jpg", UriKind.Relative)));
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
            textName3.Text = "Calgary Tower";

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
            text3.Text = "5.9KM              $$";
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
            b4.Click += btnCanadaSportsHOF_Click;

            //CANADA SPORTS HALL OF FAME BUTTON
            ImageBrush image4 = new ImageBrush(new BitmapImage(new Uri("Images/canada-sports-hof.jpg", UriKind.Relative)));
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
            textName4.Text = "Canada's Sports Hall of Fame";

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
            text4.Text = "18.8KM              $$";
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
            b5.Click += btnTelusSpark_Click;

            //TELUS SPARK BUTTON
            ImageBrush image5 = new ImageBrush(new BitmapImage(new Uri("Images/telus-spark.jpg", UriKind.Relative)));
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
            textName5.Text = "Telus Spark";

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
            text5.Text = "9.2              $$";
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
            b6.Click += btnGlenbowMuseum_Click;

            ImageBrush image6 = new ImageBrush(new BitmapImage(new Uri("Images/glenbow-museum.jpg", UriKind.Relative)));
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
            textName6.Text = "Glenbow Museum";

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
            text6.Text = "6.4KM              $$$";
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
            b7.Click += btnCalgaryZoo_Click;

            //CALGARY ZOO BUTTON
            ImageBrush image7 = new ImageBrush(new BitmapImage(new Uri("Images/calgary-zoo.jpg", UriKind.Relative)));
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
            textName7.Text = "Calgary Zoo";

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
            text7.Text = "13.3KM              $$$";
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
            b8.Click += btnCanadaOlympicPark_Click;

            //CANADIAN OLYMPIC PARK
            ImageBrush image8 = new ImageBrush(new BitmapImage(new Uri("Images/c-o-p.jpg", UriKind.Relative)));
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
            textName8.Text = "Canada Olympic Park";

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
            text8.Text = "18.4KM              $$$";
            text8.Margin = new Thickness(80, 10, 74, 0);
            text8.HorizontalAlignment = HorizontalAlignment.Left;
            text8.VerticalAlignment = VerticalAlignment.Bottom;

            grid8.Children.Add(b8);
            grid8.Children.Add(border8);
            grid8.Children.Add(text8);



            Grid grid9 = new Grid();
            Button b9 = new Button();
            b9.Width = 175;
            b9.Height = 175;
            b9.Click += btnCalawayPark_Click;

            //CALAWAY PARK
            ImageBrush image9 = new ImageBrush(new BitmapImage(new Uri("Images/calaway-park.jpg", UriKind.Relative)));
            image9.Stretch = Stretch.UniformToFill;
            b9.Background = image9;

            TextBlock textName9 = new TextBlock();
            textName9.TextWrapping = TextWrapping.Wrap;
            textName9.HorizontalAlignment = HorizontalAlignment.Right;
            textName9.VerticalAlignment = VerticalAlignment.Bottom;
            textName9.FontFamily = new FontFamily("Stencil");
            textName9.FontSize = 13.333;
            textName9.Margin = new Thickness(0, 130, 50, 0);
            textName9.Foreground = Brushes.White;
            textName9.Text = "Calaway Park";

            b9.Content = textName9;

            b9.Margin = new Thickness(42, 5, 42, 13);

            Border border9 = new Border();
            border9.BorderBrush = Brushes.Black;
            border9.BorderThickness = new Thickness(1);
            border9.Height = 192;
            border9.Width = 184;
            border9.HorizontalAlignment = HorizontalAlignment.Left;

            border9.Margin = new Thickness(38, 8, 0, 0);

            TextBlock text9 = new TextBlock();
            text9.Text = "28.5KM              $$$$";
            text9.Margin = new Thickness(80, 10, 74, 0);
            text9.HorizontalAlignment = HorizontalAlignment.Left;
            text9.VerticalAlignment = VerticalAlignment.Bottom;

            grid9.Children.Add(b9);
            grid9.Children.Add(border9);
            grid9.Children.Add(text9);

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
            Grid.SetRow(grid9, 2);
            Grid.SetColumn(grid9, 2);


            grdAttractions.Children.Add(grid);
            grdAttractions.Children.Add(grid2);
            grdAttractions.Children.Add(grid3);
            grdAttractions.Children.Add(grid4);
            grdAttractions.Children.Add(grid5);
            grdAttractions.Children.Add(grid6);
            grdAttractions.Children.Add(grid7);
            grdAttractions.Children.Add(grid8);
            grdAttractions.Children.Add(grid9);
        }

        private void setupCalendar()
        {
            calendar1.SelectionMode = CalendarSelectionMode.MultipleRange;

            month = calendar1.DisplayDate.Month;
            int year = calendar1.DisplayDate.Year;

            int startDay = 1;
            int endDay = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, endDay);
            DateTime startOfMonth = new DateTime(year, month, startDay);

            for (DateTime d = startOfMonth; d <= endOfMonth; d = d.AddDays(1))
            {
                if (eventListing.ContainsKey(d.Date.ToShortDateString()))
                {
                    calendar1.SelectedDates.Add(d);
                }
            }
        }

        private void calendar1_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            setupCalendar();
            if (month != calendar1.DisplayDate.Month)
            {
                buttonStackpanel.Children.Clear();
            }
        }
    }
}
