using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_JournalEntries : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            JournalNo();          
            SetInitialRow();            
            GetTrType();
            txtDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }
    }
    public void GetTrType()
    {
        DataTable Dt = mydal.GetTRType();
        ddlCashorCredit.DataSource = Dt;
        ddlCashorCredit.DataTextField = "AccName";
        ddlCashorCredit.DataValueField = "AccCode";
        ddlCashorCredit.DataBind();
        ddlCashorCredit.Items.Insert(0, "--Select--");
    }
    public void GetBank()
    {
        DataTable dt = mydal.GetBank();
        ddlBank.DataSource = dt;
        ddlBank.DataTextField = "AccName";
        ddlBank.DataValueField = "AccCode";
        ddlBank.DataBind();
        ddlBank.Items.Insert(0, "--Select Bank Name--");
    }

    protected void ddlCashorCredit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCashorCredit.SelectedItem.ToString() == "Bank")
        {
            ddlBank.Visible = true;
            label3.Visible = true;
            txtCheck.Visible = true;
            label8.Visible = true;

        }
        else if (ddlCashorCredit.SelectedItem.ToString() == "Cash")
        {
            label8.Visible = false;
            ddlBank.Visible = false;
            label3.Visible = false;
            txtCheck.Visible = false;
        }
        else
        {
            label8.Visible = false;
            ddlBank.Visible = false;
            label3.Visible = false;
            txtCheck.Visible = false;
        }
        DataTable dtcahsCr = mydal.GetCahBalanceCr(ddlCashorCredit.SelectedItem.ToString());
        DataTable dtcahsDr = mydal.GetCahBalanceDr(ddlCashorCredit.SelectedItem.ToString());

        double cashcr = Convert.ToDouble(dtcahsCr.Rows[0][0].ToString());
        double cashdr = Convert.ToDouble(dtcahsDr.Rows[0][0].ToString());

        lblBablance.Text = (cashdr - cashcr).ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (txtDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {
            DateTime DT = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);     
              

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                        //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                        //dtotal = dtotal + Convert.ToDouble(box3.Text);
                        //ctotal = ctotal + Convert.ToDouble(box4.Text);
                        string uid = Session["Uid"].ToString();

                        bool Success = mydal.JournalEntriesLine(txtJournalNo.Text, ddlCashorCredit.SelectedItem.ToString(), uid, box1.SelectedItem.ToString(), box3.Text, box4.Text, box5.Text, DT);
                        string DrCr = "0";
                        
                        if (box4.Text != "")
                        {
                            DrCr = "Cr";
                        }
                        else
                        {
                            DrCr = "Dr";
                        }
                        if (box1.SelectedItem.Text == "Cash")
                        {
                            DrCr = "0";
                        }
                        bool Success1 = mydal.RecivePaymentReport(txtJournalNo.Text, ddlCashorCredit.SelectedItem.ToString(), uid, box1.SelectedItem.ToString(), box1.SelectedItem.ToString(), box1.SelectedValue, box3.Text, box4.Text, box5.Text, box1.SelectedValue, DT, DrCr);

                        rowIndex++;
                    }
                }
            }
            // }
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Save Information Successfully!!!!');", true);
            SetInitialRow();
            cleantext();
        }
        cleantext();
        Gridview1.DataSource = null;
        // Response.Redirect("IncomeVoucherReport.aspx?id=" + txtVoucherName.Text, true);
    }

    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {

    }    
    public void cleantext()
    {

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
        //dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        //dr["Column5"] = string.Empty;
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
                    //extract the TextBox values
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                    //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;

                    //dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                    dtCurrentTable.Rows[i - 1]["Column2"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box5.Text;

                    // dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;

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
        //Set Previous Data on Postbacks
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
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                    //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    //box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column2"].ToString();
                    box4.Text = dt.Rows[i]["Column3"].ToString();
                    box5.Text = dt.Rows[i]["Column4"].ToString();
                    // box4.Text = dt.Rows[i]["Column4"].ToString();

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
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                    //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    //box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column2"].ToString();
                    box4.Text = dt.Rows[i]["Column3"].ToString();
                    box5.Text = dt.Rows[i]["Column4"].ToString();


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
    public void JournalNo()
    {
        DataTable n = mydal.GetJournalNo();
        txtJournalNo.Text = "JOUR-" + n.Rows[0][0].ToString();
    }

    double sum = 0;
    double sum2 = 0;
    double total1 = 0;
    double total2 = 0;
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = mydal.getChartofAccounts();
            var type = (DropDownList)e.Row.FindControl("ddlChartofAccounts");
            type.DataSource = dt;
            type.DataTextField = "AccName";
            type.DataValueField = "AccCode";
            type.DataBind();
            type.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtCredit = e.Row.FindControl("txtCredit") as TextBox;
            var txtDebit = e.Row.FindControl("txtDebit") as TextBox;

            if (txtDebit != null  && txtCredit != null)
            {
                total1 += int.Parse(txtCredit.Text);
                total2 += int.Parse(txtDebit.Text);
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblCreditTotal = (Label)e.Row.FindControl("lblCreditTotal");
            Label lblDebitTotal = (Label)e.Row.FindControl("lblDebitTotal");

            lblCreditTotal.Text = total1.ToString();
            lblDebitTotal.Text = total2.ToString();
        }
    }

    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        double sum = 0;
        for (int index = 0; index < Gridview1.Rows.Count; index++)
        {
            sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtAmount") as TextBox).Text);
        }
        //txtTotal.Text = sum.ToString();
    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetBankBranch();
    }

    protected void ddlChartofAccounts_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList ddlit = sender as DropDownList;
        GridViewRow gr = ddlit.NamingContainer as GridViewRow;

        DropDownList ddlChartofAccounts = (DropDownList)gr.Cells[1].FindControl("ddlChartofAccounts");
        TextBox txtDebit = (TextBox)gr.Cells[2].FindControl("txtDebit");
        //DataTable dt = mydal.GetDistributorBydId(ddlChartofAccounts.SelectedValue);

        //if (dt.Rows.Count > 0)
        //{
        //    lbldiscode.Text = dt.Rows[0]["Dist_Id"].ToString();
        //}
        txtDebit.Focus();
    }


    protected void txtDebit_TextChanged(object sender, EventArgs e)
    {
        if (chkDoubleEntry.Checked)
        {
         
        }
        else
        {
            double sum = 0;
            double sum2 = 0;
            for (int index = 0; index < Gridview1.Rows.Count; index++)
            {
                //sum += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtDebit") as TextBox).Text);
                //sum2 += Convert.ToDouble((Gridview1.Rows[index].FindControl("txtCredit") as TextBox).Text);
                TextBox txtdebit = (Gridview1.Rows[index].FindControl("txtDebit") as TextBox);
                TextBox txtCredit = (Gridview1.Rows[index].FindControl("txtCredit") as TextBox);

                sum2 += Convert.ToDouble(txtCredit.Text == "" ? "0" : txtCredit.Text);
                sum += Convert.ToDouble(txtdebit.Text == "" ? "0" : txtdebit.Text);

            }

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                        //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box5.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }

            SetPreviousData();

            if (sum > sum2)
            {
                TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                box4.Text = sum.ToString();

                box3.Enabled = false;
                lblcredittotal.Text = sum.ToString();

            }
            else
            {
                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");

                double equal = sum2 - sum;
                box3.Text = equal.ToString();
                //txtCreditmain.Enabled = false;
            }

            lbldebittotal.Text = sum.ToString();

            if (double.Parse(lbldebittotal.Text) == double.Parse(lblcredittotal.Text))
            {
                btnSave.Enabled = true;

            }
            else
            {

                btnSave.Enabled = false;
            }

            int rownumber = 0;
            TextBox txtCreditmain = (((System.Web.UI.WebControls.TextBox)(Gridview1.Rows[rownumber].Cells[3].FindControl("txtCredit"))));
            txtCreditmain.Enabled = false;
        }
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
    protected void txtCredit_TextChanged(object sender, EventArgs e)
    {
        if (chkDoubleEntry.Checked)
        {
  
        }
        else
        {
            double sum = 0;
            double sum2 = 0;

            for (int index = 0; index < Gridview1.Rows.Count; index++)
            {
                TextBox txtdebit = (Gridview1.Rows[index].FindControl("txtDebit") as TextBox);
                TextBox txtCredit = (Gridview1.Rows[index].FindControl("txtCredit") as TextBox);
                sum2 += Convert.ToDouble(txtCredit.Text == "" ? "0" : txtCredit.Text);
                sum += Convert.ToDouble(txtdebit.Text == "" ? "0" : txtdebit.Text);
            }
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                        //DropDownList box2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlClient");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;

                        //dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Column2"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box5.Text;

                        // dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }

            //Set Previous Data on Postbacks

            SetPreviousData();

            if (sum > sum2 || sum == sum2)
            {
                TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");


                box3.Enabled = false;
                double equal = sum - sum2;
                box4.Text = equal.ToString();

                lbldebittotal.Text = sum.ToString();
                lblcredittotal.Text = (sum2 + equal).ToString();


                if (double.Parse(lbldebittotal.Text) == double.Parse(lblcredittotal.Text))
                {
                    btnSave.Enabled = true;

                }
                else
                {

                    btnSave.Enabled = false;
                }
            }
            else
            {
                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");

                double equal = sum2 - sum;
                box3.Text = equal.ToString();

            }

            int rownumber = 0;
            TextBox txtDebitmain = (((System.Web.UI.WebControls.TextBox)(Gridview1.Rows[rownumber].Cells[2].FindControl("txtDebit"))));
            txtDebitmain.Enabled = false;
        }
    }
}