using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_HumanResource_OfficerInfo : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
            GetOfficerId();
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
    public void GetOfficerId()
    {
        DataTable dt = mydal.GetOfficerId();
        txtOfficerId.Text = "100" + dt.Rows[0][0].ToString();
    }  
   
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string[] insert = new string[20];
              
        insert[1] = txtOffName.Text;
        insert[2] = txtAddress.Text;
        insert[3] = txtMobile.Text;
        insert[4] = txtGN.Text;
        insert[5] = txtGMob.Text;
        insert[6] = txtGAdd.Text;
        insert[7] = txtCheck.Text;
        insert[8] = txtBasicSalary.Text;
        insert[9] = Convert.ToDateTime(txtDofBirth.Text).ToShortDateString();
        insert[10] = Convert.ToDateTime(txtDofMar.Text).ToShortDateString();
        insert[11] = txtChil.Text;
        insert[12] = txtCompany.Text;     
        insert[15] = txtOfficerId.Text;
        insert[16] = txtRelation.Text;
        insert[17] = txtNid.Text;
        insert[18] = ddlOfficer.SelectedItem.ToString();

        bool Save = mydal.InsertOfficer(insert);

        if (Save == true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);       
            txtOffName.Text = null;
            txtAddress.Text = null;
            txtMobile.Text = null;
            txtGN.Text = null;
            txtGMob.Text = null;
            txtGAdd.Text = null;
            txtCheck.Text = null;
            txtBasicSalary.Text=null;
            txtDofBirth.Text = null;
            txtDofMar.Text = null;
            txtChil.Text = null;
            txtCompany.Text = null;
            GetOfficerId();
           
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
        }                
    }   
}