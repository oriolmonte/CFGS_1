using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StarterTeclatMouseControlsDinàmics.Model
{
    public class Persona : DependencyObject //Ha de derivar d'aquesta
    {
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public int AnyDeNaixement
        {
            get
            {
                return (int)GetValue(AnyDeNaixementProperty);
            }

            set
            {
                SetValue(AnyDeNaixementProperty, value);
            }

        }
        //propdp snippet!
        //propdp snippet!
        //propdp snippet!

        public int AnyDeCasament
        {
            get { return (int)GetValue(AnyDeCasamentProperty); }
            set { SetValue(AnyDeCasamentProperty, value); }
        }

        //propdp snippet!//propdp snippet!

        // Using a DependencyProperty as the backing store for AnyDeCasament.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnyDeCasamentProperty =
            DependencyProperty.Register("AnyDeCasament", typeof(int), typeof(Persona), new PropertyMetadata(
                //Una propietat de dependencia té uns valors heretats (del contenidor, logics...)
                //Una propietat de dependencia té a part un valor predeterminat
                //Posteriorment se li pot assignar un valor
                //El valor coaccionat va per sobre de tota la resta. 
                1920,
                new PropertyChangedCallback(OnAnyDeCasament_Changed),
                new CoerceValueCallback(OnAnyDeCasament_Coerced)
                ));

        private static object OnAnyDeCasament_Coerced(DependencyObject d, object baseValue)
        {
            Persona persona = (Persona)d;
            int anyCasament = (int)baseValue;
            if (persona.AnyDeCasament < persona.AnyDeNaixement)
                anyCasament = persona.AnyDeNaixement;
            if (persona.AnyDeCasament > persona.AnyDeDefuncio)
                anyCasament = persona.AnyDeDefuncio;
            return anyCasament;
        }

        

        private static void OnAnyDeCasament_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Persona persona = (Persona)d;           

        }

        public int AnyDeDefuncio
        {
            get { return (int)GetValue(AnyDeDefuncioProperty); }
            set { SetValue(AnyDeDefuncioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnyDeDefuncio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnyDeDefuncioProperty =
            DependencyProperty.Register("AnyDeDefuncio", typeof(int), typeof(Persona), new PropertyMetadata(
                1920,
                new PropertyChangedCallback(OnAnyDeDefuncio_Changed),
                new CoerceValueCallback(OnAnyDeDefuncio_Coerced)
                ));

        private static void OnAnyDeDefuncio_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Persona persona = (Persona)d;
            //Coaccionem el valor
            persona.CoerceValue(e.Property);
            persona.CoerceValue(AnyDeDefuncioProperty);
        }
        private static object OnAnyDeDefuncio_Coerced(DependencyObject d, object baseValue)
        {
            //NO POT TENIR UN ANY DE DEFUNCIO MENOR QUE NAIXEMENT..
            Persona persona = (Persona)d;
            int anyMort = (int)baseValue;
            if (persona.AnyDeNaixement > anyMort)
                anyMort = persona.AnyDeNaixement;
            return anyMort;
        }
        //PROP de dependencia sempre public static readonly
        public static readonly DependencyProperty AnyDeNaixementProperty =
            DependencyProperty.Register(
                "AnyDeNaixement",
                typeof(int),
                typeof(Persona),
                new PropertyMetadata(
                    1900,
                    //Callback que passa quan canvia el valor, cridem el mètode dins
                    new PropertyChangedCallback(OnAnyDeNaixement_Changed)
                    )
                );

        private static void OnAnyDeNaixement_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Persona persona = (Persona)d;
            persona.CoerceValue(AnyDeDefuncioProperty);
            persona.CoerceValue(AnyDeCasamentProperty);
        }

        public override string ToString()
        {
            return $"{Nom} {Cognom} - {AnyDeNaixement} - {AnyDeCasament} - {AnyDeDefuncio}";
        }
    }
}
