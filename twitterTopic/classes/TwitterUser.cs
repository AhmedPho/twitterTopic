using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twitterTopic.classes
{
    public class TwitterUser
    {
        twitterTopic.classes.DBConnection MyDBConnection;
        string UsaerID;
        string strToken;
        string strTokenSecret;
        string Email;
        string TwitterID;
        string UserName;
        string IP;
        

        List<string> arrTwts = new List<string>();
        List<int> arrTwtsRT = new List<int>();


        public TwitterUser(string UsaerID, string strT, string strTS) 
        {
            this.UsaerID = UsaerID;
            this.strToken = strT;
            this.strTokenSecret = strTS;
        }
        public Boolean IsSignUp(string TwitterID)
        {
            return MyDBConnection.IsSignUp(TwitterID);
        }
        public string GetIDFromDB(string TwitterID)
        {
            return MyDBConnection.GetID(TwitterID);
        }
        public string getUsaerID() { return UsaerID; }
        public string getToken() { return strToken; }
        public string getTokenSecret() { return strTokenSecret; }
        public string getEmail() { return Email; }
        public string getTwitterID() { return TwitterID; }
        public string getUserName() { return UserName; }
        public string getIP() { return IP; }
        public List<string> getarrTwts() { return arrTwts; }
        public List<int> getarrTwtsRT() { return arrTwtsRT; }

        public void setarrTwts(List<string> twts) { arrTwts.AddRange(twts); }
        public void setarrTwtsRT(List<int> twtsRT) { arrTwtsRT.AddRange(twtsRT); }

        public void setLstTwts(List<string> twts) { arrTwts.AddRange(twts); }
        public void setLstTwtsRT(List<int> twtsRT) { arrTwtsRT.AddRange(twtsRT); }

        ////  !!!!!!!!!!  there is no ScreenName
        public string getScreenName() { return UserName; }
        
    }
}