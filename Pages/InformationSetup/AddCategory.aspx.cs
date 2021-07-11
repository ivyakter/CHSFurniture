using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_Category : System.Web.UI.Page
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
                getCategorybyid();

            }
        }
        else
        {
            btnupdate.Visible = false;
            btnSave.Visible = true;

            GetProductNo();
        }
    }
    private void getCategorybyid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);
        DataTable dt = mydal.getCategorybyid(id);
        if (dt.Rows.Count > 0)
        {
            txtcategoryid.Text = dt.Rows[0]["ID"].ToString();
            txtcategoryname.Text = dt.Rows[0]["CategoryName"].ToString();

        }
    }

    public void GetProductNo()
    {
        DataTable n = mydal.GetCategoryNo();
        txtcategoryid.Text = n.Rows[0]["ID"].ToString();
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtcategoryid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtcategoryid.Text;
            insert[1] = txtcategoryname.Text;


            bool Save = mydal.InsertCategoryname(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtcategoryid.Text = null;
                txtcategoryname.Text = null;

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

        string name = txtcategoryname.Text;

        bool update = mydal.UpdateCategoryName(id, name);
        Response.Redirect("ListCategory.aspx");

    }
}