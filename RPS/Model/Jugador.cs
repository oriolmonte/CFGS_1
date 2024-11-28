using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Model
{
    public class Jugador
    {
        string id;
        string nom;
        int punts;
        string foto;


        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Punts { get => punts; set => punts = value; }
        public string Foto { get => foto; set => foto = value; }
    }
}
