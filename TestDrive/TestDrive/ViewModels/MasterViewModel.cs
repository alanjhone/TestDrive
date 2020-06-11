using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos(usuario);

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

    }
}
