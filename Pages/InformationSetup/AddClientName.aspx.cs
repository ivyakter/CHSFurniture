using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_AddClientName : System.Web.UI.Page
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
                getClientbyid();

            }
        }
        else
        {
            btnupdate.Visible = false;
            btnSave.Visible = true;

            GetClientNo();
        }
    }
    private void getClientbyid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);
        DataTable dt = mydal.getClientbyid(id);
        if (dt.Rows.Count > 0)
        {
            txtclientid.Text = dt.Rows[0]["ClientID"].ToString();
            txtclientname.Text = dt.Rows[0]["ClientName"].ToString();
            txtcontact.Text = dt.Rows[0]["ContactNo"].ToString();
            txtaddress.Text = dt.Rows[0]["Address"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();

        }
    }

    public void GetClientNo()
    {
        DataTable n = mydal.GetClientNo();
        txtclientid.Text ="CHS/C/" + n.Rows[0]["ID"].ToString();
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtclientid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtclientid.Text;
            insert[1] = txtclientname.Text;
            insert[2] = txtcontact.Text;
            insert[3] = txtaddress.Text;
            insert[4] = txtEmail.Text;

            bool Save = mydal.InsertClientName(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtclientid.Text = null;
                txtclientname.Text = null;
                txtcontact.Text = null;
                txtaddress.Text = null;
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

        string name = txtclientname.Text;
        string contact = txtcontact.Text;
        string address = txtaddress.Text;
        string Email = txtEmail.Text;

        bool update = mydal.UpdateClientName(id, name, contact, address, Email);
        Response.Redirect("ListClient.aspx");

    }
}