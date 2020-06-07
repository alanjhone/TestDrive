using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;
using TestDrive.views;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemViewModel() 
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }

    }
}
