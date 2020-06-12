using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class AgendamentoService
    {

        const string URL_SALVAR_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public async Task SalvarAgendamentoServidor(Agendamento agendamento)
        {
            HttpClient client = new HttpClient();
            var dataHoraAgendamento = new DateTime(agendamento.DataAgendamento.Year, agendamento.DataAgendamento.Month, agendamento.DataAgendamento.Day,
                                                agendamento.HoraAgendamento.Hours, agendamento.HoraAgendamento.Minutes, agendamento.HoraAgendamento.Seconds);
            var json = JsonConvert.SerializeObject(new
            {
                nome = agendamento.Nome,
                fone = agendamento.Fone,
                email = agendamento.Email,
                carro = agendamento.Modelo,
                preco = agendamento.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var retorno = await client.PostAsync(URL_SALVAR_AGENDAMENTO, content);

            agendamento.Confirmado = retorno.IsSuccessStatusCode;
            SalvarAgendamentoDB(agendamento);

            if (agendamento.Confirmado)
            {
                MessagingCenter.Send<Agendamento>(agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        private static void SalvarAgendamentoDB(Agendamento agendamento)
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                dao.Salvar(agendamento);
            }
        }

    }
}
