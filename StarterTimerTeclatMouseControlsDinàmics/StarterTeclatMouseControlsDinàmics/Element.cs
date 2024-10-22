using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarterTeclatMouseControlsDinàmics
{
    public class Element: ContentControl
    {
        SolidColorBrush pinzellFons = new SolidColorBrush(Colors.CadetBlue);
        SolidColorBrush pinzellMarc = new SolidColorBrush(Colors.BlueViolet);
        SolidColorBrush pinzellText = new SolidColorBrush(Colors.White);
        public Element() 
        {
            Border marc = new Border();
            Viewbox viewbox = new Viewbox();
            TextBlock textBlock = new TextBlock();

            this.Content = marc;
            marc.Child = textBlock;

            marc.BorderThickness = new Thickness(5,5,5,5);
            marc.BorderBrush = pinzellMarc;
            marc.Background = pinzellFons;
            textBlock.Foreground = pinzellText;
            
        }
        public Color ColorFons
        {
            get { return pinzellFons.Color; }
            set {  pinzellFons.Color = value;}
        }
        public Color ColorMarc
        {
            get { return pinzellMarc.Color; }
            set { pinzellMarc.Color = value; }
        }
        public Color ColorText
        {
            get { return pinzellText.Color; }
            set { pinzellText.Color = value; }
        }
        public string Text
        {
            get
            {
                Border marc = (Border)(Content);
                TextBlock text = (TextBlock)marc.Child;
                return text.Text;
            }
            set
            {
                Border marc = (Border)(Content);                
                TextBlock text = (TextBlock)marc.Child;
                text.Text = value;
            }
        }
    }
}
