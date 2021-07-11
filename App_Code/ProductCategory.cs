using System.Data;
using Nano.DataAccessLayer;

/// <summary>
/// Summary description for ProductCategory
/// </summary>
public class ProductCategory
{
    DatabaseManager dm = new DatabaseManager();
	public ProductCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertUpdateDeleteCategory(string callName, string id, string categoryCode, string categoryName)
    {
        dm.AddParameteres("@callName", callName);
        dm.AddParameteres("@Id", id);
        dm.AddParameteres("@CategoryCode", categoryCode);
        dm.AddParameteres("@CategoryName", categoryName);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_Category]");
    }
    public int InsertUpdateDeleteSubCategory(string callName, string id, string category, string subcategoryCode, string subcategoryName)
    {
        dm.AddParameteres("@callName", callName);
        dm.AddParameteres("@Id", id);
        dm.AddParameteres("@CategoryId", category);
        dm.AddParameteres("@CategoryCode", subcategoryCode);
        dm.AddParameteres("@CategoryName", subcategoryName);
        return dm.ExecuteNonQuery("[USP_Ins_UP_del_SubCategory]");
    }

    public DataTable GetCategoryTable(int id)
    {
        dm.AddParameteres("@Id",id);
        return dm.ExecuteQuery("USP_Category_GetById");
    }
    public DataTable GetSubCategoryTable(int id)
    {
        dm.AddParameteres("@Id", id);
        return dm.ExecuteQuery("USP_SubCategory_GetById");
    }
}