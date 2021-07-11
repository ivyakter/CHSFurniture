using Nano.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalCounter
{
    DatabaseManager dm = new DatabaseManager();
    public dalCounter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUpdateDeleteCounter(int id, string callname, string code, string name, int storeid)
    {
        dm.AddParameteres("@StoreId", storeid);
        dm.AddParameteres("@CounterID", id);
        dm.AddParameteres("@CounterCode", code);
        dm.AddParameteres("@CounterName", name);
        dm.AddParameteres("@callname", callname);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_Counter]");
    }


    public DataTable GetCounterList()
    {
        return dm.ExecuteQuery("[USP_Counter_GetAll]");
    }

    public DataTable GetCounterById(int id)
    {
        dm.AddParameteres("@ID", id);
        return dm.ExecuteQuery("USP_Counter_GetById");
    }
    

}