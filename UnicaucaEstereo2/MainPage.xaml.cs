﻿/*
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
using UnicaucaEstereo2.Resources;
using UnicaucaEstereo2.Models;
using UnicaucaEstereo2.Net;
using System.Collections.ObjectModel;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
using System.Threading;

namespace UnicaucaEstereo2
{
    public partial class MainPage : PhoneApplicationPage, Conexion<Musica>.Iconexion
    {
        DataModel dataM;
        
        resultadosBusqueda RB = new resultadosBusqueda();
        
        Conexion<Musica> conexion;
        ProgramacionDAO programacionDAO;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            programacionDAO = new ProgramacionDAO();
            try
            {
                cargarProgramacionDia();
                programacionDAO.ProgramacionSemana();
                conexion = new Conexion<Musica>();
                conexion.findAllDocuments(this);
            }
            catch
            {
                MessageBox.Show("Comprueba tu conexion a internet");
            }
           
            

            List<Programa> lisIni = programacionDAO.findAllProgramas();
            if(lisIni.Count == 0){            
                programacionDAO.insertAllProgramas();
            }
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
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Envivo.Play();

            }
            else
            {
                MessageBox.Show("Revisa tu conexión a internet");
            }
            
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

                if (j == 0)
                {
                    MessageBox.Show("No se encontró: " + busqueda.Text);
                }
                else
                {
                    //MessageBox.Show("contexto de resultadosbusqueda = datares ");
                    NavigationService.Navigate(new Uri("/resultadosBusqueda.xaml", UriKind.Relative));
                }


            }
            catch (Exception exp)
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

        private void cargarProgramacionDia()
        {
            DateTime hoy = DateTime.Now;
            String dia = hoy.DayOfWeek.ToString();
            
            List<Programa> diaActual = programacionDAO.findActualDay(dia);
            List<Programa> porHora = new List<Programa>();
            Programa prActual = new Programa();

            int hora = hoy.Hour;
            int min = hoy.Minute;
            

            for (int i = 0; i < diaActual.Count(); i++)
            {
                if ((hora >= diaActual.ElementAt(i).startTime)&&(hora <= diaActual.ElementAt(i).endTime))
                {                    
                    porHora.Add(diaActual.ElementAt(i));                    
                }
            }

           

            for (int j = 0; j < porHora.Count(); j++)
            {
                if (porHora.ElementAt(j).endMin < min)
                {
                    prActual = porHora.ElementAt(j);
                }
                else
                {
                    if (porHora.ElementAt(j).endMin >= min)
                    {
                        prActual = porHora.ElementAt(j); 
                    }
                }
            }

            if (prActual.startMin == 0)
            {
                horaPrActual.Text = "" + prActual.startTime + ":0" + prActual.startMin + " - " + prActual.endTime + ":" + prActual.endMin+" ";
            }
            else
            {
                if (prActual.endMin == 0)
                {
                    horaPrActual.Text = "" + prActual.startTime + ":" + prActual.startMin + " - " + prActual.endTime + ":0" + prActual.endMin + " ";
                }
                else
                {

                    horaPrActual.Text = "" + prActual.startTime + ":" + prActual.startMin + " - " + prActual.endTime + ":" + prActual.endMin + " ";
                }
            }
            nombrePrActual.Text = " "+prActual.name;
        }



        //private void traerResultado(object sender, RoutedEventArgs e)
        //{

        //    List<Programa> listapro = programacionDAO.findAllProgramas();
        //    hoy.Text = listapro.Last<Programa>().name;
        //    hoy2.Text = "" + listapro.Count();
        //}

        private void insertarProg(object sender, RoutedEventArgs e)
        {
            programacionDAO.insertAllProgramas();
        }



    }
}