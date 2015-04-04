using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace UnicaucaEstereo2
{
    public partial class Reproductor : PhoneApplicationPage
    {
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
            ApplicationBar.Buttons.Add(Siguiente);

        }

        void Pause_Click(object sender, EventArgs e)
        {
            reproductor.Pause();
        }

            void Play_Click(object sender, EventArgs e)
            {
                reproductor.Play();
            }
    }
}