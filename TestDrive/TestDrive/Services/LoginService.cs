using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class LoginService
    {

        public async Task FazerLogin(AcessoLogin acessoLogin)
        {

            using (var client = new HttpClient())
            {
                var camposLogin = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", acessoLogin.Login),
                    new KeyValuePair<string, string>("senha", acessoLogin.Senha)
                });

                client.BaseAddress = new Uri("https://aluracar.herokuapp.com");

                HttpResponseMessage retorno = null;
                try
                {
                    retorno = await client.PostAsync("/login", camposLogin);
                }
                catch (Exception)
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Ocorreu um erro de conexão com o servidor. Por favor, verifique sua conexão e tente novamente."), "FalhaLogin");
                }


                if (retorno.IsSuccessStatusCode)
                {
                    var conteudoResultado = await retorno.Content.ReadAsStringAsync();
                    var usuarioLogado = JsonConvert.DeserializeObject<UsuarioLogado>(conteudoResultado);
                    MessagingCenter.Send<Usuario>(new Usuario(usuarioLogado.Usuario.Id, acessoLogin.Senha, new Pessoa(
                        usuarioLogado.Usuario.Nome, usuarioLogado.Usuario.Telefone, usuarioLogado.Usuario.Email, usuarioLogado.Usuario.DataNascimento)), "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha inválidos"), "FalhaLogin");
                }


            }
        }
    }

        public class LoginException : Exception
        {
            public LoginException(string message) : base(message)
            {
            }
        }

}
