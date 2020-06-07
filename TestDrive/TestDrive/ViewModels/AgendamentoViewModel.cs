using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel
    {

        public AgendamentoViewModel(Veiculo veiculo) 
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
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

    }
}
