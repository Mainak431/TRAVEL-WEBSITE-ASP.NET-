<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateprofile.aspx.cs" Inherits="updateprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #660066;
        }
        .auto-style2 {
            color: #000066;
        }
    </style>
</head>
<body style="height: 316px">
    <form id="form1" runat="server">
    <div dir="auto" style="height: 336px; width: 953px;">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="Aqua" Height="1174px" Width="1345px">
            <asp:Panel ID="Panel2" runat="server" BackColor="#660066" Height="127px">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="Yellow" Text="CHANGE PASSWORD WINDOW"></asp:Label>
                <br />
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Bold="True" ForeColor="#663300" OnClick="Button2_Click" Text="LOGOUT" Width="101px" />
            </asp:Panel>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#000066" NavigateUrl="~/Route.aspx">SEE PACKAGES</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#660066" NavigateUrl="~/default.aspx">GO BACK TO HOME PAGE</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <span class="auto-style1"><em>LOGGD IN AS</em></span>&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#000099"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<br />
            <br />
            <br />
            <span class="auto-style2">OLD PASSWORD</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" style="width: 182px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            <span class="auto-style2"><strong>NEW PASSWORD</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" MaxLength="10" OnTextChanged="TextBox3_TextChanged" TextMode="Password" Width="186px"></asp:TextBox>
            <br />
            <br />
            <br />
            <span class="auto-style2"><strong>CONFIRM NEW PASSWORD</strong></span>&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="189px"></asp:TextBox>
&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="*CONFIRM PASSWORD AND NEW PASSWORD SHOULD MATCH*" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Names="Castellar" Font-Size="X-Large" OnClick="Button1_Click" Text="SUBMIT" Width="242px" ForeColor="Lime" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
    
    </div>
    </form>
</body>
</html>
