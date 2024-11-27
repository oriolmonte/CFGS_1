using ClientsMVVM.Model;
using ClientsMVVM.Repositiori;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsMVVM.ViewModel
{
    public partial class ClientViewModelCommunityToolkit : ObservableObject
    {
        IRepositoriDeClients repositoriDeClients = Repositori.ObreBDClients();
        [ObservableProperty] //<- ATRIBUT QUE ENS FA AUTOMATICAMENT ELS ATRIBUTS EN PROPIETATS NOTIFICABLES [COMM TOOLKIT!]
        [NotifyPropertyChangedFor(nameof(NomComplet))] //<-- On es notifica!
        string nom;
        partial void OnNomChanged(string value)
        {
            ValidaDades();
        }
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NomComplet))]
        [NotifyCanExecuteChangedFor(nameof(AfegeixClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(ConfirmaClientCommand))]

        string cognom;
        partial void OnCognomChanged(string value)
        {
            ValidaDades();
        }
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AfegeixClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(ConfirmaClientCommand))]
        string saldo;
        partial void OnSaldoChanged(string value)
        {
            ValidaDades();
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditaClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(EliminaClientCommand))]
        int posicio = -1;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AfegeixClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(ConfirmaClientCommand))]
        bool esValid;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfirmaClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(DescartaClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditaClientCommand))]
        [NotifyCanExecuteChangedFor(nameof(AfegeixClientCommand))]

        bool estemEditant = false;
        [ObservableProperty]
        ObservableCollection<Client> clients = new();
        public String NomComplet { get => Nom + " " + Cognom; }

        public ClientViewModelCommunityToolkit()
        {
            Posicio = -1;
            Clients = repositoriDeClients.Obten();
        }
        [RelayCommand (CanExecute =nameof(CanConfirmaEdicioClient))]
        private void ConfirmaClient()
        {
            Client client = new Client()
            {
                Id = Clients[Posicio].Id,
                Nom = this.Nom,
                Cognom = Cognom,
                Saldo = Decimal.Parse(Saldo),
                Foto = Clients[Posicio].Foto
            };
            repositoriDeClients.Modifica(client);
            Clients = repositoriDeClients.Obten();
            EstemEditant = false;
            Nom = "";
            Cognom = "";
            Saldo = "0";
        }
        [RelayCommand (CanExecute = nameof(CanEliminaClient))]
        private void EliminaClient()
        {
            repositoriDeClients.Esborra(Clients[Posicio].Id);
            Clients = repositoriDeClients.Obten();
        }
        [RelayCommand (CanExecute = nameof(CanDescartaEdicioClient))]
        private void DescartaClient()
        {
            EstemEditant = false;
            Nom = "";
            Cognom = "";
            Saldo = "0";
        }
        [RelayCommand(CanExecute = nameof(CanActivaEdicioClient))]

        private void EditaClient()
        {
            Nom = Clients[Posicio].Nom;
            Cognom = Clients[Posicio].Cognom;
            Saldo = Clients[Posicio].Saldo.ToString();
            EstemEditant = true;

        }
        [RelayCommand(CanExecute = nameof(CanAfegeixClient))]
        private void AfegeixClient()
        {

            Client clientNou = new Client()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = Nom,
                Cognom = Cognom,
                Saldo = decimal.Parse(Saldo),
                Foto = "https://loremflickr.com/320/240/ff14",
            };
            repositoriDeClients.Afegeix(clientNou);
            Clients = repositoriDeClients.Obten();
            Nom = "";
            Cognom = "";
            Saldo = "0";
        }
        [RelayCommand(CanExecute = nameof(CanCreaClients))]
        private void CreaClients(string nClients)
        {
            int nClientsInt = 0;
            if (Int32.TryParse(nClients, out nClientsInt))
            {
                repositoriDeClients.CreaClients(Convert.ToInt32(nClients));
                Clients = repositoriDeClients.Obten();
            }

        }
        private bool CanEliminaClient()
        {
            return Posicio != -1;
        }
        private bool CanDescartaEdicioClient()
        {
            return EstemEditant;
        }
        private bool CanConfirmaEdicioClient()
        {
            return EsValid && !EstemEditant;
        }
        private bool CanActivaEdicioClient()
        {
            return !EstemEditant && Posicio != -1;
        }
        private bool CanAfegeixClient()
        {
            return EsValid && !EstemEditant;
        }
        private bool CanCreaClients()
        {
            return Clients.Count == 0;
        }

        public void ValidaDades()
        {
            decimal ssaldo;
            EsValid = !String.IsNullOrEmpty(Nom) && !String.IsNullOrEmpty(Cognom) && Decimal.TryParse(saldo, out ssaldo);
        }
    }

}
