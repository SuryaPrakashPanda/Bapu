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
    public partial class Bankstatemententry : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                Bindcompany();

            }
        }
        
        private void Bindcompany()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
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

        protected void ddlbank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,AccountNo FROM Bank where companyid='" + drpcompany.SelectedValue + "' and bankname='"+ddlbank.SelectedItem.Text+"'";
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
            }
            catch { }
        }

        protected void drpcompany_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
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
                }
            }
            catch { }
        }

        protected void drpaccno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,villagename FROM Village where companynameid='" + drpcompany.SelectedValue + "'";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpvillage.DataSource = dt;
                        drpvillage.DataValueField = "id";
                        drpvillage.DataTextField = "villagename";
                        drpvillage.DataBind();
                        sqlConn.Close();
                        drpvillage.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }
        }



        protected void drpvillage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,custcompany FROM customer where companyid='" + drpcompany.SelectedValue + "' and Villageid='" + drpvillage.SelectedValue + "'";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpcustcmpny.DataSource = dt;
                        drpcustcmpny.DataValueField = "id";
                        drpcustcmpny.DataTextField = "custcompany";
                        drpcustcmpny.DataBind();
                        sqlConn.Close();
                        drpcustcmpny.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }
        }
        protected void drpcustcmpny_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,custName FROM customer where companyid='" + drpcompany.SelectedValue + "' and Villageid='" + drpvillage.SelectedValue + "' and custcompany='"+drpcustcmpny.SelectedItem.Text+"'";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpcustomer.DataSource = dt;
                        drpcustomer.DataValueField = "id";
                        drpcustomer.DataTextField = "custName";
                        drpcustomer.DataBind();
                        sqlConn.Close();
                        drpcustomer.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(connection))
            {
                sqlConn.Open();
                string insert = "insert into statementdatails(date,companyname,accountno,village,Customercmpny,Customename,amount,tranthrough,trantype,chequeno,status)values('" + txtdate.Text + "','" + drpcompany.SelectedItem.Text + "','" + drpaccno.SelectedItem.Text + "','" + drpvillage.SelectedItem.Text + "','"+drpcustcmpny.SelectedItem.Text+"','" + drpcustomer.SelectedItem.Text + "','" + txtamount.Text + "','" + drptrathrough.SelectedItem.Text + "','" + radiotran.SelectedItem.Text + "','" + txtchequeno.Text + "','"+ddlstatus.SelectedItem.Text+"')";
                SqlCommand cmd = new SqlCommand(insert, sqlConn);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
                Response.Write("<script>alert('Date inserted Succefully')</script>");
                
                
                txtdate.Text = txtamount.Text=txtchequeno.Text = string.Empty;
                ddlstatus.Items.Clear();
                ddlbank.Items.Clear();
                drpaccno.Items.Clear();
                drpcompany.Items.Clear();
                drpvillage.Items.Clear();
                drpcustcmpny.Items.Clear();
                drpcustomer.Items.Clear();
                drptrathrough.Items.Clear();
            }
        }

        protected void drptrathrough_TextChanged(object sender, EventArgs e)
        {
            if (drptrathrough.SelectedItem.Text == "Cheque")
            {
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
            }
        }

        
    }
}