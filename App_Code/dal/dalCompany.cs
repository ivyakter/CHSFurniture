using Nano.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dalRole
/// </summary>
public class dalCompany
{
    DatabaseManager dm = new DatabaseManager();
    public dalCompany()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int UpdateCompany(int id, string name, string address, string email, string phone, string conperson, string conEmail, string ConPhone, string photo, string createby)
    {
        dm.AddParameteres("@Id", id);
        dm.AddParameteres("@Name", name);
        dm.AddParameteres("@Logo", photo);
        dm.AddParameteres("@Address", address);
        dm.AddParameteres("@Phone", phone);
        dm.AddParameteres("@ContactPerson", conperson);
        dm.AddParameteres("@ConEmail", conEmail);
        dm.AddParameteres("@ConPhone", conperson);
        dm.AddParameteres("@UpdateBy", createby);
        return dm.ExecuteNonQuery("[USP_Company_Update]");
    }
}