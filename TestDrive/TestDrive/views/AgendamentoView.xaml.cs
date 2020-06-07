using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.AgendamentoViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.AgendamentoViewModel;
        }

        private void Btn_Agendamento_Clicked(object sender, EventArgs e)
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
                this.AgendamentoViewModel.Agendamento.Veiculo.Nome,
                this.AgendamentoViewModel.Agendamento.Pessoa.Nome,
                this.AgendamentoViewModel.Agendamento.Pessoa.Fone,
                this.AgendamentoViewModel.Agendamento.Pessoa.Email,
                this.AgendamentoViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyy"),
                this.AgendamentoViewModel.Agendamento.HoraAgendamento), "OK");
        }
    }
}