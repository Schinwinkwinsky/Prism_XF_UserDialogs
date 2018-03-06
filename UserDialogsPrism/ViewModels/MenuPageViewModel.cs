using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;

namespace UserDialogsPrism.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        public DelegateCommand ActionSheetCommand { get; set; }
        public DelegateCommand AlertCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public DelegateCommand ToastCommand { get; set; }

        public MenuPageViewModel(INavigationService navigationService,
                                 IUserDialogs userDialogs)
            : base(navigationService, userDialogs)
        {
            Title = "Menu Page";

            ActionSheetCommand = new DelegateCommand(ActionSheetMethod);
            AlertCommand = new DelegateCommand(AlertMethod);
            ConfirmCommand = new DelegateCommand(ConfirmMethod);
            ToastCommand = new DelegateCommand(ToastMethod);
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;

            await Task.Delay(5000);

            IsBusy = false;
        }

        private async void ActionSheetMethod()
        {
            var result = await _userDialogs.ActionSheetAsync("Choose an option",
                                               "Cancel",
                                               null,
                                               null,
                                                new string[] { "Page A", "Page B" });

            if (result == "Page A")
                await _navigationService.NavigateAsync("PageA");
            else
                await _navigationService.NavigateAsync("PageB");
        }

        private async void AlertMethod()
        {
            await _userDialogs.AlertAsync("This is an UserDialogs Alert",
                                         "Alert",
                                          "OK");
        }

        private async void ConfirmMethod()
        {
            var result = await _userDialogs.ConfirmAsync("Confirm if you are learning how to use UserDialogs funcions.",
                                                        "Confirmation",
                                                        "Yes",
                                                         "No");

            if (result == true)
                await _userDialogs.AlertAsync("That's great!",
                                              "Congratulations",
                                             "OK");
            else
                await _userDialogs.AlertAsync("Don't surrender!",
                                             "Try Again",
                                              "OK");
            
        }

        private void ToastMethod()
        {
            _userDialogs.Toast("This is a Toast");
        }
    }
}
