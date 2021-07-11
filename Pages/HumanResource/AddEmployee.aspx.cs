using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_HumanResource_AddEmployee : System.Web.UI.Page
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
                GetOfficer();
                getClientbyid();


            }
        }
        else
        {
            btnupdate.Visible = false;
            btnSave.Visible = true;
            GetOfficer();
            GetClientNo();
        }
    }
    private void getClientbyid()
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);
        DataTable dt = mydal.getEmployeebyid(id);
        //if (dt.Rows.Count > 0)
        //{
        //    txtclientid.Text = dt.Rows[0]["ClientID"].ToString();
        //    txtclientname.Text = dt.Rows[0]["ClientName"].ToString();
        //    txtcontact.Text = dt.Rows[0]["Contact"].ToString();
        //    txtaddress.Text = dt.Rows[0]["Address"].ToString();

        //}

        ddlOfficer.SelectedValue = dt.Rows[0]["Officer_Type"].ToString();
        txtOffName.Text = dt.Rows[0]["Name"].ToString();

        txtOfficerId.Text = dt.Rows[0]["OfficerId"].ToString();
        //txtOfficerIdOld.Text = dt.Rows[0]["OfficerId"].ToString();
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
        //txtSalesTarget.Text = dt.Rows[0]["SalesTarget"].ToString();
        txtBasicSalary.Text = dt.Rows[0]["BasicSalary"].ToString();
        txtRelation.Text = dt.Rows[0]["Relation"].ToString();
        txtNid.Text = dt.Rows[0]["NID"].ToString();
    }

    public void GetClientNo()
    {
        DataTable dt = mydal.GetOfficerId();
        txtOfficerId.Text = "100" + dt.Rows[0][0].ToString();
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


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (ddlOfficer.SelectedItem.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Select Officer Type');", true);
        }
        else
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
                txtBasicSalary.Text = null;
                txtDofBirth.Text = null;
                txtDofMar.Text = null;
                txtChil.Text = null;
                txtCompany.Text = null;
                GetClientNo();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
            }
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Int64 id = Convert.ToInt64(Request.QueryString["ID"]);

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


        bool update = mydal.UpdateEmployee(id, insert);
        if (update == true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated');", true);
            Response.Redirect("ListEmployee.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
        }


    }
}