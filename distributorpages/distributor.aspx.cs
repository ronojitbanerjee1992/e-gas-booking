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

public partial class distrubutorpages_distributor : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["un"] != null)
        {
            Label1.Text = Session["un"].ToString();
            Button1.Visible = false;
            if (!IsPostBack)
                Panel3.Visible = false;

            cmd = new SqlCommand("select stock from distributor where username='" + Session["un"].ToString() + "'", con);
            con.Open();
            Label5.Text = "";
            int s=(Int32)(cmd.ExecuteScalar());
            stock.Text = s.ToString();
            Session["stock"] = s;
            con.Close();

        }
        else
        {
            Response.Redirect("../Default.aspx");

        }
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["un"] = null;
        Response.Redirect("../Default.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        GridView2.Visible = false;
        GridView1.Visible = true;
        Button1.Visible = true ;
        Panel3.Visible = false;
      
     getdata();
        if(ds.Tables[0].Rows.Count>0)
     binddata();
       
    }
    protected void getdata()
    {    
        da=new SqlDataAdapter("Select orderno,orderdate,deliverydate,Delivery,name from booking where distributorname='"+Session["din"].ToString()+"' and Delivery='Request pending'",con);
        ds=new DataSet();
        da.Fill(ds, "bk");
        if (ds.Tables[0].Rows.Count > 0)
        {
           //SqlCommandBuilder scbd = new SqlCommandBuilder(da);
            Session["da"] = da;
            Session["dt"] = ds.Tables["bk"];

        }
        else
        {
            Label2.Text = "No booking requests";
            GridView1.Visible = false;
            Button1.Visible = false;
        }
           

    }
    protected void binddata()
    {
        DataTable dt=(DataTable)Session["dt"];
        GridView1.DataSource=dt;
        GridView1.DataBind();

    }


    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("delivered.aspx");
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        int s = int.Parse(Session["stock"].ToString());
        DataTable dt = (DataTable)Session["dt"];
        con.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow gr;
            gr = GridView1.Rows[i];

            CheckBox ch = (CheckBox)gr.FindControl("CheckBox1");
            if (ch.Checked == true)
            {
                Label l= (Label)gr.FindControl("Label3");
                cmd = new SqlCommand("update booking set deliverydate=@dd,delivery=@d where distributorname='" + Session["din"].ToString() + "'", con);
                cmd.Parameters.AddWithValue("@dd", DateTime.Now.AddDays(2));
                cmd.Parameters.AddWithValue("@d", "Approved");
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update consumer set nob=nob+1 where distributor=@d and name=@nm", con);
                cmd.Parameters.AddWithValue("@d", Session["din"].ToString());
                cmd.Parameters.AddWithValue("@nm", l.Text);
                cmd.ExecuteNonQuery();
                s--;
                
            }
        }
        
        stock.Text = s.ToString();
        cmd = new SqlCommand("update distributor set stock=@s where username='" + Session["un"].ToString() + "'", con);
        cmd.Parameters.AddWithValue("@s", s);
        cmd.ExecuteNonQuery();
        getdata();
        binddata();
       
        
        con.Close();
        }
        
        
    
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Button1.Visible = false;
        Panel3.Visible = false;
        GridView1.Visible = false;
        GridView2.Visible = true;
        Label5.Text = "";
        Label2.Text = "";
        da = new SqlDataAdapter("select * from booking where distributorname='" + Session["din"].ToString() + "'", con);
        ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        GridView2.Visible = false;
        cmd = new SqlCommand("select distributorname from drequestgas", con);
        con.Open();
        if (cmd.ExecuteScalar() != null)
        {
            Label5.Text = "Already sent a request";
            Panel3.Visible = true;
            Button2.Visible = TextBox4.Visible = Label4.Visible = false;

        }
        else
            Panel3.Visible = true;
        con.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        if (check(TextBox4.Text))
        {
            cmd = new SqlCommand("insert into drequestgas values(@d,@g)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@d", Session["din"].ToString());
            cmd.Parameters.AddWithValue("@g", TextBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label5.Text = "Request sent to administrator";
            TextBox4.Text = "";
        }
        else
            Label5.Text = "Invalid input";
    }
    protected bool check(string s)
    {
        bool flag=true;
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
}
