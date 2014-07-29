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
public partial class consumer : System.Web.UI.Page
{
    SqlConnection con= new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["un"] == null)
            Response.Redirect("Default.aspx");
        
        else
        {
            Label5.Text = "";
            Label1.Text = Session["un"].ToString();
        SqlDataAdapter da=new SqlDataAdapter("select username,consumerid,state,city,distributor,address,email,name from consumer where username='"+Session["un"].ToString()+"'",con);
        DataSet ds=new DataSet();
       

            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
            if (IsPostBack == true)
            {
                if (Session["pn"]!=null)
                {
                    Panel1.Visible = true;
                }
            }
            else
            {
                Panel1.Visible = false;
                

            }
            Session["dn"] = dt.Rows[0][4].ToString();
            Session["nm"] = dt.Rows[0][7].ToString();
            
            
           
          
            
        }
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["un"] = null;
        Response.Redirect("../Default.aspx");

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        
        
        Response.Redirect("updatepro.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {

        Panel1.Visible = true;
        GridView1.Visible = false;
        Label3.Text = "";
        Label4.Text = "";

    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        GridView1.Visible = true;
        GridView2.Visible = false;
        Label4.Text = "";
       
        Label2.Text = "";
        SqlDataAdapter da = new SqlDataAdapter("select * from booking where name='"+Session["nm"].ToString()+"' and distributorname='"+Session["dn"].ToString()+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count==0)
            Label3.Text = "No booking history";
        else
        {
            Label3.Text = "Booking History";
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

    }
    SqlCommand cmd;
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
     
        SqlDataAdapter da = new SqlDataAdapter("select orderdate from booking where name='"+Session["nm"].ToString()+"' and distributorname='"+Session["dn"].ToString()+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {

            int j = dt.Rows.Count - 1;
            DateTime d1 = new DateTime();
            d1 = DateTime.Now;

            DateTime d2 = new DateTime();
            d2 = (DateTime)dt.Rows[j][0];
            TimeSpan t = d1-d2;
            int days = (int)(t.TotalDays);



            if (days <15)
            {
               
                Label2.Text ="you already booked";
                i = 1;
            }
        }
            if(i==0)
            {
                cmd = new SqlCommand("select max(orderno) from booking", con);
                con.Open();
                
                int max = 0;
                if (!cmd.ExecuteScalar().Equals(DBNull.Value))
                    max = Int32.Parse(cmd.ExecuteScalar().ToString());
                    
         
                
               
                cmd = new SqlCommand("insert into booking values(@or,@od,@dd,@dn,@del,@nm)", con);
                cmd.Parameters.AddWithValue("@or", max + 1);
                cmd.Parameters.AddWithValue("@od", DateTime.Now);
                cmd.Parameters.AddWithValue("@dd",DBNull.Value );
                cmd.Parameters.AddWithValue("@dn", Session["dn"].ToString());
                
                cmd.Parameters.AddWithValue("@del", "Request pending");
                cmd.Parameters.AddWithValue("@nm", Session["nm"].ToString());

                
                cmd.ExecuteNonQuery();
                Session["pn"] = "rret";
                Label2.Text = "Order Requested Succesfully Your Order reference no. is " + (max+1);
                con.Close();
            }

        }
        
    
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Label4.Text = "Cancel Booking";
        Panel1.Visible = false;
        GridView2.Visible = true;
        GridView1.Visible = false;
        Label3.Text = "";
        Label2.Text = "";
        GetData();
       if(ds.Tables[0].Rows.Count>0)
        Binddata();
    }
    SqlDataAdapter da;
    DataSet ds;
    protected void GetData()
    {
        
         da = new SqlDataAdapter("select * from booking where name='" +Session["nm"].ToString() + "' and Delivery='Request pending' and distributorname='"+Session["dn"].ToString()+"'", con);
        ds = new DataSet();
        
        da.Fill(ds, "stud");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["da"] = da;
            Session["dt"] = ds.Tables[0];
        }
        else
        {
            Label4.Text = "YOU HAVEN'T ORDERED ANY GAS";
            
        }
       
    }
    protected void Binddata()
    {
        DataTable dt = (DataTable)Session["dt"];
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int r = e.RowIndex;
        DataTable dt = (DataTable)Session["dt"];
        dt.Rows[r].Delete();
        
        SqlDataAdapter daa = (SqlDataAdapter)Session["da"];
        SqlCommandBuilder scbd = new SqlCommandBuilder(daa);
        daa.Update(dt);
        Label5.Text = "Booking has been cancelled";
        GetData();
        Binddata();
        Label4.Text = "";
        Panel1.Visible = false;
    }
    
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("transfer.aspx");

    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("generatebill.aspx");
    }
}
