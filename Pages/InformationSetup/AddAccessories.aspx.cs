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

public partial class Pages_InformationSetup_AddAccessories : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    SqlConnection con = new SqlConnection();
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {                
            LoadCategory();
            LoadModel();
            GetProductNo(); 
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

    protected void LoadCategory()
    {
        DataTable dt = mydal.getCategoryList();
        ddlcategory.DataSource = dt;
        ddlcategory.DataTextField = "MenuText";
        ddlcategory.DataValueField = "Id";
        ddlcategory.DataBind();
        ddlcategory.Items.Insert(0, new ListItem("-Select-", "0"));

    }

    public void GetProductNo()
    {
        DataTable n = mydal.GetAccessoriestNo();
        txtAccessoriesid.Text = n.Rows[0]["ID"].ToString();
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAccessoriesid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtAccessoriesid.Text;
            insert[1] = txtAccessoriesname.Text;
            insert[2] = ddlcategory.SelectedItem.Text;
            insert[3] = ddlModel.SelectedItem.ToString();
            insert[4] = txtCostingPrice.Text;

            bool Save = mydal.InsertAccessoriesname(insert);

            if (Save == true)
            {
                string PID = "0";
                DataTable PIDsearch = mydal.SelectAccessoriesMaxID();
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
                        string SavePath = Server.MapPath("~/AccessoriesImage/") + PID;
                        if (!Directory.Exists(SavePath))
                        {
                            Directory.CreateDirectory(SavePath);
                        }
                        string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                        fuImg01.SaveAs(SavePath + "\\" + txtAccessoriesid.Text.ToString().Trim() + "01" + Extention);
                        SqlCommand cmd3 = new SqlCommand("insert into AccessoriesImages values('" + PID + "',N'" + txtAccessoriesid.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
                        cmd3.ExecuteNonQuery();
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtAccessoriesid.Text = null;
                txtAccessoriesname.Text = null;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('Something wrong please try again');", true);
            }
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
       

    }
}