<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delivered.aspx.cs" Inherits="distributorpages_delivered" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            font-family: "Meiryo UI";
            font-weight: bold;
            font-size: medium;
            color: #FFFFFF;
        }
        </style>
</head>
<body background="../img/high-quality-1920x1200-web-abstract-15-website-175888-desktop.jpg">
    <form id="form1" runat="server">
    <p>
        <span class="style1">Customer Booking History</span></p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Consumer Name" />
                <asp:BoundField DataField="nob" HeaderText="Cylinders delivered" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            style="font-family: 'Meiryo UI'; color: #FFFFFF">Home</asp:LinkButton>
&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
            style="font-family: 'Meiryo UI'; color: #C0C0C0">Logout</asp:LinkButton>
    </p>
    <div>
    
    </div>
    </form>
</body>
</html>
