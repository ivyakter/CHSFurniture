using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_InformationSetup_AddModel : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                btnupdate.Visible = true;
                btnSave.Visible = false;
                getAccessoriesbyid();
                LoadPName();
            }
            else
            {
                btnupdate.Visible = false;
                btnSave.Visible = true;            
                GetProductNo();
                LoadPName();
            }
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
        DataTable n = mydal.GetModeltNo();
        txtModelid.Text="Mod"+ n.Rows[0]["id"].ToString();
    }
    private void getAccessoriesbyid()
    {
        string id = Request.QueryString["ID"].ToString();
        DataTable dt = mydal.getModelid(id);
        if (dt.Rows.Count > 0)
        {
            txtModelid.Text = dt.Rows[0]["ModelId"].ToString();
            txtModelName.Text = dt.Rows[0]["ModelName"].ToString();
            ddlPName.SelectedValue = dt.Rows[0]["PId"].ToString();         
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtModelid.Text== "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give Doctor Title');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtModelid.Text;
            insert[1] = txtModelName.Text;
            insert[2] = ddlPName.SelectedItem.ToString();
          
            bool Save = mydal.InsertModel(insert);

            if (Save == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
                txtModelName.Text = null;

                GetProductNo();
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
        string  id = Request.QueryString["ID"].ToString();
        string name = txtModelName.Text;
        string Pname = ddlPName.SelectedItem.ToString();

        bool update = mydal.UpdateModelName(id, name, Pname);
        Response.Redirect("ListModel.aspx");

    }
}