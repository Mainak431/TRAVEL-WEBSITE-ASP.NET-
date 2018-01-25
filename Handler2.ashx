<%@ WebHandler Language="C#" Class="Handler2" %>

using System;
using System.Web;
using MySql.Data.MySqlClient;

public class Handler2 : IHttpHandler {

    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;password=10970000;persistsecurityinfo=True;database=travel_agency");

    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["Id"];
        con.Open();
        string str = "select Image from route where Route_name = '"+imageid+"'";
        MySqlCommand command = new MySqlCommand(str, con);
        MySqlDataReader dr = command.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((Byte[])dr[0]);
        context.Response.ContentType="image/jpg";
        con.Close();
        context.Response.End();



    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}