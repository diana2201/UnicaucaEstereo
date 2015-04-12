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
        public Chat()
        {
            InitializeComponent();
            TraerPorHashtag();
        }

        public TwitterService CrearServicio()
        {
            var service = new TwitterService("vyC1jcdmwiITzLGXFHDwsH7Bt", "L6sarTFzb9QTCzOs1j1NjSdeD2yTZnFrsOzhuN6PN6cEZ3o6KU");
            service.AuthenticateWith("435393700-3XfGClwmkI95SauKX88exrN4aPz5u9hxnIdjK69Z", "UtcU4OATLuZqWJ9wOwIhwm4FEnSyKX7EPwAn3rE1gvpyV");
            return service;
        }

        public void EnviarTweet(object sender, RoutedEventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var service = CrearServicio();
                service.SendTweet(new SendTweetOptions { Status = "#PideTuCancionEnUnicaucaEstereo " + chat.Text }, (tweet, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            MessageBox.Show("Canción Solicitada");
                            chat.Text = "";
                        }
                        );

                    }
                    else
                    {
                        MessageBox.Show("Tweet no enviado" + response.StatusCode.ToString());
                        chat.Text = "";
                    }
                });

            }
            else
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

                    ObservableCollection<TwitterStatus> data = new ObservableCollection<TwitterStatus>(ts.Statuses);

                    this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = data; });
                }
            });
        }
    }
}