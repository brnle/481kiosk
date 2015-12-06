using System;
using System.Collections;
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

            //Set up function that will call resize tab function whenever the tab item collection has changed in tab control
            var view = CollectionViewSource.GetDefaultView(tabControl.Items);
            view.CollectionChanged += (o, e) => { resize(tabControl.Items); };
        }

        //Function used to resize all the tab items
        private void resize(ItemCollection items)
        {
            //Iterates through each tab item and changes the size according to the number of tab items available
            for (int index = 0; index < items.Count; index++)
            {
                TabItem tab = (TabItem) items.GetItemAt(index);
                tab.Width = (tabControl.ActualWidth - 6) / items.Count;
            }
        }

        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {

            resetTab(tabControl.SelectedIndex);

            UCDiscoverScreen _ucDiscover = new UCDiscoverScreen(this);
            TabItem _tabDiscover = new TabItem();

            screenColor((SolidColorBrush)(new BrushConverter().ConvertFrom("#ffa366")), _tabDiscover);
            _tabDiscover.MouseLeftButtonUp += delegate { screenColor((SolidColorBrush)(new BrushConverter().ConvertFrom("#ffa366")), _tabDiscover); };
            
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

        public void screenColor(Brush brush, TabItem tab)
        {
            MainGrid.Background = brush;
            tabControl.Background = brush;
            tab.Background = brush;

        }
        private void langTab_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            screenColor((Brush)converter.ConvertFromString("#FF00CFCF"), (TabItem)sender);
        }

        private void btnFrench_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in French");
        }

        private void btnSpanish_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Spanish");
        }

        private void btnChinese_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Chinese");
        }

        private void btnHindi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Hindi");
        }

        private void btnArabic_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Arabic");
        }

        private void btnRussian_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Russian");
        }

        private void btnJapanese_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button will display the Kiosk content in Japanese");
        }
    }
}
