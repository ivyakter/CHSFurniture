using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Set_ListCategory : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCategory();
        }
    }
    protected void getCategory()
    {
        DataTable dt = mydal.getCategory();
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

            bool delete = mydal.CategoryDeletebyid(lblid.Text);           
            getCategory();
        }
        catch (Exception ex)
        {
        }

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.DataBind();
        getCategory();
    }

    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        getCategory();
    }

    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string[] insert = new string[20];
            insert[0] = ((Label)gv.Rows[e.RowIndex].FindControl("lblid")).Text;
            insert[1] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtcatname")).Text;
          
            

        bool Edit = mydal.UpdateCategoryname(insert);

            string Pname = ((Label)gv.Rows[e.RowIndex].FindControl("lblNamefromtblimage")).Text;
            string PID = ((Label)gv.Rows[e.RowIndex].FindControl("lblid")).Text;
            string lblPIMGID = ((Label)gv.Rows[e.RowIndex].FindControl("lblPIMGID")).Text;
            FileUpload fu = (FileUpload)gv.Rows[e.RowIndex].FindControl("FileUpload1");


            gv.EditIndex = -1;
            getCategory();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        getCategory();
    }
}