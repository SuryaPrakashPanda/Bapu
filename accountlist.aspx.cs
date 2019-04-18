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
    public partial class accountlist : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("select row_number() over(order by b.id) as sno,b.*,c.companyname from Bank b inner join company c on c.id=b.companyid order by id", conn44);

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
            SqlConnection conn = new SqlConnection(connstrg);
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlCommand cmd = new SqlCommand("Select * from Bank where Id = '" + lblid.Text + "'", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtbank.Text = dr["bankname"].ToString();
                txtacno.Text = dr["AccountNo"].ToString();

            }
            this.ModalPopupExtender1.Show();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstrg);
            SqlCommand cmd = new SqlCommand("Update Bank set bankname='"+txtbank.Text+"', AccountNo = '" + txtacno.Text + "' where Id = '" + lblid.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
        }

        protected void linkdelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstrg);
            LinkButton btn = sender as LinkButton;
            lblid.Text = btn.CommandArgument;
            SqlConnection con = new SqlConnection(connstrg);
            SqlCommand cmd = new SqlCommand("Delete from Bank  where Id = '" + lblid.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
        }
    }
}