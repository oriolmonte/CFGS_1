using ClientsMVVM.Model;
using ClientsMVVM.Repositiori;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsMVVM.ViewModel
{
    public class ClientViewModelAMa : INotifyPropertyChanged
    {
        string id;
        string nom;
        string cognom;
        decimal saldo;
        
        int posicio = -1;
        bool esValid;
        string foto;
        ObservableCollection<Client> clients = new();

        public string NomComplet
        {
            get => Nom + " " + Cognom;
        }
        public string Id { get => id; set => id = value; }
        public string Nom
        {
            get => nom; 
            set
            {
                if (nom != value)
                {
                    nom = value;                    
                    OnCanviEnpropietat();
                    ValidaDades();
                }                    
            }
        }
        public string Cognom
        {
            get => cognom;
            set
            { if (cognom != value)
                {
                    cognom = value;
                    OnCanviEnpropietat();
                    ValidaDades();
                }
            }
        }
        public decimal Saldo { get => saldo; set => saldo = value; }
        public ObservableCollection<Client> Clients { get => clients; set => clients = value; }
        public string Foto { get => foto; set => foto = value; }
        public bool EsValid
        {
            get => esValid; set
            {
                if(esValid!=value)
                {
                    esValid = value;
                    OnCanviEnpropietat();
                }
            }
        }

        IRepositoriDeClients repositoriDeClients = Repositori.ObreBDClients();
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnCanviEnpropietat([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClientViewModelAMa()
        {
            repositoriDeClients.CreaClients(10);
            Clients.Clear();
            Clients = repositoriDeClients.Obten();

        }
        public void ValidaDades()
        {
            string ssaldo = Saldo.ToString();
            EsValid = !String.IsNullOrEmpty(Nom) && !String.IsNullOrEmpty(Cognom) && !String.IsNullOrEmpty(ssaldo);
        }
    }
}
