using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_OnlineOrder_OrderList : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        DataTable dt = mydal.GetOnlineOrderList();
        gvOrderList.DataSource = dt;
        gvOrderList.DataBind();
    }
    
    protected void gvOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdDelete")
            {
                string Id = e.CommandArgument.ToString();
                bool detete = mydal.DeleteOnlineOrder(Id);
                if (detete)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Delete Successfully!!');", true);
                    LoadData();
                }
                
            }
        }
        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
    
}