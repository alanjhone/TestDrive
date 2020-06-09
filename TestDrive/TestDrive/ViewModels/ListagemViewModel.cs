using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {

        public ObservableCollection<Veiculo> Veiculos { get; set; }
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get 
            {
                return veiculoSelecionado;
            }
            set 
            {
                veiculoSelecionado = value;
                if (veiculoSelecionado != null)
                    MessagingCenter.Send<Veiculo>(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get
            {
                return aguarde;
            }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ListagemViewModel() 
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;

            HttpClient cliente = new HttpClient();
            var retorno = await cliente.GetStringAsync(URL_GET_VEICULOS);
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(retorno);

            foreach (var veiculojson in veiculosJson) 
            {
                Veiculos.Add(new Veiculo
                {
                    Nome = veiculojson.Nome,
                    Preco = veiculojson.Preco
                });
            }

            Aguarde = false;

        }

        public class VeiculoJson { 
            public string Nome { get; set; }
            public int Preco { get; set; }
        }

    }
}
