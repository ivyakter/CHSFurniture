using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_SalarySheet : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialRow();
          
        }
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
      
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
      
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
                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddllabour");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtMonthFor");  
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtbasicsalary");                  
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayment");                  
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtdue");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;                 
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;              
                    dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
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


                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddllabour");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtMonthFor");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtbasicsalary");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayment");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtdue");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();                  
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

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

                    DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddllabour");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtMonthFor");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtbasicsalary");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtpayment");
                    TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtdue");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

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

        if (e.CommandName.Equals("Pay"))
        {
            if (txtDateto.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please select Date!!');", true);
            }
            else
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);            
                GridViewRow row = Gridview1.Rows[rowIndex];
               
                string lbldate = txtDateto.Text;
                DropDownList ddlLabourName = row.FindControl("ddllabour") as DropDownList;
                string txtAmount = (row.FindControl("txtpayment") as TextBox).Text;              
                string txtDueAmount = (row.FindControl("txtdue") as TextBox).Text;
                string txtMonthFor = (row.FindControl("txtMonthFor") as TextBox).Text;
                string Basicsalary = (row.FindControl("txtbasicsalary") as TextBox).Text;

                DataTable SamedateCheck = mydal.SamedateCheck(ddlLabourName.SelectedItem.Text, ddlLabourName.SelectedValue, lbldate);

                if (SamedateCheck.Rows.Count > 0)
                {
                    string ID = SamedateCheck.Rows[0]["ID"].ToString();

                    bool Update = mydal.UpdateAmountForlabourBySelect(lbldate, ddlLabourName.SelectedItem.Text, txtAmount, txtDueAmount, ddlLabourName.SelectedValue, ID,txtMonthFor);
                    if (Update == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Update Successfull');", true);
                    }
                }
                else
                {
                    bool Save = mydal.SaveAmountForlabourBySelect(lbldate, ddlLabourName.SelectedItem.Text, txtAmount, txtDueAmount, ddlLabourName.SelectedValue, Basicsalary,txtMonthFor);
                    if (Save == true)
                    {
                        bool InsertRecive_PaymentFromSales = mydal.InsertRecive_PaymentFromSalary(ddlLabourName.SelectedValue, ddlLabourName.SelectedValue, lbldate, txtAmount);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Submit Successfull');", true);
                    }
                }
            }


        }

    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var bassalary = (TextBox)e.Row.FindControl("txtbasicsalary");
             DataTable dt = mydal.GetEmployeeId();
            var type = (DropDownList)e.Row.FindControl("ddllabour");
            type.DataSource = dt;
            type.DataValueField = "OfficerId";
            type.DataTextField = "Name";
            type.DataBind();
            type.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    public void cleantext()
    {
       // ddlProjectname.SelectedItem.Text = "";
        txtDateto.Text = "";
        txtComment.Text = "";
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

    protected void ddllabour_SelectedIndexChanged(object sender, EventArgs e)
    {
        double due = 0;
        DropDownList txtqty = sender as DropDownList;
        GridViewRow gr = txtqty.NamingContainer as GridViewRow;
        TextBox bassalary = (TextBox)gr.Cells[1].FindControl("txtbasicsalary");
        DropDownList labour = (DropDownList)gr.Cells[0].FindControl("ddllabour");
        Label Dueshow = (Label)gr.Cells[0].FindControl("lbldue");
     
        DataTable getbasicsalary = mydal.GetBasicSalary(labour.SelectedValue);
        if (getbasicsalary.Rows.Count > 0)
        {
            string basicsalary = getbasicsalary.Rows[0]["BasicSalary"].ToString();         
            bassalary.Text = basicsalary;      
        }

        //DataTable GetDueAmount = mydal.GetDueSalary(labour.SelectedValue);
        //if (GetDueAmount.Rows.Count > 0)
        //{
        //    string dueamountbylabour = GetDueAmount.Rows[0]["Due"].ToString();

        //    if (dueamountbylabour == "")
        //    {
        //        dueamountbylabour = "0";
        //    }
        //    Dueshow.Text = dueamountbylabour;

        //}
    }

    protected void txtpayment_TextChanged(object sender, EventArgs e)
    {
        TextBox txtpayment = sender as TextBox;
        GridViewRow gr = txtpayment.NamingContainer as GridViewRow;
        Label Due = (Label)gr.Cells[2].FindControl("lbldue");
        TextBox txtamount = (TextBox)gr.Cells[3].FindControl("txtpayment");
        TextBox txtbasicsalary = (TextBox)gr.Cells[1].FindControl("txtbasicsalary");
        TextBox txtTotalDue = (TextBox)gr.Cells[4].FindControl("txtdue");

        int basic = Convert.ToInt32(txtbasicsalary.Text == "" ? "0" : txtbasicsalary.Text);
        int payment = Convert.ToInt32(txtamount.Text == "" ? "0" : txtamount.Text);

        txtTotalDue.Text = (basic - payment).ToString();
      
    }
}