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
            if (tabControl.Items.Count > 2)
            {
                for (int index = tabControl.Items.Count - 1; index > 1; index--)
                {
                    tabControl.Items.RemoveAt(index);
                }
            }

            tabDiscover.Visibility = Visibility.Visible;
            tabControl.SelectedItem = tabDiscover;
        }

        private void btnTestPage_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabTestPage = new TabItem();
            _tabTestPage.Header = "Test";

            tabControl.Items.Add(_tabTestPage);
            tabControl.SelectedItem = _tabTestPage;
        }
    }
}
