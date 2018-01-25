using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public partial class delete : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency"); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Admin"]==null)
        {
            if(Session["Customer"]==null)
            {
                MessageBox.Show("U have to login first...");
                Response.Redirect("login.aspx");
            }
            else
            {
                Label1.Text = "DELETE MY ACCOUNT";
                HyperLink1.Visible = false;
                Label3.Visible = false;
                DropDownList1.Visible = false;
                Label3.Text = Session["User_name"].ToString();
                Label5.Text = Session["Customer"].ToString();
            }
        }
        else
        {
            Label1.Text = "DELETE CUSTOMER ACCOUNT";
            Label2.Visible = false;
            TextBox2.Visible = false;
            HyperLink2.Visible = false;
            Label5.Text = Session["Admin"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        if(Session["Admin"]==null)
        {
            string str = "select count(*) from customer where  User_name = '" + Label3.Text + "'and Cpassword = '" + TextBox2.Text + "'";
            string str1 = "select Cpassword from customer where  User_name='" + Label3.Text + "'and Cpassword='" + TextBox2.Text + "'";
            string str2 = TextBox2.Text;
            MySqlCommand cmd2 = new MySqlCommand(str1, con);
            object obj2 = cmd2.ExecuteScalar();
            string str3 = Convert.ToString(obj2); 
            MySqlCommand sd = new MySqlCommand(str, con);
            object obj = sd.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0&&str3.Contains(str2))
            {
                string sql = "delete from customer where  User_name='" + Label3.Text + "'and Cpassword='" + TextBox2.Text + "'";
                string sql1 = "delete from my_order where User_name ='" + Label3.Text + "'";
                string sql2 = "delete from request where User_name='" + Label3.Text + "'";               
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlCommand sd1 = new MySqlCommand(sql1, con);
                MySqlCommand sd2 = new MySqlCommand(sql2, con);
                sd1.ExecuteNonQuery();
                sd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Deleted Successfully" + "\n" + "We dont give the personal data of user to any third party" + "\n " + "Also be sure your data kept with us till date is successfully deleted" + "\n" + "Consider using our valuable resources again as a registered user" + "\n" + "Goodbye   "+Session["Customer"].ToString());
                MessageBox.Show("Redirecting to Registration Page");
                Session.Abandon();
                Response.Redirect("signup.aspx");
            }
            else
            {
                MessageBox.Show("Password Doesn't Match....Please Recheck the Password ");
                Response.Redirect("delete.aspx");
            }
        }
        else
        {
            string str = DropDownList1.SelectedItem.ToString();
            string sql = "delete from customer where  User_name ='" +str+"'";
            string sql1 = "delete from my_order where User_name ='" + str + "'";
            string sql2 = "delete from request where User_name ='" + str + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlCommand sd1 = new MySqlCommand(sql1, con);
            MySqlCommand sd2 = new MySqlCommand(sql2, con);
            sd1.ExecuteNonQuery();
            sd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("One Customer account deleted successfully");
            Response.Redirect("delete.aspx");
        }
        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}