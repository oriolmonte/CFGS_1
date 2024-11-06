﻿using System;
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

namespace RecursosIEstils
{
    /// <summary>
    /// Lógica de interacción para wndRecursosDeFinestra.xaml
    /// </summary>
    public partial class wndRecursosDeFinestra : Window
    {
        public wndRecursosDeFinestra()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush pinzellImatge = (ImageBrush)this.Resources["PinzellLuigi"];
            ImageBrush pinzell2 = (ImageBrush)FindResource("PinzellLuigi");
            this.Resources["PinzellLuigi"] = Brushes.Linen;
        }
    }
}
