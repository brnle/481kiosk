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
            List<Events> novEvents = new List<Events>();
            novEvents.Add(new Events("Calgary Flames", "Calgary flames face off against the league leading team Chicago Blackhawks", "Calgary-Flames.jpg"));
            novEvents.Add(new Events("Illuminasia", "Exotic lantern festival from different parts of asia", "illuminasia.jpg"));
            novEvents.Add(new Events("Calgary Stampede", "Famous cowboy festival for all ages", "stampede_logo.png"));
            InitializeComponent();
            eventListing = new Dictionary<string, List<Events>>();
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

        private void btnCalgaryTower_Click(object sender, RoutedEventArgs e)
        {
            Button _btn = (Button)sender;

            UCInfoScreen _ucInfo = new UCInfoScreen();
            TabItem _tabTestPage = new TabItem();
            _tabTestPage.Header = "Calgary Tower";

            _ucInfo.txtBlockTitle.Text = "Calgary Tower";
            _ucInfo.txtBlockAddress.Text = "101 9 Ave SW\nCalgary, AB T2P 1J9";

            _tabTestPage.Content = _ucInfo;

            _main.tabControl.Items.Add(_tabTestPage);
            _main.tabControl.SelectedItem = _tabTestPage;
        }
    }
}
