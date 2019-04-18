using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RohiniBankBilling
{
    public partial class Betweendate : System.Web.UI.Page
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

        protected void Btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("select row_number() over(order by id) as sno,convert(varchar(10),date,101) as date1,* from statementdatails where date between '" + txtfrmdate.Text + "' and '"+txttodate.Text+"'  order by date  desc", conn44);

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