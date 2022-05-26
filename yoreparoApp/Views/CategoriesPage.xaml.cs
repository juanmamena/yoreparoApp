using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Xamarin.Forms;
using yoreparoApp.Models;
using yoreparoApp.ViewModels;

namespace yoreparoApp.Views
{
    public partial class CategoriesPage : ContentPage
    {       
        public CategoriesPage(string nombreUsuario)
        {
            InitializeComponent();
            BindingContext = new CategoriesPageViewModel(listCategories);
            lblUsuario.Text = "!Hola! " + nombreUsuario;
        }

        void listCategories_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            seleccionarItem(e.CurrentSelection);

        }

        async void seleccionarItem(IEnumerable<object> itemSeleccionado)
        {
            int item = (int)((itemSeleccionado.FirstOrDefault() as Category)?.categoryId);
            string categoria = ((itemSeleccionado.FirstOrDefault() as Category)?.description);
            await Navigation.PushAsync(new StoresPage(item,categoria, lblUsuario.Text));
        }

        void btnCerrarSesion_Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}
