using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
namespace yoreparoApp.ViewModels
{
    public class LoginPage1ViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));



        public LoginPage1ViewModel(INavigationService NavigationService)
        {
            Title = "Login Page";
            _navigationService = NavigationService;
        }

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("CategoriesPage");
        }
    }
}
