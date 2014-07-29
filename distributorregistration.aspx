<%@ Page Language="C#" AutoEventWireup="true" CodeFile="distributorregistration.aspx.cs" Inherits="distributorregistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
   
    
    <style type="text/css">
         body
    {
    margin-left:50px;
    margin-right:160px;
    }
        .style1
        {
            color: #333333;
            font-weight: bold;
            background-color: #660033;
        }
        .style2
        {
            color: #333333;
            font-weight: bold;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="" src="img/cropped-indane-gas2.jpg" 
            style="width: 1300px; height: 213px" /></div>
    <div style="height: 393px; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; line-height: normal; font-family: 'Meiryo UI';">
        <asp:Label ID="Label1" runat="server" 
            style="color: #FFFFFF; font-size: large; font-weight: 700; background-color: #CC0099" 
            Text="Registration"></asp:Label>
        <span class="style2">
        <br />
        <br />
        <br />
        Enter your name&nbsp;&nbsp;&nbsp;&nbsp;         <asp:TextBox ID="TextBox1" runat="server" Width="203px"></asp:TextBox>
        <br />
        <br />
        Desired Username&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
        <br />
&nbsp;<br />
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="195px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Confirm Password&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="189px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Width="186px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" 
            style="font-family: 'Meiryo UI'; font-weight: 700; text-decoration: underline; color: #FFFFFF; background-color: #990099" 
            Text="Submit" onclick="Button1_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><span class="style2">Home</span></asp:LinkButton>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div style="background-position: center; height: 375px; background-image: url('img/high-quality-1920x1200-web-abstract-15-website-175888-desktop.jpg'); width: 1301px;">
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        </span><span class="style1">
        <br />
        <br />
        <br />
        <br />
        </span>
    </div>
    </form>
</body>
</html>
