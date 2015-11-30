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
        private String api = "AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY";
        private String _embeddedInstructions = @"
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
                            destination: 'Calgary Tower, Canada',
                            travelMode: google.maps.DirectionsTravelMode.TRANSIT,
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

        private String _embeddedMap = @"
            <!doctype html><html>
                <head>
                    <meta http-equiv='X - UA - Compatible' content='IE=edge'/>
                </head>
                <body>
                    <div id = 'map' style = 'width: 520px; height: 360px;'/>
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
                            destination: 'Calgary Tower, Canada',
                            travelMode: google.maps.DirectionsTravelMode.TRANSIT,
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

        public UCMapScreen(MainWindow _window)
        {
            _main = _window;
            InitializeComponent();
            /* Embedded method of google-maps
            < !doctype html >< html >
                 < head >
                 < meta http - equiv = 'X - UA - Compatible' content = 'IE=edge' />
                            </ head >
                      < body >
                          < iframe class='youtube-player' type='text/html' width='510' height='360' frameborder='0' style='border: 0'
                        src ='https://www.google.com/maps/embed/v1/directions?origin=Chinook Mall&destination=Calgary Tower&mode=transit&key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY'>
                    </iframe>
                </body>
            </html>";
            */
            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("https://maps.google.com/maps?output=embed");
                //queryAddress.Append("https://maps.googleapis.com/maps/api/staticmap?center=Calgary Tower Calgary AB&zoom=14&size=510x360&maptype=roadmap&key=AIzaSyDXmn-af22SRskpan1hT4KljI1XuWKSwVY");
                wbMap.NavigateToString(_embeddedMap);
                wbInstructions.NavigateToString(_embeddedInstructions);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
            }
        }
    }
}
