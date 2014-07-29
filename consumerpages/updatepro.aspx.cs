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
using System.Data.SqlClient;
using System.Data.Sql;
public partial class updatepro : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["un"] != null)
        {
            Label1.Text = "";
            if (!IsPostBack)
            {
                string r = Session["un"].ToString();

                SqlCommand cmd = new SqlCommand("select * from consumer where username=@u", con);
                con.Open();
                cmd.Parameters.AddWithValue("@u", r);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    
                    TextBox2.Text = dr.GetValue(5).ToString();
                   con.Close();
            }
        }
        else
            Response.Redirect("Default.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("select password from consumer where username=@u", con);
        cmd.Parameters.AddWithValue("@u", Session["un"].ToString());
        string p=cmd.ExecuteScalar().ToString();
        if (p== TextBox4.Text && TextBox5.Text == TextBox6.Text&check(TextBox2.Text))
        {
            cmd = new SqlCommand("update consumer set password=@p,email=@em where username=@up", con);

         
            if (TextBox5.Text != "")
                cmd.Parameters.AddWithValue("@p", TextBox5.Text.ToString());
            else
                cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@em", TextBox2.Text);
            cmd.Parameters.AddWithValue("@up", Session["un"].ToString());
            cmd.ExecuteNonQuery();
            Label1.Text = "updated succesfully";
            Button1.Visible = false;
        }
        if(p!=TextBox4.Text)
            Label1.Text = "**Old password is wrong";
        if( TextBox5.Text != TextBox6.Text)
             Label1.Text=Label1.Text+" \n**Password field doesn't match";
        if (check(TextBox2.Text) == false)
            Label1.Text = Label1.Text + "\n** Email format is wrong";

       TextBox4.Text = TextBox5.Text = TextBox6.Text =TextBox2.Text ="";
        
        con.Close();
        
    }
    protected bool check(string s)
    {
        if (s.IndexOf('@') != -1)
            return true;
        else
            return false;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["un"] = null;
        Response.Redirect("../Default.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("./consumer.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        
    }
    
}
