using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Data;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {

        public Agendamento Agendamento { get; set; }
        public Usuario Usuario { get; set; }

        public AgendamentoViewModel(Veiculo veiculo , Usuario usuario) 
        {
            this.Agendamento = new Agendamento(usuario.Pessoa.Nome, usuario.Pessoa.Fone, usuario.Pessoa.Email, veiculo.Nome, veiculo.Preco);
            this.Usuario = usuario;
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

        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { Agendamento.Preco = value; }
        }

        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }

            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)BtnAgendarCommand).ChangeCanExecute();
            }

        }
        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }

            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)BtnAgendarCommand).ChangeCanExecute();
            }

        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }

            set
            {
                Agendamento.Email = value;
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
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.SalvarAgendamentoServidor(this.Agendamento);
        }


    }
}
