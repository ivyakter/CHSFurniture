using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_JournalVoucherEdit : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                txtJournalNo.Text = Request.QueryString["ID"].ToString();
                GetTrType();
                LoadData();
                //txtGTotal.Text = sum.ToString();
            }
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
    private void SetInitialRow()
    {
        if (Request.QueryString["ID"] != null)
        {
            DataTable dt = mydal.getjournalVoucherUnfo(Request.QueryString["ID"]);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
        else
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
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");


                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = 0;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;


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

                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");
                    HiddenField hfItemName = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("hfchartofacc");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    //box4.Text = dt.Rows[i]["Column4"].ToString();
                    hfItemName.Value = dt.Rows[i]["Column1"].ToString();

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
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");
                    HiddenField hfchartofacc = (HiddenField)Gridview1.Rows[rowIndex].Cells[1].FindControl("hfchartofacc");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    //box4.Text = dt.Rows[i]["Column4"].ToString();
                    hfchartofacc.Value = dt.Rows[i]["Column1"].ToString();

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

    double total = 0;

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

            HiddenField hfchartofacc = (HiddenField)e.Row.FindControl("hfchartofacc");
            type.SelectedValue = hfchartofacc.Value;

            //var totalp = e.Row.FindControl("txtTotal") as TextBox;

            //if (totalp.Text != null)
            //{
            //    total += double.Parse(totalp.Text);
            //    txtGTotal.Text = total.ToString();
            //}

        }
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

    public void LoadData()
    {
        txtJournalNo.Text = Request.QueryString["ID"].ToString();
        DataTable dt = mydal.GetJournalValue(txtJournalNo.Text);

        ddlCashorCredit.SelectedItem.Text = dt.Rows[0]["reference"].ToString();
       // ddlChartofAccounts.SelectedValue = dt.Rows[0]["accountname"].ToString();
        //txtDebit.Text = dt.Rows[0]["debit"].ToString();
        //txtCredit.Text = dt.Rows[0]["credit"].ToString();
        //txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
        txtDate.Text = dt.Rows[0]["date"].ToString();

        //Gridview1.DataSource = dt;
        //Gridview1.DataBind();
  
        //journalrowid = dt.Rows[0]["JournalNo"].ToString();
        //DrCr, 
        //rownumber
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
        }
        else
        {
            string[] insert = new string[20];
            insert[0] = txtJournalNo.Text;
            //insert[1] = txtDebit.Text;
            //insert[2] = txtCredit.Text;

            //bool IsSuccess = mydal.insertSalesvoucher(insert);


            //DateTime DT = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime DT = DateTime.Parse(txtDate.Text);
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        string uid = Session["Uid"].ToString();

                        string rownumber = Gridview1.Rows[rowIndex].Cells[0].Text;
                        //string journalrowid = Gridview1.Rows[rowIndex].Cells[5].Text;
                        string journalrowid = "";
                        DropDownList ddlChartofAccounts = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlChartofAccounts");
                        TextBox txtDebit = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                        TextBox txtCredit = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox txtRemarks = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");



                        if (rownumber == "0")
                        {
                            bool Success = mydal.JournalEntriesLine(txtJournalNo.Text, ddlCashorCredit.SelectedItem.ToString(), uid, ddlChartofAccounts.SelectedValue, txtDebit.Text, txtCredit.Text, txtRemarks.Text, DT);
                        }
                        else
                        {

                            bool Success = mydal.UpdateJournalEntriesLine(txtJournalNo.Text, ddlCashorCredit.SelectedItem.ToString(), uid, ddlChartofAccounts.SelectedItem.Text, txtDebit.Text, txtCredit.Text, txtRemarks.Text, DT, journalrowid);

                            //bool Success = mydal.UpdateExpenceVoucherFromEdit(txtVoucher.Text, ddlItem.SelectedValue, txtdesc.Text, txtamount.Text, rownumber);
                        }

                        string DrCr = "0";

                        if (txtCredit.Text != "")
                        {
                            DrCr = "Cr";
                        }
                        else
                        {
                            DrCr = "Dr";
                        }
                        if (ddlCashorCredit.SelectedItem.Text == "Cash" && ddlChartofAccounts.SelectedValue == "Cash")
                        {
                            DrCr = "0";
                        }
                        bool Success1 = mydal.UpdateFromJournalentryRecivePaymentReport(txtJournalNo.Text, ddlCashorCredit.SelectedItem.ToString(), uid, "", ddlChartofAccounts.SelectedItem.Text, ddlChartofAccounts.SelectedValue, txtDebit.Text, txtCredit.Text, txtRemarks.Text, ddlChartofAccounts.SelectedValue, DT, DrCr, rownumber);

                        rowIndex++;
                    }

                    //bool updaterecivepayment = mydal.UpdatefromPaymentvoucheredit(insert);
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Update Journal Successfully!!!!');", true);
            //string scr = "<script>if(windows.confirem('Update Journal Successfully!!!!')){windows.location.href('JournalEntriesList.aspx')}</script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "confirm", scr, true);
            SetInitialRow();

        }

        Gridview1.DataSource = null;
        //Response.Redirect("ExpenseVoucherReport.aspx?Vid=" + txtJournalNo.Text, true);
    }

    protected void ddlChartofAccounts_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList ddlit = sender as DropDownList;
        GridViewRow gr = ddlit.NamingContainer as GridViewRow;

        DropDownList ddlChartofAccounts = (DropDownList)gr.Cells[1].FindControl("ddlChartofAccounts");
        DataTable dt = mydal.GetDistributorBydId(ddlChartofAccounts.SelectedValue);

        if (dt.Rows.Count > 0)
        {
            lbldiscode.Text = dt.Rows[0]["Dist_Id"].ToString();
        }
    }


    protected void txtDebit_TextChanged(object sender, EventArgs e)

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

                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    //TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box4.Text;
                    // dtCurrentTable.Rows[i - 1]["Column4"] = box5.Text;

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

    protected void txtCredit_TextChanged(object sender, EventArgs e)
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

                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDebit");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtRemarks");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;



                    dtCurrentTable.Rows[i - 1]["Column2"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box4.Text;
                    //dtCurrentTable.Rows[i - 1]["Column4"] = box5.Text;

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