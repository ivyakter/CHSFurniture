using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_ReciveVoucherEdit : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetInitialRow();

            LoadVoucherno();
        }
    }

    public void cleantext()
    {
        //ddlclientname.SelectedItem.Text = "";
        //txtSupplierName.Text = "";
        txtAddress.Text = "";
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
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
   
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;
       
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
                                               
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");                
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");
                 

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
               
                   

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
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                  
                   

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
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                    DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                    HiddenField box4 = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("TranssactionTypename");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                  
                   
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
            DataTable Dt = mydal.GetTRType();
            var ddlIncomeType = (DropDownList)e.Row.FindControl("ddlIncomeType");

            ddlIncomeType.DataSource = Dt;
            ddlIncomeType.DataTextField = "AccName";
            ddlIncomeType.DataValueField = "AccCode";
            ddlIncomeType.DataBind();
            ddlIncomeType.Items.Insert(0, "--Select--");

            HiddenField TranssactionTypename = (HiddenField)e.Row.FindControl("TranssactionTypename");
            ddlIncomeType.SelectedItem.Text = TranssactionTypename.Value;
           

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

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList ddlIncomeType = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlIncomeType");
                        
                        TextBox txtpayment = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtamount");
                        TextBox txtdescription = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtdescription");
                        HiddenField DbRownumber = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("DbRownumber");

                        string rownumber = DbRownumber.Value;
                        lblratesum.Text = txtpayment.Text;


                        bool UpdateRecivevoucher = mydal.UpdateRecivevoucher(ddlIncomeType.SelectedItem.ToString(), ddlvoucherno.SelectedItem.Text, lblratesum.Text);
                        if (UpdateRecivevoucher == true)
                        {
                            bool UpdateIncomeVoucher = mydal.UpdateIncomeVoucher(ddlIncomeType.SelectedItem.ToString(), ddlvoucherno.SelectedItem.Text, txtpayment.Text, txtdescription.Text, rownumber);

                            bool UpdateIncomeVoucherList = mydal.UpdateIncomeVoucherList(ddlIncomeType.SelectedItem.ToString(), ddlvoucherno.SelectedItem.Text, txtpayment.Text, txtdescription.Text, rownumber);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Something Went Wrong!!!!');", true);
                        }


                        //bool Update = mydal.update_Bulk(Convert.ToInt32(ddlItem.SelectedValue), ddlItem.SelectedItem.ToString(), double.Parse(txtTotal.Text), Convert.ToInt32(ddlItem.SelectedValue), "Stock");                       
                        rowIndex++;
                    }
                }
            }

            bool InsertIncomeVoucherList = mydal.UpdateIncomeVoucherList(ddlvoucherno.SelectedItem.Text, txtComment.Text, txtDate.Text, lblratesum.Text);

            //Session["VoucherNo"] = txtVoucherName.Text;
            //string strconfirm = "<script>if(window.confirm('Payment Successfully!!!!')){window.location.href='../Report/PaymentReceiveReport.aspx'}</script>";
            //ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
            string strconfirm = "<script>if(window.confirm('Payment Successfully!!!!')){window.location.href='ViewReceiveVoucher.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
            
            SetInitialRow();
            cleantext();
            Gridview1.DataSource = null;
            cleantext();
           

        }
    }

   

    protected void delete_Click(object sender, EventArgs e)
    {

        //Button btndel = sender as Button;
        //GridViewRow gr = btndel.NamingContainer as GridViewRow;
        //string rownumber = gr.Cells[0].Text;

        //DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
        //{
        //    DataRow dr = dtCurrentTable.Rows[i];
        //    if (dtCurrentTable.Rows[i]["RowNumber"].ToString() == rownumber)
        //        dr.Delete();
        //}
        //ViewState["CurrentTable"] = dtCurrentTable;
        //Gridview1.DataSource = dtCurrentTable;
        //Gridview1.DataBind();
        //SetPreviousData1(dtCurrentTable);

        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            string VoucherNo = ddlvoucherno.SelectedValue;

            bool delete = mydal.IncomeVoucherDeletebyvoucherfromexpence(VoucherNo);
            bool deleteExpenselist = mydal.IncomeVoucherListDeletebyvoucherfromexpenceList(VoucherNo);

            bool deleteRecivePayment = mydal.PaymentVoucherDeletebyvoucherfromRecivePayment(VoucherNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadVoucherno()
    {
        DataTable getvoucherbyclient = mydal.getAllVouchername();
        if (getvoucherbyclient.Rows.Count > 0)
        {
            ddlvoucherno.DataSource = getvoucherbyclient;
            ddlvoucherno.DataTextField = "VoucherNo";
            ddlvoucherno.DataValueField = "VoucherNo";
            ddlvoucherno.DataBind();
            ddlvoucherno.Items.Insert(0, new ListItem("-Select-", "0"));
        }

        if (Request.QueryString["id"] != "")
        {
            ddlvoucherno.SelectedValue = Request.QueryString["id"];
            ddlvoucherno.SelectedItem.Text = Request.QueryString["id"];
            ddlvoucherno_SelectedIndexChanged(null, null);
        }
    }
    
    protected void ddlvoucherno_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = mydal.GetRecivedetailsbyclient(ddlvoucherno.SelectedValue);

      
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            txtDate.Text = dt.Rows[0]["Date"].ToString();
            txtComment.Text = dt.Rows[0]["Comment"].ToString();

        }
  
    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        double sum = 0;
        for (int index = 0; index < Gridview1.Rows.Count; index++)
        {
            sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtamount") as TextBox).Text);
        }
        lblratesum.Text= sum.ToString(); ;
    }


}

   
