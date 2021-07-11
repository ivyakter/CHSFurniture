using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_InformationSetup_AccessoriesCategory : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    SqlConnection con = new SqlConnection();

    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        { 
            LoadModel();    
            GetProductNo();
            LoadPName();
            BindCategory();
        }     
    }
    public void LoadModel()
    {
        DataTable dtmodel = mydal.bindModel();      
        ddlModel.DataSource = dtmodel;
        ddlModel.DataValueField = "ModelName";
        ddlModel.DataTextField = "ModelName";
        ddlModel.DataBind();
        ddlModel.Items.Insert(0, new ListItem("--Select--", "0"));
    
    }

    private void BindCategory()
    {
        DataTable dt = mydal.GetallCategories();
        if (dt.Rows.Count > 0)
        {
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "MenuText";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        string MainCategoryID = ddlCategory.SelectedValue;

        DataTable dt = mydal.getSubCategoryByCategort(MainCategoryID);

        if (dt.Rows.Count != 0)
        {

            ddlSubCategory.DataSource = dt;
            ddlSubCategory.DataTextField = "MenuText";
            ddlSubCategory.DataValueField = "Id";
            ddlSubCategory.DataBind();
            //ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }
    public void LoadPName()
    {
        DataTable dt = mydal.getPName();
        ddlPName.DataSource = dt;
        ddlPName.DataValueField = "ProId";
        ddlPName.DataTextField = "PName";
        ddlPName.DataBind();
        ddlPName.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    public void GetProductNo()
    {
        DataTable n = mydal.GetProductNo();
        txtproductId.Text = n.Rows[0]["ID"].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtproductId.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Product Name');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtproductId.Text;
            insert[1] = ddlPName.SelectedItem.ToString();
            insert[2] = ddlModel.SelectedItem.ToString();
            insert[3] = txtCostingPrice.Text;
            insert[4] = txtPDetails.Text;
            insert[5] = ddlCategory.SelectedValue;
            insert[6] = ddlSubCategory.SelectedValue;    

            bool Save = mydal.InsertProductname(insert);

            if (Save == true)
            {
                string PID = "0";
                DataTable PIDsearch = mydal.SelectProductMaxID();
                if (PIDsearch.Rows.Count > 0)
                {
                    PID = PIDsearch.Rows[0]["PID"].ToString();
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //Insert and upload Images

                    if (fuImg01.HasFile)
                    {
                        string SavePath = Server.MapPath("~/ProductImage/") + PID;
                        if (!Directory.Exists(SavePath))
                        {
                            Directory.CreateDirectory(SavePath);
                        }
                        string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                        fuImg01.SaveAs(SavePath + "\\" + PID + "01" + Extention);
                        SqlCommand cmd3 = new SqlCommand("insert into ProductImages values('" + PID + "',N'" + PID + "01" + "','" + Extention + "','" + ddlPName.SelectedValue + "','" + ddlModel.SelectedItem.ToString() + "')", con);
                        cmd3.ExecuteNonQuery();
                    }
                }
                string strconfirm = "<script>if(window.confirm('Data Saved')){window.location.href='AddProduct.aspx'}</script>";
                ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
                //ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);              
                GetProductNo();  
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('Something wrong please try again');", true);
            }
        }
    }
 
}