using StarterTeclatMouseControlsDinàmics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StarterTeclatMouseControlsDinàmics
{
    /// <summary>
    /// Lógica de interacción para PropietatsDependencia.xaml
    /// </summary>
    public partial class PropietatsDependencia : Window
    {
        List<Persona> llistaPersones = new List<Persona>();
        public PropietatsDependencia()
        {

            InitializeComponent();
            llistaPersones.Add(new Persona
            {
                Nom="Joan",
                Cognom="Petit",
                AnyDeNaixement=1950,
                AnyDeCasament=1975,
                AnyDeDefuncio=2010
            });
            llistaPersones.Add(new Persona
            {
                Nom = "Pere",
                Cognom = "Cullera",
                AnyDeNaixement = 1910,
                AnyDeCasament = 1945,
                AnyDeDefuncio = 2073
            });
            llistaPersones.Add(new Persona
            {
                Nom = "Pepito",
                Cognom = "Palote",
                AnyDeNaixement = 1950,
                AnyDeCasament = 1985,
                AnyDeDefuncio = 2020
            });
            llistaPersones.Add(new Persona
            {
                Nom = "Maria",
                Cognom = "Fontaneda",
                AnyDeNaixement = 1930,
                AnyDeCasament = 1915,
                AnyDeDefuncio = 2023
            }); llistaPersones.Add(new Persona
            {
                Nom = "Dolores",
                Cognom = "Furertes",
                AnyDeNaixement = 1980,
                AnyDeCasament = 2005,
                AnyDeDefuncio = 2070
            });
            lstPersones.ItemsSource = llistaPersones;
        }

        private void lstPersones_DragOver(object sender, DragEventArgs e)
        {
            //POT ENTRAR QUALSEVOL COSA... he de preguntar
            if(e.Data.GetDataPresent(DataFormats.Text))
                e.Effects = DragDropEffects.Copy;
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void lstPersones_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                lstPersones.ItemsSource = null;
                lstPersones.Items.Add(e.Data.GetData(DataFormats.Text));
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var s = e.Data.GetData(DataFormats.FileDrop) as string[];
                foreach (string f in s)
                {
                    lstPersones.Items.Add(f);
                }
            }
        }
    }
}
