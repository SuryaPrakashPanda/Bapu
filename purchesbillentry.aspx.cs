using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace RohiniBankBilling
{
    public partial class purchesbillentry : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindvillage();
            }
        }

        public void bindvillage()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select id,villagename from Village group by villagename,id";
                        cmd.Connection = con;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpvillage.DataSource = dt;
                        drpvillage.DataValueField = "id";
                        drpvillage.DataTextField = "villagename";
                        drpvillage.DataBind();
                        con.Close();
                        drpvillage.Items.Insert(0, new ListItem("select village", "0"));
                    }
                }


            }
            catch
            {
                
            }
       

        }

        protected void drpvillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select id,custcompany from customer";
                        cmd.Connection = con;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpcomp.DataSource = dt;
                        drpcomp.DataValueField = "id";
                        drpcomp.DataTextField = "custcompany";
                        drpcomp.DataBind();
                        con.Close();
                        drpcomp.Items.Insert(0, new ListItem("select village", "0"));
                    }
                }


            }
            catch
            {

            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (billpdf.HasFile)
                {
                    string str = billpdf.FileName;
                    billpdf.PostedFile.SaveAs(Server.MapPath("~/Billimages/" + str));
                    string Image = "~/Billimages/" + str.ToString();
                    SqlCommand cmd = new SqlCommand("insert into purchasebill(date,village,company,invoiceno,invoicedate,vehical,billamount,billpdf) values('" + txtdate.Text + "','" + drpvillage.SelectedItem.Text + "','" + drpcomp.SelectedItem.Text + "','" + txtinvoiceno.Text + "','" + txtinvdate.Text + "','" + txtvehical.Text + "','" + txtbillamnt.Text + "',@Image)", con);
                    cmd.Parameters.AddWithValue("Image", Image);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Data inserted successfully')</script>");
                    txtdate.Text = txtinvdate.Text = txtinvoiceno.Text = txtvehical.Text = txtbillamnt.Text = string.Empty;
                    drpcomp.SelectedIndex = drpvillage.SelectedIndex = -1;
                }
            }
        }

    }
}