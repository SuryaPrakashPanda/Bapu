using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RohiniBankBilling
{
    public partial class Reports : System.Web.UI.Page
    {
        string connstrg = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                Bindcompany();
                bindgrid();
            }
        }

        private void Bindcompany()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connstrg))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,companyname FROM company";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpcompany.DataSource = dt;
                        drpcompany.DataValueField = "id";
                        drpcompany.DataTextField = "companyname";
                        drpcompany.DataBind();
                        sqlConn.Close();
                        drpcompany.Items.Insert(0, new ListItem("Select Company", "0"));
                    }
                }
            }
            catch { }
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

        protected void drpcompany_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connstrg))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,bankname FROM Bank where companyid='" + drpcompany.SelectedValue + "' group by bankname,id";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlbank.DataSource = dt;
                        ddlbank.DataValueField = "id";
                        ddlbank.DataTextField = "bankname";
                        ddlbank.DataBind();
                        sqlConn.Close();
                        ddlbank.Items.Insert(0, new ListItem("Select Bank", "0"));
                    }
                    SqlConnection con = new SqlConnection(connstrg);
                    SqlCommand cmd = new SqlCommand("select row_number() over(order by id) as sno,convert(varchar(10),date,101) as date1,* from statementdatails where companyname = '" + drpcompany.SelectedItem.Text + "'", con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da1.Fill(ds);
                    con.Close();
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
            }
            catch { }
        }

        protected void ddlbank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connstrg))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,AccountNo FROM Bank where companyid='" + drpcompany.SelectedValue + "' and bankname='" + ddlbank.SelectedItem.Text + "'";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpaccno.DataSource = dt;
                        drpaccno.DataValueField = "id";
                        drpaccno.DataTextField = "AccountNo";
                        drpaccno.DataBind();
                        sqlConn.Close();
                        drpaccno.Items.Insert(0, new ListItem("Select Account", "0"));
                    }
                }
                SqlConnection con = new SqlConnection(connstrg);
                SqlCommand cmd = new SqlCommand("select row_number() over(order by s.id) as sno,convert(varchar(10),s.date,101) as date1,* from statementdatails s inner join Bank b on b.AccountNo = s.accountno where s.companyname = '" + drpcompany.SelectedItem.Text + "' and b.bankname = '" + ddlbank.SelectedItem.Text + "'", con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da1.Fill(ds);
                con.Close();
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
            catch { }

        }

       

        protected void drpaccno_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstrg);
            SqlCommand cmd = new SqlCommand("select row_number() over(order by s.id) as sno,convert(varchar(10),s.date,101) as date1,* from statementdatails s inner join Bank b on b.AccountNo = s.accountno where s.companyname = '" + drpcompany.SelectedItem.Text + "' and b.bankname = '" + ddlbank.SelectedItem.Text + "' and s.accountno='"+drpaccno.SelectedItem.Text+"'", con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            con.Close();
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
    }
}