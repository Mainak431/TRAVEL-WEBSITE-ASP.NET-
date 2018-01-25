using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Route : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Admin"]==null)
        {
            if(Session["Customer"]==null)
            {
                Label6.Text = "No Session";
                Label6.Visible = false;
                Button2.Visible = false;
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
                
            }
            else
            {
                Label6.Text = "Logged in As " + Session["Customer"].ToString();
                HyperLink2.Visible = false;
                Menu1.Visible = true;
            }
        }
        else 
        {
            Label6.Text = "Logged in As Admin Name-->" + Session["Admin"].ToString();
            HyperLink1.Visible = false;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = DropDownList1.SelectedItem.ToString();
    }
     protected void GridView2_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Statusclick")
        {
            con.Open();
            Label2.Text = e.CommandArgument.ToString();
            string sql = "select Route_url for route_dtls_id where Route_id='" + Label2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            object obj = cmd.ExecuteScalar();
            string str = Convert.ToString(obj);
            HttpContext.Current.Response.Redirect(str);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        Label3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        GridView2.Visible = true;
        bindgriddata();

   }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void bindgriddata()
    {
        con.Open();
        MySqlCommand command = new MySqlCommand("SELECT   Route_id, Route_dtls, Date, Hotel_sttus, Amt_adult, Amt_child, Image, Map_image,Route_Url FROM route_dtls_id where Route_name= '" + Label1.Text + "'", con);
        MySqlDataAdapter daimages = new MySqlDataAdapter(command);
        DataTable dt = new DataTable();
        daimages.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        con.Close();
    }
}