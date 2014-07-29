<%@ Page Language="C#" AutoEventWireup="true" CodeFile="consumer.aspx.cs" Inherits="consumer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            font-family: "Meiryo UI";
            font-weight: bold;
            color: #CCCCCC;
        }
        body
        {
            background-position: center;
            margin-left: 100px;
            margin-right : 150px;
            margin-top: 20px;
            background-color: #FFFFFF;
            background-image: url('../img/high-quality-1920x1200-web-abstract-15-website-175888-desktop.jpg');
        }
        .style2
        {
            background: scroll;
            font-family: "Meiryo UI";
            font-size: small;
            color: #666666;
            margin-top: 0px;
        }
        .style3
        {
            background: scroll;
            font-family: "Meiryo UI";
            font-size: medium;
            color: #C0C0C0;
            margin-top: 0px;
            font-weight: bold;
        }
        .style4
        {
            color: #C0C0C0;
        }
        .style5
        {
            font-family: "Meiryo UI";
        }
        .style6
        {
            font-size: medium;
        }
        .style7
        {
            font-family: "Meiryo UI";
            font-size: medium;
        }
        #form1
        {
            width: 1432px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 43px; width: 996px; margin-top: 0px">
    
        <span class="style1">WELCOME </span><b>&nbsp;
        <asp:Label ID="Label1" runat="server" 
            style="font-family: 'Meiryo UI'; color: #C0C0C0;"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<span 
            class="style4"><asp:LinkButton 
            ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            
            style="font-family: 'Meiryo UI'; text-decoration: none; color: #C0C0C0; font-weight: 700;">Logout</asp:LinkButton>
        &nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
            
            style="font-family: 'Meiryo UI'; text-decoration: none; color: #C0C0C0; font-weight: 700;">Update Profile</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <br />
        <hr style="line-height: normal; margin-top: 0px; height: -3px; background-color: #666666; width: 989px;" />
    
    </div>
    <p class="style2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="style3">
        CONNECTION DETAILS:></p>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Height="144px" 
        Width="489px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="username" HeaderText="USERNAME">
                <ControlStyle Font-Names="Meiryo UI" />
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:BoundField DataField="name" HeaderText="Consumer Name">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:BoundField DataField="consumerid" HeaderText="Consumer id">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:BoundField DataField="state" HeaderText="State">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:BoundField DataField="city" HeaderText="City">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Distributor name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("distributor") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("distributor") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("distributor") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:TemplateField>
            <asp:BoundField DataField="email" HeaderText="Email">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
            <asp:BoundField DataField="address" HeaderText="Address">
                <HeaderStyle Font-Names="Meiryo UI" />
                <ItemStyle Font-Names="Meiryo UI" />
            </asp:BoundField>
        </Fields>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:DetailsView>
    <br />
    <hr style="width: 129%; height: -12px" />
    <p style="font-weight: 700; font-style: normal">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton4" runat="server" 
            
            style="font-family: 'Meiryo UI'; color: #C0C0C0; text-decoration: inherit; font-style: normal; font-variant: normal; font-weight: 700; font-size: 100%; line-height: normal" 
            onclick="LinkButton4_Click">Transfer 
        Connection</asp:LinkButton>
        </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton6" runat="server" 
            style="color: #C0C0C0; font-family: 'Meiryo UI'; text-decoration: none" 
            onclick="LinkButton6_Click">Order 
        gas</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton7" runat="server" 
            style="color: #C0C0C0; font-family: 'Meiryo UI'; text-decoration: none" 
            onclick="LinkButton7_Click">View 
        Order History</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click" 
            style="color: #C0C0C0; font-family: 'Meiryo UI'; font-size: medium; text-decoration: none">Cancel 
        Booking</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton9_Click" 
            style="color: #FFFFFF; font-family: 'Meiryo UI'; text-decoration: none">Generate 
        bill</asp:LinkButton>
    </p>
    <asp:Panel ID="Panel1" runat="server" Height="241px" 
        style="color: #FFFFFF; font-family: fantasy; font-weight: 700; font-size: large; float: none; margin-right: 0px;" 
        Width="279px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Booking<br />
        <br />
        <br />
        &nbsp;LPG Refill : Domestic type&nbsp;&nbsp; </span><span class="style5"><span class="style6">
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><b><span class="style5">
        <span class="style6">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            style="color: #333333; background-color: #C0C0C0" Text="ORDER" 
            Height="27px" Width="70px" />
        </span></span></b><span class="style6">
        <br class="style5" />
        </span><span class="style5"><span class="style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        </span></span>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="219px" 
        style="color: #C0C0C0; font-size: small; font-family: 'Meiryo UI'; margin-top: 0px" 
        Width="527px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" 
                style="font-size: medium; font-weight: 700"></asp:Label>
            <span class="style6">
            &nbsp;<br />
            </span>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="175px" 
                Width="517px">
                <RowStyle BackColor="#F7F7DE" />
                <Columns>
                    <asp:BoundField DataField="orderno" HeaderText="Order No.">
                        <HeaderStyle Font-Names="Meiryo UI" />
                        <ItemStyle Font-Names="Meiryo UI" />
                    </asp:BoundField>
                    <asp:BoundField DataField="orderdate" HeaderText="Booking Date">
                        <HeaderStyle Font-Names="Meiryo UI" />
                        <ItemStyle Font-Names="Meiryo UI" />
                    </asp:BoundField>
                    <asp:BoundField DataField="deliverydate" HeaderText="Delivery Date">
                        <HeaderStyle Font-Names="Meiryo UI" />
                        <ItemStyle Font-Names="Meiryo UI" />
                    </asp:BoundField>
                    <asp:BoundField DataField="distributorname" HeaderText="Distributor name" />
                    <asp:BoundField DataField="Delivery" HeaderText="Delivery request" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label4" 
                runat="server" 
                
                style="color: #FFFFFF; font-family: 'Meiryo UI'; font-weight: 700; font-size: medium;"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" 
                style="font-size: medium; font-weight: 700"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;<span class="style7"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="175px" 
        onrowdeleting="GridView2_RowDeleting" Width="517px">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="orderno" HeaderText="Order no." />
            <asp:BoundField DataField="orderdate" HeaderText="Order date" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Cancel" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    <p style="font-weight: 700; font-style: normal">
        &nbsp;</p>
    </form>
</body>
</html>
