using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using twitterTopic.classes;
namespace twitterTopic.view.test
{
    public partial class AhmedTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            twitterTopic.classes.clean myRoot = new twitterTopic.classes.clean();
            RootLabel.Text = myRoot.GetRoot(TextBox1.Text);
        }
    }
}