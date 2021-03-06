﻿using System;
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
        String originChange = "new";
        public UCInfoScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();
        }

        public UCInfoScreen(MainWindow _window, String origin)
        {
            _main = _window;
            originChange = origin;
            InitializeComponent();
        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            if (!IEVersionFix.IsBrowserEmulationSet())
            {
                IEVersionFix.SetBrowserEmulationVersion();
            }

            _main.resetTab(_main.tabControl.SelectedIndex);
            TabItem _current = (TabItem) _main.tabControl.SelectedItem;

            if (this.txtBlockTitle.Text.Equals("Calaway Park"))
            {
                MessageBox.Show("Calaway Park does not have a transit route available, please select one of the other two modes of transportation. Sorry for the inconvenience.");
            }

            UCMapScreen _ucMap;

            if (!originChange.Equals("new"))
            {
                Console.WriteLine("NOT NULL");
                _ucMap = new UCMapScreen(_main, this.txtBlockAddress.Text.ToString().Replace("\n", " "), originChange);
            } else
            {
                _ucMap = new UCMapScreen(_main, this.txtBlockAddress.Text.ToString().Replace("\n", " "));
                
            }
            
            TabItem _tabPage = new TabItem();

            //Code for color
            _main.screenColor(Brushes.Gold, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Gold, _tabPage); };

            _tabPage.Header = "Navigation";

            _tabPage.Content = _ucMap;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void btnRestaurantsNearby_Click(object sender, RoutedEventArgs e)
        {
            _main.resetTab(_main.tabControl.SelectedIndex);

            String newOrigin = this.txtBlockAddress.Text.ToString().Replace("\n", " ");

            UCRestaurants _ucRestaurants = new UCRestaurants(_main, newOrigin);
            TabItem _tabPage = new TabItem();


            //Code for color
            _main.screenColor(Brushes.Lavender, _tabPage);
            _tabPage.MouseLeftButtonUp += delegate { _main.screenColor(Brushes.Lavender, _tabPage); };

            _tabPage.Header = "Restaurants";

            _tabPage.Content = _ucRestaurants;
            _main.tabControl.Items.Add(_tabPage);
            _main.tabControl.SelectedItem = _tabPage;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Image newImage = (Image)listBox.SelectedItem;
                imgPicture.Source = newImage.Source;
            }
            
        }
    }
}
