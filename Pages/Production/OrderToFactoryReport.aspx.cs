using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Inventory_OrderToFactoryReport : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getVendorList();
            GetInvoiceNo();
        }
    }
    protected void getVendorList()
    {
        DataTable dt = mydal.getAllOrdersFromfactory();
        if (dt.Rows.Count > 0)
        {
            gv.DataSource = dt;
            gv.DataBind();

        }
        else
        {
           //ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something Wrong');", true);

        }

    }

    public void GetInvoiceNo()
    {
        DataTable n = mydal.GetFactoryorderInvoiceNo();
        txtinvoiceno.Text =n.Rows[0]["ID"].ToString();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[2].FindControl("lblid");

            bool delete = mydal.OrderDeletebyid(lblid.Text);
            getVendorList();
        }
        catch (Exception ex)
        { }

    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
            //if (txtDateto.Text == "")
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
            //}
            //else
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = gv.Rows[rowIndex];

            //    string lbldate = txtDateto.Text;

            //    string OrderID = (row.FindControl("lblOrderID") as Label).Text;

            //    bool UpdateOrderTable = mydal.UpdateOrderSatatus(lbldate, OrderID);


            //    if (UpdateOrderTable == true)
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Update Successfull');", true);
            //    }

            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something Wrong');", true);

            //    }

            //}
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDateto.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {

            foreach (GridViewRow GVorder in gv.Rows)
            {
                CheckBox chkyearly = GVorder.Cells[3].FindControl("chkinsertforyearly") as CheckBox;
                if (chkyearly.Checked)
                {
                    string OrderID = (GVorder.Cells[0].FindControl("lblid") as Label).Text;
                    string lblModelID = (GVorder.Cells[0].FindControl("lblModelID") as Label).Text;
                    string lblProductID = (GVorder.Cells[0].FindControl("lblProductID") as Label).Text;
                    string lblProductName = (GVorder.Cells[0].FindControl("lblProductName") as Label).Text;
                    string lblQuantity = (GVorder.Cells[0].FindControl("lblQuantity") as Label).Text;
                    string lblUnit = (GVorder.Cells[0].FindControl("lblUnit") as Label).Text;
                    string invoiceno = txtinvoiceno.Text;
                    string lbldate = txtDateto.Text;

                    bool UpdateOrderTable = mydal.UpdateOrderSatatus(lbldate, OrderID, invoiceno);

                    if (UpdateOrderTable == true)
                    {

                        DataTable searchproductinstock = mydal.Priceandqtyof(lblProductID, lblModelID);      
                        if (searchproductinstock.Rows.Count > 0)
                        {
                            DataTable searchPriceandqtyofproduct = mydal.PriceandqtyofProduction(lblProductID, lblModelID);
                            string qty = searchPriceandqtyofproduct.Rows[0]["Qty"].ToString();

                            double UpdatedQty = double.Parse(qty) + double.Parse(lblQuantity);
                            //string price = searchPriceandqtyofproduct.Rows[0]["PresentPrice"].ToString();

                            bool Updateproduct = mydal.UpdateExistingProductformProduction(lblProductID, lblModelID, UpdatedQty, DateTime.Now);
                        }
                        else
                        {
                            bool stockbulk = mydal.FinishedGoodStockfromProduction(lblProductID, lblProductName, lblModelID, lblQuantity, txtDateto.Text, lblUnit);
                        }                        
                         Response.Redirect("OrderToFactoryReport.aspx");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Update Successfull');", true);
                   
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something Wrong');", true);

                    }
                }

            }            
        }
    }
    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = mydal.getAllOrdersFromByOrderId(txtOrderNo.Text);
        if (dt.Rows.Count > 0)
        {
            gv.DataSource = dt;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = null;
            gv.DataBind();
        }
    }
}