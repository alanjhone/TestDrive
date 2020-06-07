using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {

        public Veiculo Veiculo { get; set; }

        private const int FREIO_ABS = 1000;
        private const int AR_CONDICIONADO = 800;
        private const int MP3 = 500;

        public string TextoFreioAbs
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", AR_CONDICIONADO);
            }
        }

        public string TextoMp3
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", MP3);
            }
        }

        bool temFreioABS;
        bool temArcondicionado;
        bool temMp3;
        public bool TemFreioABS
        {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArcondicionado
        {
            get
            {
                return temArcondicionado;
            }
            set
            {
                temArcondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMP3
        {
            get
            {
                return temMp3;
            }
            set
            {
                temMp3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal 
        {
            get 
            {
                return string.Format("Valor total: R$ {0}", 
                    Veiculo.Preco + 
                    (temFreioABS ? FREIO_ABS : 0) +
                    (temArcondicionado ? AR_CONDICIONADO : 0) +
                    (temMp3 ? MP3 : 0) 
                    );
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;

            this.BindingContext = this;
        }

        private void btnProximo_Clicked(object sender, EventArgs e)
        {


            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}