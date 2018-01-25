using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Customer"]!=null)
        {
            Label1.Text = "Logged In As " + Session["Customer"].ToString();
        }
        else
        {
            if(Session["Admin"]!=null)
            {
                Label1.Text = "Logged In As " + Session["Admin"].ToString();
            }
            else
            {
                Button1.Visible = false;
                Label1.Visible = false;
            }
            HyperLink1.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}