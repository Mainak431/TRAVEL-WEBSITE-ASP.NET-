<%@ Page Language="C#" AutoEventWireup="true" CodeFile="My Orders.aspx.cs" Inherits="My_Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            left: 00px;
            top: 0px;
            position: absolute;
            height: 100px;
            width: 1481px;
            background-color: #660066;
        }
        .auto-style2 {
            z-index: 1;
            left: 0px;
            top:100px;
            position: absolute;
            height: 1000px;
            width: 1481px;
            background-color: #CCFFCC;
        }
        .auto-style3 {
            z-index: 1;
            left: 9px;
            top: -78px;
            position: absolute;
            font-weight: 700;
            font-style: italic;
            color: #FFFFFF;
            font-size: xx-large;
            font-family: "Agency FB";
        }
        .auto-style4 {
            z-index: 1;
            left: 800px;
            top: -82px;
            position: absolute;
            height: 26px;
            font-weight: 700;
            color: #FFFF00;
            font-style: italic;
        }
        .auto-style6 {
            z-index: 1;
            left: 9px;
            top: 54px;
            position: absolute;
            height: 133px;
            width: 187px;
        }
        .auto-style7 {
            z-index: 1;
            left: 0px;
            top: 526px;
            position: absolute;
            height: 118px;
            width: 1481px;
            background-color: #660066;
        }
        .auto-style8 {
            z-index: 1;
            left: 25px;
            top: 282px;
            position: absolute;
            font-weight: 700;
            color: #000066;
        }
        .auto-style9 {
            z-index: 1;
            left: 242px;
            top: 281px;
            position: absolute;
        }
        .auto-style10 {
            z-index: 1;
            left: 32px;
            top: 349px;
            position: absolute;
        }
        .auto-style11 {
            z-index: 1;
            left: 227px;
            top: 345px;
            position: absolute;
        }
        .auto-style12 {
            z-index: 1;
            left: 493px;
            top: 310px;
            position: absolute;
            color: #FFFF66;
            background-color: #006600;
        }
        .auto-style13 {
            z-index: 1;
            left: 27px;
            top: 408px;
            position: absolute;
            color: #FF0000;
            font-family: "Arial Black";
        }
        .auto-style14 {
            z-index: 1;
            left: 10px;
            top: 555px;
            position: absolute;
            color: #FFFF00;
            font-weight: 700;
            font-size: xx-large;
            width: 214px;
            text-align: center;
            background-color: #660066;
            font-family: "Agency FB";
        }
        .auto-style15 {
            z-index: 1;
            left: 15px;
            top: 786px;
            position: absolute;
            height: 55px;
            width: 373px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
            <asp:Panel ID="Panel2" runat="server" CssClass="auto-style2" BackColor="#00CCFF">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="MY REQUESTS" Font-Bold="True" Font-Italic="False" ForeColor="Yellow"></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="Yellow" Text="Logged In As :"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style6" DataKeyNames="Request_id" GridLines="Vertical" ForeColor="Black">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="User_name" HeaderText="User Name" SortExpression="User_name" />
                        <asp:BoundField DataField="Request_id" HeaderText="Request ID" SortExpression="Request_id" ReadOnly="True" />
                        <asp:BoundField DataField="Route_id" HeaderText="Route ID" SortExpression="Route_id" />
                        <asp:BoundField DataField="No_male" HeaderText="No Of Male" SortExpression="No_male" />
                        <asp:BoundField DataField="No_fmale" HeaderText="No Of Female" SortExpression="No_fmale" />
                        <asp:BoundField DataField="No_child" HeaderText="No Of Child" SortExpression="No_child" />
                        <asp:BoundField DataField="Re_ack" HeaderText="Request Status" SortExpression="Re_ack" />
                        <asp:BoundField DataField="address" HeaderText="Full Address" SortExpression="address" />
                        <asp:BoundField DataField="Total_amount" HeaderText="Total Amount" SortExpression="Total_amount" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <asp:Panel ID="Panel3" runat="server" CssClass="auto-style7" Visible="False">
                </asp:Panel>
                <asp:Label ID="Label5" runat="server" CssClass="auto-style10" Font-Bold="True" ForeColor="#000066" Text="Payment Mode :" Visible="False"></asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="auto-style8" ForeColor="#000066" Text="Select Request ID " Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" BackColor="#660066" CssClass="auto-style11" ForeColor="White" Visible="False">
                            <asp:ListItem>Cash</asp:ListItem>  
                            <asp:ListItem>Cheque</asp:ListItem>  
                            <asp:ListItem>Demand Draft</asp:ListItem>  
                            
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" CssClass="auto-style12" OnClick="Button1_Click" Text="Place Order" Visible="False" />
                <asp:Label ID="Label6" runat="server" CssClass="auto-style13" Text="*We Regret to Inform You That We Do Not Currently Accept Online Payment.. Please  Pay It  By Cheque ,Cash Or in DD ( In Name Of BHROMON.COM) ..." Visible="False"></asp:Label>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="font-weight: 700; color: #663300" Text="LOGOUT" Width="83px" />
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#660066" CssClass="auto-style9" ForeColor="White" Visible="False">
                </asp:DropDownList>
                <asp:Label ID="Label7" runat="server" CssClass="auto-style14" Text="MY ORDERS" Visible="False"></asp:Label>
            </asp:Panel>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Route.aspx" style="font-weight: 700; color: #FFFF00">SEE PACKAGES</asp:HyperLink>
        </asp:Panel>
    
    </div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style15" GridLines="Vertical" Visible="False" ForeColor="Black">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Transaction_no" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="Request_id" HeaderText="Request ID" />
                        <asp:BoundField DataField="Payment_mode" HeaderText="Payment Mode" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
    </form>
</body>
</html>
