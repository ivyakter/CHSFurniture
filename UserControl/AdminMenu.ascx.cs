using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_AdminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadParent();
        }
    }
    protected void LoadParent()
    {
        string sql = @" SELECT distinct tbl_task_master.task_name, tbl_task_master.text, tbl_task_master.url, tbl_task_master.parentID,tbl_task_master.id ,Icon
                FROM  tbl_role_master INNER JOIN tbl_role_detail ON tbl_role_master.id = tbl_role_detail.role_id INNER JOIN 
                tbl_task_master ON tbl_role_detail.task_id = tbl_task_master.id INNER JOIN TBL_USER ON 
                TBL_USER.ROLE_ID=tbl_role_master.ID WHERE  TBL_USER.USERID ='" + Session["Uid"].ToString() + "' and tbl_task_master.FOR_ALL ='N' and parentID is null  order by tbl_task_master.id ";
        DataTable dt = DataAccess.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            rptParent.DataSource = dt;
            rptParent.DataBind();
        }
    }
    protected void rptCategory_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptChild = (Repeater)e.Item.FindControl("rptChild");
        HiddenField hdnValue = (HiddenField)e.Item.FindControl("hdnValue");
        string sql = @" SELECT distinct tbl_task_master.task_name, tbl_task_master.text, tbl_task_master.url, tbl_task_master.parentID,tbl_task_master.id ,Icon
                FROM  tbl_role_master INNER JOIN tbl_role_detail ON tbl_role_master.id = tbl_role_detail.role_id INNER JOIN 
                tbl_task_master ON tbl_role_detail.task_id = tbl_task_master.id INNER JOIN TBL_USER ON 
                TBL_USER.ROLE_ID=tbl_role_master.ID WHERE  TBL_USER.USERID ='" + Session["Uid"].ToString() + "' and tbl_task_master.FOR_ALL ='N' and parentID='"+hdnValue.Value+"'  order by tbl_task_master.id ";
        DataTable dt = DataAccess.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            rptChild.DataSource = dt;
            rptChild.DataBind();
        }
    }
}