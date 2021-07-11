using Nano.DataAccessLayer;
using System.Data;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalCard
{
    DatabaseManager dm = new DatabaseManager();
    public int InsertUpdateDeleteCard(int id, string callname,  string name)
    {
        dm.AddParameteres("@Id", id);
        dm.AddParameteres("@Name", name);
        dm.AddParameteres("@callname", callname);
        return dm.ExecuteNonQuery("[UP_del_Card]");
    }


    public DataTable GetCardList()
    {
        return dm.ExecuteQuery("[USP_Card_GetAll]");
    }

    public DataTable GetCardById(int id)
    {
        dm.AddParameteres("@ID", id);
        return dm.ExecuteQuery("USP_Card_GetById");
    }
    

}