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

        public Usuario(int id, string senha, Pessoa pessoa)
        {
            this.Id = id;
            this.Senha = senha;
            this.Pessoa = pessoa;
        }

        public int Id { get; set; }

        public string Senha { get; set; }

        public Pessoa Pessoa { get; set; }

    }

    public class LoginResult
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

    }

    public class UsuarioLogado
    {
        public LoginResult Usuario { get; set; }
    }


}
