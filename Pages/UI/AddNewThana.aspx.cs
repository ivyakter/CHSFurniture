using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_AddNewThana : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        }
        if (!IsPostBack)
        {
            mydal.dropdown(dropDistrict, "TBL_DISTRICT ", 1, 0, "DISTRICT");

          //  gvbind();
        }
    }
    private void gvbind()
    {
        //if (ddTariff.SelectedValue.ToString() != "0")
        //{
        //mydal.SelectAreasetup(gvAreaSetup, dropDistrict.SelectedValue.ToString());
        //}
        //else
        //{
        //    gvdocDTL.Dispose();
        //}
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        laMeg.Text = null;
        Label1.Text = "";
        clear();
    }
    protected void clear()
    {
        txtArea.Text = "";
        btSave.Text = "Save";
        gvbind();

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        string uid = Session["Uid"].ToString();

        try
        {
            if (btSave.Text == "Save")
            {
                mydal.save_Thana(txtArea.Text, dropDistrict.SelectedValue.ToString());
                //laMeg.Text = "Saved !";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);


            }
            //else
            //{
            //    bool success = mydal.update_areasetup(dropDistrict.SelectedValue.Trim(), txtArea.Text, uid, Label1.Text);
            //    if (success == true)
            //        //laMeg.Text = "Updated Successfully";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated !');", true);
            //    else
            //        //laMeg.Text = "Not Updated !!";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Updated !');", true);
            //    btSave.Text = "Save";

            //}

            clear();

        }

        catch (Exception ex)
        {
            laMeg.Text = ex.Message.ToString();
        }
    }
}