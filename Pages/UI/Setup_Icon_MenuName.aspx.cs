using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_UI_Setup_Icon_MenuName : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load();
        }
    }
    public void Load()
    {
        DataTable dt = mydal.getMenuNameandIcon();
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Button linkbtn = sender as Button;
        GridViewRow gr = linkbtn.NamingContainer as GridViewRow;

        string Id = gr.Cells[0].Text;
        TextBox txtRoll = (TextBox)gr.Cells[1].FindControl("txtRoll");
        TextBox txttext = (TextBox)gr.Cells[2].FindControl("txtRegNo");
        TextBox txticon = (TextBox)gr.Cells[3].FindControl("txtSession");

        string sqlInsert = @"Update tbl_task_master set text='" + txttext.Text + "', Icon='" + txticon.Text + "' where id='" + Id + "' ";

        DataAccess.ExecuteSQL(sqlInsert);

        string strconfirm = "<script>if(window.confirm('Successfully Update'))</script>";
        ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);



    }
}