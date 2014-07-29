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
public partial class adminpages_stockincrease : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["un"]!=null)
        {
            if (!IsPostBack)
            {
                getdata();
                if (ds.Tables[0].Rows.Count > 0)
                    binddata();
            }

        }
    
    }
    protected void getdata()
    {
        da = new SqlDataAdapter("Select * from drequestgas", con);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
              Session["dt"] = ds.Tables[0];
        }
        else
        {
            Label1.Text = "No gas Requests";
            Button1.Visible = false;
            Session["dt"] = ds.Tables[0];


        }

    }
    protected void binddata()
    {
        DataTable dt = (DataTable)Session["dt"];
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    SqlCommand cmd;
    protected void Button1_Click(object sender, EventArgs e)
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
                cmd=new SqlCommand("update distributor set stock=stock+@s where distributor=@d",con);
                cmd.Parameters.AddWithValue("@s", dt.Rows[i][1].ToString());
                cmd.Parameters.AddWithValue("@d", dt.Rows[i][0].ToString());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from drequestgas where distributorname=@dname", con);
                cmd.Parameters.AddWithValue("@dname", dt.Rows[i][0].ToString());
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
