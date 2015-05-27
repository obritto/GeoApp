using ExternalMaps.Plugin;
using Geolocator.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GeoApp
{
    public class App : Application
    {
        Label l = new Label
        {
            XAlign = TextAlignment.Center,
            Text = ""
        };

        double latitude = 0;
        double longitude = 0;

        public App()
        {
            var btn = new Button
            {
                Text = "PEGAR POSIÇÃO"
            };
            btn.Clicked += Btn_Clicked;

            var btn2 = new Button
            {
                Text = "CARREGAR NO MAPA"
            };
            btn2.Clicked += Btn2_Clicked;


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                       l, btn, btn2
                    }
                }
            };
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                l.Text = "obtendo...";

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.
                    GetPositionAsync(timeout: 10000);

                

                l.Text += "Status: " + position.Timestamp + "\n";
                l.Text += "Latitude: " + position.Latitude + "\n";
                l.Text += "Longitude: " + position.Longitude;

                latitude = position.Latitude;
                longitude = position.Longitude;
            }
            catch (Exception ex)
            {
                l.Text = "erro: " + ex.ToString();
            }
        }


        private void Btn2_Clicked(object sender, EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo("teste", latitude,longitude);

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
