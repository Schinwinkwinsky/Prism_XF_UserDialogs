using System;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;

namespace UserDialogsPrism.ViewModels
{
    public class RootPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToMenuPageCommand { get; set; }

        public RootPageViewModel(INavigationService navigationService,
                                 IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Root Page";

            GoToMenuPageCommand = new DelegateCommand(GoToMenuPage);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //Never call _userDialogs on the RootPage of your project.
        }

        private async void GoToMenuPage()
        {
            await _navigationService.NavigateAsync("MenuPage");
        }
    }
}
