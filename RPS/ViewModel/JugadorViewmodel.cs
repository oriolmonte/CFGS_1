using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class JugadorViewmodel : ObservableObject
    {
        [ObservableProperty] 
        string id;
        [ObservableProperty]
        string nom;
        [ObservableProperty]
        int punts;
        [ObservableProperty]
        string foto;

        ObservableCollection<Jugador> jugadors = new();
        IRepositori repositori = Repositori.ObreBDClients();


    }
}
