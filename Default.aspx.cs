using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page
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
            if(Session["Master"]!=null)
            {
                Label5.Visible = true;
                HyperLink1.Visible = true;
            }
            Label2.Text = "Logged in As --->" + Session["Admin"].ToString();
        }
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DropDownList1.Visible = true;
        Button2.Visible = true;
        Button3.Visible = true;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "Accepted";
        string sql = ("update request set Re_ack ='"+str+"' where request_id='"+DropDownList1.SelectedItem.ToString()+"'");
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "Rejected";
        string sql = ("update request set Re_ack ='" + str + "' where request_id='" + DropDownList1.SelectedItem.ToString() + "'");
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Default.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "Accepted";
        string sql = ("update request set Re_ack ='" + str + "' where Re_ack='Pending'");
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("All REQUEST ACCEPTED SUCCESSFULLY");
        Response.Redirect("Default.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "Rejected";
        string sql = ("update request set Re_ack ='" + str + "' where Re_ack='Pending'");
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("All REQUEST REJECTED SUCCESSFULLY");
        Response.Redirect("Default.aspx");
    }



    protected void Button7_Click(object sender, EventArgs e)
    {
        Label6.Visible = true;
        Button8.Visible = true;
        GridView1.Visible = false;
        TextBox1.Visible = true;
        Label3.Visible = false;
        Button1.Visible = false;
        Button6.Visible = false;
        Button5.Visible = false;
        DropDownList1.Visible = false;
        Button3.Visible = false;
        Button2.Visible = false;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        con.Open();
        string sql= "select lpassword from admin where User_name='"+Session["Admin"].ToString()+ "' and lpassword='"+TextBox1.Text+"'";
        string pass = TextBox1.Text;
        MySqlCommand cmd = new MySqlCommand(sql, con);
        object obj = cmd.ExecuteScalar();
        cmd.ExecuteNonQuery();
        string check = Convert.ToString(obj);
        if(check.Contains(pass))
        {
            
                string sql1 = "select count(master_status) from admin";
                MySqlCommand sd = new MySqlCommand(sql1, con);
                object obj1 = sd.ExecuteScalar();
                sd.ExecuteNonQuery();
                if (Convert.ToInt32(obj1) == 1 && Session["Master"]!=null)
                {
                    MessageBox.Show("YOU CANT LEAVE THE WEBSITE AS YOU ARE THE ONLY MASTER ADMIN LEFT IN THE WEBSITE" + "\n" + "ADD ONE NEW ADMIN.PROMOTE HIM/HER TO MASTER ADMIN" + "\n" + "THEN LEAVE..." + "\n" + "GoodDay");
                    Response.Redirect("default.aspx");
                }
                else
                {
                    string sql2 = "delete from admin where  User_name='" + Session["Admin"].ToString() + "'and lpassword='" + TextBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Admin , YOU Have Deleted Your Account Successfully.");
		    Session.Abandon();
                    Response.Redirect("login.aspx");
                }
            
            

        }
        else
        {
            MessageBox.Show("Recheck Your Password");
        }
        con.Close();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}