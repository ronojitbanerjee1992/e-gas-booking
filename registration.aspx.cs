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

public partial class registration : System.Web.UI.Page
{SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=jj;Integrated Security=True;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        string Password = TextBox2.Text;
        TextBox2.Attributes.Add("value", Password);
        if (IsPostBack == false)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("select * from state", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "st");
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "state";
            DropDownList1.DataValueField = "sid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select");
            DropDownList2.Items.Insert(0, "Select");
            DropDownList3.Items.Insert(0, "Select");
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
           
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            SqlCommand cmd = new SqlCommand("insert into consumer values(@u,@p,@ad,@cid,@st,@em,@ct,@dt,@nm,@nob)", con);
            cmd.Parameters.AddWithValue("@u", TextBox1.Text);
            cmd.Parameters.AddWithValue("@p", TextBox2.Text);
            cmd.Parameters.AddWithValue("@ad", TextBox6.Text);
            cmd.Parameters.AddWithValue("@cid", int.Parse(TextBox4.Text));
            
            cmd.Parameters.AddWithValue("@st", DropDownList1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@em", TextBox5.Text);
            cmd.Parameters.AddWithValue("@ct", DropDownList2.SelectedItem.ToString());
             cmd.Parameters.AddWithValue("@dt",DropDownList3.SelectedItem.ToString());
             cmd.Parameters.AddWithValue("@nm", TextBox7.Text);
             cmd.Parameters.AddWithValue("@nob","0");
            con.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Registration Succesful ";
           
            con.Close();
           
        }


       

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList2.Enabled = true;
        int s = int.Parse(DropDownList1.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter("select city,cityid,did from cities where cityid='" + s + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tb");
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "city";
        DropDownList2.DataValueField = "did";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select");
        DropDownList2.SelectedIndex = 0;
        DropDownList3.Items.Insert(0, "Select");
        DropDownList3.SelectedIndex = 0;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.Enabled = true;
        int s = int.Parse(DropDownList2.SelectedItem.Value);
        SqlDataAdapter da = new SqlDataAdapter("select distributor,did from distributor where did='" + s + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tb");
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "distributor";
        DropDownList3.DataValueField = "did";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, "Select");
        DropDownList3.SelectedIndex = 0;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

