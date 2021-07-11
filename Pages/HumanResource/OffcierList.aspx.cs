using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_HumanResource_OffcierList : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getAllOfficer();
            LoadDesignation();         
        } 
    } 
    public void LoadDesignation()
    {
        DataTable dt = mydal.GetDeignation();
        ddldesignation.DataSource = dt;
        ddldesignation.DataTextField = "OFF_TYPE_NAME";
        ddldesignation.DataValueField = "id";
        ddldesignation.DataBind();
        ddldesignation.Items.Insert(0,"--Select Designation--");
    }

    public void getAllOfficer()
    {
        DataTable dt = mydal.GetAllOfficer();
        gvOfficer.DataSource = dt;
        gvOfficer.DataBind();
    }
   
    public void getAllOfficerbydesignation()
    {
        DataTable dt = mydal.GetAllOfficerbyDesignation(ddldesignation.SelectedItem.ToString());
        gvOfficer.DataSource = dt;
        gvOfficer.DataBind();
    }

    protected void ddldesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAllOfficerbydesignation();
    }


    protected void gvOfficer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOfficer.PageIndex = e.NewPageIndex;
    }   
    protected void gvOfficer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
    //    try
    //    {
    //        string Employeeid = ((Label)gvOfficer.Rows[e.RowIndex].FindControl("txtOfficerId")).Text;
    //        string Project = ((DropDownList)gvOfficer.Rows[e.RowIndex].FindControl("ddlProject")).SelectedItem.ToString();

    //        bool update = mydal.UpdateEmployee(Employeeid, Project);

    //        gvOfficer.EditIndex = -1;
    //        getAllOfficer();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    }
    protected void gvOfficer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOfficer.EditIndex = e.NewEditIndex;
        getAllOfficer();
    }

    protected void gvOfficer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOfficer.EditIndex = -1;
        getAllOfficer();
    }    
   
}