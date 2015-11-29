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
    /// Interaction logic for UC_MapScreen.xaml
    /// </summary>
    public partial class UCMapScreen : UserControl
    {
        private MainWindow _main;
        private String api = "AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY";
        public UCMapScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();

            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("https://www.google.ca/maps/dir/Chinook+Centre,+Macleod+Trail+Southwest,+Calgary,+AB/Glenbow+Museum,+130+9+Ave+SE,+Calgary,+AB+T2G+0P3/@51.0194567,-114.0606488,13.5z/data=!4m13!4m12!1m5!1m1!1s0x537170558da99659:0x4425176f71808691!2m2!1d-114.0741402!2d50.9964781!1m5!1m1!1s0x53717001fff162df:0xeff2ea4f4cfa8e6c!2m2!1d-114.0611335!2d51.0449777?hl=en");
                wbMap.Navigate(queryAddress.ToString());
            } catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
            }
        }
    }
}
