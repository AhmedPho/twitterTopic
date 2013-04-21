using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;

namespace twitterTopic.view.test.twitterOAuth
{
    public partial class done : System.Web.UI.Page
    {
        twtUser twt;
        protected void Page_Load(object sender, EventArgs e)
        {
            twt = (twtUser)Session["objTwt"];
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var auth = new WebAuthorizer
            {
                Credentials = new SessionStateCredentials()
            };

            var twitterCtx = new TwitterContext(auth);

            //twtUser twt = (twtUser)Session["objTwt"];

            string name = TextBoxUser.Text;// twt.getScreenName();

            Label1.Text = twt.getToken();
            Label2.Text = twt.getTokenSecret();
            Label4.Text = twt.getScreenName();
            var statusTweets =
              from tweet in twitterCtx.Status
              where tweet.Type == StatusType.User
                    && tweet.ScreenName == name
                    && tweet.Count == 200
                    && tweet.ExcludeReplies == true
                    && tweet.IncludeMyRetweet == false
                    && tweet.IncludeRetweets == false
              select tweet;

            
            var test = statusTweets.Select(tweet => tweet.Text).ToArray();
            var test2 = statusTweets.Select(tweet => tweet.RetweetCount).ToArray();
            var test3 = statusTweets.Select(tweet => tweet.UserID).ToArray();

            List<String> test8 = new List<string>();
            test8.AddRange(test);
            List<int> test9 = new List<int>();
            test9.AddRange(test2);
            List<String> test10 = new List<string>();
            test10.AddRange(test3);

            twt.setarrTwts(test8);
            twt.setarrTwtsRT(test9);

            List<String> tempTWT = new List<string>();
            tempTWT = twt.getarrTwts();
            List<int> tempRT = new List<int>();
            tempRT = twt.getarrTwtsRT();
            for (int k = 0; k < tempTWT.Count; k++)
            {
                classes.DBConnection NewConnection = new classes.DBConnection();
                NewConnection.AddTweetInDB(tempTWT[k], " ", TextBoxUser.Text, " ");
                TextBox3.Text += tempTWT[k] + "\n\n" + tempRT[k] + "\n\n\n" + test10[k] + "\n\n\n";

            }
            Label3.Text = tempTWT.Count.ToString();
            //----------------------------------
            var lists =
                (from list in twitterCtx.List
                 where list.Type == ListType.Lists &&
                       list.ScreenName == twt.getScreenName()
                 select list)
                .ToList();
            TextBox1.Text = "";
            TextBox2.Text = "";
            foreach (var list in lists)
            {
                Console.WriteLine("ID: {0}  Slug: {1} Description: {2}",
                    list.ListIDResult, list.SlugResult, list.Description);
                 TextBox1.Text = TextBox1.Text + " " +list.ListIDResult+" - " + list.SlugResult + " - " +  list.Description + "\n";
            }
            //---------------------------------
            foreach (var Mylists in lists)
            {
                var lists1 =
                    (from list in twitterCtx.List
                     where list.Type == ListType.Members &&
                     //list.ListID == "88244464"
                     list.ListID == Mylists.ListIDResult
                     select list).First();

                TextBox2.Text = TextBox2.Text + "\n" + Mylists.SlugResult + "( " + Mylists.Description + " ) " + " : " + "\n";
                //TextBox2.Text = lists1.Users.First().Name.ToString();//(i).Users.ToList();
                foreach (var UsersOfList in lists1.Users)
                {
                    TextBox2.Text = TextBox2.Text + UsersOfList.Identifier.ID + " - " + UsersOfList.Name.ToString() + "\n";
                }
            }
            
        }

        
    }
}