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


public partial class distributorpages_delivered : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            da = new SqlDataAdapter("select name,nob from consumer where distributor='" + Session["din"].ToString() + "' and nob>0", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
      
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("./distributor.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Session["un"] = null;
        Session["din"] = null;
        Response.Redirect("../Default.aspx");
    }
}
