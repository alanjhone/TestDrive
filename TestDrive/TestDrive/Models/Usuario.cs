using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Usuario
    {

        public Usuario() 
        {
            Pessoa = new Pessoa();
        }

        public int Id { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }

        public Pessoa Pessoa { get; set; }

    }

    public class LoginResult
    {
        public Usuario Usuario { get; set; }
    }
}
