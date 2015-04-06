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
using System.Collections.ObjectModel;
using Microsoft.Phone.Tasks;

namespace UnicaucaEstereo2
{
    public partial class MainPage : PhoneApplicationPage, Conexion<Musica>.Iconexion
    {
        DataModel dataM;
        Conexion<Musica> conexion;
        resultadosBusqueda RB = new resultadosBusqueda();
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
           dataM = Application.Current.Resources["dataModel"] as DataModel;

            for (int i = 0; i < documents.Count; i++)
            {
                dataM.Data.Add(documents.ElementAt(i));
            }
        }

        private void btnBuscar(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int j = 0;
            DataModelResult dataRes = Application.Current.Resources["dataModelResult"] as DataModelResult;
            dataRes.DataR.Clear();
            try
            {
                 for (int i = 0; i < dataM.Data.Count(); i++)
                //for (int i = 0; i < 5; i++)
                 {
                    String title = dataM.Data.ElementAt(i).title;
                    String artist = dataM.Data.ElementAt(i).artist;
                                         
                    if (title != null)
                    {
                        if (title.ToUpper().Contains(busqueda.Text.ToUpper()))
                        {
                            j = 1;
                            dataRes.DataR.Add(dataM.Data.ElementAt(i));
                        }
                        if (artist.ToUpper().Contains(busqueda.Text.ToUpper()))
                        {
                            j = 1;
                            dataRes.DataR.Add(dataM.Data.ElementAt(i));
                        }
                    }
                   
                }
               
                if(j == 0)
                {
                    MessageBox.Show("No se encontró: " + busqueda.Text);
                }
                else
                {                  
                    //MessageBox.Show("contexto de resultadosbusqueda = datares ");
                    NavigationService.Navigate(new Uri("/resultadosBusqueda.xaml", UriKind.Relative));
                }
                
                
            }
            catch(Exception exp)
            {
                MessageBox.Show("Error: " + exp.GetBaseException());
            }
            busqueda.Text = "";
        }

        private void Facebook(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var page = new WebBrowserTask();
            Uri direccion = new Uri("https://www.facebook.com/pages/Unicauca-Estereo/245571882310420", UriKind.Absolute);
            page.Uri = direccion;
            page.Show();
        }

        private void Twitter(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var page = new WebBrowserTask();
            Uri direccion = new Uri("https://twitter.com/unicaucaestereo", UriKind.Absolute);
            page.Uri = direccion;
            page.Show();
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