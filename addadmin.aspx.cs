using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public partial class addadmin : System.Web.UI.Page
{

    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Master"] != null)
        {
            Label7.Text = "Logged In As   " + Session["Admin"].ToString();
        }
        else 
        {
            MessageBox.Show("U Need Special Permission To View This Page");
            Response.Redirect("Default.aspx");
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand sd = new MySqlCommand("select count(*) from admin where User_name='" + TextBox1.Text + "' ", con);
        object obj = sd.ExecuteScalar();
        if (Convert.ToInt32(obj) == 0)
        {
            string sql= "insert into admin(User_name,lpassword)Values ('" + TextBox1.Text + "' , '" + TextBox2.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("ADMIN ADDED SUCCESSFULLY");
            Response.Redirect("addadmin.aspx");
        }
        else
        {
            MessageBox.Show("User Name Already Taken.. Provide Another");
            Response.Redirect("addadmin.aspx");
        }
        sd.ExecuteNonQuery();
        con.Close();

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        con.Open();
        string sql = "select count(master_status) from admin where User_name='" + DropDownList1.SelectedItem.ToString() + "'";
        MySqlCommand sd = new MySqlCommand(sql, con);
        sd.ExecuteNonQuery();
        object obj = sd.ExecuteScalar();
        if(Convert.ToInt32(obj)>0)
        {
            MessageBox.Show("You Have No Permission To Delete A Master Admin");
            Response.Redirect("addadmin.aspx");
        }
        else
        {
            string str = "delete from admin where  User_name='" + DropDownList1.SelectedItem.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Admin Deleted Successfully");
            Response.Redirect("addadmin.aspx");
        }
        con.Close();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        con.Open();
        string sql = ("update admin set master_status='1' where User_name='" + DropDownList2.SelectedItem.ToString() + "'");
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("PROMOTION OF SELECTED ADMIN TO MASTER ADMIN IN SUCCESSFUL");
        Response.Redirect("addadmin.aspx");

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}