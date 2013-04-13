using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;
using System.Configuration;
using System.Diagnostics;

namespace twitterTopic.view.test.twitterOAuth
{
    public class TwitConect
    {

        public  void first() 
        {
            var auth = new PinAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"]
                },
                UseCompression = true,
                GoToTwitterAuthorization = pageLink => Process.Start(pageLink),
                GetPin = () =>
                {
                    // this executes after user authorizes, which begins with the call to auth.Authorize() below.
                    Console.WriteLine("\nAfter you authorize this application, Twitter will give you a 7-digit PIN Number.\n");
                    Console.Write("Enter the PIN number here: ");
                    return Console.ReadLine();
                }
            };

            auth.Authorize();
            using (var twitterCtx = new TwitterContext(auth, "https://api.twitter.com/1/", "https://search.twitter.com/"))
            {
                //Log
                twitterCtx.Log = Console.Out;

                // LINQ to Twitter query goes here
            }

        }
    }
}