/*
 *Desarrollado por:
 * Hamilton Andrés Urbano Benavides
 * h.a.u.r1993@gmail.com
 * Diana Marcela Samboní
 * dianasamboni22@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnicaucaEstereo2.Models;

namespace UnicaucaEstereo2
{
    public partial class resultadosBusqueda : PhoneApplicationPage
    {
        public resultadosBusqueda()
        {
            InitializeComponent();
        }

        
         private void IrReproductor(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Reproductor.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
             base.OnNavigatedFrom(e);

             Reproductor reproductor = e.Content as Reproductor;

             if (reproductor != null)
             {
                 Musica musicaSelected = new Musica();
                 musicaSelected = listaCanciones.SelectedItem as Musica;
                 reproductor.DataContext = musicaSelected;


             }
         }
        
    }
}