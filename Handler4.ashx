<%@ WebHandler Language="C#" Class="Handler4" %>

using System;
using System.Web;
using MySql.Data.MySqlClient;

public class Handler4 : IHttpHandler {

    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");

    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["Id"];
        con.Open();
        string str = "select Route_url from route_dtls_id where Route_id = '" + imageid + "'";
        MySqlCommand command = new MySqlCommand(str, con);
        object obj = command.ExecuteScalar();
        string str3 = Convert.ToString(obj);
        HttpContext.Current.Response.Redirect(str3);


    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}