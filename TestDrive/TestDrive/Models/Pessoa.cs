using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
                
        }

        public Pessoa(string Nome, string Telefone, string Email, string DataNascimento)
        {
            this.Nome = Nome;
            this.Fone = Telefone;
            this.Email = Email;
            this.DataNascimento = DataNascimento;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        public string DataNascimento { get; set; }

    }
}
