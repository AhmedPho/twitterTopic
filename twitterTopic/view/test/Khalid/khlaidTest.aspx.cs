using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace stopwordRemovel
{
    

    public partial class index : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

         


        protected void btnRemoveStopword_Click(object sender, EventArgs e)
        {
            twitterTopic.classes.clean myClean = new twitterTopic.classes.clean();
            TxtBoxOutput.Text = myClean.stopwordsRemove(TxtBoxInput.Text);
            lblNumOfSW.Text = myClean.getNumWordRmov().ToString();
        }
        






























    }


    

}