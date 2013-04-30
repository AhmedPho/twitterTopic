using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace twitterTopic.view.control_panel
{
    public partial class categoryManagement : System.Web.UI.Page
    {
        twitterTopic.classes.DBConnection MyDBConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDBConnection = new twitterTopic.classes.DBConnection();
            //DropDownList1.SelectedValue = "";
            //DropDownList1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (TextBox1.Text == "")
            //{
                MyDBConnection.AddCategory(TextBox1.Text);
            //}
            //else
            //{
            //    Error1.Visible = true;
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //if (TextBox2.Text != "" /*|| DropDownList2.SelectedValue != ""*/)
            //{
                MyDBConnection.EditCategory(int.Parse(DropDownList2.SelectedValue), TextBox2.Text);
            //}
            //else if (TextBox2.Text == "")
            //{
            //    Error1.Visible = true;
            //}
            //else if (DropDownList2.SelectedValue != "")
            //{
            //    Error2.Visible = true;
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //if (DropDownList1.SelectedValue != "")
            //{
                MyDBConnection.DeleteCategory(int.Parse(DropDownList1.SelectedValue));
            //}
            //else if (DropDownList1.SelectedValue == "")
            //{
            //    Error2.Visible = true;
            //}
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MyDBConnection.LinkListToCategory(TextBox3.Text, DropDownList3.SelectedValue);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        

    }
}