using System;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
public partial class frm_BankBranchSetup : System.Web.UI.Page
{
    DAL mydal = new DAL();
    
    //string uid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        }
     
     
        if (!IsPostBack)
        {
            mydal.dropdown(ddBankname, "TBL_BANK_NAME ", 1, 0 , "BANK_NAME");           
             gvbind();
        }
   }

    private void gvbind()
    {
        DataTable dt = mydal.GetBankBranch();
        gvBranchSetup.DataSource = dt;
        gvBranchSetup.DataBind();
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        string uid = Session["Uid"].ToString();

        try
        {
            if (btSave.Text == "Save")
            {
               mydal.save_Branchsetup(ddBankname.SelectedValue.ToString(), txtBranchName.Text, uid);
                //laMeg.Text = "Saved !";
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);
               

            }
            else
            {
                bool success = mydal.update_Branchsetup(ddBankname.SelectedValue.Trim(), txtBranchName.Text, uid, Label1.Text);
                if (success == true)
                    //laMeg.Text = "Updated Successfully";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Updated !');", true);
                else
                    //laMeg.Text = "Not Updated !!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Not Updated !');", true);
                btSave.Text = "Save";

            }
            
        clear();

        }

        catch (Exception ex)
        {
            laMeg.Text = ex.Message.ToString();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //laMeg.Text = gvAreaSetup.SelectedDataKey["ID"].ToString();
        txtBranchName.Text = gvBranchSetup.Rows[gvBranchSetup.SelectedIndex].Cells[0].Text;
        ddBankname.SelectedValue = gvBranchSetup.SelectedDataKey["BANK_ID"].ToString();
        Label1.Text = gvBranchSetup.DataKeys[gvBranchSetup.SelectedIndex].Value.ToString();
        
        btSave.Text = "Update";
        
    }
   
    protected void btnClear_Click(object sender, EventArgs e)
    {
        laMeg.Text = null;
        Label1.Text = "";
        clear();
    }
    protected void clear()
    {
        ddBankname.SelectedIndex = 0;
        txtBranchName.Text = "";
        btSave.Text = "Save";
        gvbind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBranchSetup.PageIndex = e.NewPageIndex;
        gvbind();
      
    }

    protected void AllDDSelectedIndexChanged(object sender, EventArgs e)
    {
        gvbind();
    }

   
}
