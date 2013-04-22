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
            ///// store user's info from Session
            twt = (twtUser)Session["objTwt"];
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var auth = new WebAuthorizer
            {
                Credentials = new SessionStateCredentials()
            };

            var twitterCtx = new TwitterContext(auth);


            string name =  twt.getScreenName();//TextBoxUser.Text;

            ////// show token and secret and Screen Name in page 
            Label1.Text = twt.getToken();
            Label2.Text = twt.getTokenSecret();
            Label4.Text = twt.getScreenName();

            ///  first API requst before the while loop to get the "maxID"
            var statusTweets =
              from tweet in twitterCtx.Status
              where tweet.Type == StatusType.User
                    && tweet.ScreenName == name         /// get this user's tweets
                    && tweet.Count == 200               /// number of tweets to retrieve in single requst  // max is 200
                    && tweet.ExcludeReplies == true     /// do not show replies
                    && tweet.IncludeMyRetweet == false  /// do not show my retweet
                    && tweet.IncludeRetweets == false   /// do not show other pepole retweet
              select tweet;

            
            var test = statusTweets.Select(tweet => tweet.Text).ToArray();
            var test2 = statusTweets.Select(tweet => tweet.RetweetCount).ToArray();
            var test3 = statusTweets.Select(tweet => tweet.UserID).ToArray();
            
            ////// store tweets and RTConut in var
            var tmepTweet = statusTweets.Select(tweet => tweet.Text).ToArray();
            var tempRetweetCount = statusTweets.Select(tweet => tweet.RetweetCount).ToArray();

            
            List<String> test8 = new List<string>();
            test8.AddRange(test);
            List<int> test9 = new List<int>();
            test9.AddRange(test2);
            List<String> test10 = new List<string>();
            test10.AddRange(test3);

            twt.setarrTwts(test8);
            twt.setarrTwtsRT(test9);

            ///// add tweet and RTCount to temp lists
            List<String> lstTempTweet = new List<string>();
            lstTempTweet.AddRange(tmepTweet);

            List<int> lstTempRTCount = new List<int>();
            lstTempRTCount.AddRange(tempRetweetCount);

            //// to store the Status that retrieve each time from the API   (Status conteant evry thing about the tweet "text" "RTCount" etc..)
            var statusList = new List<Status>(); ;

            //// 22222222222222222222222222222222222222222222222222222
            //// the rest of APT requsts (up to 3200 tweets including replies and retweets)
            int intcall = 1;        // counter for number of requst to twitter API
            while (statusTweets.Count() != 0)
            {

                //// get the ID of last tweet retrieved -1
                ulong maxID = statusTweets.Min(status => ulong.Parse(status.StatusID)) - 1;


                statusTweets =
                  from tweet in twitterCtx.Status
                  where tweet.Type == StatusType.User
                        && tweet.ScreenName == name         /// get this user's tweets
                        && tweet.Count == 200               /// number of tweets to retrieve in single requst  // max is 200
                        && tweet.ExcludeReplies == true     /// do not show replies
                        && tweet.IncludeMyRetweet == false  /// do not show my retweet
                        && tweet.IncludeRetweets == false   /// do not show other pepole retweet
                        && tweet.MaxID == maxID             /// retrieve before this ID
                  select tweet;

                ////// no need to wright in console
                //statusTweets.ToList().ForEach(
                //    tweet => Console.WriteLine(
                //    "Name: {0}, Tweet: {1}\n",
                //    tweet.User.Name, tweet.Text));

                //// store the Status and add 1 to requst counter
                statusList.AddRange(statusTweets);
                intcall++;


            } /// end while loop


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
            
            //---------------------------------- start
            /*
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
                 TextBox1.Text = TextBox1.Text + " " +list.ListIDResult+" - " + list.SlugResult + " - " +  list.Description + "\n";
            }*/
            //---------------------------------
            /*foreach (var Mylists in lists)
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
            }*/
            //----------------------------------- end
        }

        
    }
}