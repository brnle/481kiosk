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
    /// Interaction logic for UCDiscoverScreen.xaml
    /// </summary>
    public partial class UCDiscoverScreen : UserControl
    {
        private Dictionary<string, List<Events>> eventListing;
        private MainWindow _main;
        public UCDiscoverScreen(MainWindow _source)
        {
            _main = _source;
            InitializeComponent();
            List<Events> decEvents1 = new List<Events>();
            decEvents1.Add(new Events("Inside", "Inside is a play about modern life. Daniel MacIvor adapted the play with University of Calgary students", "Images/inside.jpg", "210 University Ct. N.W\nReeve Theatre",
                "Tuesday 7:30 p.m\nWednesday 7:30 p.m\nThursday 7:30 p.m\nFriday 7:30 p.m\nSaturday 7:30 p.m\nSunday 2 p.m"));
            decEvents1.Add(new Events("Jewish Book Festival", "Browse hundreds of books at the annual Jewish Book Festival", "Images/jewish_book_event.jpg", "1607 90 Ave. S.W\nJewish Centre Calgary",
                "Sunday 10 a.m. to 8:30 p.m\nMonday 10 a.m.to 8:30 p.m\nTuesday 10 a.m.to 8:30 p.m\nWednesday 10 a.m.to 8:30 p.m\nThursday 10 a.m.to 8:30 p.m\nFriday 10 a.m.to 4 p.m\nSaturday 6 p.m.to 8:30 p.m."));
            eventListing = new Dictionary<string, List<Events>>();
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
        }

        private void Selection_Change(object sender, SelectionChangedEventArgs e)
        {

            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.
            foreach (DateTime day in calendar1.SelectedDates)
            {
                if (eventListing.ContainsKey(day.Date.ToShortDateString()))
                {
                    buttonStackpanel.Children.RemoveRange(1, buttonStackpanel.Children.Count - 1);
                    List<Events> tempEventListing = eventListing[day.Date.ToShortDateString()];
                    int count = tempEventListing.Count();
                    //For loop to create a list of buttons depending on how many events there are
                    List<Button> buttons = new List<Button>();
                    for (int i = 0; i < count; i++)
                    {

                        Grid grid = new Grid();
                        StackPanel stackpanel = new StackPanel();

                        Image eventImage = new Image();
                        BitmapImage bitmap = new BitmapImage();
                        eventImage.Source = new BitmapImage(new Uri(tempEventListing[i].getImg(), UriKind.Relative));
                        eventImage.HorizontalAlignment = HorizontalAlignment.Left;
                        eventImage.Width = 150;
                        eventImage.Height = 100;
                        Thickness margin = eventImage.Margin;
                        margin.Left = -160;
                        margin.Top = 0;
                        margin.Right = 0;
                        margin.Bottom = -9;
                        eventImage.Margin = margin;

                        TextBlock eventName = new TextBlock();
                        eventName.FontWeight = FontWeights.Bold;
                        eventName.Text = tempEventListing[i].getName();

                        TextBlock eventDesc = new TextBlock();
                        eventDesc.Text = day.Date.ToShortDateString() + "\n" + tempEventListing[i].getDescription();
                        eventDesc.TextWrapping = TextWrapping.Wrap;

                        stackpanel.Children.Add(eventName);
                        stackpanel.Children.Add(eventDesc);
                        grid.Children.Add(eventImage);
                        Grid.SetColumn(eventImage, 0);
                        grid.Children.Add(stackpanel);
                        Grid.SetColumn(stackpanel, 1);

                        Button b = new Button();
                        b.Tag = tempEventListing[i];
                        b.Click += event_Click;
                        //b.Name = tempEventListing[i].getName();
                        b.Content = grid;
                        buttonStackpanel.Children.Add(b);
                    }
                }
                else
                {
                    buttonStackpanel.Children.RemoveRange(1, buttonStackpanel.Children.Count - 1);
                }



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
            _ucInfo.txtBlockAddress.Text = "101 9 Ave SW\nCalgary, AB T2P 1J9";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/calgary-tower.jpg", UriKind.Relative));

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
            _ucInfo.txtBlockAddress.Text = "130 9 Ave SE\nCalgary, AB T2G 0P3";
            _ucInfo.imgPicture.Source = new BitmapImage(new Uri("Images/glenbow-museum.jpg", UriKind.Relative));

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
    }
}
