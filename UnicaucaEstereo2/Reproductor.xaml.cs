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
using System.ComponentModel;

namespace UnicaucaEstereo2
{
    public partial class Reproductor : PhoneApplicationPage
    {
        DataModel dataM = Application.Current.Resources["dataModel"] as DataModel;
        public Reproductor()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            
        }
        
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            //Set the Application Bar properties as needed
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 0.6;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = false;

            //    // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton Anterior = new ApplicationBarIconButton(new Uri("/Images/transport.rew.png", UriKind.Relative));
            Anterior.Text = "Atras";
            Anterior.Click += Anterior_Click;
            ApplicationBar.Buttons.Add(Anterior);

            ApplicationBarIconButton Play = new ApplicationBarIconButton(new Uri("/Images/transport.play.png", UriKind.Relative));
            Play.Text = "Play";
            Play.Click += Play_Click;
            ApplicationBar.Buttons.Add(Play);
            

            ApplicationBarIconButton Pause = new ApplicationBarIconButton(new Uri("/Images/transport.pause.png", UriKind.Relative));
            Pause.Text = "Pause";
            Pause.Click += Pause_Click;
            ApplicationBar.Buttons.Add(Pause);
            
           

            ApplicationBarIconButton Siguiente = new ApplicationBarIconButton(new Uri("/Images/transport.ff.png", UriKind.Relative));
            Siguiente.Text = "Siguiente";
            Siguiente.Click += Siguiente_Click;
            ApplicationBar.Buttons.Add(Siguiente);

        }

        void Anterior_Click(object sender, EventArgs e)
        {
            int id_new;
            Musica cancionActual = new Musica();
            cancionActual = reproductor.DataContext as Musica;
            int id = cancionActual.id;
            if(id == 1)
            {
                id_new = dataM.Data.Count();
            }
            else
            {
                id_new = id - 1;
            }
            BuscarCancionPorId(id_new);
        }

        void Siguiente_Click(object sender, EventArgs e)
        {
            int id_new;
            Musica cancionActual = new Musica();
            cancionActual = reproductor.DataContext as Musica;
            int id = cancionActual.id;
            if (id == dataM.Data.Count())
            {
                id_new = 1;
            }
            else
            {
                id_new = id + 1;
            }
            BuscarCancionPorId(id_new);
        }

        void Pause_Click(object sender, EventArgs e)
        {
            reproductor.Pause();
            
        }

        void Play_Click(object sender, EventArgs e)
        {
            reproductor.Play();
            
        }

        private void reproductor_MediaEnded(object sender, RoutedEventArgs e)
         {
             Musica cancionActual = new Musica();
             cancionActual = reproductor.DataContext as Musica;
             int id = cancionActual.id;
             int id_new;
             if (id == dataM.Data.Count())
             {
                 id_new = 1;
             }
             else
             {
                 id_new = id + 1;
             }
             BuscarCancionPorId(id_new);

         }

         void BuscarCancionPorId(int id_new)
         {
             int j = 0;
             for (int i = 0; i < dataM.Data.Count(); i++)
             {
                 int id_Found = dataM.data.ElementAt(i).id;

                 if (id_Found == id_new)
                 {
                     j = 1;
                     reproductor.DataContext = dataM.Data.ElementAt(i);
                     nombre.Text = dataM.Data.ElementAt(i).title;
                     artist.Text = dataM.Data.ElementAt(i).artist;
                 }
                 
             }
            if(j == 0)
            {
                MessageBox.Show("No hay mas canciones");
            }
         }

        private void BarraReproducion()
        {
            
            TimeSpan tiempo = reproductor.Position;
            Duration duracion = reproductor.NaturalDuration;
            TimeSpan duracion1 = duracion.TimeSpan;

            int minActual = tiempo.Minutes;
            int segActual = tiempo.Seconds;

            int minTotal = duracion1.Minutes;
            int segTotal = duracion1.Seconds;

            int actual = (minActual * 60) + segActual;
            int total = (minTotal * 60) + segTotal;

            int progreso = (actual * 100) / total;
         
        }

        

        
                
    }
}