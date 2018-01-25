using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

public partial class Add_Route : System.Web.UI.Page
{
    
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    public double am, cm, dm, tm, pm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Customer"] != null)
            {
                Label11.Text = "Logged In AS  : " + Session["Customer"].ToString();
                string query = "select Route_name from route where Route_name!=' '";
                con.Open();
                MySqlCommand cy = new MySqlCommand(query, con);
                MySqlDataAdapter ad = new MySqlDataAdapter(cy);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "Route_name";
                DropDownList1.DataValueField = "Route_name";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select", "0"));

                con.Close();
            }
            else
            {
                if (Session["Admin"] != null)
                {
                    MessageBox.Show("ITS A USER SUBMIT REQUEST PAGE.. " + "\n" + "ITS WORKIKNG FINE" + "\n" + "YOU HAVE NO WORK HERE");
                    Response.Redirect("default.aspx");
                }
                else
                {
                    MessageBox.Show("You Have To Register To Access This Page");
                    Response.Redirect("signup.aspx");
                }
            }
        }

        
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = "select Route_id from route_dtls_id where Route_name='"+DropDownList1.SelectedItem.ToString()+"'";
        con.Open();
        MySqlCommand cy = new MySqlCommand(query, con);
        MySqlDataAdapter ad = new MySqlDataAdapter(cy);
        DataSet dt = new DataSet();
        ad.Fill(dt);
        DropDownList2.DataSource = dt.Tables[0];
        DropDownList2.DataTextField = "Route_id";
        DropDownList2.DataValueField = "Route_id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("Select", "0"));
        cy.ExecuteNonQuery();
        con.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select" || DropDownList2.SelectedItem.Text == "Select"||TextBox5.Text==""||TextBox6.Text==""||TextBox1.Text=="")
        {

            MessageBox.Show("Please Enter Details As Advised");
        }
        else
        {
            string query = "select Route_id,Amt_adult,Amt_child from route_dtls_id where Route_id='" + DropDownList2.SelectedItem.Text + "'";
            con.Open();
            MySqlCommand cy = new MySqlCommand(query, con);
            MySqlDataAdapter ad = new MySqlDataAdapter(cy);
            DataSet dt = new DataSet();
            ad.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                Label8.Visible = true;

                am = int.Parse(dt.Tables[0].Rows[0][1].ToString());
                cm = int.Parse(dt.Tables[0].Rows[0][2].ToString());
                dm = int.Parse(TextBox5.Text.ToString());
                tm = int.Parse(TextBox6.Text.ToString());
                pm = int.Parse(TextBox1.Text.ToString());
                Label8.Text = ((dm + tm) * am + pm * cm).ToString();
            }
            else
            {

                Label8.Visible = true;
                Label8.Text = "Not Available";
            }
             con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select" || DropDownList2.SelectedItem.Text == "Select" || TextBox4.Text == "" || Label8.Text == "")
        {
            if (TextBox4.Text == "")
                MessageBox.Show("Address Required");
            if (Label8.Text == "")
                MessageBox.Show("Please Calculate And Check Total Amount");
            else
                MessageBox.Show("Please Select Both Route Name and Route Id ");
        }

        else
        {
            Random r = new Random();
            string c = "RQ" + r.Next(100, 900);
            string pending = "pending";
            string query = "insert into request(User_name,Request_id,Route_id,No_male,No_fmale,No_child,address,Total_amount,Re_ack) values('"+Session["User_name"].ToString()+"','" + c + "','" + DropDownList2.SelectedItem.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox1.Text + "','" + TextBox4.Text + "','" + Label8.Text + "','"+pending+"')";
            con.Open();
            MySqlCommand cy = new MySqlCommand(query, con);
            cy.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your Request Successfully Accepted."+"\n"+"Your Request ID is :" + c);
            Response.Redirect("My Orders.aspx");
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}