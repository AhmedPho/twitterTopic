using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twitterTopic.classes
{
    public class module
    {
        public static string GetDate()
        {
            DateTime now = DateTime.Now;
            return now.ToShortDateString();
        }
        public static string GetTime()
        {
            DateTime now = DateTime.Now;
            return now.TimeOfDay.ToString();
        }
    }
}