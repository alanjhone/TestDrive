using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;
using TestDrive.views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {

        public List<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get 
            {
                return veiculoSelecionado;
            }
            set 
            {
                veiculoSelecionado = value;
                if (veiculoSelecionado != null)
                    MessagingCenter.Send<Veiculo>(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel() 
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }

    }
}
