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
    /// Lógica de interacción para wndEventSetter.xaml
    /// </summary>
    public partial class wndEventSetter : Window
    {
        public wndEventSetter()
        {
            InitializeComponent();
        }

        private void Element_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender). Background = Brushes.LightGoldenrodYellow;
        }
        private void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }
    }
}
