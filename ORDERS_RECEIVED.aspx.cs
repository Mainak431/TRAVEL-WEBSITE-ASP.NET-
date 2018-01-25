using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

public partial class ORDERS_RECEIVED : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Admin"]==null)
        {
            MessageBox.Show("U have to Login First");
            Response.Redirect("login.aspx");
        }
        else
        {
            Label5.Text = "Logged in as  " + Session["Admin"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        con.Open();
        MySqlCommand command = new MySqlCommand("SELECT   User_name,Cname,E_mail,Contact_no,City,Pincode,ob FROM customer where User_name= '" + DropDownList1.SelectedItem.ToString() + "'", con);
        MySqlDataAdapter daimages = new MySqlDataAdapter(command);
        DataTable dt = new DataTable();
        daimages.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        MySqlCommand sd = new MySqlCommand("select count(address) from request where User_name='" + DropDownList1.SelectedItem.ToString() + "'", con);
        object obj2 = sd.ExecuteScalar();
        MySqlCommand sd2 = new MySqlCommand("select count(*)from request where User_name='" + DropDownList1.SelectedItem.ToString() + "'",con);
        object obj3 = sd2.ExecuteScalar();

        if (Convert.ToInt32(obj2) > 0)
        {
            MySqlCommand cmd = new MySqlCommand("select address from request where User_name = '" + DropDownList1.SelectedItem.ToString() + "'", con);
            object obj = cmd.ExecuteScalar();
            Label4.Text = Convert.ToString(obj);
            cmd.ExecuteNonQuery();
        }
        if(Convert.ToInt32(obj3)>1)
        {
            DropDownList2.Visible = true;
            Label4.Visible = false;
            Button3.Visible = true;
        }
        string query = "select Request_id from request where User_name ='" + DropDownList1.SelectedItem.ToString() + "'";
        MySqlCommand cy = new MySqlCommand(query, con);
        MySqlDataAdapter ad = new MySqlDataAdapter(cy);
        DataSet dt2 = new DataSet();
        ad.Fill(dt2);
        DropDownList2.DataSource = dt2.Tables[0];
        DropDownList2.DataTextField = "Request_id";
        DropDownList2.DataValueField = "Request_id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("Select", "0"));
        cy.ExecuteNonQuery();
        sd.ExecuteNonQuery();
        sd2.ExecuteNonQuery();
        con.Close();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        Label4.Visible = true;
        string str = "select address from request where Request_id='" + DropDownList2.SelectedItem.ToString() + "'";
        MySqlCommand cmd = new MySqlCommand(str,con);
        object obj = cmd.ExecuteScalar();
        Label4.Text = Convert.ToString(obj);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}