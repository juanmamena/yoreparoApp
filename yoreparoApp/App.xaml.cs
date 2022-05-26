using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Sharpnado.Presentation.Forms.RenderedViews;
using yoreparoApp.ViewModels;
using yoreparoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace yoreparoApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage1());
            //await NavigationService.NavigateAsync("MainPage");
            //await NavigationService.NavigateAsync("LoginPage1");
            //await NavigationService.NavigateAsync("CategoriesPage");
            //await NavigationService.NavigateAsync("UserRegistrationPage");
            //await NavigationService.NavigateAsync("RegisterPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavPage>();
            containerRegistry.RegisterForNavigation<LoginPage1, LoginPage1ViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage2, LoginPage2ViewModel>();
            containerRegistry.RegisterForNavigation<CategoriesPage, CategoriesPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage>();
            containerRegistry.RegisterForNavigation<UserRegistrationPage>();


        }
    }
}
