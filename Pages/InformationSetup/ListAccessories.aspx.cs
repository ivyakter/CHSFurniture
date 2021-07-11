using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_ListAccessories : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAccessoriesList();
           
        }
    }
    protected void getAccessoriesList()
    {
        DataTable dt = mydal.getAccessoriesList();
        gv.DataSource = dt;
        gv.DataBind();
    }   
    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        getAccessoriesList();
    }
    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        getAccessoriesList();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            //string uid = Session["Uname"].ToString();
            string ProductID = e.CommandArgument.ToString();

            bool deletefromtblproduct = mydal.AccessoriesDeletebyid(ProductID);         
            string path = Server.MapPath("~/AccessoriesImage/") + ProductID;
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            //then delete folder
            Directory.Delete(path);


            bool deletefromprdImage = mydal.deletefromAccessoriesImage(ProductID);

            if (deletefromtblproduct == true && deletefromprdImage == true)
            {
                string strconfirm = "<script>if(window.confirm('Deleting Successfull')){window.location.href='ListAccessories.aspx'}</script>";

                ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);

            }
            getAccessoriesList();
        }
    }
    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string[] insert = new string[10];
            insert[0] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtPID")).Text;
            insert[1] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtAccessoriesName")).Text;
            insert[2] = ((DropDownList)gv.Rows[e.RowIndex].FindControl("ddlcategory")).SelectedItem.Text;
            insert[3] = ((DropDownList)gv.Rows[e.RowIndex].FindControl("ddlModel")).SelectedItem.Text;
            insert[4] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtCostingPrice")).Text;

            bool Edit = mydal.UpdateAccessoriesName(insert);

            string Pname = ((Label)gv.Rows[e.RowIndex].FindControl("lblNamefromtblimage")).Text;
            string PID = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtPID")).Text;
            string lblPIMGID = ((Label)gv.Rows[e.RowIndex].FindControl("lblPIMGID")).Text;
            FileUpload fu = (FileUpload)gv.Rows[e.RowIndex].FindControl("FileUpload1");

            if (fu.HasFile)
            {
                string SavePath = Server.MapPath("~/AccessoriesImage/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extention = Path.GetExtension(fu.PostedFile.FileName);
                fu.SaveAs(SavePath + "\\" + Pname.ToString() + Extention);

                bool updatephoto = mydal.updatephoto(PID, Pname, Extention, lblPIMGID);

            }
            gv.EditIndex = -1;
            getAccessoriesList();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.DataBind();
        getAccessoriesList();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DataTable dt = mydal.getCategoryList();
                var type = (DropDownList)e.Row.FindControl("ddlCategory");
                type.DataSource = dt;
                type.DataValueField = "Id";
                type.DataTextField = "MenuText";
                type.DataBind();
                type.Items.Insert(0, new ListItem("--Select--", "0"));

                Label Category = (Label)e.Row.FindControl("lblCategory");
                type.SelectedValue = Category.Text;


                DataTable dtmodel = mydal.bindModel();
                var model = (DropDownList)e.Row.FindControl("ddlModel");
                model.DataSource = dtmodel;
                model.DataValueField = "ModelName";
                model.DataTextField = "ModelName";
                model.DataBind();
                model.Items.Insert(0, new ListItem("--Select--", "0"));

                Label hfPeriod = (Label)e.Row.FindControl("lblModel");
                model.SelectedValue = hfPeriod.Text;
            }

          
        }
    }
}