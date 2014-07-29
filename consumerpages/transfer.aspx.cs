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

public partial class consumerpages_transfer : System.Web.UI.Page
{
    string state;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
     protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from state", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "st");
            DropDownList3.DataSource = ds.Tables[0];
            DropDownList3.DataTextField = "state";
            DropDownList3.DataValueField = "sid";
            DropDownList3.DataBind();
            DropDownList1.Items.Insert(0, "Select");
            DropDownList2.Items.Insert(0, "Select");
            DropDownList3.Items.Insert(0, "Select");
            DropDownList2.Enabled = false;
            DropDownList1.Enabled = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

       /* cmd = new SqlCommand("select state from state where sid='" + DropDownList1.SelectedItem.Value + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if(dr.Read())
        state = dr.GetValue(0).ToString();
        con.Close();*/
        DropDownList2.Enabled = true;
        int s = int.Parse(DropDownList1.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter("select distributor,did from distributor where did='" + s + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tb");
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "distributor";
        DropDownList2.DataValueField = "did";
        DropDownList2.DataBind();
      
       
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        con.Open();
        cmd = new SqlCommand("select name from consumer where username='"+Session["un"].ToString()+"'", con);
        string s = cmd.ExecuteScalar().ToString();
        cmd = new SqlCommand("insert into request values(@u,@nm,@st,@c,@d,@ad)", con);
        cmd.Parameters.AddWithValue("@u",Session["un"].ToString());
        cmd.Parameters.AddWithValue("@nm", s);
        cmd.Parameters.AddWithValue("@st",DropDownList3.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@c",DropDownList1.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@d",DropDownList2.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@ad", TextBox1.Text);
      
        
        cmd.ExecuteNonQuery();
        con.Close();
        Label1.Text = "Requested to administrator you will be transferred to your desired location within few days";


    }
    
    protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList1.Enabled = true;
        int s = int.Parse(DropDownList3.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter("select city,cityid,did from cities where cityid='" + s + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tb");
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "city";
        DropDownList1.DataValueField = "did";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
        DropDownList2.SelectedIndex = 0;
        DropDownList2.Items.Insert(0, "Select");
        DropDownList2.SelectedIndex = 0;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

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
}
