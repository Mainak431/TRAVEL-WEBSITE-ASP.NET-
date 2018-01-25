using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


public partial class CSignUp : System.Web.UI.Page

{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = Label12.Text;
        string str2 = "Label";
        string str3 = "User Name Available";
        if (TextBox6.Text == "")
        {
            MessageBox.Show("PLEASE ENTER A VALID DATE OF BIRTH");
        }
        else if (str2.Contains(str))
        {
            MessageBox.Show("Check Availability First");
        }
        else if (str.Contains(str3))
        {
            string strText = TextBox6.Text;
            string qryStr = string.Format("{0:yyyy-MM-dd HH:mm:ss}", Convert.ToDateTime(strText));
            string StrQuery1 = "insert into customer(User_Name,Cname,E_mail,Contact_no,City,Pincode,ob,Cpassword)Values ('" + TextBox1.Text + "' , '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList1.SelectedItem.ToString() + "','" + TextBox5.Text + "','" + qryStr + "','" + TextBox7.Text + "');";
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(StrQuery1, con);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registration Completed.. Redirecting to Login Page");
            Response.Redirect("login.aspx");
        }
        else
        {
            MessageBox.Show(Label12.Text);
        }
        
     }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Calendar1.Visible=true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox6.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select count(*) from customer where User_name ='" + TextBox1.Text + "'", con);
        object obj= cmd.ExecuteScalar();
        Label12.Visible = true;
        if(Convert.ToInt32(obj)>0)
        {
            Random number = new Random();
            for (int i = 0; i < 10; i++)

            {
                Label12.Text ="User Name Already Taken .. Choose Another Like.. " + TextBox1.Text + (Convert.ToString(number.Next(10, 200)));
            }
            
        }
        else
        {
            Label12.Text = "User Name Available";
        }
        

    }
}
