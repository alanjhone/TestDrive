using System;
using TestDrive.Models;
using TestDrive.views;
using TestDrive.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (user) =>
            {
                MainPage = new MasterDetailView(user);
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
