using RPS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Dades
{
    public interface IRepositori
    {
        bool Afegeix(Jugador jugador);
        void Crea(int quantitat);
        void Desa(ObservableCollection<Jugador> jugador);
        bool Esborra(string id);
        bool Modifica(Jugador client);
        ObservableCollection<Jugador> Obten();
    }
}
