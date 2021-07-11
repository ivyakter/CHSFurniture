using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Nano.DataAccessLayer;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Common
/// </summary>
public class CommonMethod
{
    DatabaseManager dm = new DatabaseManager();
    public CommonMethod()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bdoSessionInfo SessionInfo
    {
        get
        {
            try
            {
                if (HttpContext.Current.Session["SessionInfo"] != null)
                    return HttpContext.Current.Session["SessionInfo"] as bdoSessionInfo;
                else
                    return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        set
        {
            HttpContext.Current.Session["SessionInfo"] = value;
        }
    }
    public static string Button()
    {
        return CommonMethod.SessionInfo.Button;
    }

    public int Delete(string table, int id)
    {
        dm.AddParameteres("@Table", table);
        dm.AddParameteres("@Id", id);
        return dm.ExecuteNonQuery("USP_Delete");
    }
    public int PersonIdByUserName(string userName)
    {
        dm.AddParameteres("@UserName", userName);
        DataTable dt = dm.ExecuteQuery("USP_PersonId_GetByUserName");
        return Convert.ToInt32(dt.Rows[0][0]);
    }
    public int GetLastRoll(string criteria)
    {
        dm.AddParameteres("@Criteria", criteria);
        DataTable dt = dm.ExecuteQuery("USP_Student_GetLastRoll");
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public static void LoadDropdown(DropDownList ddl, string table, int dataTextField, int dataValueField)
    {
        DataTable dt = new dalCommon().LoadDropdown(table);
        ddl.Items.Add(new ListItem("", ""));
        ddl.DataSource = dt;
        ddl.DataTextField = dt.Columns[dataTextField].ToString();
        ddl.DataValueField = dt.Columns[dataValueField].ToString();
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", string.Empty));
        ddl.SelectedIndex = 0;
    }
    public static void LoadDropdownByDatatable(DropDownList ddl, DataTable  dt, int dataTextField, int dataValueField)
    {
        ddl.Items.Add(new ListItem("", ""));
        ddl.DataSource = dt;
        ddl.DataTextField = dt.Columns[dataTextField].ToString();
        ddl.DataValueField = dt.Columns[dataValueField].ToString();
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", string.Empty));
        ddl.SelectedIndex = 0;
    }
    public static void DropdownByCondition(DropDownList ddl, string table, string tableColumn, string whereby, int dataTextField, int dataValueField)
    {
        DataTable dt = new dalCommon().DropdownByCondition(table, tableColumn, whereby);
        ddl.Items.Add(new ListItem("", ""));
        ddl.DataSource = dt;
        ddl.DataTextField = dt.Columns[dataTextField].ToString();
        ddl.DataValueField = dt.Columns[dataValueField].ToString();
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", string.Empty));
        ddl.SelectedIndex = 0;
    }

}