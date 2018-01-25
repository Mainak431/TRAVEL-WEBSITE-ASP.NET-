using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public partial class editroute : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Admin"]==null)
        {
            MessageBox.Show("U Have to Login First");
            Response.Redirect("login.aspx");
        }
        else
        {
            Label7.Text = "Logged in as Admin--->" + Session["Admin"].ToString();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button7_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand sd = new MySqlCommand("select count(*) from route where Route_name='" + TextBox1.Text + "' ", con);
        object obj = sd.ExecuteScalar();
        if (Convert.ToInt32(obj) == 0)
        {
            Label2.Visible = false;
            MySqlCommand cmd = new MySqlCommand("insert into route(Route_name)Values ('" + TextBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Name added" + "\n" + "\n" + "Add Package Details Now");
            
            }
        else
        {
            Label2.Visible = true;
        }
        Button1.Visible = false;
        Label3.Visible = true;
        Random number = new Random();
        for (int i = 0; i < 10; i++)

        {
            Label3.Text = TextBox1.Text + (Convert.ToString(number.Next(10, 200)));
        }

        sd.ExecuteNonQuery();
        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = Label3.Text.ToString();
        if (str.Contains("Label"))
        {
            MessageBox.Show("PLease Enter Package Name First");
         }
        else
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO route_dtls_id (Route_name,Route_id,Route_dtls,Date,Hotel_sttus,Amt_adult,Amt_child,Route_url,Image,Map_image) VALUES ('" + TextBox1.Text + "','" + Label3.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "',@imagedata,@mapimage)", con);
            int length = FileUpload1.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = FileUpload1.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);
            cmd.Parameters.Add("@imagedata", MySqlDbType.LongBlob).Value = imgbyte;
            int length1 = FileUpload2.PostedFile.ContentLength;
            byte[] imgbyte1 = new byte[length1];
            HttpPostedFile img1 = FileUpload2.PostedFile;
            img1.InputStream.Read(imgbyte1, 0, length1);
            cmd.Parameters.Add("@mapimage", MySqlDbType.LongBlob).Value = imgbyte1;
            cmd.ExecuteNonQuery();
            MySqlCommand update = new MySqlCommand("update route set Image=@imagedata where Route_name='" + TextBox1.Text + "'", con);
            update.Parameters.Add("@imagedata", MySqlDbType.LongBlob).Value = imgbyte;
            MessageBox.Show("Route Added Successfully");
            update.ExecuteNonQuery();
            Response.Redirect("editroute.aspx");
            con.Close();
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Button5.Visible = false;
        Label6.Visible = true;
        DropDownList1.Visible = true;
        Buttonname.Visible = true;

    }

    protected void Buttonname_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = DropDownList1.SelectedItem.ToString();
        string sql = "delete from route where  Route_name='" + str + "'";
        string sql1 = "delete from route_dtls_id where Route_name='" + str + "'";
        MySqlCommand cmd2 = new MySqlCommand(sql1, con);
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd2.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        MessageBox.Show("Package Deleted Successfully");
        Response.Redirect("editroute.aspx");
        con.Close();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Button4.Visible = false;
        Buttonid.Visible = true;
        Label5.Visible = true;
        DropDownList2.Visible = true;
        Buttonid.Visible = true;
       
        
    }

    protected void Buttonid_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = DropDownList2.SelectedItem.ToString();
        string sql = "delete from route_dtls_id where  Route_id='" + str + "'";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        MessageBox.Show("Route Deleted Successfully");
        con.Close();
        Response.Redirect("editroute.aspx");
    }
}