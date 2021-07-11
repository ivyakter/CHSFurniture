using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_BankSetup : System.Web.UI.Page
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
            bind();
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        try
        {
            laMeg.Text = "";
            if (!string.IsNullOrEmpty(txtBankName.Text))
            {
                string uid =  Session["Uid"].ToString();
                if (btSave.Text == "Save")
                {
                    bool success = mydal.save_banksetup(txtBankName.Text.Trim(), uid);
                    if (success == true)
                    {
                        //laMeg.Text = "Save Successful";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);
                        txtBankName.Text = "";
                    }
                    else
                        //laMeg.Text = "Not Saved !!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Saved !');", true);
                }
                else
                {
                    bool success = mydal.update_banksetup(txtBankName.Text.Trim(), uid, Label1.Text);
                    if (success == true)
                    {
                        //laMeg.Text = "Update Successful";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated !');", true);
                         txtBankName.Text = "";
                    }
                    else
                        //laMeg.Text = "Not Updated !!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Updated !');", true);
                    btSave.Text = "Save";

                }
                bind();
            }
        }
        catch (Exception ex)
        {
            laMeg.Text = ex.Message.ToString();
        }
    }

    protected void gvDocMST_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        txtBankName.Text = gvBank.Rows[gvBank.SelectedIndex].Cells[0].Text;
        Label1.Text = gvBank.DataKeys[gvBank.SelectedIndex].Value.ToString();
        

        btSave.Text = "Update";
    }
    protected void bind()
    {
        mydal.grid_banksetup(gvBank);

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Label1.Text = null;
        laMeg.Text = null;
        clear();
    }
    protected void clear()
    {
        txtBankName.Text = null;
        btSave.Text = "Save";
    }
    protected void gvDocMST_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBank.PageIndex = e.NewPageIndex;
        //  bindwithcoll();
        bind();
    }
}
