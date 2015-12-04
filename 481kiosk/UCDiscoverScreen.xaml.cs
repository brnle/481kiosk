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
            int x = 0;
            int y = 0;
            var elements = grdAttractions.Children.Cast<UIElement>().
                Where(ele => Grid.GetColumn(ele) == x && Grid.GetRow(ele) == y);
            var elements2 = grdAttractions.Children.Cast<UIElement>().
                Where(ele => Grid.GetColumn(ele) == x+1 && Grid.GetRow(ele) == y+1);


            //This grabs a cell from a grid, goes row by row, left to right, so this would be the top left cell
            Grid _grd = (Grid)grdAttractions.Children[0];

            //Children of grid is organized into another array, goes in order Button-Border-TextBlock-TextBlock
            Button _btn = (Button) _grd.Children[0];
            Border _brd = (Border)_grd.Children[1];
            TextBlock _txtblDistance = (TextBlock)_grd.Children[2];
            TextBlock _txtblPrice= (TextBlock)_grd.Children[3];

            //Just a message to show which grid block you're looking at
            MessageBox.Show(_txtblDistance.Text);
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
    }
}
