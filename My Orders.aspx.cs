using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
public partial class My_Orders : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Customer"] != null)
        { 
            con.Open();
            MySqlCommand command = new MySqlCommand("SELECT * from request where User_name= '" + Session["User_name"].ToString() + "'", con);
            MySqlDataAdapter daimages = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            daimages.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            command.ExecuteNonQuery();
            con.Close();
            Label2.Text = "Logged In As  :  " + Session["Customer"].ToString();
            order();
            morder();
        }
        else
        {
            if(Session["Admin"]!=null)
            {
                MessageBox.Show("THIS IS A CUSTOMER MY ORDER PAGE." + "\n" + "ITS WORKING FINE" + "\n" + "YOU HAVE NO WORK THERE");
                Response.Redirect("default.aspx");
            }
            else
            {
                MessageBox.Show("U Have to Login First");
                Response.Redirect("login.aspx");
            }
        }
    }
    public void order()
    { 
            string query = "select Request_id from request where Re_ack='Accepted'and User_name='"+Session["User_name"].ToString()+"'";
            con.Open();
            MySqlCommand cy = new MySqlCommand(query, con);
            MySqlDataAdapter ad = new MySqlDataAdapter(cy);
            DataSet dt = new DataSet();
            ad.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                Panel3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                Button1.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList1.DataSource = dt.Tables[0];
                DropDownList1.DataTextField = "Request_id";
                DropDownList1.DataValueField = "Request_id";
                DropDownList1.DataBind();
                
            }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        string c = "TR" + r.Next(10000000, 90000000);
        string qu = "select Total_amount from request where Request_id='"+DropDownList1.SelectedItem.Text+"'";
        con.Open();
        MySqlCommand cy = new MySqlCommand(qu, con);
        MySqlDataAdapter at = new MySqlDataAdapter(cy);
        DataSet dl = new DataSet();
        cy.ExecuteNonQuery();
        at.Fill(dl);
        if (dl.Tables[0].Rows.Count > 0)
        {
            String cb = dl.Tables[0].Rows[0][0].ToString();
            string query = "insert into my_order(User_name,Transaction_no,Payment_mode,Amount,Request_id) values('"+Session["User_name"].ToString()+"','" + c + "','" + DropDownList2.SelectedItem.Text + "','" + cb + "','"+DropDownList1.SelectedItem.Text+"')";
            MySqlCommand ct = new MySqlCommand(query, con);
            ct.ExecuteNonQuery();
            MessageBox.Show("Your Order Is Successfully Placed"+"\n"+"Your TRANSACTION ID is :" + c+"\n"+"WE WILL COLLECT YOUR PAYMENT FROM YOUR ADDRESS WITHIN TWO WORKING DAYS"+"\n"+"IF YOU LIKE TO SUBMIT THE PAYMENT TO OUR OFFICE. PLEASE LET US KNOW "+"\n"+"GoodDAY"+"\n"+"THANK YOU");
            Response.Redirect("My Orders.aspx");
        }
        con.Close();
    }
    public void morder()
    { 
            string query = "select Transaction_no,Payment_mode,Amount,Request_id from my_order where User_name='"+Session["User_name"].ToString()+"'";
            con.Open();
            MySqlCommand cy = new MySqlCommand(query, con);
            MySqlDataAdapter ad = new MySqlDataAdapter(cy);
            DataSet dt = new DataSet();
            ad.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                Label7.Visible = true;
                GridView2.Visible = true;
                Panel3.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}