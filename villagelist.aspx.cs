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
    public partial class villagelist : System.Web.UI.Page
    {
        string connstrg = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }
        }


        protected void bindgrid()
        {

            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("select row_number() over(order by v.id) as sno,v.*,c.companyname from village v inner join company c on c.id=v.companynameid", conn44);

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


        protected void linkedit_Click(object sender, EventArgs e)
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            Label1.Text = GridView1.DataKeys[gRow.RowIndex].Value.ToString();
            SqlConnection conn44 = new SqlConnection(connstrg);
            conn44.Open();
            SqlCommand cmd = new SqlCommand("select * from Village where id='" + Label1.Text + "'", conn44);
            int n = cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn44.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtvillagedit.Text = ds.Tables[0].Rows[0]["villagename"].ToString();

            }
            this.ModalPopupExtender1.Show();
        }

        protected void linkdelete_Click(object sender, EventArgs e)
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            Label1.Text = GridView1.DataKeys[gRow.RowIndex].Value.ToString();

            SqlConnection conn33 = new SqlConnection(connstrg);
            conn33.Open();
            SqlCommand cmd3 = new SqlCommand("delete FROM Village where Id='" + Label1.Text + "'", conn33);
            cmd3.ExecuteNonQuery();
            conn33.Close();
            bindgrid();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlConnection conn33 = new SqlConnection(connstrg);
            conn33.Open();
            SqlCommand cmd3 = new SqlCommand("update Village set villagename='" + txtvillagedit.Text + "' where id='" + Label1.Text + "'", conn33);
            cmd3.ExecuteNonQuery();
            conn33.Close();
            bindgrid();
        }
    }
}