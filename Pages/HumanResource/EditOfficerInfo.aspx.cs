using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_HumanResource_EditOfficerInfo : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetOfficerById();
            GetOfficer();          
        }
        
    }
   
    public void GetOfficer()
    {
        DataTable dt = mydal.GetOfficer();
        ddlOfficer.DataSource = dt;
        ddlOfficer.DataTextField = "OFF_TYPE_NAME";
        ddlOfficer.DataValueField = "id";
        ddlOfficer.DataBind();
        ddlOfficer.Items.Insert(0, "--Select Officer Type--");
    }

    public void GetOfficerById()
    {
        DataTable dt = mydal.GetOfficerById(Request.QueryString["ID"].ToString());

        ddlOfficer.SelectedValue = dt.Rows[0]["Officer_Type"].ToString();
        txtOffName.Text = dt.Rows[0]["Name"].ToString();
    
        txtOfficerId.Text = dt.Rows[0]["OfficerId"].ToString();
        txtOfficerIdOld.Text = dt.Rows[0]["OfficerId"].ToString();
        txtAddress.Text = dt.Rows[0]["Address"].ToString();
        txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
        txtGN.Text = dt.Rows[0]["Guaranter_Name"].ToString();
        txtGMob.Text = dt.Rows[0]["Guaranter_Mobile"].ToString();
        txtGAdd.Text = dt.Rows[0]["Guaranter_Add"].ToString();
        txtCheck.Text = dt.Rows[0]["MIC_Check_No"].ToString();
       
        txtDofBirth.Text = dt.Rows[0]["Date_of_Birth"].ToString();
        txtDofMar.Text = dt.Rows[0]["Date_of_Marriage"].ToString();
        txtChil.Text = dt.Rows[0]["Number_of_Children"].ToString();
        txtCompany.Text = dt.Rows[0]["Previous_Company"].ToString();
        txtSalesTarget.Text = dt.Rows[0]["SalesTarget"].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string[] insert = new string[30];

        insert[0] = txtOfficerId.Text;
        insert[1] = txtOffName.Text;
        insert[2] = txtMobile.Text;
        insert[3] = txtGN.Text;
        insert[4] = txtGMob.Text;
        insert[5] = txtGAdd.Text;
        insert[6] = txtCheck.Text;
        insert[7] = txtDofBirth.Text;
        insert[8] = txtDofMar.Text;

        insert[9] = txtChil.Text;
        insert[10] = txtCompany.Text;
        insert[11] = txtAddress.Text;
        insert[12] = ddlOfficer.SelectedValue;  
        insert[16] = txtOfficerIdOld.Text;
       

        bool Save = mydal.UpdateOfficer(insert);

        if (Save == true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated');", true);
            Response.Redirect("OffcierList.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
        }
    }
}