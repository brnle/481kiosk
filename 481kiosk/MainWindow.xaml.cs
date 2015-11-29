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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {

            resetTab(tabControl.SelectedIndex);

            UCDiscoverScreen _ucDiscover = new UCDiscoverScreen(this);
            TabItem _tabDiscover = new TabItem();
            _tabDiscover.Header = "Discover";
            _tabDiscover.Content = _ucDiscover;

            tabControl.Items.Add(_tabDiscover);
            tabControl.SelectedItem = _tabDiscover;
        }

        //Public function to be called whenever tabs need to be refreshed
        public void resetTab(int start)
        {
            if (tabControl.SelectedIndex < tabControl.Items.Count - 1)
            {
                for (int index = tabControl.Items.Count - 1; index > start; index--)
                {
                    tabControl.Items.RemoveAt(index);
                }
            }
        }
    }
}
