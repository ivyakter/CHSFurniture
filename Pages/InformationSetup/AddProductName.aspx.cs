using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_InformationSetup_AddProductName : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                btnupdate.Visible = true;
                btnSave.Visible = false;
                getProductbyid();
            }
            else
            {
                btnupdate.Visible = false;
                btnSave.Visible = true;
                GetProductNo();
            }
        }
    }
    public void GetProductNo()
    {
        DataTable n = mydal.GetProNameNo();
        txtProductid.Text = "PRO" + n.Rows[0]["id"].ToString();
    }
    private void getProductbyid()
    {
        string id = Request.QueryString["ID"].ToString();
        DataTable dt = mydal.getPnameByid(id);
        if (dt.Rows.Count > 0)
        {
            txtProductid.Text = dt.Rows[0]["Proid"].ToString();
            txtProductName.Text = dt.Rows[0]["PName"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtProductName.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Priduct Name');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtProductid.Text;
            insert[1] = txtProductName.Text;

            bool Save = mydal.InsertProName(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtProductName.Text = null;

                GetProductNo();
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
        string id = Request.QueryString["ID"].ToString();

        string name = txtProductName.Text;

        bool update = mydal.UpdateProName(id, name);
        Response.Redirect("ListProduct.aspx");

    }
}