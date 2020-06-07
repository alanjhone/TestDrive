using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.views
{
    public class ListagemVeiculos
    {

        public List<Veiculo> Veiculos{ get; set; }

        public ListagemVeiculos() 
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo {Nome = "Hillux", Preco=150000},
                new Veiculo {Nome = "HB20", Preco=40000},
                new Veiculo {Nome = "S10", Preco=130000},
                new Veiculo {Nome = "Gol G6", Preco=30000},
            };
        }
    }
}
