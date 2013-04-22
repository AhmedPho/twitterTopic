using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twitterTopic.view.test.twitterOAuth
{
    public class twtUser
    {
        string strScreenName;

        string strToken;
        string strTokenSecret;

        List<string> arrTwts = new List<string>();
        List<int> arrTwtsRT = new List<int>();
        

        public twtUser(string strSN, string strT, string strTS) 
        {
            this.strScreenName = strSN;
            this.strToken = strT;
            this.strTokenSecret = strTS;
        }

        public string getScreenName() { return strScreenName; }
        public string getToken() { return strToken; }
        public string getTokenSecret() { return strTokenSecret; }
        public List<string> getarrTwts() { return arrTwts; }
        public List<int> getarrTwtsRT() { return arrTwtsRT; }

        public void setarrTwts(List<string> twts) { arrTwts.AddRange(twts); }
        public void setarrTwtsRT(List<int> twtsRT) { arrTwtsRT.AddRange(twtsRT); }

        public void setLstTwts(List<string> twts) { arrTwts.AddRange(twts); }
        public void setLstTwtsRT(List<int> twtsRT) { arrTwtsRT.AddRange(twtsRT); }

    }
}