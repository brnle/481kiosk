using Microsoft.Win32;
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
        private String destination;
        private String origin = "Chinook Centre";

        public UCMapScreen(MainWindow _window, String location)
        {
            _main = _window;
            InitializeComponent();
            this.textBlock.Text = "Transit Instructions";
            destination = location;
            String _embeddedMap, _embeddedInstructions;

            //Call generic function to develop the appropriate API call strings
            setupContent(0, out _embeddedMap, out _embeddedInstructions);

            //Call generic function to show the map and instructions
            showContent(_embeddedMap, _embeddedInstructions);
        }

        public UCMapScreen(MainWindow _window, String location, String newOrigin)
        {
            _main = _window;
            origin = newOrigin;
            InitializeComponent();
            this.textBlock.Text = "Transit Instructions";
            destination = location;
            Console.WriteLine(destination);
            Console.WriteLine(origin);
            String _embeddedMap, _embeddedInstructions;

            //Call generic function to develop the appropriate API call strings
            setupContent(0, out _embeddedMap, out _embeddedInstructions);

            //Call generic function to show the map and instructions
            showContent(_embeddedMap, _embeddedInstructions);
        }

        //Generic template for creating the appropriate values for each string used in API call
        private void setupContent(int mode, out String _embeddedMap, out String _embeddedInstructions)
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
                            origin: '"+ origin + @"',
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
                <script type = 'text/javascript' src='https://maps.googleapis.com/maps/api/js?key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY&callback=initMap'></script>
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
                            origin: '" + origin + @"',
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
                <script type = 'text/javascript' src='https://maps.googleapis.com/maps/api/js?key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY&callback=initMap'></script>
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
            this.textBlock.Text = "Transit Instructions";
            String _embeddedMap, _embeddedInstructions;
            setupContent(0, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }

        private void btnWalking_Click(object sender, RoutedEventArgs e)
        {
            this.textBlock.Text = "Walking Instructions";
            String _embeddedMap, _embeddedInstructions;
            setupContent(1, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            this.textBlock.Text = "Driving Instructions";
            String _embeddedMap, _embeddedInstructions;
            setupContent(2, out _embeddedMap, out _embeddedInstructions);

            showContent(_embeddedMap, _embeddedInstructions);
        }

        private void btnReverse_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.textBlock.Text = "Transit Instructions";
            String temp = destination;
            destination = origin;
            origin = temp;
            String _embeddedMap, _embeddedInstructions;

            //Call generic function to develop the appropriate API call strings
            setupContent(0, out _embeddedMap, out _embeddedInstructions);

            //Call generic function to show the map and instructions
            showContent(_embeddedMap, _embeddedInstructions);
        }
    }
}
