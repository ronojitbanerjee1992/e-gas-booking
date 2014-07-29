using System;
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
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        if (IsPostBack)
        {
            Panel1.Visible = true;
        }


    }
   SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        string u = TextBox1.Text;
        SqlCommand cmd = new SqlCommand("select username,password from consumer where username=@u", con);
        cmd.Parameters.AddWithValue("@u", u);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr.GetValue(1).ToString() == TextBox2.Text)
            {
                con.Close();
                Session["un"] = u;
                Response.Redirect("consumerpages/consumer.aspx");
            }
            else
                Label1.Text = "wrong pass";
        }
        else
            Label1.Text = "wrong username";
        con.Close();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("registration.aspx");
    }
    protected void distrubutor_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label3.Text = "";
        Panel1.Visible = true;
        Label2.Text = "DISTRIBUTOR LOGIN";
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        
        if (Label2.Text == "DISTRIBUTOR LOGIN")
        {
            cmd = new SqlCommand("select username,password,distributor from distributor where username=@u", con);
            con.Open();
            cmd.Parameters.AddWithValue("@u", TextBox3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if (dr.GetValue(1).ToString() == TextBox4.Text)
                {
                    Session["din"] = dr.GetValue(2).ToString();
                    con.Close();
                    Session["un"] = TextBox3.Text;

                    Response.Redirect("distributorpages/distributor.aspx");
                }
                else
                    Label3.Text = "wrong pass";

            }
            else
            {
                Label3.Text = "wrong username";

                TextBox3.Focus();
            }
            con.Close();
        }
        else
        {
                if (TextBox3.Text=="admin"&&TextBox4.Text=="566")
                {

                    con.Close();
                    Session["un"] = TextBox3.Text;

                    Response.Redirect("adminpages/admin.aspx");
                }
                else
                {
                    Label3.Text = "wrong password";
                    TextBox4.Focus();
                }
            

        }
        
     }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label3.Text = "";
        Panel1.Visible = true;
        Label2.Text = "ADMINISTRATOR LOGIN";
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        Response.Redirect("distributorregistration.aspx");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("consumerforgotpassword.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("aboutus.aspx");
    }
}

