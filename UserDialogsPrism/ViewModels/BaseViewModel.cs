using System;
using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;

namespace UserDialogsPrism.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value, RaiseIsBusyChanged);
        }

        public event EventHandler IsBusyChanged;

        protected INavigationService _navigationService;
        protected IUserDialogs _userDialogs;

        public BaseViewModel(INavigationService navigationService,
                            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;

            IsBusyChanged += HandleIsBusyTrue;
            IsBusyChanged += HandleIsBusyFalse;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters) { }

        public virtual void OnNavigatedTo(NavigationParameters parameters) { }

        public virtual void OnNavigatingTo(NavigationParameters parameters) { }

        private void RaiseIsBusyChanged()
        {
            IsBusyChanged?.Invoke(this, EventArgs.Empty);
        }

        protected void HandleIsBusyTrue(object sender, EventArgs e)
        {
            if (IsBusy == false) return;

            _userDialogs.ShowLoading("Loading", MaskType.Black);
        }

        protected void HandleIsBusyFalse(object sender, EventArgs e)
        {
            if (IsBusy == true) return;

            _userDialogs.HideLoading();
        }

        public void Destroy() 
        {
            IsBusyChanged -= HandleIsBusyTrue;
            IsBusyChanged -= HandleIsBusyFalse;
        }
    }
}
