using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace twitterTopic.view
{
    public partial class report : System.Web.UI.Page
    {
        string MyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            MyID = (string)Session["ID"];
        }

    }
}