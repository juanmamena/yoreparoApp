using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Acr.UserDialogs;

namespace yoreparoApp.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            DisplayCurrentLocation();
        }

        public async void DisplayCurrentLocation()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);

                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    txtLatitud.Text = location.Latitude.ToString() ;
                    txtLongitud.Text = location.Longitude.ToString();
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    map.MoveToRegion(mapSpan);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        async void btnValidar_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            string ubicacion = "Lat:" + txtLatitud.Text + "|" + "Long:" + txtLongitud.Text;
            await Navigation.PushAsync(new UserRegistrationPage(ubicacion));
            UserDialogs.Instance.HideLoading();
        }
    }
}
