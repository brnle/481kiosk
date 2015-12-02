﻿using Microsoft.Win32;
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
        private String[] _travelMode = new String[3] {"TRANSIT", "WALKING", "DRIVING"};
        private UCInfoScreen _info;

        public UCMapScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();
           
            TabItem _prevTab = (TabItem)_main.tabControl.Items.GetItemAt(_main.tabControl.Items.Count - 1);
            _info = (UCInfoScreen) _prevTab.Content;
            String destination = _info.txtBlockTitle.Text + " Calgary Alberta" ;
            String _embeddedMap, _embeddedInstructions;

            //Call generic function to develop the appropriate API call strings
            setupContent(destination, 0, out _embeddedMap, out _embeddedInstructions);

            //Call generic function to show the map and instructions
            showContent(_embeddedMap, _embeddedInstructions);
        }

        //Generic template for creating the appropriate values for each string used in API call
        private void setupContent(String destination, int mode, out String _embeddedMap, out String _embeddedInstructions)
        {
            _embeddedMap = @"
            <!doctype html><html>
                <head>
                    <meta http-equiv='X - UA - Compatible' content='IE=edge'/>
                </head>
                <body>
                    <div id = 'map' style = 'width: 535px; height: 385px;'/>
                <script type = 'text/javascript'>
                    function initMap() {
                        var directionsService = new google.maps.DirectionsService();
                        var directionsDisplay = new google.maps.DirectionsRenderer();
                        var map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 13,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        });

                        directionsDisplay.setMap(map);

                        var request = {
                            origin: 'Chinook Centre',
                            destination: '" + destination + @"',
                            travelMode: google.maps.DirectionsTravelMode." + _travelMode[mode] + @",
                            unitSystem: google.maps.UnitSystem.METRIC,
                            optimizeWaypoints: true
                        };

                        directionsService.route(request, function(response, status)
                        {
                            if (status == google.maps.DirectionsStatus.OK)
                            {
                                directionsDisplay.setDirections(response);
                            }
                        });
                    }
                </script> 
                <script type = 'text/javascript' src='https://maps.googleapis.com/maps/api/js?key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY&signed_in=true&callback=initMap'></script>
                <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js'></script>
                </body>
            </html>";

            _embeddedInstructions = @"
            <!DOCTYPE html>
            <html> 
            <head> 
                <meta http-equiv='X - UA - Compatible' content='IE=edge'/>
            </head>
            <body style='font-family: Arial; font-size: 12px;'>
                <div id = 'panel' style = 'width: 150px;'/>
                <script type = 'text/javascript'>
                    function initMap() {
                        var directionsService = new google.maps.DirectionsService();
                        var directionsDisplay = new google.maps.DirectionsRenderer();
                        directionsDisplay.setPanel(document.getElementById('panel'));

                        var request = {
                            origin: 'Chinook Centre',
                            destination: '" + destination + @"',
                            travelMode: google.maps.DirectionsTravelMode." + _travelMode[mode] + @",
                            unitSystem: google.maps.UnitSystem.METRIC,
                            optimizeWaypoints: true
                        };

                        directionsService.route(request, function(response, status)
                        {
                            if (status == google.maps.DirectionsStatus.OK)
                            {
                                directionsDisplay.setDirections(response);
                            }
                        });
                    }
                </script> 
                <script type = 'text/javascript' src='https://maps.googleapis.com/maps/api/js?key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY&signed_in=true&callback=initMap'></script>
                <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js'></script>
            </body> 
            </html>";
        }

        private void showContent(String _map, String _instructions)
        {
            try
            {
                wbMap.NavigateToString(_map);
                wbInstructions.NavigateToString(_instructions);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
            }
        }

        private void btnTransit_Click(object sender, RoutedEventArgs e)
        {
            String destination = _info.txtBlockTitle.Text + " Calgary Alberta";
            String _embeddedMap, _embeddedInstructions;
            setupContent(destination, 0, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }

        private void btnWalking_Click(object sender, RoutedEventArgs e)
        {
            String destination = _info.txtBlockTitle.Text + " Calgary Alberta";
            String _embeddedMap, _embeddedInstructions;
            setupContent(destination, 1, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            String destination = _info.txtBlockTitle.Text + " Calgary Alberta";
            String _embeddedMap, _embeddedInstructions;
            setupContent(destination, 2, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }
    }
}
