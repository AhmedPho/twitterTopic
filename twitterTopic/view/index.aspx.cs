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

namespace twitterTopic.view
{
    public partial class index : System.Web.UI.Page
    {
        private WebAuthorizer auth;
        private string TwitterID;
        TwitterUser twt;
        IOAuthCredentials credentials;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            credentials = new SessionStateCredentials();

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


            TwitterID = credentials.UserId;
            string token = credentials.OAuthToken;
            string sec = credentials.AccessToken;
            ////// creat twtUser object to store the info about the user
            twt = new TwitterUser(TwitterID, token, sec);


            ////// move user's info to another page throw Session
            Session["objTwt"] = twt;
        }

        protected void Button1_Click(object sender, ImageClickEventArgs e)
        {
            auth.BeginAuthorization(Request.Url);
            Session["AccessToken"] = credentials.AccessToken;
            Session["OAuthToken"] = credentials.OAuthToken;
            if (twt.IsSignUp(TwitterID))
            {
                Response.Redirect("~/view/report.aspx");
            }
            else
            {
                Session["ID"] = twt.GetIDFromDB(TwitterID);
                Response.Redirect("~/view/profile.aspx");
            }

        }
    }
}