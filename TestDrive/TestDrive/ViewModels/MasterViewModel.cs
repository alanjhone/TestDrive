using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using TestDrive.Media;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {

        private Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }
        public ICommand MeusAgendamentosCommand { get; private set; }
        public ICommand NovoAgendamentoCommand { get; private set; }
        

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private void DefinirComandos(Usuario usuario) 
        {
            EditarPerfilCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfilCommand");
            });

            SalvarPerfilCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });

            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });

            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            MeusAgendamentosCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "MeusAgendamentos");
            });

            NovoAgendamentoCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "NovoAgendamento");
            });

        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos(usuario);
            AssinarComandos();
        }

        private void AssinarComandos()
        {
            MessagingCenter.Subscribe<byte[]>(this, "FotoCapturada", (bytes) =>
            {
                ImagemPerfil = ImageSource.FromStream(() => new MemoryStream(bytes));
            });
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set 
            { 
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        public string Nome
        {
            get { return this.usuario.Pessoa.Nome; }
            set { this.usuario.Pessoa.Nome = value; }
        }

        public string Email
        {
            get { return this.usuario.Pessoa.Email; }
            set { this.usuario.Pessoa.Email = value; }
        }

        public string DataNascimento
        {
            get { return this.usuario.Pessoa.DataNascimento; }
            set { this.usuario.Pessoa.DataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.usuario.Pessoa.Fone; }
            set { this.usuario.Pessoa.Fone = value; }
        }

        private ImageSource imagemPerfil = "perfil_128.png";

        public ImageSource ImagemPerfil
        {
            get { return imagemPerfil; }
            set 
            { 
                imagemPerfil = value;
                OnPropertyChanged();
            }
        }


    }
}
