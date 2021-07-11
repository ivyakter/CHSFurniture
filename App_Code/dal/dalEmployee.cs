using Nano.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalEmployee
{
    DatabaseManager dm = new DatabaseManager();
    public dalEmployee()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUpdateDeleteEmployee(int id, string callname, string name, string fathername,string motherName, string presentAdd,
        string permanentAddress, string designation, string department, string joindate, string mobile, string email, string note, 
        string createby, int storeid, string cv)
    {
        dm.AddParameteres("@Id", id);
        dm.AddParameteres("@callName", callname);
        dm.AddParameteres("@Name", name);
        dm.AddParameteres("@FName", fathername);
        dm.AddParameteres("@MName", motherName);
        dm.AddParameteres("@PresentAddress", presentAdd);
        dm.AddParameteres("@PermanentAddress", permanentAddress);
        dm.AddParameteres("@Designation", designation);
        dm.AddParameteres("@Department", department);
        dm.AddParameteres("@JoinDate", joindate);
        dm.AddParameteres("@Mobile", mobile);
        dm.AddParameteres("@Email", email);
        dm.AddParameteres("@Note", note);
        dm.AddParameteres("@Cv", cv);
        dm.AddParameteres("@CreateBy", createby);
        dm.AddParameteres("@StoreId", storeid);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_Employee]");
    }


    public DataTable GetEmployeeList()
    {
        return dm.ExecuteQuery("USP_Employee_GetAll");
    }

    public DataTable GetById(int id)
    {
        dm.AddParameteres("@ID", id);
        return dm.ExecuteQuery("USP_Employee_GetById");
    }
    

}