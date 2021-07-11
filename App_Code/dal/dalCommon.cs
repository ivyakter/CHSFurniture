using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Nano.DataAccessLayer;

/// <summary>
/// Summary description for dalCommon
/// </summary>
public class dalCommon
{
    DatabaseManager dm = new DatabaseManager();
    public dalCommon()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetRegistrationNo()
    {
        return dm.ExecuteQuery("USP_RegistrationNo");
    }

    public int UpdateRegistrationNo()
    {
        return dm.ExecuteNonQuery("USP_RegistrationNo_Update");
    }
    public DataTable DropdownByCondition(string table, string tableColumn, string whereby)
    {
        dm.AddParameteres("@Table", table);
        dm.AddParameteres("@Column", tableColumn);
        dm.AddParameteres("@Condition", whereby);
        return dm.ExecuteQuery("USP_GetById");
    }
    public DataTable LoadDropdown(string table)
    {
        dm.AddParameteres("@Table", table);
        return dm.ExecuteQuery("USP_GetAll");
    }
    public DataTable GetAll(string table)
    {
        dm.AddParameteres("@Table", table);
        return dm.ExecuteQuery("USP_GetAll");
    }
    public int GetRolePriority(int roleId)
    {
        dm.AddParameteres("@RoleId", roleId);
        DataTable dt = dm.ExecuteQuery("USP_Role_GetPriority");
        return Convert.ToInt32(dt.Rows[0][0]);
    }
    public double CurrentBalance(int leaveTypeId, int employeeId, int startYear, int endYear)
    {
        dm.AddParameteres("@LeaveTypeId", leaveTypeId);
        dm.AddParameteres("@EmployeeId", employeeId);
        dm.AddParameteres("@StartYear", startYear);
        dm.AddParameteres("@EndYear", endYear);
        DataTable dt = dm.ExecuteQuery("USP_Leave_CurrentBalance");
        if (dt.Rows.Count > 0)
            return Convert.ToDouble(dt.Rows[0][0]);
        return 0;
    }
}