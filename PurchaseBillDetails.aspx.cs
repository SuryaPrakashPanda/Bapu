using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RohiniBankBilling
{
    public partial class PurchaseBillEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindGrid();
                BindBill();
            }
        }
        string constr = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        string paths;
        private void BindBill()
        {
            SqlConnection conn44 = new SqlConnection(constr);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("Select billpdf from purchasebill", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
             paths = ds.ToString();
            conn44.Close();
        }
        private void BindGrid()
        {
            SqlConnection conn44 = new SqlConnection(constr);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("Select *,substring(billpdf,3,len(billpdf)-1) as billpdf1 from purchasebill", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }

        protected void lnkpdf_Click(object sender, EventArgs e)
        {

            //LinkButton btn = sender as LinkButton;
            //lblid.Text = btn.CommandArgument;
            //string pdf = string.Empty;
            //string subpdf = string.Empty;
            //SqlConnection conn44 = new SqlConnection(constr);
            //conn44.Open();
            //SqlCommand cmd = new SqlCommand("SELECT billpdf,SUBSTRING(billpdf, CHARINDEX('.', billpdf) + 1, LEN(billpdf)) as format from purchasebill  where Id = '" + lblid.Text + "'", conn44);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //     pdf = ds.Tables[0].Rows[0]["billpdf"].ToString();
            //    subpdf = ds.Tables[0].Rows[0]["format"].ToString();
            //}
            //string FilePath = Server.MapPath(pdf);
            //WebClient User = new WebClient();
            //Byte[] FileBuffer = User.DownloadData(FilePath);


            //if (FileBuffer != null)
            //{
            //    if(subpdf=="pdf")
            //    {
            //        Response.ContentType = "application/pdf";
            //    }
            //  else  if (subpdf == "xlsx")
            //    {
            //        Response.ContentType = "application/xlsx";
            //    }
            //    else if (subpdf == "jpg")
            //    {
            //        Response.ContentType = "application/jpg";

            //    }
            //    else if (subpdf == "png")
            //    {
            //        Response.ContentType = "application/png";
            //    }
            //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
            //    Response.BinaryWrite(FileBuffer);

            //}    

            
            
        }
    }
}
