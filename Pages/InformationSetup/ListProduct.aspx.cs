using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_ListAccessoriesCategory : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getProductList();
        }
    }
    protected void getProductList()
    {
        DataTable dt = mydal.getProductList();
        gv.DataSource = dt;
        gv.DataBind();
    }   

    ///////////////////////

    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        getProductList();
    }
    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        getProductList();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            //string uid = Session["Uname"].ToString();
            string ProductID = e.CommandArgument.ToString();

            bool deletefromtblproduct = mydal.DeletePNamebyid(ProductID);
            //bool deletefrombarcode = mydal.DeleteProductformbarcode(ProductID);

            // fro deleting the directory folder too 
            //we need to delete all the files inside the directory folder too . 

            string path = Server.MapPath("~/ProductImage/") + ProductID;
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            //then delete folder
            Directory.Delete(path);


            bool deletefromprdImage = mydal.deletefromProductImage(ProductID);

            if (deletefromtblproduct == true && deletefromprdImage == true)
            {
                string strconfirm = "<script>if(window.confirm('Deleting Successfull')){window.location.href='ListProduct.aspx'}</script>";

                ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);

            }
            getProductList();
        }
    }
    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string[] insert = new string[10];
            insert[0] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtPID")).Text;
            insert[1] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtproductName")).Text;
            insert[2] = ((DropDownList)gv.Rows[e.RowIndex].FindControl("ddlModel")).Text;
            insert[3] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtCostingPrice")).Text;
            insert[4] = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtPDescription")).Text;

            bool Edit = mydal.UpdateProductName(insert);

            string Pname = ((Label)gv.Rows[e.RowIndex].FindControl("lblNamefromtblimage")).Text;
            string PID = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtPID")).Text;
            string lblPIMGID = ((Label)gv.Rows[e.RowIndex].FindControl("lblPIMGID")).Text;
            FileUpload fu = (FileUpload)gv.Rows[e.RowIndex].FindControl("FileUpload1");

            if (fu.HasFile)
            {
                string SavePath = Server.MapPath("~/ProductImage/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extention = Path.GetExtension(fu.PostedFile.FileName);
                fu.SaveAs(SavePath + "\\" + Pname.ToString() + Extention);

                bool updatephoto = mydal.updatephoto(PID, Pname, Extention, lblPIMGID);

            }
            gv.EditIndex = -1;
            getProductList();
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
        getProductList();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
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