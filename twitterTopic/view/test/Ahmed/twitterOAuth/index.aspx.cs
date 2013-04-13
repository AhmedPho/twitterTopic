using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;
using System.Configuration;
using System.Net;


namespace twitterTopic.view.test.twitterOAuth
{
    public partial class index : System.Web.UI.Page
    {

        private WebAuthorizer auth;
        private TwitterContext twitterCtx;
        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {

            var twitterCtx = new TwitterContext();

            IOAuthCredentials credentials = new SessionStateCredentials();

            if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
            {
                credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
                credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            }



            auth = new WebAuthorizer
            {
                Credentials = credentials,
                PerformRedirect = authUrl => Response.Redirect(authUrl)
            };


            if (!Page.IsPostBack)
            {
                auth.CompleteAuthorization(Request.Url);
            }

            else if (auth.IsAuthorized)
            {
                Label1.Text = "Congratulations, you're authorized";
                
            }

            twitterCtx = new TwitterContext(auth);
            //twitterCtx = auth.IsAuthorized ? new TwitterContext(auth) : new TwitterContext();
            string token = credentials.OAuthToken;
            string sec = credentials.AccessToken;
            name = credentials.ScreenName;
            Label2.Text = token;
            Label3.Text = sec;
            Label4.Text = credentials.UserId;

            twtUser twt = new twtUser(name, token, sec);
            
            Session["objTwt"] = twt;

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            auth.BeginAuthorization(Request.Url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/test/Ahmed/twitterOAuth/done.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


           // var statusTweets = (from tweet in twitterCtx.Status where tweet.Type == StatusType.User && tweet.ScreenName == "ikhalid" select tweet);

            //statusTweets.ToList().ForEach(tweet => Console.WriteLine( "Name: {0}, Tweet: {1}\n", tweet.User.Name, tweet.Text));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Uri u = Request.Url;
            TwitConect t = new TwitConect();
            t.first();
        }
    }
}