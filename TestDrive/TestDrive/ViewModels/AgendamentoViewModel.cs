using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {

        const string URL_SALVAR_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public AgendamentoViewModel(Veiculo veiculo) 
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            this.BtnAgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "BtnAgendarCommand");
            }, ()=> 
            {
                return !string.IsNullOrEmpty(this.Nome)
                    && !string.IsNullOrEmpty(this.Fone)
                    && !string.IsNullOrEmpty(this.Email);
            });
        }

        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }

        public string Nome
        {
            get
            {
                return Agendamento.Pessoa.Nome;
            }
            set
            {
                Agendamento.Pessoa.Nome = value;
                OnPropertyChanged();
                ((Command)BtnAgendarCommand).ChangeCanExecute();
            }
        }
        public string Fone
        {
            get
            {
                return Agendamento.Pessoa.Fone;
            }
            set
            {
                Agendamento.Pessoa.Fone = value;
                OnPropertyChanged();
                ((Command)BtnAgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return Agendamento.Pessoa.Email;
            }
            set
            {
                Agendamento.Pessoa.Email = value;
                OnPropertyChanged();
                ((Command)BtnAgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }

        public ICommand BtnAgendarCommand { get; set; }

        public async System.Threading.Tasks.Task SalvarAgendamentoAsync() 
        {
            HttpClient client = new HttpClient();
            var dataHoraAgendamento = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                                                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);
            var json = JsonConvert.SerializeObject(new 
            { 
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var retorno = await client.PostAsync(URL_SALVAR_AGENDAMENTO, content);

            if (retorno.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(Agendamento, "SucessoAgendamento");
            }
            else 
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }


        }

    }
}
