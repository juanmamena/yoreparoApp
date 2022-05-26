using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using yoreparoApp.Models;
using Newtonsoft.Json;
using System.Text;
using Prism.Navigation;
using Acr.UserDialogs;

namespace yoreparoApp.Views
{
    public partial class LoginPage1 : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();

        public BodyOut bodyOut = new BodyOut();

        private readonly INavigationService _navigationService;

        public LoginPage1()
        {
            InitializeComponent();
        }

        async void btnIniciarSesion_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
                User user = new User();

                user.userName = txtUsuario.Text;
                user.password = txtContrasena.Text;

                var client = new HttpClient();
                Uri uri = new Uri(string.Format(Constantes.URL_LOGIN, string.Empty));
                string json = JsonConvert.SerializeObject(user);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);


                string responseString = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<object>(responseString);
                string data = Convert.ToString(obj);

                bodyOut = new BodyOut();
                bodyOut = JsonConvert.DeserializeObject<BodyOut>(data);
                if (bodyOut.operationSuccesfull != true)
                {
                    await DisplayAlert("LOGIN", bodyOut.error.message, "CERRAR");
                   
                }
                else
                {
                    await DisplayAlert("LOGIN", bodyOut.error.message, "CERRAR");
                    await Navigation.PushAsync(new CategoriesPage(bodyOut.user.name1));
                }
                UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR EN LOGIN", ex.Message, "Cerrar");
            }




        }

        async void btnRegistrarme_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            await Navigation.PushAsync(new UserRegistrationPage("Confirme su ubicación"));
            UserDialogs.Instance.HideLoading();
        }
    }
}
