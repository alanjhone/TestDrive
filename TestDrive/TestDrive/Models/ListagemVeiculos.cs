using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;

namespace TestDrive.views
{
    public class ListagemVeiculos
    {
        const string URL_GET_VEICULOS = "aluracar.herokuapp.com";
        public List<Veiculo> Veiculos{ get; set; }

        public ListagemVeiculos() 
        {
            this.Veiculos = new List<Veiculo>();
        }


    }
}
