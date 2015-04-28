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
using System.Net.NetworkInformation;
using TweetSharp;
using System.Collections.ObjectModel;

namespace UnicaucaEstereo2
{
    public partial class Chat : PhoneApplicationPage
    {
        ObservableCollection<TwitterStatus> data;
        public Chat()
        {
            try
            {
            InitializeComponent();
            TraerPorHashtag();
            }
            catch
            {
                MessageBox.Show("Comprueba tu conexión a internet");
            }
        }

        public TwitterService CrearServicio()
        {
            var service = new TwitterService("zpnBDPJmE7akTNeH3iaR6rVX5", "JDLz7EDUVfC46OqLVqGleft20JVrxT8WyRkYYKRREQsGJpAgIJ");
            service.AuthenticateWith("3142540078-E5SovOi3o9bnn1iTL2tcc7ZSoKRYFE5nULYwkNA", "5tqZvgyT8tnhqrz9TUfkgt70REDrlmcC00Ofl1Qocbi1B");
            return service;
        }

        public void EnviarTweet(object sender, RoutedEventArgs e)
        {
            try{
                var service = CrearServicio();
                service.SendTweet(new SendTweetOptions { Status = "#PideTuCancionEnUnicaucaEstereo " + chat.Text }, (tweet, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            data.Insert(0, tweet);
                            this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = data; });
                            MessageBox.Show("Canción Solicitada");
                            chat.Text = "";
                        }
                        );

                    }
                });

            }        
        catch(Exception exp)
            {
                MessageBox.Show("Debes estar conectado a internet para pedir una canción");
            }
            
        }

        public void TraerPorHashtag()
        {
            var service = CrearServicio();
            service.Search(new SearchOptions { Q = "#PideTuCancionEnUnicaucaEstereo" }, (ts, rep) =>
            {
                if (rep.StatusCode == HttpStatusCode.OK)
                {

                    data = new ObservableCollection<TwitterStatus>(ts.Statuses);

                    this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = data; });
                }
            });
        }
    }
}