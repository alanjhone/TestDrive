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

        public AgendamentoViewModel AgendamentoViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();
            this.AgendamentoViewModel = new AgendamentoViewModel(veiculo, usuario);
            this.BindingContext = this.AgendamentoViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AssinarMessagens();

        }
          
        private void AssinarMessagens()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "BtnAgendarCommand", async (agendamento) =>
            {

                var status = await DisplayAlert("Salvar Agendamento", "Deseja confirmar esta operação?", "sim", "não");
                if (status)
                {
                    await this.AgendamentoViewModel.SalvarAgendamentoAsync();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Operação realizada com sucesso!", "Ok");
                await Navigation.PopToRootAsync();
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", async (msg) =>
            {
                await DisplayAlert("Agendamento", "Não foi possível realizar esta operação!", "Ok");
                await Navigation.PopToRootAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "BtnAgendarCommand");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }

    }
}