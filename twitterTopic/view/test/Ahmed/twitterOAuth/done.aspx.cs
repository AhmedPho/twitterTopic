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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var auth = new WebAuthorizer
            {
                Credentials = new SessionStateCredentials()
            };

            var twitterCtx = new TwitterContext(auth);

            twtUser twt = (twtUser)Session["objTwt"];

            string name = "mishari11";// twt.getScreenName();

            Label1.Text = twt.getToken();
            Label2.Text = twt.getTokenSecret();

            string[] aar;
            int i = 0;
            // 111111111111111111111111111111111111111  ////////////////////

            var statusTweets =
              from tweet in twitterCtx.Status
              where tweet.Type == StatusType.User
                    && tweet.ScreenName == name
                    && tweet.Count == 200
                    && tweet.ExcludeReplies == true
                    && tweet.IncludeMyRetweet == false
                    && tweet.IncludeRetweets == false
              select tweet;

            statusTweets.ToList().ForEach(
                tweet => Console.WriteLine(
                "Name: {0}, Tweet: {1}\n",
                tweet.User.Name, tweet.Text));

            var test = statusTweets.Select(tweet => tweet.Text).ToArray();
            var test2 = statusTweets.Select(tweet => tweet.RetweetCount).ToArray();

            List<String> test8 = new List<string>();
            test8.AddRange(test);


            List<int> test9 = new List<int>();
            test9.AddRange(test2);


            for (int j = 0; j < test.Length; j++)
            {
                TextBox1.Text += test[j] + "\n\n\n" + test2[j] + "\n\n" + test.Length + "\n\n";
            }

            var statusList = new List<Status>(); ;

            ////// 2222222222222222222222222222222222222222222222  //////////////////
            //int intcall = 1;
            //while (statusTweets.Count() != 0)
            //{


            //    ulong maxID = statusTweets.Min(status => ulong.Parse(status.StatusID)) - 1;


            //    statusTweets =
            //      from tweet in twitterCtx.Status
            //      where tweet.Type == StatusType.User
            //            && tweet.ScreenName == name
            //            && tweet.Count == 200
            //            && tweet.ExcludeReplies == true
            //            && tweet.IncludeMyRetweet == false
            //            && tweet.IncludeRetweets == false
            //            && tweet.MaxID == maxID
            //      select tweet;

            //    statusTweets.ToList().ForEach(
            //        tweet => Console.WriteLine(
            //        "Name: {0}, Tweet: {1}\n",
            //        tweet.User.Name, tweet.Text));

            //    statusList.AddRange(statusTweets);
            //    intcall++;


            //}

            var test3 = statusList.Select(tweet => tweet.Text).ToArray();
            var test4 = statusList.Select(tweet => tweet.RetweetCount).ToArray();



            test8.AddRange(test3);
            twt.setarrTwts(test8);


            test9.AddRange(test4);
            twt.setarrTwtsRT(test9);



            for (int j = 0; j < test3.Length; j++)
            {
                TextBox2.Text += test3[j] + "\n\n\n" + test4[j] + "\n\n" + test3.Length + "\n\n";
            }


            /////////////////////////////////////////////////////////////////////////////////////////

            List<String> tempTWT = new List<string>();
            tempTWT = twt.getarrTwts();

            List<int> tempRT = new List<int>();
            tempRT = twt.getarrTwtsRT();


            for (int k = 0; k < tempTWT.Count; k++)
            {
                TextBox3.Text += tempTWT[k] + "\n\n" + tempRT[k] + "\n\n\n";

            }

            Label3.Text = tempTWT.Count.ToString();
            //Label4.Text = intcall.ToString();
        }

        
    }
}