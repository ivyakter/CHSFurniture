using Nano.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalStore
{
    DatabaseManager dm = new DatabaseManager();
    public dalStore()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUpdateDeleteStore(int id, string callname, string code, string name,string address, int companyid)
    {
        dm.AddParameteres("@StoreId", id);
        dm.AddParameteres("@CompanyID", companyid);
        dm.AddParameteres("@StoreCode", code);
        dm.AddParameteres("@StoreName", name);
        dm.AddParameteres("@Address", address);
        dm.AddParameteres("@callname", callname);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_Store]");
    }


    public DataTable GetStoreList()
    {
        return dm.ExecuteQuery("[USP_Store_GetAll]");
    }

    public DataTable GetById(int id)
    {
        dm.AddParameteres("@ID", id);
        return dm.ExecuteQuery("USP_Store_GetById");
    }
    

}