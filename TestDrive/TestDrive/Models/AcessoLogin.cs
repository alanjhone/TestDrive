using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class AcessoLogin
    {
        public AcessoLogin(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
