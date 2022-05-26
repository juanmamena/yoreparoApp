using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace yoreparoApp
{
    public partial class MainPageGPS : ContentPage
    {
        public MainPageGPS()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try { 
            var timeoutmillis = new TimeSpan(10000);
            
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;


            var position = await locator.GetPositionAsync(timeout: timeoutmillis);
            LongitudLabel.Text = position.Longitude.ToString();
            LatitudLabel.Text = position.Latitude.ToString();
            }catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }
    }
}
