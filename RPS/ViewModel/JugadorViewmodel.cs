using RPS.Dades;
using RPS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.ViewModel
{
    public class JugadorViewmodel
    {
        string id;
        string nom;
        int punts;
        string foto;

        ObservableCollection<Jugador> jugadors = new();
        IRepositori repositori = Repositori.ObreBDClients();


    }
}
