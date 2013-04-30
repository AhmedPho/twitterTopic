using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;
using System.Configuration;
using System.Net;
using twitterTopic.classes;
//using System.Data.SqlClient.SqlException;


namespace twitterTopic.view.test.twitterOAuth
{
    public partial class index : System.Web.UI.Page
    {

        private WebAuthorizer auth;
        //private TwitterContext twitterCtx;
        private string UserId;

        protected void Page_Load(object sender, EventArgs e)
        {

            //var twitterCtx = new TwitterContext();

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

            var twitterCtx = new TwitterContext(auth);
            //twitterCtx = auth.IsAuthorized ? new TwitterContext(auth) : new TwitterContext();


            UserId = credentials.UserId;
            string token = credentials.OAuthToken;
            string sec = credentials.AccessToken;

            ////// show token and secret in index page after Authorization
            Label2.Text = token;
            Label3.Text = sec;
            Label4.Text = credentials.UserId;


            ////// creat twtUser object to store the info about the user
            TwitterUser twt = new TwitterUser(UserId, token, sec);


            ////// move user's info to another page throw Session
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/test/Ahmed/twitterOAuth/tweets.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/control_panel/categoryManagement.aspx");
        }
    }
}