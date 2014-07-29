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
public partial class consumerpages_generatebill : System.Web.UI.Page
{
    SqlConnection  con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    
    SqlCommand cmd;

    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel3.Visible = false;
       if (Session["un"] != null)
        {
            cmd = new SqlCommand("select orderno,Delivery from booking where name='" + Session["nm"].ToString() + "'and distributorname='" + Session["dn"].ToString() + "'", con);
            con.Open();
            
            dr = cmd.ExecuteReader();
            if (dr.Read()==false)
            {
               Labelorder.Visible= Labeldelivery.Visible = Button1.Visible = false;
                Label33.Text = "You haven't ordered any gas till now";
            }
            else
            {
            if (!IsPostBack)
            {
                dr.Close();
                cmd = new SqlCommand("select orderno,Delivery from booking where name='" + Session["nm"].ToString() + "'and distributorname='" + Session["dn"].ToString() + "'", con);
               
                string s1 = ""; 
                dr = cmd.ExecuteReader();
                /*if (dr.Read()==false)
                {
                   Labelorder.Visible= Labeldelivery.Visible = Button1.Visible = false;
                    Label33.Text = "You haven't ordered any gas till now";
                }
                else
                {*/
                  while (dr.Read())
                  {
                     
                    s1 = dr.GetValue(0).ToString();
                    Labeldeliveryresult.Text = dr.GetValue(1).ToString();
                  }
                  Labelorderid.Text = s1;
                  if (Labeldeliveryresult.Text == "Request pending")
                  {
                    Button1.Visible = false;
                  }
                }
            }
           con.Close();
            }
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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Panel3.Visible = true;

        Label26.Text = Session["dn"].ToString();
        cmd = new SqlCommand("select orderno,orderdate,deliverydate,name from booking where name='" + Session["nm"].ToString() + "' and Delivery='" + Labeldeliveryresult.Text + "' and distributorname='" + Session["dn"].ToString() + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        string s1 = "";
        while (dr.Read())
        {
            s1 = dr.GetValue(0).ToString();

            TextBox18.Text = dr.GetValue(1).ToString();
            TextBox14.Text = dr.GetValue(2).ToString();
            TextBox16.Text = dr.GetValue(3).ToString();
        }
        TextBox12.Text = s1;
        TextBox13.Text = (int.Parse(s1) + 1000).ToString();
        dr.Close();
        cmd = new SqlCommand("select email,city from consumer where username='" + Session["un"].ToString() + "'", con);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TextBox17.Text = dr.GetValue(0).ToString();
            TextBox19.Text = dr.GetValue(1).ToString();

        }
    }
}
