using RPS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RPS.Dades
{
    public class JugadorsXml : IRepositori
    {
        const string NOM_FITXER_XML = @"BBDD/jugadors.xml";
        string RUTA_FITXER_XML = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), NOM_FITXER_XML);
        public void Crea(int quantitat = 10)
        {
            Random random = new Random();
            List<string> noms = new List<string> { "Joan", "Pere", "Maria", "Sílvia", "Ricard", "Lluís", "Roser", "Laura" };

            ObservableCollection<Jugador> jugadors = new ObservableCollection<Jugador>();
            Jugador jugadorActual = null;


            for (int njugador = 0; njugador < quantitat; njugador++)
            {
                jugadorActual = new Jugador()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = noms[random.Next(noms.Count)],
                    Punts = random.Next(0, 5),
                    Foto = "https://loremflickr.com/320/240/"
                };
                jugadors.Add(jugadorActual);
            }

            Desa(jugadors);
        }
        /// <summary>
        /// Desa els jugadors en un fitxer XML
        /// </summary>
        /// <param name="jugadors">Dades dels jugadors que ha de desar</param>
        public void Desa(ObservableCollection<Jugador> jugadors)
        {
            using (TextWriter fitxer = new StreamWriter(RUTA_FITXER_XML, new FileStreamOptions { Mode = FileMode.OpenOrCreate }))
            {

                XmlSerializer serialitzador = new XmlSerializer(typeof(ObservableCollection<Jugador>));
                serialitzador.Serialize(fitxer, jugadors);
            }
        }

        /// <summary>
        /// Obté els jugadors desats en un fitxer XML
        /// </summary>
        /// <returns>Les dades dels jugadors en format de llista observable</returns>
        public ObservableCollection<Jugador> Obten()
        {
            ObservableCollection<Jugador> jugadors;

            using (TextReader fitxer = new StreamReader(RUTA_FITXER_XML)) //
            {
                if (fitxer.Peek() != -1)
                {
                    XmlSerializer serialitzador = new XmlSerializer(typeof(ObservableCollection<Jugador>));
                    jugadors = (ObservableCollection<Jugador>)serialitzador.Deserialize(fitxer);
                }
                else
                {
                    jugadors = new ObservableCollection<Jugador>();
                }
            }
            return jugadors;
        }

        /// <summary>
        /// Elimina un jugador a partir del seu identificador
        /// </summary>
        /// <param name="id">Identificador del jugador a eliminar</param>
        /// <returns></returns>
        public bool Esborra(String id)
        {
            bool esborrat = false;
            ObservableCollection<Jugador> jugadors = Obten();
            Jugador jugadorEliminable = jugadors.FirstOrDefault(jugador => jugador.Id == id);
            if (jugadorEliminable != null)
            {
                jugadors.Remove(jugadorEliminable);
                esborrat = true;
            }
            Desa(jugadors);
            return esborrat;
        }

        /// <summary>
        /// Modifica un jugador
        /// </summary>
        /// <param name="jugador">Noves dades que ha de tenir el jugador</param>
        /// <returns></returns>
        public bool Modifica(Jugador jugador)
        {
            bool modificat = false;
            ObservableCollection<Jugador> jugadors = Obten();
            Jugador jugadorModificable = jugadors.FirstOrDefault(jugadorActual => jugadorActual.Id == jugador.Id);
            if (jugadorModificable != null)
            {
                jugadorModificable.Nom = jugador.Nom;
                jugadorModificable.Punts = jugador.Punts;
                modificat = true;
            }
            Desa(jugadors);
            return modificat;
        }

        /// <summary>
        /// Afegeix un jugador
        /// </summary>
        /// <param name="jugador">Dades del jugador a afegir</param>
        /// <returns></returns>
        public bool Afegeix(Jugador jugador)
        {
            bool afegit = false;
            ObservableCollection<Jugador> jugadors = Obten();
            Jugador jugadorModificable = jugadors.FirstOrDefault(jugadorActual => jugadorActual.Id == jugador.Id);
            if (jugadorModificable == null)
            {
                jugadors.Add(jugador);
                afegit = true;
            }
            Desa(jugadors);
            return afegit;
        }
    }
}
