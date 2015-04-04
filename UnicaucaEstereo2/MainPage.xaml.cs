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
using UnicaucaEstereo2.Net;

namespace UnicaucaEstereo2
{
    public partial class MainPage : PhoneApplicationPage, Conexion<Musica>.Iconexion
    {
        Conexion<Musica> conexion;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            conexion = new Conexion<Musica>();
            conexion.findAllDocuments(this);

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
                Musica musicaSelected = new Musica();
                musicaSelected = listaCanciones.SelectedItem as Musica;
                reproductor.DataContext = musicaSelected;
                

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

        public void loadDocuments(List<Musica> documents)
        {
            DataModel dataM = Application.Current.Resources["dataModel"] as DataModel;

            for (int i = 0; i < documents.Count; i++)
            {
                dataM.Data.Add(documents.ElementAt(i));
            }
        }

        private void btnBuscar(object sender, System.Windows.Input.GestureEventArgs e)
        {
            DataModel datam = new DataModel();
            var canciones = datam.data;
                         
 
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