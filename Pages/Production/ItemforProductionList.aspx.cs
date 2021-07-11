using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Production_ItemforProductionList : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getVendorList();
        }
    }
    protected void getVendorList()
    {
        DataTable dt = mydal.getAllOrdersAccList();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[2].FindControl("lblid");

            bool delete = mydal.OrderListDeletebyid(lblid.Text);
            getVendorList();
        }
        catch (Exception ex)
        { }

    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Deliver"))
        {
            if (txtDateto.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
            }
            else
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv.Rows[rowIndex];

                string lbldate = txtDateto.Text;

                string OrderID = (row.FindControl("lblOrderID") as Label).Text;

                bool UpdateOrderTable = mydal.UpdateOrderListSatatus(lbldate, OrderID);


                if (UpdateOrderTable == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Update Successfull');", true);
                    getVendorList();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something Wrong');", true);

                }

            }


        }
    }
}