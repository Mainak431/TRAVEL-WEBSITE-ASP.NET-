<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Submit-Request.aspx.cs" Inherits="Add_Route" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            color: #000066;
        }
        .auto-style3 {
            z-index: 1;
            left: 31px;
            top: 54px;
            position: absolute;
            color: #FFFFFF;
            font-size: xx-large;
            width: 280px;
            text-align: center;
            letter-spacing: 1pt;
        }
        .auto-style4 {
            z-index: 1;
            left: 545px;
            top: 240px;
            position: absolute;
            font-weight: 700;
            color: #000066;
        }
        .auto-style5 {
            z-index: 1;
            left: 712px;
            top: 385px;
            position: absolute;
        }
        .auto-style6 {
            z-index: 1;
            left: 898px;
            top: 382px;
            position: absolute;
        }
        .auto-style7 {
            z-index: 1;
            left: -25px;
            top: 6px;
            position: absolute;
            height: 131px;
            width: 1769px;
            background-color: #660066;
        }
        .auto-style8 {
            z-index: -3;
            left: -7px;
            top: 137px;
            position: absolute;
            height: 648px;
            width: 1749px;
            background-color: #CCFFFF;
        }
        .auto-style9 {
            z-index: 1;
            left: 209px;
            top: 542px;
            position: absolute;
            text-align: center;
            color: #660066;
            right: 434px;
            font-style: italic;
        }
        .auto-style10 {
            z-index: 1;
            top: 543px;
            position: absolute;
            color: #0033CC;
            right: 327px;
            width: 95px;
        }
        .auto-style11 {
            z-index: 1;
            left: 894px;
            top: 29px;
            position: absolute;
            width: 382px;
            height: 40px;
            color: #FFFF00;
            font-style: italic;
            font-weight: 700;
        }
        .auto-style13 {
            color: #FF0000;
            z-index: 1;
            left: 856px;
            top: 274px;
            position: absolute;
            width: 166px;
        }
        .auto-style14 {
            z-index: 1;
            left: 856px;
            top: 311px;
            position: absolute;
            width: 167px;
        }
        .auto-style15 {
            z-index: 1;
            left: 856px;
            top: 348px;
            position: absolute;
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
    <div>
    
        <asp:Label ID="Label14" runat="server" CssClass="auto-style13" Text="*Place 0 If not Available "></asp:Label>
        <asp:Label ID="Label13" runat="server" CssClass="auto-style15" Text="* Place 0 If not Available " ForeColor="Red"></asp:Label>
        <asp:Label ID="Label15" runat="server"  Text="*Place 0 If not Available " CssClass="auto-style14" ForeColor="Red"></asp:Label>
    
        <asp:Button ID="Button2" runat="server" CssClass="auto-style6" Text="Calculate" style="z-index: 2" OnClick="Button2_Click" />
    
    </div>
        <asp:Label ID="Label6" runat="server" Text="Route Name :" style="z-index: 2; left: 475px; top: 162px; position: absolute; font-size: medium; font-weight: 700" height="19px" width="134px" CssClass="auto-style2"></asp:Label>
              <asp:Label ID="Label16" runat="server" Text="*Required" style="z-index: 2; left: 873px; top: 238px; position: absolute; font-size: medium; text-align: left; width: 116px;" height="19px" ForeColor="Red"></asp:Label>
            
                <asp:Button ID="Button1" runat="server" style="z-index: 2; left: 695px; top: 435px; position: absolute; height: 48px; color: #00FFFF; background-color: #336600; width: 178px;" Text="Submit Request" OnClick="Button1_Click" />
            
        <asp:Label ID="Label1" runat="server" Text="No. Of Male :" style="z-index: 2; left: 475px; top: 274px; position: absolute; font-size: medium; font-weight: 700" height="19px" width="134px" CssClass="auto-style2"></asp:Label>
            <asp:Label ID="Label8" runat="server" CssClass="auto-style5" Visible="False" style="z-index: 2"></asp:Label>
            <asp:Label ID="Label9" runat="server" CssClass="auto-style4" Text="Address :" style="z-index: 2"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="No. Of Female :" style="z-index: 2; left: 475px; top: 313px; position: absolute; font-size: medium; font-weight: 700; bottom: 142px; width: 134px" height="19px" CssClass="auto-style2"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="No. Of Child :" height="19px" style="z-index: 2; left: 457px; top: 348px; position: absolute; font-size: medium; font-weight: 700; width: 152px" CssClass="auto-style2"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="position: absolute; top: 345px; left: 712px; height: 19px; width: 130px; z-index: 2;"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 2; left: 712px; top: 162px; position: absolute" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataTextField="Route_name" DataValueField="Route_name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:travel_agencyConnectionString %>" ProviderName="<%$ ConnectionStrings:travel_agencyConnectionString.ProviderName %>" SelectCommand="select Route_name from route where Route_name !=&quot; &quot;"></asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 2; left: 712px; top: 200px; position: absolute" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        <asp:TextBox ID="TextBox5" runat="server" style="z-index: 2; left: 712px; top: 270px; position: absolute" height="19px" width="128px"></asp:TextBox>
            
        <asp:TextBox ID="TextBox6" runat="server" style="z-index: 2; left: 712px; top: 308px; position: absolute" height="19px" width="128px"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" CssClass="auto-style3" Text="Place Your Request" style="z-index: 2; font-weight: 700; font-family: 'Agency FB'; text-decoration: underline;" ForeColor="Yellow"></asp:Label>
            <p>
                &nbsp;</p>
        <asp:Label ID="Label4" runat="server" Text="Route Id :" style="z-index: 2; left: 475px; top: 203px; position: absolute; font-size: medium; font-weight: 700" height="19px" width="134px" CssClass="auto-style2"></asp:Label>
            <asp:Label ID="Label5" runat="server" style="z-index: 2; left: 454px; top: 387px; position: absolute; font-weight: 700; font-size: medium; width: 155px;" Text="Total Amount :" CssClass="auto-style2" height="19px"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox4" runat="server" style="z-index: 2; left: 712px; top: 235px; position: absolute; text-align: left; height: 19px; bottom: 110px;" width="128px"></asp:TextBox>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style7">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Route.aspx" style="color: #FFFF00; font-weight: 700">SEE PACKAGES</asp:HyperLink>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="auto-style8" BackColor="Aqua" BorderColor="Aqua">
            <asp:Button ID="Button3" runat="server" Text="LOGOUT" OnClick="Button3_Click" style="color: #663300; font-weight: 700" Width="117px" />
        </asp:Panel>
        <asp:Label ID="Label10" runat="server" CssClass="auto-style9" Text="To View Your Order's and Request Status Click  Here"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style10" NavigateUrl="~/My Orders.aspx">My Orders</asp:HyperLink>
        <asp:Label ID="Label11" runat="server" CssClass="auto-style11" ForeColor="Yellow" Text="Logged In As :"></asp:Label>
    </form>
</body>
</html>
