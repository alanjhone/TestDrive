using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.ViewModels;
using TestDrive.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.BindingContext = new AgendamentoViewModel(veiculo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "BtnAgendarCommand", (agendamento) =>
            {
            DisplayAlert("Agendamento",
                string.Format(
                @" 
                Veículo: {0}
                Nome: {1}
                Fone: {2}
                E-mail: {3}
                Data: {4}
                Hora: {5}",
                agendamento.Veiculo.Nome,
                agendamento.Pessoa.Nome,
                agendamento.Pessoa.Fone,
                agendamento.Pessoa.Email,
                agendamento.DataAgendamento.ToString("dd/MM/yyy"),
                agendamento.HoraAgendamento), "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "BtnAgendarCommand");
        }

    }
}