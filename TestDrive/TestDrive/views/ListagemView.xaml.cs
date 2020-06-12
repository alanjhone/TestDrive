using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using TestDrive.views;
using Xamarin.Forms;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {

        public ListagemViewModel ListagemViewModel { get; set; }
        readonly Usuario usuario;
        public ListagemView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            ListagemViewModel = new ListagemViewModel();
            this.BindingContext = this.ListagemViewModel;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                (veiculo) =>
                {
                    Navigation.PushAsync(new DetalheView(veiculo, this.usuario));
                });


            await this.ListagemViewModel.GetVeiculos();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

    }
}
