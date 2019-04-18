using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RohiniBankBilling
{
    public partial class SingleeDate : System.Web.UI.Page
    {
        string connstrg = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bindgrid();
            }
        }


        protected void bindgrid()
        {

            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("select row_number() over(order by id) as sno,convert(varchar(10),date,101) as date1,* from statementdatails  order by date  desc", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                btnpdf.Visible = true;
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

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("select row_number() over(order by id) as sno,convert(varchar(10),date,101) as date1,* from statementdatails where date='" + txtdate.Text+"'  order by date  desc", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                btnpdf.Visible = true;
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;


            Response.AddHeader("content-disposition",
            "attachment;filename='delivered items.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;

            GridView1.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void lnkDone_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("update statementdatails set status = 'Done' where Id = '" + lblid.Text + "' ", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            bindgrid();
        }

        protected void lnkUnderProcess_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("update statementdatails set status = 'Under Process' where Id = '" + lblid.Text + "' ", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            bindgrid();
        }

        protected void lnkNotClear_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("update statementdatails set status = 'Not Clear ' where Id = '" + lblid.Text + "' ", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            bindgrid();
        }

        protected void lnkChequeReturn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("update statementdatails set status = 'Cheque Return' where Id = '" + lblid.Text + "' ", conn44);

            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            bindgrid();
        }
    }
}