using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        public ICommand CommandEntrarLogin { get; set; }

        private string login;
        public string Login
        {
            get { return login; }
            set 
            {
                login = value;
                ((Command)CommandEntrarLogin).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set 
            { 
                senha = value;
                ((Command)CommandEntrarLogin).ChangeCanExecute();
            }
        }

        public LoginViewModel() 
        {

            CommandEntrarLogin = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new AcessoLogin(Login, Senha));
            }, () => 
            {
                return !string.IsNullOrEmpty(Login)
                    && !string.IsNullOrEmpty(Senha);
            });

        }

    }
}
