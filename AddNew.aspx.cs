using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RohiniBankBilling
{
    public partial class AddNew : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Rohini"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(!IsPostBack)
            {
                Bindcompany();
                Bindcompany1();
                Bindcompany2();
                BindVillage();
                bank();
            }
        }

        protected void Btncompany_Click(object sender, EventArgs e)
        {
          
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from company where companyname='"+txtcompany.Text+"'",con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                Response.Write("<script>alert('Duplicate entry')</script>");
                            }
                            else
                            {
                                String insert = "insert into company(companyname,address) values('"+txtcompany.Text+"','"+txtcmpnyaddress.Text+"')";
                                SqlCommand cmd1 = new SqlCommand(insert, con);
                                con.Open();
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                Response.Write("<script>alert('Data inserted Successfully')</script>");
                               Response.Redirect("Comapnylist.aspx");

                            }
                        }
                    }
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
                        drpcompanyac.DataSource = dt;
                        drpcompanyac.DataValueField = "id";
                        drpcompanyac.DataTextField = "companyname";
                        drpcompanyac.DataBind();
                        sqlConn.Close();
                        drpcompanyac.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }

        }

        protected void btnaccount_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Bank where companyid='" + drpcompanyac.SelectedValue+ "' and AccountNo='"+txtaccount.Text+"'",con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Duplicate entry')</script>");
                        }
                        else
                        {
                            String insert = "insert into Bank(AccountNo,Ifsc,companyid,bankname) values('" + txtaccount.Text + "','" +txtifsc.Text + "','"+drpcompanyac.SelectedValue+"','"+ddlbank.SelectedItem.Text+"')";
                            SqlCommand cmd1 = new SqlCommand(insert, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Data inserted Successfully')</script>");

                            Response.Redirect("accountlist.aspx");

                        }
                    }
                }
            }
        }
        private void Bindcompany1()
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
                        drpcompanyvlg.DataSource = dt;
                        drpcompanyvlg.DataValueField = "id";
                        drpcompanyvlg.DataTextField = "companyname";
                        drpcompanyvlg.DataBind();
                        sqlConn.Close();
                        drpcompanyvlg.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }

        }

        protected void btnvillage_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Village where companynameid='" + drpcompanyvlg.SelectedValue + "' and villagename='" + txtvillage.Text + "'",con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Duplicate entry')</script>");
                        }
                        else
                        {
                            String insert = "insert into Village(companynameid,villagename) values('" + drpcompanyvlg.SelectedValue + "','" + txtvillage.Text + "')";
                            SqlCommand cmd1 = new SqlCommand(insert, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Data inserted Successfully')</script>");
                            Response.Redirect("villagelist.aspx");
                        }
                    }
                }
            }
        }
        private void bank()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,name FROM bankname";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlbank.DataSource = dt;
                        ddlbank.DataValueField = "id";
                        ddlbank.DataTextField = "name";
                        ddlbank.DataBind();
                        sqlConn.Close();
                        ddlbank.Items.Insert(0, new ListItem("select bank", "0"));
                    }
                }
            }
            catch { }

        }
        private void Bindcompany2()
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
                        drpcompanycust.DataSource = dt;
                        drpcompanycust.DataValueField = "id";
                        drpcompanycust.DataTextField = "companyname";
                        drpcompanycust.DataBind();
                        sqlConn.Close();
                        drpcompanycust.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }

        }
        private void BindVillage()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandText = "SELECT id,villagename FROM Village";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        drpvilagecus.DataSource = dt;
                        drpvilagecus.DataValueField = "id";
                        drpvilagecus.DataTextField = "villagename";
                        drpvilagecus.DataBind();
                        sqlConn.Close();
                        drpvilagecus.Items.Insert(0, new ListItem("", "0"));
                    }
                }
            }
            catch { }

        }

        protected void btncust_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from customer where companyid='" + drpcompanycust.SelectedValue + "' and Villageid='" +drpvilagecus.SelectedValue + "' and custName='"+txtcust.Text+"'",con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Duplicate entry')</script>");
                        }
                        else
                        {
                            String insert = "insert into customer(custName,custcompany,Villageid,companyid) values('" + txtcust.Text + "','"+txtcustcmpname.Text+"','" + drpvilagecus.SelectedValue + "','"+drpcompanycust.SelectedValue+"')";
                            SqlCommand cmd1 = new SqlCommand(insert, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Data inserted Successfully')</script>");
                            Response.Redirect("customerlist.aspx");
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from bankname where name='" + Textbank.Text + "'", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Duplicate entry')</script>");
                        }
                        else
                        {
                            String insert = "insert into bankname(name) values('" +Textbank.Text + "')";
                            SqlCommand cmd1 = new SqlCommand(insert, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            Textbank.Text = string.Empty;
                            
                        }
                    }
                }
            }
        }
    }
}