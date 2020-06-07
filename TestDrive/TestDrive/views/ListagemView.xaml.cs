using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.views;
using Xamarin.Forms;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {

        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();
            this.Veiculos = new List<Veiculo>
            { 
                new Veiculo {Nome = "Hillux", Preco=150000},
                new Veiculo {Nome = "HB20", Preco=40000},
                new Veiculo {Nome = "S10", Preco=130000},
                new Veiculo {Nome = "Gol G6", Preco=30000},
            };

            listViewVeiculos.ItemsSource = this.Veiculos;

            this.BindingContext = this;
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo) e.Item;

            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}
