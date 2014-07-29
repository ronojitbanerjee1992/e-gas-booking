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
using System.Data.Sql;
using System.Data.SqlClient;

public partial class distributorregistration : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
protected void  Button1_Click(object sender, EventArgs e)
{
    if(TextBox3.Text==TextBox4.Text && TextBox1.Text!=""&&TextBox2.Text!=""&&TextBox5.Text!="")
    {
        
        cmd=new SqlCommand("select did from cities where city=@city",con);
        con.Open();
        cmd.Parameters.AddWithValue("@city",TextBox5.Text);

        if(cmd.ExecuteScalar()==null)
        Label2.Text="City not available";
         
        else
        {  
           int did=int.Parse(cmd.ExecuteScalar().ToString());
           cmd=new SqlCommand("insert into distributorapplication values(@d,@did,@u,@p,@c)",con);
           cmd.Parameters.AddWithValue("@d",TextBox1.Text);
           cmd.Parameters.AddWithValue("@did",did);
           cmd.Parameters.AddWithValue("@u",TextBox2.Text);
            cmd.Parameters.AddWithValue("@p",TextBox3.Text);
            cmd.Parameters.AddWithValue("@c", TextBox5.Text);
            cmd.ExecuteNonQuery();
            Label2.Text="Request for registration sent to administrator. You will be notified within few dayd";
            TextBox1.Text = TextBox2.Text = TextBox5.Text = "";
        }
        con.Close();
    }
    else if(TextBox3.Text!=TextBox4.Text)
        Label2.Text="Password doesn't match";
    else
    {
        Label2.Text="Please fill in all the details";
    }
}
protected void LinkButton1_Click(object sender, EventArgs e)
{
 
    Response.Redirect("Default.aspx");
}
}
