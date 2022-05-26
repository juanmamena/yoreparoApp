using System;
using System.Collections.Generic;

using Xamarin.Forms;
using yoreparoApp.ViewModels;
using Acr.UserDialogs;

namespace yoreparoApp.Views
{
    public partial class StoresPage : ContentPage
    {
        public StoresPage(int idCategory, string categoryName, string nombreUsuario)
        {
            InitializeComponent();
            BindingContext = new StoresPageViewModel(listStores);
            lblUsuario.Text = nombreUsuario;
            lblCategoriaSeleccionada.Text = idCategory + "-" + categoryName;

        }

        void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        async void btnCerrarSesion_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            await Navigation.PushAsync(new LoginPage1());
            UserDialogs.Instance.HideLoading();
        }

       async void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);
            await Navigation.PushAsync(new CategoriesPage(lblUsuario.Text));
            UserDialogs.Instance.HideLoading();
        }
    }
}
