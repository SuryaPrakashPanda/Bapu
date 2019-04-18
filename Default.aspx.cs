using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace RohiniBankBilling
{
    public partial class Default : System.Web.UI.Page
    {
        string connstrg = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsignin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con=new SqlConnection(connstrg))
            {
                con.Open();
                string select = "select * from login where uname='"+txtuname.Text+"' and password='"+txtpass.Text+"'";
                SqlCommand cmd = new SqlCommand(select,con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if(ds.Tables[0].Rows.Count==1)
                {
                    string name = ds.Tables[0].Rows[0]["name"].ToString().Trim();
                    Session["name"] = name;
                    Response.Redirect("Bankstatemententry.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid username or password')</script>");
                }
            }
        }
    }
}