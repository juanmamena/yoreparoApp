using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using yoreparoApp.Models;
using yoreparoApp.Views;

namespace yoreparoApp.ViewModels
{
    public class StoresPageViewModel : BindableBase
    {
      


        private static readonly HttpClient client = new HttpClient();
        List<Store> ListaStores = new List<Store>();
        public ObservableCollection<Store> stores { get; set; }


        public StoresPageViewModel(CollectionView collectionView)
        {
            getStores(collectionView);
        }

        private async void getStores(CollectionView collectionView)
        {

            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);

            var client = new HttpClient();
            var responseString = await client.GetStringAsync(Constantes.URL_GET_STORES);
            string resp = Convert.ToString(responseString);
            JsonConvert.PopulateObject(resp, ListaStores);
            stores = new ObservableCollection<Store>(ListaStores);
            collectionView.ItemsSource = stores;

            UserDialogs.Instance.HideLoading();

        }

    }
}
