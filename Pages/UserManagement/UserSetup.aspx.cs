using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_UserManagement_UserSetup : System.Web.UI.Page
{
    dalUser objUser = new dalUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonMethod.LoadDropdown(ddlRole, "RoleSetup", 1, 0);
            BindData();
        }
    }
    int Id
    {
        set { ViewState["Id"] = value; }
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["Id"]);
            }
            catch
            {
                return 0;
            }
        }
    }

    protected void BindData()
    {
        DataTable dt = objUser.GetUsers();
        if(dt.Rows.Count>0)
        {
            rpt.DataSource = dt;
            rpt.DataBind();
        }
        else
        {
            rpt.DataSource = null;
            rpt.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Id = objUser.CreateUsers(tbxUserName.Text, Convert.ToInt32(ddlRole.SelectedValue), tbxpassword.Text, tbxEmail.Text, "", DateTime.Now,0);
        if(Id>0)
        {
            MessageController.Show(MessageCode.SaveSucceeded, MessageType.Confirmation, Page);
        }
        else
        {
            MessageController.Show("This user name already exists. Please try another.", MessageType.Error, Page);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {

    }
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {

    }
}