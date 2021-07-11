using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_Role_MST : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(txtRoleName.Text))
            {
                string uid = Session["Uid"].ToString();
                //string uid = "";
                if (btSave.Text == "Save")
                {
                    bool success = mydal.save_rolemst(txtRoleName.Text.Trim(), txtRoleDesc.Text.Trim(), uid);
                    if (success == true)
                    {
                        clear();
                        //laMeg.Text = "Save Successful";                        
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);
                    }
                    else
                        //laMeg.Text = "Not Saved !!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Saved !');", true);
                }
                else
                {
                    bool success = mydal.update_rolemst(txtRoleName.Text.Trim(), txtRoleDesc.Text.Trim(), uid, Label1.Text);
                    if (success == true)
                    {
                        clear();
                        //laMeg.Text = "Update Successful";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Update Successfully !');", true);
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

    protected void gvRoleMST_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        txtRoleName.Text = gvRoleMST.Rows[gvRoleMST.SelectedIndex].Cells[0].Text;
        txtRoleDesc.Text = gvRoleMST.Rows[gvRoleMST.SelectedIndex].Cells[1].Text;
        Label1.Text = gvRoleMST.DataKeys[gvRoleMST.SelectedIndex].Value.ToString();
        
        btSave.Text = "Update";
    }
    protected void bind()
    {
        mydal.grid_rolemst(gvRoleMST);

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
       clear();
    }
    protected void clear()
    {
        txtRoleDesc.Text = "";
        txtRoleName.Text = "";
        Label1.Text = "";
        laMeg.Text = "";
        btSave.Text = "Save";
    }
    protected void gvRoleMST_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoleMST.PageIndex = e.NewPageIndex;
        //  bindwithcoll();
        bind();
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[0].FindControl("lblid");

            mydal.deleteRole(lblid.Text);

            string strconfirm = "<script>if(window.confirm('Delete Ok')){window.location.href='frm_Role_MST.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
        }
        catch (Exception ex)
        { }
        bind();
    }
}
