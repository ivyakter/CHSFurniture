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
        string orderId = Request.QueryString["Id"].ToString();
        DataTable dt = mydal.GetOnlineOrderDetails(orderId);
        if (dt.Rows.Count > 0)
        {
            gvOrderDetails.DataSource = dt;
            gvOrderDetails.DataBind();
            lvlOrderId.Text = dt.Rows[0]["OrderId"].ToString();
            lvlName.Text = dt.Rows[0]["CustomerName"].ToString();
            lvlPhone.Text = dt.Rows[0]["CustomerPhone"].ToString();
            lvlDate.Text = dt.Rows[0]["Date"].ToString();
        }
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