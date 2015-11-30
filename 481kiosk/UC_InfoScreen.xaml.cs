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
        private MainWindow _main;
        public UCInfoScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();
        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            if (!IEVersionFix.IsBrowserEmulationSet())
            {
                IEVersionFix.SetBrowserEmulationVersion();
            }

            _main.resetTab(_main.tabControl.SelectedIndex);

            UCMapScreen _ucMap = new UCMapScreen(_main);
            TabItem _tabPage = new TabItem();

            _tabPage.Header = "Navigation";

            _tabPage.Content = _ucMap;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }
    }
}
