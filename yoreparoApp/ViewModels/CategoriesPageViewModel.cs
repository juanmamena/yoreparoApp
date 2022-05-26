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
    public class CategoriesPageViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService navigationService;


        private static readonly HttpClient client = new HttpClient();
        List<Category> ListaCategorias = new List<Category>();
        public ObservableCollection<Category> categories { get; set; }


        public CategoriesPageViewModel(CollectionView collectionView)
        {
            getCategories(collectionView);
        }

        private async void getCategories(CollectionView collectionView)
        {

            UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Clear);

            var client = new HttpClient();
            var responseString = await client.GetStringAsync(Constantes.URL_GET_CAGORIES);
            string resp = Convert.ToString(responseString);
            JsonConvert.PopulateObject(resp,ListaCategorias);
            categories = new ObservableCollection<Category>(ListaCategorias);
            collectionView.ItemsSource = categories;

            UserDialogs.Instance.HideLoading();

        }

    }
}
