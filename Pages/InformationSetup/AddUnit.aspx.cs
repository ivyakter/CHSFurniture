using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_AddUnit : System.Web.UI.Page
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
                getUnitbyid();

            }
        }
        else
        {
            btnupdate.Visible = false;
            btnSave.Visible = true;

            GetProductNo();
        }
    }
    private void getUnitbyid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);
        DataTable dt = mydal.getUnitbyid(id);
        if (dt.Rows.Count > 0)
        {
            txtunitid.Text = dt.Rows[0]["ID"].ToString();
            txtunitname.Text = dt.Rows[0]["UnitName"].ToString();

        }
    }

    public void GetProductNo()
    {
        DataTable n = mydal.GetUnitNo();
        txtunitid.Text = n.Rows[0]["ID"].ToString();
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtunitid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtunitid.Text;
            insert[1] = txtunitname.Text;


            bool Save = mydal.InsertUnitname(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtunitid.Text = null;
                txtunitname.Text = null;

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

        string name = txtunitname.Text;

        bool update = mydal.UpdateUnittName(id, name);
        Response.Redirect("ListUnit.aspx");

    }
}