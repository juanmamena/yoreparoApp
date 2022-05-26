using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using yoreparoApp.Models;
using Acr.UserDialogs;

namespace yoreparoApp.Views
{
    public partial class UserRegistrationPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();

        public BodyOut bodyOut = new BodyOut();

        public UserRegistrationPage(string ubicacion)
        {
            InitializeComponent();
            txtUbicacion.Text = ubicacion;

        }

        async void btnAceptar_Clicked(System.Object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            Uri uri = new Uri(string.Format(Constantes.URL_CREATE_USER, string.Empty));

           
            if ((txtPassword1.Text).Equals(txtPassword2.Text))
            {
                UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
                User user = new User();
                user.name1 = txtNombre.Text;
                user.lastName1 = txtApellidos.Text;
                user.location = txtUbicacion.Text;
                user.userName = txtCorreo.Text;
                user.mailAdress = txtCorreo.Text;
                user.password = txtPassword2.Text;
                user.profileId = 1;
                user.isActive = true;

                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                String responseString = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<object>(responseString);
                string data = Convert.ToString(obj);

                bodyOut = new BodyOut();
                bodyOut = JsonConvert.DeserializeObject<BodyOut>(data);
                if (bodyOut.operationSuccesfull != true)
                {
                    await DisplayAlert("REGISTRO", bodyOut.error.message, "CERRAR");
                }
                else
                {
                    await DisplayAlert("REGISTRO", bodyOut.error.message, "CERRAR");
                    await Navigation.PushAsync(new LoginPage1());
               
                }
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
                await DisplayAlert("REGISTRO", "Contraseña no coincide", "CERRAR");
                UserDialogs.Instance.HideLoading();
            }
          


        }

        async void btnCancelar_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            await Navigation.PushAsync(new LoginPage1());
            UserDialogs.Instance.HideLoading();
        }

        async void btnVer_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            await Navigation.PushAsync(new RegisterPage());
            UserDialogs.Instance.HideLoading();
        }
    }
}
