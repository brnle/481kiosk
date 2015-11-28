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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UCInfoScreen : UserControl
    {
        MainWindow _main;
        public UCInfoScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();
        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            Window1 _map = new Window1();
            _map.Title = "CALGARY TOWER";
            _map.Show();
        }
    }
}
