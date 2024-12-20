﻿using Ordenacions.Viewmodel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ordenacions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void btnGenera_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (PintaArrayViewModel)DataContext;
            cnvGrafic.Background = viewModel.Fons;
            cnvGrafic.Children.Clear();
            if(cmbFigures.SelectedIndex == 0) 
            {
                foreach (var rect in viewModel.Rectangles)
                {
                    cnvGrafic.Children.Add(rect);
                }
            
            }
            else
            {
                foreach(var circ in viewModel.Circles)
                {
                    cnvGrafic.Children.Add(circ);
                }
            }
            

        }
    }
}