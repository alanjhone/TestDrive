using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TestDrive.Services.LoginService;

namespace TestDrive.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginViewModel LoginViewModel { get; set; }

        public LoginView()
        {
            InitializeComponent();
            LoginViewModel = new LoginViewModel();
            this.BindingContext = LoginViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (exc) =>
            {
                await DisplayAlert("Login", exc.Message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }

    }
}