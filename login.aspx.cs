using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
public partial class login : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label2.Visible = false;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        Button1.Visible = false;
        Label3.Visible = true;
        Label4.Visible = true;
        Button2.Visible = false;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        Button3.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand sd = new MySqlCommand("SELECT count(*) from customer where User_name='" + TextBox1.Text + "'and Cpassword='" + TextBox2.Text + "'", con);
        string sql = "select Cname from customer where  User_name='" + TextBox1.Text + "'and Cpassword='" + TextBox2.Text + "'";
        string str1 = "select Cpassword from customer where  User_name='" + TextBox1.Text + "'and Cpassword='" + TextBox2.Text + "'";
        string str = TextBox2.Text;
        MySqlCommand cmd2 = new MySqlCommand(str1, con);
        object obj2 = cmd2.ExecuteScalar();
        string str3 = Convert.ToString(obj2);
        MySqlCommand cmd = new MySqlCommand(sql, con);
        object obj = sd.ExecuteScalar();
        object obj1 = cmd.ExecuteScalar();
        string str2 = Convert.ToString(obj1);
        if (Convert.ToInt32(obj) > 0 && str3.Contains(str))
        {
            MessageBox.Show("Login Successful" + "\n" + "Logged in as" + "  " + str2);
            Session["Customer"] = str2;
            Session["Admin"] = null;
            Session["User_name"] = TextBox1.Text;
            Response.Redirect("route.aspx");
            
        }
        else
        {
            MessageBox.Show("Recheck Your User Name and Password");

            Response.Redirect("login.aspx");
        }
        sd.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand sd = new MySqlCommand("SELECT count(*) from admin where User_name='" + TextBox3.Text + "'and lpassword='" + TextBox4.Text + "'", con);
        string sql = "select User_name from admin where  User_name='" + TextBox3.Text + "'and lpassword='" + TextBox4.Text + "'";
        string str1 = "select lpassword from admin where  User_name='" + TextBox3.Text + "'and lpassword='" + TextBox4.Text + "'";
        string sql1 = "select count(master_status) from admin where  User_name='" + TextBox3.Text + "'and lpassword='" + TextBox4.Text + "'";
        string str = TextBox4.Text;
        MySqlCommand cmd2 = new MySqlCommand(str1, con);
        MySqlCommand cmd3 = new MySqlCommand(sql1, con);
        object obj3 = cmd3.ExecuteScalar();
        object obj2 = cmd2.ExecuteScalar();
        string str3 = Convert.ToString(obj2);
        MySqlCommand cmd = new MySqlCommand(sql, con);
        object obj = sd.ExecuteScalar();
        object obj1 = cmd.ExecuteScalar();
        string str2 = Convert.ToString(obj1);
        if (Convert.ToInt32(obj) > 0 && str3.Contains(str))
        {
            MessageBox.Show("Login Successful" + "\n" + "Logged in as ADMIN " + "  " + str2);
            Session["Customer"] = null;
            Session["Admin"] = str2;
            if(Convert.ToInt32(obj3)>0)
            {
                Session["Master"] = "True ";
            }
            else
            {
                Session["Master"] = null;
            }
            Response.Redirect("Default.aspx");

        }
        else
        {
            MessageBox.Show("Recheck Your User Name and Password");

            Response.Redirect("login.aspx");
        }
        sd.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}