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
public partial class adminpages_admin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["un"] == null)
        {

            Response.Redirect("../Default.aspx");


        }
        
        if (!IsPostBack)
        {
            Button2.Visible = false;
            DropDownList1.Items.Add("January");
            DropDownList1.Items.Add("February");
            DropDownList1.Items.Add("March");
            DropDownList1.Items.Add("April");
            DropDownList1.Items.Add("May");
            DropDownList1.Items.Add("June");
            DropDownList1.Items.Add("July");
            DropDownList1.Items.Add("August");
            DropDownList1.Items.Add("September");
            DropDownList1.Items.Add("October");
            DropDownList1.Items.Add("November");
            DropDownList1.Items.Add("December");
            da = new SqlDataAdapter("select distributor from distributor", con);
            ds = new DataSet();
            da.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "distributor";
            DropDownList2.DataBind();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Session["un"] = null;
        Response.Redirect("../Default.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
       
        getdata();
        if (ds.Tables[0].Rows.Count > 0)
            binddata();
    }
    protected void getdata()
    {
        da = new SqlDataAdapter("Select * from request ", con);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            Session["da"] = da;
            Session["dt"] = ds.Tables[0];
            Button2.Visible = true;
        }
        else
        {
            Session["dt"] = ds.Tables[0];
            Label2.Text = "No transfer connection Requests";
            Button2.Visible = false;
        }

    }
    protected void binddata()
    {
        DataTable dt = (DataTable)Session["dt"];
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

   
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Label7.Text="No. of gases dispatched  ";
        da = new SqlDataAdapter("select deliverydate from booking where distributorname='" + DropDownList2.SelectedItem.ToString() + "'", con);
        ds = new DataSet();
        da.Fill(ds);
        int nob = 0;
        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DateTime m = (DateTime)dt.Rows[i][0];
            int month = int.Parse(m.Month.ToString());
            if (DropDownList1.SelectedIndex == month - 1)
            {
                nob++;
            }

        }
        Label8.Text = nob.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        con.Open();
        DataTable dt = (DataTable)Session["dt"];
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow gr;
            gr = GridView1.Rows[i];
            
            CheckBox ch = (CheckBox)gr.FindControl("CheckBox1");
            if (ch.Checked == true)
            {
                
                cmd = new SqlCommand("update consumer set state=@s,city=@c,distributor=@d,address=@ad where username=@u", con);
                cmd.Parameters.AddWithValue("@s",dt.Rows[i][2].ToString() );
                cmd.Parameters.AddWithValue("@c", dt.Rows[i][3].ToString());
                cmd.Parameters.AddWithValue("@d", dt.Rows[i][4].ToString());
                cmd.Parameters.AddWithValue("@ad", dt.Rows[i][5].ToString());
                cmd.Parameters.AddWithValue("@u", dt.Rows[i][0].ToString());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from request where username=@u", con);
                cmd.Parameters.AddWithValue("@u", dt.Rows[i][0].ToString());
                cmd.ExecuteNonQuery();
           }
            
            
        }
        con.Close();
        getdata();
        binddata();
       
    }
  
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("distributorapproval.aspx");
    }
    protected void LinkButton5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("stockincrease.aspx");
    }
}