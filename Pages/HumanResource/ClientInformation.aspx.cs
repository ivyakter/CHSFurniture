using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_HumanResource_Configuration_ClientInformation : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {       
            ClientId();
            LoadGrid();
            ChartofAccount();
        }
    }
    public void ClientId()
    {
        DataTable dt = mydal.GetClientId();
        txtClientId.Text = "CHS/CL/" + dt.Rows[0][0].ToString();
    }
    public void ChartofAccount()
    {
        DataTable dt = mydal.getChartofAccounts();
        ddlChartofAccounts.DataSource = dt;
        ddlChartofAccounts.DataTextField = "AccName";
        ddlChartofAccounts.DataValueField = "AccCode";
        ddlChartofAccounts.DataBind();
        ddlChartofAccounts.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string [] insert = new string[20];

        insert[0] = txtClientId.Text;
        insert[1] = txtClientName.Text;
        insert[2] = txtContactNo.Text;
        insert[3] = txtAddress.Text;      
        insert[6] = ddlChartofAccounts.SelectedValue;
        insert[7] = txtBusinessName.Text;

        bool Save = mydal.InsertClient(insert);

        if (Save == true)
        {
            string strconfirm = "<script>if(window.confirm('Client Information Saved')){window.location.href='ClientInformation.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
            LoadGrid();
            ClientId();            
            txtClientName.Text = "";
            txtContactNo.Text = "";
            txtAddress.Text = "";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
        }
      
    }
    public void LoadGrid()
    {
      
        DataTable dt = new DataTable();
        try
        {
            dt = mydal.LoadEmployee();
            if (dt.Rows.Count > 0)
            {
                gvemployee.DataSource = dt;
                gvemployee.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvemployee.DataSource = dt;
                gvemployee.DataBind();
                gvemployee.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void gvemployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvemployee.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void gvemployee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdDelete")
            {
                string Id = e.CommandArgument.ToString();
               
                bool detete =mydal.DeleteEmp(Id);
                
                LoadGrid();
            }
           
                LoadGrid();
           
        }
        catch (Exception ex)
        {
           
        }
    }
    protected void gvemployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
        try
        {
            string Id = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtId")).Text;

            string ClientId = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtClientId")).Text;
            string ClientName = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtClientName")).Text;
            string ContactNo = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtContactNo")).Text;           
            string Address = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtAddress")).Text;
            string BusinessName = ((TextBox)gvemployee.Rows[e.RowIndex].FindControl("txtBusinessName")).Text;

            bool update = mydal.EditEmployee(ClientId, ClientName, ContactNo, Address, BusinessName);

            gvemployee.EditIndex = -1;
            LoadGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void gvemployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvemployee.EditIndex = e.NewEditIndex;
        LoadGrid();
    }

    protected void gvemployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvemployee.EditIndex = -1;
        LoadGrid();
    }   
}