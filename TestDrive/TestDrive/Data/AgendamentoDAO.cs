using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento) 
        {
            if (conexao.Find<Agendamento>(agendamento.Id) == null)
                conexao.Insert(agendamento);
            else
                conexao.Update(agendamento);


        }

        private List<Agendamento> lista;

        public List<Agendamento> Lista
        {
            get 
            { 
                return conexao.Table<Agendamento>().ToList();
            }
            set { lista = value; }
        }


    }
}
