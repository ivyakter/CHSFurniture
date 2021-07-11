using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ExpenseType : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(txtExpense.Text))
            {
                string uid = Session["Uid"].ToString();
                if (btSave.Text == "Save")
                {
                    bool success = mydal.save_ExpenseType(txtExpense.Text.Trim(), uid);
                    if (success == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);
                        txtExpense.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Saved !');", true);
                    }
                }
                else
                {
                    bool success = mydal.update_ExpenseType(txtExpense.Text.Trim(), uid, Label1.Text);
                    if (success == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated !');", true);
                        txtExpense.Text = "";
                        btSave.Text = "Save";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Updated !');", true);
                        btSave.Text = "Save";
                    }
                }
                bind();
            }
        }
        catch (Exception ex)
        {
            laMeg.Text = ex.Message.ToString();
        }
    }
    protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
    {

        txtExpense.Text = gvUnit.Rows[gvUnit.SelectedIndex].Cells[0].Text;
        Label1.Text = gvUnit.DataKeys[gvUnit.SelectedIndex].Value.ToString();


        btSave.Text = "Update";
    }
    protected void bind()
    {
        mydal.grid_ExpenseType(gvUnit);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Label1.Text = null;
        laMeg.Text = null;
        clear();
    }
    protected void clear()
    {
        txtExpense.Text = null;
        btSave.Text = "Save";
    }
    protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUnit.PageIndex = e.NewPageIndex;
        bind();
    }
}