using ClientsMVVM.Model;
using ClientsMVVM.Repositiori;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientsMVVM.ViewModel
{
    public class ClientViewmodel : ObservableBase
    {
    
        string nom;
        string cognom;
        string saldo;
        int posicio = -1;
        bool esValid;
        bool estemEditant = false;


        ObservableCollection<Client> clients = new();
        IRepositoriDeClients repositoriDeClients = Repositori.ObreBDClients();

        #region Propietats
        public string Nom
        {
            get
            { 
                return nom; 
            }
            set
            {
                SetProperty(ref nom,value); //el valor de nom canviara, com ho rebra per parametre necessita la referencia a la propietat per canviarla
                NotifyPropertyChanged(nameof(NomComplet));
            }
        }
        public string Cognom
        {
            get
            {
                return cognom;  
            }
            set
            {
                SetProperty(ref cognom,value); 
                NotifyPropertyChanged(nameof(NomComplet));
            }
        }

        public bool EsValid
        {
            get
            {
                return esValid;
            }
            set
            {
                SetProperty(ref esValid,value); 
            }
        }
        public bool EstemEditant
        {
            get
            {
                return estemEditant;
            }
            set
            {
                SetProperty(ref estemEditant, value);
            }
        }
        public string NomComplet
        {
            get
            {
                return Nom+ " "+ cognom;
            }
        }
        public string Saldo
        {
            get => saldo;
            set
            {
                SetProperty(ref saldo, value);
                ValidaDades();
            }
        }
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set => SetProperty(ref clients, value);
        }

        public int Posicio
        {
            get => posicio;
            set => SetProperty(ref posicio, value);
        }

        #endregion
        #region Propietats de Commands
        public ICommand CreaClientsCommand { get; set; }
        public ICommand AfegeixClientCommand { get; set; }
        public ICommand EditaClientCommand {  get; set; }
        public ICommand ConfirmaClientCommand {  get; set; }
        public ICommand DescartaClientCommand { get; set; }
        public ICommand EliminaClientCommand { get; set;}
        #endregion 


        public ClientViewmodel()
        {
            Clients = repositoriDeClients.Obten();
            Posicio = -1;
            #region Commands
            //es un string pk la font es un xml i es un exemple
            CreaClientsCommand = new RelayCommand<String>(
                //LO QUE FARA
                nClients => CreaClients(nClients),
                //CAN EXECUTE
                nclients => Clients.Count == 0
                );
            AfegeixClientCommand = new RelayCommand(
                    obj => AfegeixClient(),
                    obj => EsValid && !EstemEditant
                );
            EditaClientCommand = new RelayCommand(
                    obj => ActivaEdicio(),
                    obj => !EstemEditant && Posicio !=-1
                );
            ConfirmaClientCommand = new RelayCommand(
                    obj => ConfirmaEdicioClient(),
                    obj => EstemEditant && EsValid
                );
            DescartaClientCommand = new RelayCommand(
                    obj => DescartaEdicioClient(),
                    obj => EstemEditant 
                    );
            EliminaClientCommand = new RelayCommand(
                    obj => EliminarClient(),
                    obj => Posicio != -1
                    );
        }


        private void ConfirmaEdicioClient()
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

        private void EliminarClient()
        {
            repositoriDeClients.Esborra(Clients[Posicio].Id);
            Clients = repositoriDeClients.Obten();
        }

        private void DescartaEdicioClient()
        {
            EstemEditant = false;
            Nom = "";
            Cognom = "";
            Saldo = "0";
        }

        private void ActivaEdicio()
        {
            Nom = Clients[Posicio].Nom;
            Cognom = Clients[Posicio].Cognom;
            Saldo = Clients[Posicio].Saldo.ToString();
            EstemEditant = true;

        }

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

        private void CreaClients(string nClients)
        {
            int nClientsInt =0;
            if (Int32.TryParse(nClients, out nClientsInt))
            {
                repositoriDeClients.CreaClients(Convert.ToInt32(nClients));
                Clients = repositoriDeClients.Obten();
            }
            
        }
        #endregion

        public void ValidaDades()
        {
            decimal ssaldo;
            EsValid = !String.IsNullOrEmpty(Nom) && !String.IsNullOrEmpty(Cognom) && Decimal.TryParse(saldo,out ssaldo);
        }
    }
}
