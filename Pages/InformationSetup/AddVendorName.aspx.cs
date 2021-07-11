using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_VendorName : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            if (!IsPostBack)
            {
                btnupdate.Visible = true;
                btnSave.Visible = false;
                ChartofAccount();
                getProductsbyid();
            }
        }
        else
        {
            btnupdate.Visible = false;
            btnSave.Visible = true;
            ChartofAccount();
            GetProductNo();
        }
    }
    public void ChartofAccount()
    {
        DataTable dt = mydal.getChartofAccounts();
        ddlChartofAccounts.DataSource = dt;
        ddlChartofAccounts.DataTextField = "AccName";
        ddlChartofAccounts.DataValueField = "AccCode";
        ddlChartofAccounts.DataBind();
        ddlChartofAccounts.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void getProductsbyid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);
        DataTable dt = mydal.getVendorbyid(id);
        if (dt.Rows.Count > 0)
        {
            txtvendorid.Text = dt.Rows[0]["ID"].ToString();
            txtvendorname.Text = dt.Rows[0]["VendorName"].ToString();
            txtcontact.Text = dt.Rows[0]["Contact"].ToString();
            txtaddress.Text = dt.Rows[0]["Address"].ToString();
            txtBusinessName.Text = dt.Rows[0]["BusinessName"].ToString();
            ddlChartofAccounts.SelectedItem.Text = dt.Rows[0]["ChartofAccount"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
        }
    }
    public void GetProductNo()
    {
        DataTable n = mydal.GetVendorNo();
        txtvendorid.Text = "CHS/V/" + n.Rows[0]["ID"].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtvendorid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtvendorid.Text;
            insert[1] = txtvendorname.Text;
            insert[2] = txtcontact.Text;
            insert[3] = txtaddress.Text;
            insert[4] = txtBusinessName.Text;
            insert[5] = ddlChartofAccounts.SelectedItem.ToString();
            insert[6] = txtEmail.Text;

            bool Save = mydal.InsertVendorName(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtvendorid.Text = null;
                txtvendorname.Text = null;
                txtcontact.Text = null;
                txtaddress.Text = null;
                txtBusinessName.Text = null;
                txtEmail.Text = null;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('Something wrong please try again');", true);
            }
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);

        string name = txtvendorname.Text;
        string contact = txtcontact.Text;
        string address = txtaddress.Text;
        string businessname = txtBusinessName.Text;
        string chartofacc = ddlChartofAccounts.SelectedItem.ToString();
        string Email = txtEmail.Text;

        bool update = mydal.UpdateVendorName(id, name, contact, address,businessname,chartofacc, Email);
        Response.Redirect("ListVendor.aspx");

    }
}