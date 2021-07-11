using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Set_AddSubCategory : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                LoadCategoruandsubcategory();
                getSubcategorywithid();
                btnupdate.Visible = true;
                btnSave.Visible = false;

            }
            else
            {

                GetNumber();
                LoadCategoruandsubcategory();
                btnupdate.Visible = false;
                btnSave.Visible = true;

            }
        }
    }

    protected void LoadCategoruandsubcategory()
    {
        DataTable dt = mydal.LoadCategoryname();
        if (dt.Rows.Count > 0)
        {
            ddlcategory.DataSource = dt;
            ddlcategory.DataTextField = "MenuText";
            ddlcategory.DataValueField = "Id";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, new ListItem("-Select-", "0"));
       
        }
    
    }

    private void getSubcategorywithid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["Id"]);
        DataTable dt = mydal.getSubCategoryid(id);
        if (dt.Rows.Count > 0)
        {
            //loadAreaname();

            txtsubcatid.Text = dt.Rows[0]["Id"].ToString();
            txtsubcategoryname.Text = dt.Rows[0]["MenuText"].ToString();
            ddlmenulevel.SelectedItem.Text = dt.Rows[0]["MenuLevel"].ToString();
            ddlcategory.SelectedItem.Text = dt.Rows[0]["ParentId"].ToString();


        }
    }





    public void GetNumber()
    {
        DataTable CategoryID = mydal.GetCategoryNo();
        txtsubcatid.Text = CategoryID.Rows[0][0].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtsubcatid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give SubCategoryID');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtsubcatid.Text;
            insert[1] = txtsubcategoryname.Text;
            insert[2] = ddlmenulevel.SelectedItem.Text;
            insert[3] = ddlcategory.SelectedValue;

            bool Save = mydal.InsertSubCategory(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtsubcategoryname.Text = null;
                ddlmenulevel.SelectedItem.Text = null;
                ddlcategory.SelectedValue = null;
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
        Int64 id = Convert.ToInt64(Request.QueryString["Id"]);

        string SubCategoryId = txtsubcatid.Text;
        string SubCategoryName = txtsubcategoryname.Text;
        string Menulevel = ddlmenulevel.SelectedItem.Text;
        string ParentID = ddlcategory.SelectedValue;


        bool update = mydal.UpdateSubCategoryname(SubCategoryId, SubCategoryName, Menulevel, ParentID);

        Response.Redirect("ListSubCategory.aspx");

    }   
}