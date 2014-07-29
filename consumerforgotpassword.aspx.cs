using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class consumerforgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd=new SqlCommand("select password from consumer where email='"+TextBox1.Text+"'",con);
        con.Open();

        if (cmd.ExecuteScalar()!=null)
        {
            string s = cmd.ExecuteScalar().ToString();


            MailMessage mail = new MailMessage();
            mail.To.Add(TextBox1.Text);
            mail.From = new MailAddress("abc@gmail.com");
            mail.Subject = "Remember Mail";
            string Body = "Password is " + s;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("ronojitrockz@gmail.com", "9232663223");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Label1.Text = "PASSWORD SENT TO YOUR EMAIL ADDRESS";
            con.Close();
        }
        else
            Label1.Text = "No such email exists ";

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
