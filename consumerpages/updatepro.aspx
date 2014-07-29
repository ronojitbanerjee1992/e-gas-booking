<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepro.aspx.cs" Inherits="updatepro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            background-color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" 
    style="background-image: url('img/high-quality-1920x1200-web-abstract-15-website-175888-desktop.jpg'); background-position: center">
    <div style="background-position: center; background: url('img/high-quality-1920x1200-web-abstract-15-website-175888-desktop.jpg'); height: 1143px; width: 1477px; font-family: 'Meiryo UI'; color: #FFFFFF">
    
        <br />
&nbsp; <b>Update your Profile:-&nbsp;
        <br />
        <br />
&nbsp; E-mail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="22px" 
            style="text-align: left" Width="169px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        </b>&nbsp;<b>&nbsp;<br />
&nbsp;Change password :-&nbsp;
        <br />
&nbsp;<asp:Panel ID="Panel1" runat="server" Height="76px" Width="689px">
            Old Password&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            New Passowrd <b>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp; Confirm Password&nbsp;&nbsp; </b>
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" style="font-family: 'Meiryo UI'; width: 64px; height: 27px;" 
            Text="Submit" onclick="Button1_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;
    
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            style="color: #FFFFFF">Logout</asp:LinkButton>
    
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
            style="color: #FFFFFF; text-decoration: underline"><b>Go back to homepage</b></asp:LinkButton>
        </b>
    
    </div>
    </form>
</body>
</html>
