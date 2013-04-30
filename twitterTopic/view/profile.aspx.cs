using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using twitterTopic.classes;

namespace twitterTopic.view
{
    public partial class profile : System.Web.UI.Page
    {
        TwitterUser twt;
        DataSet1TableAdapters.UsersTableAdapter MyUsersTableAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///// store user's info from Session
            twt = (TwitterUser)Session["objTwt"];
            MyUsersTableAdapter = new DataSet1TableAdapters.UsersTableAdapter();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Label1.Text = twt.getToken();
            //Label2.Text = twt.getTokenSecret();
            //MyUsersTableAdapter.InsertQuery(twt.getToken(),twt.getTokenSecret()
        }
    }
}