using Nano.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalProduct
{
    DatabaseManager dm = new DatabaseManager();
    public dalProduct()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUpdateDelete(int id, string callname, string code, string name,string description, int category, int subcategory, string ventor, string photo, string tag, string createby)
    {
        dm.AddParameteres("@id", id);
        dm.AddParameteres("@callname", callname);
        dm.AddParameteres("@Code", code);
        dm.AddParameteres("@Name", name);
        dm.AddParameteres("@Description", description);
        dm.AddParameteres("@CategoryId", category);
        dm.AddParameteres("@SubcategoryId", subcategory);
        dm.AddParameteres("@VendorId", ventor);
        dm.AddParameteres("@Photo", photo);
        dm.AddParameteres("@Tag", tag);
        dm.AddParameteres("@CreateBy", createby);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_Product]");
    }


    public DataTable GetProductList()
    {
        return dm.ExecuteQuery("USP_Product_GetAll");
    }

    public DataTable GetById(int id)
    {
        dm.AddParameteres("@ID", id);
        return dm.ExecuteQuery("USP_Product_GetById");
    }
    

}