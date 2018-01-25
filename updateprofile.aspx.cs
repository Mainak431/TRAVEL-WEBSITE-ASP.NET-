using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public partial class updateprofile : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Customer"] != null)
        {
            Label2.Text = Session["Customer"].ToString();
            Label3.Text = Session["User_name"].ToString();
            HyperLink2.Visible = false;
        }
        else
        {
            if (Session["Admin"] != null)
            {
                Label2.Text = Session["Admin"].ToString();
                HyperLink1.Visible = false;
            }
            else
            {
                MessageBox.Show("U Have to Login First");
                Response.Redirect("login.aspx");
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        if (Session["Customer"] != null)
        {
            MySqlCommand sd = new MySqlCommand("SELECT count(*) from customer where User_name='" + Label3.Text + "'and Cpassword='" + TextBox2.Text + "'", con);
            string str1 = "select Cpassword from customer where  User_name='" + Label3.Text + "'and Cpassword='" + TextBox2.Text + "'";
            string str = TextBox2.Text;
            MySqlCommand cmd2 = new MySqlCommand(str1, con);
            object obj2 = cmd2.ExecuteScalar();
            string str3 = Convert.ToString(obj2);
            object obj = sd.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0 && str3.Contains(str))
            {
                string sql = ("update customer set Cpassword='" + TextBox3.Text + "' where User_name='" + Label3.Text + "'and Cpassword='" + TextBox2.Text + "'");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully.... U have to Login again...");
                Response.Redirect("login.aspx");

            }
            else
            {
                MessageBox.Show("User name or password does not match");

                Response.Redirect("updateprofile.aspx");
            }
            sd.ExecuteNonQuery();
        }
        else
        {
            string str1 = "select lpassword from admin where  User_name='" + Label2.Text + "'and lpassword='" + TextBox2.Text + "'";
            string str = TextBox2.Text;
            MySqlCommand cmd2 = new MySqlCommand(str1, con);
            object obj2 = cmd2.ExecuteScalar();
            string str3 = Convert.ToString(obj2);
            if(str3.Contains(str))
            {
                string sql = ("update admin set lpassword='" + TextBox3.Text + "' where User_name='" + Label2.Text + "'and lpassword='" + TextBox2.Text + "'");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully.... U have to Login again...");
                Response.Redirect("login.aspx");
            }
            else
            {
                MessageBox.Show("User name or password does not match");

                Response.Redirect("updateprofile.aspx");
            }
            con.Close();
        }
    }



  

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}