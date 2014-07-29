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
public partial class adminpages_distributorapproval : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["un"] != null)
        {
           
            if (!IsPostBack)
            {
                getdata();
                binddata();
            }
        }
        else
            Response.Redirect("../Default.aspx");
    }
    protected void getdata()
    {
        da=new SqlDataAdapter("Select * from distributorapplication",con);
        ds=new DataSet();
        da.Fill(ds, "bk");
        if (ds.Tables[0].Rows.Count > 0)
        {


            //SqlCommandBuilder scbd = new SqlCommandBuilder(da);
            Session["da"] = da;
            Session["dt"] = ds.Tables[0];
        }
        else
        {
            Label1.Text="No new distrubutor registration";
            Button1.Visible = false;
            Session["dt"] = ds.Tables[0];
        }
    }
    protected void binddata()
    {
        DataTable dt=(DataTable)Session["dt"];
        GridView1.DataSource=dt;
        GridView1.DataBind();

    }
protected void  Button1_Click(object sender, EventArgs e)
{  
    DataTable dt=(DataTable)Session["dt"];
   
    con.Open();
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
        GridViewRow gr;
        gr = GridView1.Rows[i];
        CheckBox ch = (CheckBox)gr.FindControl("CheckBox1");
        if (ch.Checked == true)
        {

            Label1.Text = dt.Rows[0][0].ToString();
            cmd = new SqlCommand("insert into distributor values(@d,@did,@u,@p,@s)", con);
            cmd.Parameters.AddWithValue("@d", dt.Rows[i][0].ToString());
            cmd.Parameters.AddWithValue("@did", dt.Rows[i][1].ToString());
            cmd.Parameters.AddWithValue("@u", dt.Rows[i][2].ToString());
            cmd.Parameters.AddWithValue("@p", dt.Rows[i][3].ToString());
            cmd.Parameters.AddWithValue("@s","0");
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete from distributorapplication where distributor=@d", con);
            cmd.Parameters.AddWithValue("@d", dt.Rows[i][0].ToString());
            cmd.ExecuteNonQuery();
            
        }
        

    }
    getdata();
    binddata();
    
    con.Close();
}
protected void LinkButton1_Click(object sender, EventArgs e)
{
    Response.Redirect("./admin.aspx");
}
protected void LinkButton2_Click(object sender, EventArgs e)
{
    Session["un"] = null;
    Response.Redirect("../Default.aspx");
}
}
