using Acr.UserDialogs;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using UserDialogsPrism.ViewModels;
using UserDialogsPrism.Views;
using Xamarin.Forms;

namespace UserDialogsPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) 
            : base(initializer) { }
     
        protected override void OnInitialized()
        {
            InitializeComponent();

            // Never use UserDialogs on this method or on OnNavigatedTo method
            // of the RootPage.
            NavigationService.NavigateAsync("NavigationPage/RootPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RootPage, RootPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<PageA>();
            containerRegistry.RegisterForNavigation<PageB>();

            //Need to register the instance of UserDialogs
            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
        }
    }
}
