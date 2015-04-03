using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnicaucaEstereo2.Resources;
using UnicaucaEstereo2.Models;

namespace UnicaucaEstereo2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
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
                Cancion cancionSelected = new Cancion();
                cancionSelected = listaCanciones.SelectedItem as Cancion;
                reproductor.DataContext = cancionSelected;

            }
        }
        
        private void irProgramacion(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Programacion.xaml", UriKind.Relative));
        }

        private void irChat(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Chat.xaml", UriKind.Relative));
        }

        private void EmisoraPlay(object sender, RoutedEventArgs e)
        {
            Envivo.Play();
        }

        private void EmisoraPause(object sender, RoutedEventArgs e)
        {
            Envivo.Pause();
        }
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}