using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms.Platform.Android;

namespace UserDialogsPrism.Droid
{
    [Activity(Label = "UserDialogsPrism", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    internal class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}

