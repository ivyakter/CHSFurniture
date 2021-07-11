using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sales_SalesInvoiceProduct : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            SetInitialRow();
            GetVoucher();
            LoadSuppliername();
            txtDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
    }
    public void GetVoucher()
    {
        DataTable dt = mydal.GetSalesVoucher();
        txtVoucherName.Text = "CHS/SV/" + DateTime.Now.Year + "/" + dt.Rows[0][0].ToString();
    }
    public void cleantext()
    {
        ddlClientname.SelectedItem.Text = "";    
        txtDate.Text = "";
        txtComment.Text = "";
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlproduct");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[6].FindControl("ddlModel"); 
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                    DropDownList box4 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlUnit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                    TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtTotal"); 

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;

                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlproduct");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[6].FindControl("ddlModel"); 
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                    DropDownList box4 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlUnit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                    TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtTotal");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();
                    box6.Text = dt.Rows[i]["Column6"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAdd_Click1(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        Gridview1.DeleteRow(index);
    }
    private void SetPreviousData1(DataTable dtCurrentTable)
    {
        int rowIndex = 0;
        if (dtCurrentTable != null)
        {
            DataTable dt = dtCurrentTable;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlproduct");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[6].FindControl("ddlModel"); 
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                    DropDownList box4 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlUnit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtPrice");                   
                    TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtTotal");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();
                    box6.Text = dt.Rows[i]["Column6"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "r")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Gridview1.DeleteRow(rowIndex);
        }
    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dtproduct = mydal.bindProduct();
            var ddlpro = (DropDownList)e.Row.FindControl("ddlproduct");
            ddlpro.DataSource = dtproduct;
            ddlpro.DataValueField = "ProId";
            ddlpro.DataTextField = "PName";
            ddlpro.DataBind();
            ddlpro.Items.Insert(0, new ListItem("--Select--", "0"));

            DataTable dtmodel = mydal.bindModel();
            var model = (DropDownList)e.Row.FindControl("ddlModel");
            model.DataSource = dtmodel;
            model.DataValueField = "ModelId";
            model.DataTextField = "ModelName";
            model.DataBind();
            model.Items.Insert(0, new ListItem("--Select--", "0")); 

            DataTable dtu = mydal.bindUnit();
            var unit = (DropDownList)e.Row.FindControl("ddlUnit");
            unit.DataSource = dtu;
            unit.DataValueField = "UnitName";
            unit.DataTextField = "UnitName";
            unit.DataBind();
            unit.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {
            bool IsSuccess = mydal.InsertSalesVoucher(txtVoucherName.Text, ddlClientname.SelectedValue, ddlClientname.SelectedItem.Text, txtDate.Text, txtComment.Text, lbltotal.Text);

            if (IsSuccess == true)
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {                            
                            DropDownList ddlproduct = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlproduct");
                            DropDownList ddlModel = (DropDownList)Gridview1.Rows[rowIndex].Cells[6].FindControl("ddlModel"); 
                            TextBox txtQuantity = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtQuantity");
                            DropDownList ddlUnit = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlUnit");
                            TextBox txtPrice = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                            TextBox txtTotal = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtTotal");
                            txtAllTotal.Text = txtTotal.Text;
                            string Itemname = "Product";

                            bool Success = mydal.InsertSalesItem(ddlClientname.SelectedValue, txtVoucherName.Text, ddlproduct.SelectedItem.ToString(),ddlModel.SelectedItem.ToString(), txtPrice.Text, ddlUnit.SelectedItem.Text, txtQuantity.Text, txtTotal.Text, Itemname,txtDate.Text);

                            bool InsertRecive_PaymentFromSales = mydal.InsertRecive_PaymentFromSales(ddlClientname.SelectedValue, ddlproduct.SelectedItem.Text,ddlClientname.SelectedItem.Text, txtVoucherName.Text, txtDate.Text, txtAllTotal.Text);

                            DataTable searchproductinstock = mydal.searchproductinstockforProduct(ddlproduct.SelectedItem.Text);

                            if (searchproductinstock.Rows.Count > 0)
                            {
                                DataTable searchPriceandqtyofproduct = mydal.searchPriceandqtyofproductforProduct(ddlproduct.SelectedItem.Text);
                                string qty = searchPriceandqtyofproduct.Rows[0]["Qty"].ToString();

                                double UpdatedQty = double.Parse(qty) - double.Parse(txtQuantity.Text);

                                bool Updateproduct = mydal.UpdateExistingProducthistory(ddlproduct.SelectedItem.Text, UpdatedQty, DateTime.Now);
                            }
                            else
                            {

                                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('There Is no Product In This Name!!!!');", true);
                            }                     
                            rowIndex++;
                        }
                    }
                }            

                Response.Redirect("../Report/SalesInvoiceReport.aspx?id=" + txtVoucherName.Text, true);

                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Save Information Successfully!!!!');", true);
                SetInitialRow();
                cleantext();
                Gridview1.DataSource = null;
                GetVoucher();
            }
            SetInitialRow();
            cleantext();
            Gridview1.DataSource = null;
            GetVoucher();
        }
    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        TextBox txtqty = sender as TextBox;
        GridViewRow gr = txtqty.NamingContainer as GridViewRow;

        //TextBox txtQtyDramorBag = (TextBox)gr.Cells[4].FindControl("txtQtyDramorBag");
        TextBox txtQuantity = (TextBox)gr.Cells[5].FindControl("txtQuantity");
        TextBox txtPrice = (TextBox)gr.Cells[3].FindControl("txtPrice");
        TextBox txtTotal = (TextBox)gr.Cells[6].FindControl("txtTotal");
        txtTotal.Text = ((Convert.ToInt32(txtPrice.Text == "" ? "0" : txtPrice.Text) * Convert.ToInt32(txtQuantity.Text == "" ? "0" : txtQuantity.Text)).ToString());
        lbltotal.Text = txtTotal.Text;
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        Button btndel = sender as Button;
        GridViewRow gr = btndel.NamingContainer as GridViewRow;
        string rownumber = gr.Cells[0].Text;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
        {
            DataRow dr = dtCurrentTable.Rows[i];
            if (dtCurrentTable.Rows[i]["RowNumber"].ToString() == rownumber)
                dr.Delete();
        }
        ViewState["CurrentTable"] = dtCurrentTable;
        Gridview1.DataSource = dtCurrentTable;
        Gridview1.DataBind();
        SetPreviousData1(dtCurrentTable);
    }

    protected void LoadSuppliername()
    {

        DataTable dt = mydal.GetAccountsReciveable();
        ddlClientname.DataSource = dt;
        ddlClientname.DataTextField = "AccName";
        ddlClientname.DataValueField = "AccCode";
        ddlClientname.DataBind();
        ddlClientname.Items.Insert(0, new ListItem("-Select-", "0"));

    }   
}