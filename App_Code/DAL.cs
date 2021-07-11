using System;
using System.Activities.Expressions;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;
using System.Data.Common;
using System.Data.SqlClient;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DataSet = System.Data.DataSet;

public class DAL
{


    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

    

    SqlCommand sqlcmd = null;

    public void con()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        cn.Open();
    }

    bool returnbool = false;
    int r_count;
    public DAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    

    public SqlConnection Connection
    {
        get
        {
            return cn;
        }
    }
    public DataSet GetDataSet(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        Connection.Close();
        return ds;
    }

    

    public DataTable GetDataTable(string sql)
    {
        DataSet ds = GetDataSet(sql);
        if (ds.Tables.Count > 0)
            return ds.Tables[0];
        return null;
    }
    public void dropdown(DropDownList drp, string table, int txt, int val, string order)
    {
        con();
        SqlDataAdapter da = new SqlDataAdapter("select * from  " + table + "   order by  " + order + "", cn);

        DataTable dt = new DataTable();
        da.Fill(dt);
        drp.Items.Add(new ListItem("", ""));
        drp.DataSource = dt;

        drp.DataTextField = dt.Columns[txt].ToString();
        drp.DataValueField = dt.Columns[val].ToString();
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("--Select--", ""));
        //drp.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drp.SelectedIndex = 0;

    }

    

    public DataTable LoadRole()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        cn.Open();

        string sql = "select id,role_name from  tbl_role_master  order by role_name ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;

    }

    public bool save_rolemst(string rn, string rd, string uid)
    {

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        //string date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString();
        string sql = "insert into TBL_ROLE_MASTER(ROLE_NAME,DESCRIPTION,CREATEBY,createdat) values('" + rn + "','" + rd + "','" + uid + "','" + date + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public bool update_rolemst(string rn, string rd, string uid, string docid)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "UPDATE TBL_ROLE_MASTER SET ROLE_NAME='" + rn + "', DESCRIPTION='" + rd + "', UPDATEBY='" + uid + "',UPDATEDATE='" + date + "' WHERE ID='" + docid + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }

        // }
        //  dr.Close();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public void grid_rolemst(GridView gv)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ROLE_MASTER", cn);
        cn.Open();
        DataTable dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        gv.DataSource = dt;

        gv.DataBind();
    }
    public bool deleteRole(string p)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            string sql = "delete from tbl_role_master where id = '" + p + "'";

            string sql1 = "delete from TBL_USER where ROLE_ID='" + p + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cn);
            cmd1.ExecuteNonQuery();

            var cmd = new SqlCommand(sql, cn);

            if (cmd.ExecuteNonQuery() > 0)
            {
            }
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    public bool update_user_password(string[] fivalue)
    {


        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "update TBL_USER set USER_PASSWORD='" + fivalue[1] + "' WHERE USERID='" + fivalue[0] + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }

        // }
        //  dr.Close();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }

    public void grid_PasswordShow(GridView gvBank)
    {

        SqlDataAdapter da = new SqlDataAdapter("select * from TBL_USER ", cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        DataTable ds = new DataTable();
        da.Fill(ds);
        cn.Close();
        gvBank.DataSource = ds;
        gvBank.DataBind();
    }
    public bool deleteUser(string p)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            string sql = "delete from TBL_USER where id = '" + p + "'";
            var cmd = new SqlCommand(sql, cn);

            if (cmd.ExecuteNonQuery() > 0)
            {
            }
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    public bool save_user(string[] fivalue)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "insert into TBL_USER(USERID,USER_NAME,USER_PASSWORD, ADDRESS,MOBILE,ROLE_ID,STATUS) values('" + fivalue[0] + "','" + fivalue[1] + "','" + fivalue[2] + "','" + fivalue[3] + "','" + fivalue[4] + "','" + fivalue[5] + "','Y' )";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }

        // }
        //  dr.Close();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public bool update_user(string[] fivalue)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "update TBL_USER set USER_NAME='" + fivalue[1] + "', USER_PASSWORD='" + fivalue[2] + "', ADDRESS='" + fivalue[3] + "', MOBILE='" + fivalue[4] + "', ROLE_ID='" + fivalue[5] + "'  WHERE ID='" + fivalue[6] + "' ";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }

        // }
        //  dr.Close();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public void dd_role(DropDownList drroleid)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ROLE_MASTER", cn);
        cn.Open();
        DataTable dt = new DataTable();
        da.Fill(dt);
        drroleid.Items.Add(new ListItem("", ""));
        drroleid.DataSource = dt;
        drroleid.DataTextField = dt.Columns["ROLE_NAME"].ToString();
        drroleid.DataValueField = dt.Columns["ID"].ToString();
        drroleid.DataBind();
        drroleid.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        drroleid.SelectedIndex = 0;
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    public void deleteprevious(string roleid)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "DELETE from tbl_role_detail where  role_id='" + roleid + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

    }
    

    public void save_role_detail(string[] fivalue, string uid)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        //string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "insert into TBL_ROLE_DETAIL (ROLE_ID, TASK_ID,CREATE_BY,CREATE_DATE) Values ('" + fivalue[0] + "','" + fivalue[1] + "','" + uid + "',getdate())";
        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    
    public DataTable selectusertask(string uid)
    {
        string sql = "SELECT distinct tbl_task_master.task_name, tbl_task_master.text, tbl_task_master.url, tbl_task_master.parentID,tbl_task_master.id " +
                " FROM  tbl_role_master INNER JOIN tbl_role_detail ON tbl_role_master.id = tbl_role_detail.role_id INNER JOIN " +
                " tbl_task_master ON tbl_role_detail.task_id = tbl_task_master.id  WHERE  tbl_role_detail.role_id ='" + uid + "' order by tbl_task_master.id";
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable ds = new DataTable();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    
    public void Update_Year(string section, string id)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "Update TBL_Year set year='" + section + "' where id='" + id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    public void Update_Timeset(string start, string end, string late, string id)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "Update TBL_AddTime set starttime='" + start + "',endtime='" + end + "',latetime='" + late + "' where id='" + id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    
    public DataTable get_user_forgot_code(string tr_no)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from NEW_CONSUMER_INFORMATION where TRACKING_NUMBER='" + tr_no + "'", cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return dt;

    }
    public DataTable SelectUser()
    {
        con();
        string sql = "select id,USERID from  TBL_USER ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable get_user_id(string[] sql)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from tbl_user where userid='" + sql[0] + "' and user_password='" + sql[1] + "' and status='Y'", cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return dt;

    }
    public bool LoginDetails(string date, string user, string ipaddress, string macaddress)
    {

        try
        {
            con();
            string sql = "insert into LastLogin (logdate,PersonId, IpAddress,MacAddress)values('" + date + "','" + user + "','" + ipaddress + "','" + macaddress + "') ";
            var cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    public DataTable getMenuNameandIcon()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        cn.Open();

        string id = "select * from tbl_task_master order by id ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }


    public bool InsertProductname(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO ProductName(ProductName,Model,CostingPrice,PDescription,Category,SubCategory)values(@ProductName,@Model,@CostingPrice,@PDescription,@Category,@SubCategory)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ProductName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Model", insert[2]);
            sqlcmd.Parameters.AddWithValue("@CostingPrice", Convert.ToDecimal(insert[3]));
            sqlcmd.Parameters.AddWithValue("@PDescription", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Category", insert[5]);
            sqlcmd.Parameters.AddWithValue("@SubCategory", insert[6]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateProductName(long id, string name, string model, string price)
    {
        try
        {
            con();
            string Save = "Update ProductName set ProductName=@ProductName,Model=@Model,CostingPrice=@CostingPrice where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@ProductName", name);
            sqlcmd.Parameters.AddWithValue("@Model", model);
            sqlcmd.Parameters.AddWithValue("@CostingPrice", Convert.ToDecimal(price));
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getProductsbyid(long id)
    {
        con();
        string query = @" select  * from ProductName where PNID='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetProductNo()
    {
        con();
        string id = @"Select ISNULL(Max(PNID),0)+1 as ID from ProductName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getProductList()
    {
        con();
        string id = @"Select * from TBL_Product inner join Productname on ProductName.ProductName=TBL_Product.PName inner join ProductImages on TBL_Product.ProId = ProductImages.ProId  and ProductName.Model=ProductImages.MId inner join Menu on ProductName.Category=Menu.Id   order by PName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProductList(string cat)
    {
        con();
        string id = @"Select * from TBL_Product inner join Productname on ProductName.ProductName=TBL_Product.PName inner join ProductImages on TBL_Product.ProId = ProductImages.ProId  and ProductName.Model=ProductImages.MId inner join Menu on ProductName.Category=Menu.Id Where MenuText='"+cat+"' order by PName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool ProducNametDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from TBL_Product where id=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getAccessoriesbyid(long id)
    {
        con();
        string query = @" select  * from AccessoriesName where ID='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getModelid(string id)
    {
        con();
        string query = @"select * from TBL_Model inner join TBL_Product on TBL_Product.ProId=TBL_Model.PId where ModelId='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getPnameByid(string id)
    {
        con();
        string query = @" select  * from TBL_Product where Proid='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getModel()
    {
        con();
        string query = @" select  * from TBL_Model  inner join TBL_Product on TBL_Product.ProId=TBL_Model.PId order by PName ";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getPName()
    {
        con();
        string query = @" select  * from TBL_Product ";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getModelByName(string itemname)
    {
        con();
        string query = @" select  * from TBL_Model ";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAccessoriestNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 as ID from AccessoriesName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetModeltNo()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 as ID from TBL_Model";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProNameNo()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 as ID from TBL_Product";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool InsertAccessoriesname(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO AccessoriesName(AccessoriesName,CategoryName,Model,Price)values(@AccessoriesName,@CategoryName,@Model,@Price)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@AccessoriesName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@CategoryName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Model", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(insert[4]));
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertModel(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO TBL_Model(ModelId,ModelName)values(@ModelId,@ModelName)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ModelId", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ModelName", insert[1]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertProName(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO TBL_Product(ProId,PName)values(@ProId,@PName)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ProId", insert[0]);
            sqlcmd.Parameters.AddWithValue("@PName", insert[1]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateAccessoriesName(long id, string name, string Categoryname, string model, string Price)
    {
        try
        {
            con();
            string Save = "Update AccessoriesName set AccessoriesName=@AccessoriesName,CategoryName=@CategoryName,Model=@Model,Price=@Price where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@AccessoriesName", name);
            sqlcmd.Parameters.AddWithValue("@CategoryName", Categoryname);
            sqlcmd.Parameters.AddWithValue("@Model", model);
            sqlcmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(Price));
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateModelName(string id, string name, string Pname)
    {
        try
        {
            con();
            string Save = "Update TBL_Model set ModelName=@ModelName,PId=@PId where ModelId=@ModelId ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ModelId", id);
            sqlcmd.Parameters.AddWithValue("@ModelName", name);
            sqlcmd.Parameters.AddWithValue("@PId", Pname);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateProName(string id, string name)
    {
        try
        {
            con();
            string Save = "Update TBL_Product set PName=@PName where ProId=@ProId ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ProId", id);
            sqlcmd.Parameters.AddWithValue("@PName", name);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable getAccessoriesList()
    {
        con();
        string id = @"Select * from AccessoriesName inner join AccessoriesImages on AccessoriesName.ID = AccessoriesImages.PID";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool AccessoriesDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from AccessoriesName where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool ModelDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from TBL_Model where ModelId=@ModelId";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ModelId", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool ProductDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from TBL_Product where ID=@id";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool DeletePNamebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from ProductName where PNID=@id";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable getCategorybyid(long id)
    {
        con();
        string query = @" select  * from Menu where Id='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCategoryNo()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0)+1 as ID from Menu";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertCategoryname(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Menu(MenuText,Icon,MenuLevel)values(@MenuText,@Icon,@MenuLevel)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@MenuText", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Icon", "fa fa-lemon-o");
            sqlcmd.Parameters.AddWithValue("@MenuLevel","0");
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateCategoryName(long id, string name)
    {
        try
        {
            con();
            string Save = "Update Menu set MenuText=@MenuText where Id=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@MenuText", name);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getCategoryList()
    {
        con();
        string id = @"Select * from Menu where MenuLevel='0'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool CategoryDeletebyid(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from Menu where Id=@ID";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetSupplierVoucher()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(id),0)+1 from PurchaseAccessoriesSupplier";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable bindAccessories()
    {
        con();
        string id = @" Select distinct AccessoriesName from AccessoriesName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable bindUnit()
    {
        con();
        string id = @"Select * from UnitName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool PurchaseItemSupplier(string vname, string supplier, string address, string date, string comment, string supplierid)
    {
        con();
        string insert = "INSERT INTO PurchaseAccessoriesSupplier (VoucherNo,SupplierName,Address,date,Comment,SupplierID)values('" + vname + "','" + supplier + "','" + address + "','" + Convert.ToDateTime(date) + "','" + comment + "','" + supplierid + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    public bool InsertPurchaseBulk(string vname, string item, string model, string qty, string unit, string price, string total, string pcost)
    {
        try
        {
            string date = DateTime.Today.ToString("dd/MMM/yyyy");
            con();
            string insert = "INSERT INTO PurchaseAccessories (VoucherNo,productItem,Model,quantity,unit,Price,Total,status,CREATE_DATE,ProductCost)values('" + vname + "','" + item + "','" + model + "','" + qty + "','" + unit + "','" + Convert.ToDecimal(price) + "','" + Convert.ToDecimal(total) + "','Not Received','" + date + "','" + pcost + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }

        catch (Exception)
        {
            throw;
        }
    }

    //public bool InsertStockBulk(string itemid, string item, decimal qty, decimal price, string drmqty, DateTime date)
    //{
    //    try
    //    {
    //        con();
    //        string insert = "INSERT INTO PresentStockAccessories (ItemId,ItemName,PresentStock,PresentPrice,qty,LastUpdateDate)values('" + itemid + "','" + item + "','" + qty + "','" + price + "','" + drmqty + "','" + date + "')";
    //        sqlcmd = new SqlCommand(insert, cn);
    //        sqlcmd.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    public DataTable getUnitbyid(long id)
    {
        con();
        string query = @" select  * from UnitName where ID='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetUnitNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 as ID from UnitName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertUnitname(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO UnitName(UnitName)values(@UnitName)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@UnitName", insert[1]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateUnittName(long id, string name)
    {
        try
        {
            con();
            string Save = "Update UnitName set UnitName=@UnitName where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@UnitName", name);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getUnitList()
    {
        con();
        string id = @"Select * from UnitName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UnitDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from UnitName where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertVendorName(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO VendorName(VendorID,VendorName,Contact,Address,BusinessName,ChartofAccount,Email)values(@VendorID,@VendorName,@Contact,@Address,@BusinessName,@ChartofAccount,@Email)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@VendorID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@VendorName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Contact", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[3]);
            sqlcmd.Parameters.AddWithValue("@BusinessName", insert[4]);
            sqlcmd.Parameters.AddWithValue("@ChartofAccount", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Email",insert[6]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateVendorName(long id, string name, string contact, string address, string business, string chartoff, string Email)
    {
        try
        {
            con();
            string Save = "Update VendorName set VendorName=@VendorName,Contact=@Contact,Address=@Address,BusinessName=@BusinessName ,ChartofAccount=@ChartofAccount, Email=@Email where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@VendorName", name);
            sqlcmd.Parameters.AddWithValue("@Contact", contact);
            sqlcmd.Parameters.AddWithValue("@Address", address);
            sqlcmd.Parameters.AddWithValue("@BusinessName", business);
            sqlcmd.Parameters.AddWithValue("@ChartofAccount", chartoff);
            sqlcmd.Parameters.AddWithValue("@Email",Email);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getVendorbyid(long id)
    {
        con();
        string query = @" select  * from VendorName where ID='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetVendorNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 as ID from VendorName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetVendor()
    {
        con();
        string id = @"Select * from VendorName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getVendorListForAccounts()
    {
        con();
        string id = @"Select * from VendorName where AccCode is null";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getVendorList()
    {
        con();
        string id = @"Select * from VendorName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool VendorDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from VendorName where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getaddressbysupplier(string suppliername)
    {
        con();
        string id = @"Select * from VendorName where AccCode='" + suppliername + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getBulkStock()
    {
        con();
        string id = "select * from PurchaseAccessories where status='Not Received' order by id asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }


    public bool SaveBulkReceive(string[] fiva)
    {
        try
        {
            con();
            string insert = "INSERT INTO PurchaseAccessoriesReceive (VoucherNo,productItem,quantity,drmqty,ReceiveDate,ReceiveBy,status)values('" + fiva[2] + "','" + fiva[3] + "','" + fiva[4] + "','" + fiva[5] + "','" + fiva[6] + "','" + fiva[7] + "','Received')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateBulk(string p)
    {
        try
        {
            con();
            string insert = "Update PurchaseAccessories set status='Received' where id='" + p + "'";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable Getdatefilterpurchase(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo  where PurchaseAccessoriesSupplier.date >= '" + date1 + "' and PurchaseAccessoriesSupplier.date <= '" + date2 + "'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetVendorName()
    {
        con();
        string id = @"Select * from VendorName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetAccessoriesName()
    {
        con();
        string id = @"Select Distinct AccessoriesName from AccessoriesName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAccessoriesByName(string Item)
    {
        con();
        string id = @"Select * from AccessoriesName where AccessoriesName='" + Item + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetdetailsbyAccessories(ListItem listItem)
    {
        con();
        string sql = @" select * from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo where PurchaseAccessories.productItem='" + listItem + "'  ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetdetailsbyVendor(ListItem listItem, DateTime date1, DateTime date2)
    {
        con();
        string sql = @" select * from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo where PurchaseAccessoriesSupplier.SupplierName='" + listItem + "' and PurchaseAccessoriesSupplier.date >= '" + date1 + "' and PurchaseAccessoriesSupplier.date <= '" + date2 + "' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPurchaseInfo()
    {
        con();
        string sql = @"select * from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getClientbyid(long id)
    {
        con();
        string query = @" select  * from ClientInformation where id='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetClientNo()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 as ID from ClientInformation";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertClientName(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO ClientInformation(ClientID,ClientName,ContactNo,Address,Email)values(@ClientID,@ClientName,@ContactNo,@Address,@Email)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ClientID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ClientName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@ContactNo", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[4]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateClientName(long id, string name, string contact, string address, string Email)
    {
        try
        {
            con();
            string Save = "Update ClientInformation set ClientName=@ClientName,ContactNo=@Contact,Address=@Address,Email=@Email where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.Parameters.AddWithValue("@ClientName", name);
            sqlcmd.Parameters.AddWithValue("@Contact", contact);
            sqlcmd.Parameters.AddWithValue("@Address", address);
            sqlcmd.Parameters.AddWithValue("@Email",Email);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertStockBulk(string item, string model, string qty, DateTime date, string Unit)
    {
        try
        {
            con();
            string insert = "INSERT INTO PresentStockItems (ItemName,Model,PresentStock,LastUpdateDate,Unit)values('" + item + "','" + model + "','" + qty + "','" + date + "','" + Unit + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable searchproductinstock(string Itemname, string model)
    {
        con();
        string id = @"Select ItemName from PresentStockItems where ItemName='" + Itemname + "' and Model='" + model + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable searchPriceandqtyofproduct(string Itemname)
    {
        con();
        string id = @"Select * from PresentStockItems where ItemName='" + Itemname + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateExistingProduct(string Itemname, string Model, double qty, DateTime dateTime)
    {
        try
        {
            con();
            string Save = "Update PresentStockItems set PresentStock=@PresentStock,LastUpdateDate=@LastUpdateDate where ItemName=@ItemName and Model='" + Model + "' ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ItemName", Itemname);
            sqlcmd.Parameters.AddWithValue("@PresentStock", qty);

            sqlcmd.Parameters.AddWithValue("@LastUpdateDate", dateTime);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable getClientListForAccounts()
    {
        con();
        string id = @"Select * from ClientInformation where AccCode is null";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getClientList()
    {
        con();
        string id = @"Select * from ClientInformation ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool ClientDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from ClientInformation where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getInfobyclient(string Clientname)
    {
        con();
        string id = @"Select * from ClientInformation where ClientName='" + Clientname + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertSalesVoucher(string voucherno, string ClientId, string clientname, string date, string comment, string total)
    {
        try
        {
            con();
            string Save = "INSERT INTO SalesVoucherList(VoucherNo,date,Comment,ClientId,ClientName,TotalAmount,DueAmount,PayStatus)values(@VoucherNo,@date,@Comment,@ClientId,@ClientName,@TotalAmount,@DueAmount,@PayStatus)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ClientId", ClientId);
            sqlcmd.Parameters.AddWithValue("@ClientName",clientname);
            sqlcmd.Parameters.AddWithValue("@VoucherNo", voucherno);
            sqlcmd.Parameters.AddWithValue("@date", date);
            sqlcmd.Parameters.AddWithValue("@Comment", comment);
            sqlcmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(total));
            sqlcmd.Parameters.AddWithValue("@DueAmount", Convert.ToDecimal(total));
            sqlcmd.Parameters.AddWithValue("@PayStatus", "Not Paid");

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
   
    public DataTable GetSalesVoucher()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(id),0)+1 from SalesVoucherList";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable bindProduct()
    {
        con();
        string id = @"Select * from TBL_Product";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetItemForProductionVoucher()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(ID),0)+1 from ItemForProduction";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public bool InsertItemForProduction(string vname, string item, string model, string qty, string unit)
    {
        try
        {
            string date = DateTime.Today.ToString("dd/MMM/yyyy");
            con();
            string insert = "INSERT INTO ItemForProduction (VoucherNo,ItemName,Model,Quantity,Unit,Date)values('" + vname + "','" + item + "','" + model + "','" + qty + "','" + unit + "','" + date + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetFinishedGoodVoucher()
    {

        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(id),0)+1 from FinishedGoodsVoucher";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public bool FinishGoodvoucher(string voucherno, string Date, string Comment, string Productname, string Model, string Unit, string Quantity, string productid)
    {
        try
        {

            con();
            string insert = "INSERT INTO FinishedGoodsVoucher (VoucherNo, Item_Id,ITEM_NAME,Model,Qty,UNIT,CREATE_DATE)values('" + voucherno + "','" + productid + "','" + Productname + "','" + Model + "','" + Quantity + "','" + Unit + "','" + Date + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool FinishGoods(string voucherno, string itemname, string Model, string date, string quantity, string unit)
    {
        try
        {

            con();
            string insert = "INSERT INTO FinishedGoods (VoucherNo,ITEM_NAME,Model, CREATE_DATE,Qty,UNIT)values('" + voucherno + "','" + itemname + "','" + Model + "','" + date + "','" + quantity + "','" + unit + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable searchproductinstockForProduct(string Itemname)
    {
        con();
        string id = @"Select ITEM_NAME from FinishedGoodsStock where ITEM_NAME='" + Itemname + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable Priceandqtyofproduct(string Itemname)
    {
        con();
        string id = @"Select * from FinishedGoodsStock where ITEM_NAME='" + Itemname + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable PriceandqtyofProduction(string ItemId, string model)
    {
        con();
        string id = @"Select * from FinishedGoodsStock where Item_Id='" + ItemId + "' and Model='" + model + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable Priceandqtyof(string ItemId, string model)
    {
        con();
        string id = @"Select * from FinishedGoodsStock where Item_Id='" + ItemId + "' and Model='" + model + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateExistingProductforProduct(string Itemname, string Model, double UpdatedQty, DateTime dateTime)
    {
        try
        {
            con();
            string Save = "Update FinishedGoodsStock set Qty=@Qty,CREATE_DATE=@CREATE_DATE where ITEM_NAME=@ITEM_NAME and Model=@Model";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ITEM_NAME", Itemname);
            sqlcmd.Parameters.AddWithValue("@Qty", UpdatedQty);
            sqlcmd.Parameters.AddWithValue("@Model", Model);
            sqlcmd.Parameters.AddWithValue("@CREATE_DATE", dateTime);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateExistingProductformProduction(string Itemname, string Model, double UpdatedQty, DateTime dateTime)
    {
        try
        {
            con();
            string Save = "Update FinishedGoodsStock set Qty=@Qty,CREATE_DATE=@CREATE_DATE where Item_Id=@ITEM_NAME and Model=@Model";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ITEM_NAME", Itemname);
            sqlcmd.Parameters.AddWithValue("@Qty", UpdatedQty);
            sqlcmd.Parameters.AddWithValue("@Model", Model);
            sqlcmd.Parameters.AddWithValue("@CREATE_DATE", dateTime);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertFinishedGoodStock(string Productid, string productname, string quantity, string date, string unit)
    {
        try
        {
            con();
            string insert = "INSERT INTO FinishedGoodsStock (Item_Id,ITEM_NAME,Qty,CREATE_DATE,UNIT)values('" + Productid + "','" + productname + "','" + quantity + "','" + date + "','" + unit + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool FinishedGoodStockfromProduction(string Productid, string productname, string model, string quantity, string date, string unit)
    {
        try
        {
            con();
            string insert = "INSERT INTO FinishedGoodsStock (Item_Id,ITEM_NAME,Model,Qty,CREATE_DATE,UNIT)values('" + Productid + "','" + productname + "','" + model + "','" + quantity + "','" + date + "','" + unit + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable searchproductinstockforProduct(string product)
    {
        con();
        string id = @"Select ITEM_NAME from FinishedGoodsStock where ITEM_NAME='" + product + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable searchPriceandqtyofproductforProduct(string product)
    {
        con();
        string id = @"Select * from FinishedGoodsStock where ITEM_NAME='" + product + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateExistingProducthistory(string product, double UpdatedQty, DateTime dateTime)
    {
        try
        {
            con();
            string Save = "Update FinishedGoodsStock set Qty=@Qty,CREATE_DATE=@CREATE_DATE where ITEM_NAME=@ITEM_NAME ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ITEM_NAME", product);
            sqlcmd.Parameters.AddWithValue("@Qty", UpdatedQty);

            sqlcmd.Parameters.AddWithValue("@CREATE_DATE", dateTime);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetFinishedGoodsStock()
    {
        con();
        string sql = @"select * from FinishedGoodsStock ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetdetailsbyProductName(ListItem listItem)
    {
        con();
        string sql = @" select * from FinishedGoodsStock where FinishedGoodsStock.ITEM_NAME='" + listItem + "'  ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetdatefilterForFinishedGoods(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from FinishedGoodsStock  where FinishedGoodsStock.CREATE_DATE >= '" + date1 + "' and FinishedGoodsStock.CREATE_DATE <= '" + date2 + "'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAccessoriesStock()
    {
        con();
        string sql = @"select * from PresentStockItems";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetdetailsbyAccessoriesName(ListItem listItem)
    {
        con();
        string sql = @" select * from PresentStockItems where PresentStockItems.ItemName='" + listItem + "'  ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Getdatefilterpurchaseforstock(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from PresentStockItems  where PresentStockItems.LastUpdateDate >= '" + date1 + "' and PresentStockItems.LastUpdateDate <= '" + date2 + "'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPurchaseInvoiceReport(string p)
    {
        con();
        string sql = @"Select * from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo where PurchaseAccessoriesSupplier.VoucherNo='" + p + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSalesnvoiceReport(string p)
    {
        con();
        string sql = @" Select * from SalesVoucherList inner join  SalesVoucherItem on SalesVoucherItem.VoucherNo=SalesVoucherList.VoucherNo where SalesVoucherList.VoucherNo='" + p + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFinishGoodsReport(string p)
    {
        con();
        string sql = @"Select * from FinishedGoods where VoucherNo='" + p + "'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable bindModel()
    {
        con();
        string sql = @"Select * from TBL_Model";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool insertIncomevoucherList(string vname, string name, string clientid, string address, string phone, string date, string comment, string bank, string branch, string trttype, double TotalPaid)
    {
        con();
        string insert = "INSERT INTO InconeVoucherList (Vid,Name,ClientId,Phone,date,Comment,BankName,BranchName,TRType,TotalPaid)values(@Vid,@Name,@ClientId,@Phone,@date,@Comment,@BankName,@BranchName,@TRType,@TotalPaid)";
        SqlCommand cmd = new SqlCommand(insert, cn);
        cmd.Parameters.AddWithValue("@Vid", vname);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@ClientId", clientid);
        cmd.Parameters.AddWithValue("@Phone", phone);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@Comment", comment);
        cmd.Parameters.AddWithValue("@BankName", bank);
        cmd.Parameters.AddWithValue("@BranchName", branch);
        cmd.Parameters.AddWithValue("@TRType", trttype);
        cmd.Parameters.AddWithValue("@TotalPaid", TotalPaid);
        cmd.ExecuteNonQuery();
        return true;

    }
    public bool IncomeVoucher(string vname, string item, string godown, string unit)
    {
        //string qty,
        try
        {
            con();
            string insert = "INSERT INTO IncomeVoucher(Vid,ItemName,Description,amount)values('" + vname + "','" + item + "','" + godown + "','" + unit + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool Updatesalesvoucher(string p, string paidamount, string dueamount, int PaidDay)
    {
        try
        {
            string paidStatus = "Paid";
            if (int.Parse(dueamount) > 0)
            {
                paidStatus = "Not Paid";
            }
            con();
            string update = "Update SalesVoucherList set PayStatus='" + paidStatus + "', PaidAmount='" + paidamount + "', DueAmount='" + dueamount + "',PaidDay='" + PaidDay + "' where VoucherNo='" + p + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool ReceiveAmountCR(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string coa)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Debit,Credit,Debitstatus,ChartofAccount,Client_Name)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','0','" + txtPayAmount + "','Ok','" + coa + "','" + name + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();

        return true;
    }

    public bool ReceiveAmountDR(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string coa)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Debit,Credit,Debitstatus,ChartofAccount,Client_Name)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','0','Ok','" + coa + "','" + name + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();

        return true;
    }

    public DataTable GetDistributorById(string dId)
    {
        con();
        string id = @"Select * from ClientInformation where ClientId='" + dId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetDistAmount(string p)
    {
        con();
        string sql = @"Select ISNULL(SUM(DueAmount),0) from SalesVoucherList where ClientId='" + p + "' and PayStatus='Not Paid'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetOpeningBlanceByDistibutor(string p)
    {
        con();
        string id = @"Select ISNULL(SUM(Debit),0) from Recive_Payment where Client_Name='" + p + "' and Trans_Type='Opening Balance' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable bindReceiveTypeAmount(string vid)
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select *,TotalAMount-isnull(PaidAmount,0) as PayableAmount  from SalesVoucherList where VoucherNo='" + vid + "' and PayStatus='Not Paid'";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }
    public DataTable bindReceiveTypeDue(string p)
    {
        con();
        string id = @"select PaidAmount from SalesVoucherList where VoucherNo='" + p + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetIncoVoucher()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 from IncomeVoucherList";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;

    }
    public DataTable bindReceiveTypeBNyClient(string cid)
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from SalesVoucherList where ClientId='" + cid + "' and PayStatus='Not Paid'";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }
    public bool SaveAcc(string accCode, string accName, string ParentId, string AccLevel)
    {
        try
        {
            con();
            string Save = "INSERT INTO ChartOfAcc(AccCode,AccName ,ParentAccId,AccLevel) VALUES(@AccCode,@AccName ,@ParentAccId,@AccLevel)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@AccCode", accCode);
            sqlcmd.Parameters.AddWithValue("@AccName", accName);
            sqlcmd.Parameters.AddWithValue("@ParentAccId", ParentId);
            sqlcmd.Parameters.AddWithValue("@AccLevel", AccLevel);
            sqlcmd.ExecuteNonQuery();

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable LoadAccountTree()
    {
        con();
        string id = "select * from ChartOfAcc order by AccName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable LoadAccountTree(string AccCode)
    {
        con();
        string id = "select * from ChartOfAcc where AccCode like'" + AccCode + "%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool DeleteEmp(string Id)
    {
        con();
        string sql = "delete from ClientInformation where ClientId='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool EditAccountTree(string AccCode, string Accname, string AccNmeOld, string Id)
    {
        con();
        string sql = "Update ChartOfAcc set AccName=@AccName where Id='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@Id", Id);
        cmd.Parameters.AddWithValue("@AccName", Accname);
        cmd.ExecuteNonQuery();

        string sqlaMat = "Update ProJectToProjectMaterials set MaterialsName=@MaterialsName where MaterialsName=@MaterialsNameOld";
        SqlCommand cmdMat = new SqlCommand(sqlaMat, cn);
        cmdMat.Parameters.AddWithValue("@MaterialsName", Accname);
        cmdMat.Parameters.AddWithValue("@MaterialsNameOld", AccNmeOld);
        cmdMat.ExecuteNonQuery();

        string sqlaRP = "Update Recive_Payment set Payment_Client=@Client_Name, Client_Name=@Client_Name where Payment_Client=@Client_NameOld";
        SqlCommand cmdRP = new SqlCommand(sqlaRP, cn);
        cmdRP.Parameters.AddWithValue("@Client_Name", Accname);
        cmdRP.Parameters.AddWithValue("@Client_NameOld", AccNmeOld);
        cmdRP.ExecuteNonQuery();

        string sqlaPur = "Update PurchaseAccessories set productItem=@productItem where productItem=@productItemOld";
        SqlCommand cmdPur = new SqlCommand(sqlaPur, cn);
        cmdPur.Parameters.AddWithValue("@productItem", Accname);
        cmdPur.Parameters.AddWithValue("@productItemOld", AccNmeOld);
        cmdPur.ExecuteNonQuery();

        return true;
    }
    public bool ExpenseVoucher(string txtVoucherName, string box1, string box2, string box4)
    {
        try
        {
            con();
            string insert = "INSERT INTO ExpenseVoucher(Vid,ExpName,ExpDescription,ExpAmount)values('" + txtVoucherName + "','" + box1 + "','" + box2 + "','" + box4 + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool ReceivedPayment(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtTotal)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Payment_Client,ClientId,date,BankName,BranchName,Trans_Type,Credit,Creditstatus,ChartofAccount,Client_Name)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + Convert.ToInt32(txtTotal) + "','Ok','Account Payable','" + name + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    public DataTable GetClientById(string clId)
    {
        con();
        string id = @"Select * from VendorName where VendorID='" + clId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetExpenseVoucher()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 from ExpenseVoucherList";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;

    }
    public DataTable bindExpenseType()
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {

            con();
            string sql = "select * from Expense_type";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }
    public DataTable GetDebitCreditInfo()
    {
        con();
        string sql = @" select * from Recive_Payment ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable Getdatefilterforrec_pay(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from Recive_Payment  where Recive_Payment.Date >= '" + date1 + "' and Recive_Payment.Date <= '" + date2 + "'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetDebit(string p)
    {
        con();
        string sql = @" select * from Recive_Payment where Recive_Payment.Debitstatus='Ok' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetCredit(string p)
    {
        con();
        string sql = @" select * from Recive_Payment where Recive_Payment.Creditstatus='Ok' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable LoadBalanceReport(string accountId)
    {
        con();
        string id = @"select ca.Id,ca.AccCode,ca.AccDec, ca.AccName,sum(rp.Credit) as crAmount, sum(rp.Debit) drAmount from ChartOfAcc ca left join [Recive_Payment] rp on  rp.ChartofAccountId=ca.AccCode  where ca.AccCode like '" + accountId + "%' group by ca.AccCode,ca.AccDec, ca.AccName,ca.Id order by ca.Id";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAccountHeads(string ParentAccId)
    {
        con();
        string id = @"Select * from ChartOfAcc where ParentAccId='" + ParentAccId + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBankBranchByBank(string bank)
    {
        con();
        string id = @"Select * from TBL_BANK_BRANCH where BANK_ID='" + bank + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBankBranch()
    {
        con();
        string id = @"Select * from TBL_BANK_BRANCH inner join TBL_BANK_NAME on TBL_BANK_NAME.id=TBL_BANK_BRANCH.BANK_ID";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBank()
    {
        con();
        string id = @"SELECT *  FROM ChartOfAcc where AccCode like'0101050%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBankBranchByBank()
    {
        con();
        string id = @"Select * from TBL_BANK_BRANCH ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetLastAccCode(string NodeId)
    {
        con();
        //string id = @"select case when MAX(AccCode) is null then ISNULL(MAX(AccCode),'" + NodeId + "'+'01') else MAX(AccCode)+1 end as cde  from ChartOfAcc where ParentAccId='" + NodeId + "'";
        string id = @"select  MAX(AccCode) as AccCode, AccLevel from ChartOfAcc where ParentAccId='" + NodeId + "' group by AccLevel ";      
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetClient()
    {
        con();
        string id = @"Select * from ClientInformation";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool ExpenseVoucherList(string txtVid, string txtName, string txtClientId, string txtAddress, string txtphone, string txtDate, string txtComment, string ddlIncomeType, string ddlBank, string ddlBranch)
    {
        con();
        string insert = "INSERT INTO ExpenseVoucherList (Vid,Name,ClientId,Address,Phone,date,Comment,TRType,BankName,BranchName)values('" + txtVid + "','" + txtName + "', '" + txtClientId + "','" + txtAddress + "','" + txtphone + "','" + Convert.ToDateTime(txtDate) + "','" + txtComment + "','" + ddlIncomeType + "','" + ddlBank + "','" + ddlBranch + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool update_Branchsetup(string bank, string branch, string uid, string id)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "UPDATE TBL_BANK_BRANCH SET BANK_ID='" + bank + "', BRANCH='" + branch + "', UPDATE_BY='" + uid + "',UPDATE_DATE='" + date + "' WHERE ID=" + id + "";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public void save_Dristict(string name)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        string sql = "insert into TBL_DISTRICT (DISTRICT) Values ('" + name + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    public bool save_Branchsetup(string bank, string branch, string uid)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "Insert Into TBL_BANK_BRANCH (BANK_ID, BRANCH, UPDATE_BY,UPDATE_DATE)Values('" + bank + "','" + branch + "','" + uid + "','" + date + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public void save_Thana(string Thana, string DisID)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "insert into TBL_THANA (THANA, DISTRICT_ID) Values ('" + Thana + "','" + DisID + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }
    public bool save_banksetup(string p, string uid)
    {

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        //string date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString();
        string sql = "insert into TBL_BANK_NAME(BANK_NAME,CREATE_BY,CREATE_DATE) values('" + p + "','" + uid + "','" + date + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public bool update_banksetup(string p, string uid, string bankid)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "UPDATE TBL_BANK_NAME SET BANK_NAME='" + p + "',CREATE_BY='" + uid + "',CREATE_DATE='" + date + "' WHERE ID='" + bankid + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        if (cmd.ExecuteNonQuery() > 0)
        {

        }

        // }
        //  dr.Close();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return true;
    }
    public void grid_banksetup(GridView gv)
    {
        con();
        SqlDataAdapter da = new SqlDataAdapter("select * from TBL_BANK_NAME", cn);
        DataTable ds = new DataTable();
        da.Fill(ds);
        gv.DataSource = ds;

        gv.DataBind();
    }
    public DataTable GetClientId()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 from ClientInformation";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getChartofAccounts()
    {
        con();
        string id = @"SELECT AccCode, AccName FROM ChartofAcc ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool InsertClient(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO ClientInformation (ClientId,ClientName,ContactNo,Address,COA,BusinessName)values(@ClientId,@ClientName,@ContactNo,@Address,@COA,@BusinessName)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ClientId", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ClientName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@ContactNo", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[3]);
            sqlcmd.Parameters.AddWithValue("@COA", insert[6]);
            sqlcmd.Parameters.AddWithValue("@BusinessName", insert[7]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable LoadEmployee()
    {
        con();
        string id = "select * from ClientInformation inner join ChartOfAcc on ChartOfAcc.AccCode=ClientInformation.COA";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool EditEmployee(string ClientId, string ClientName, string ContactNo, string Address, string BusinessName)
    {
        con();
        string sql = "Update ClientInformation set ClientId=@ClientId,ClientName=@ClientName,ContactNo=@ContactNo,Address=@Address,BusinessName=@BusinessName where ClientId='" + ClientId + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@ClientId", ClientId);
        cmd.Parameters.AddWithValue("@ClientName", ClientName);
        cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
        cmd.Parameters.AddWithValue("@Address", Address);
        cmd.Parameters.AddWithValue("@BusinessName", BusinessName);
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool update_ExpenseType(string Unit, string uid, string p_2)
    {
        con();
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "UPDATE Expense_type SET Expense_name='" + Unit + "',CREATE_BY='" + uid + "',CREATE_DATE='" + date + "' WHERE ID='" + p_2 + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }
    public bool save_ExpenseType(string exp, string uid)
    {
        con();
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "insert into Expense_type(Expense_name,CREATE_BY,CREATE_DATE) values('" + exp + "','" + uid + "','" + date + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }
    public void grid_ExpenseType(GridView gvUnit)
    {
        con();
        SqlDataAdapter da = new SqlDataAdapter("select * from Expense_type", cn);
        DataTable ds = new DataTable();
        da.Fill(ds);
        gvUnit.DataSource = ds;

        gvUnit.DataBind();
    }
    public DataTable GetExpenseVoucherList()
    {
        con();
        string id = @"Select * from ExpenseVoucherList ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    
    public DataTable GetReceiveVoucherList()
    {
        con();
        string id = @"select * from Recive_Payment where  VoucherNo like 'INC%' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetReceiveVoucherList(string voucherNo)
    {
        con();
        string id = @"select * from Recive_Payment where  VoucherNo ='"+ voucherNo + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetExpenseVoucherListByDate(string fromdate, string todate)
    {
        con();
        string id = @"Select * from ExpenseVoucher inner join ExpenseVoucherList on ExpenseVoucherList.Vid=ExpenseVoucher.Vid where ExpenseVoucherList.date>='" + fromdate + "' and ExpenseVoucherList.date<='" + todate + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetExpenseVoucherList(string voucher)
    {
        con();
        string id = @"Select * from ExpenseVoucher inner join ExpenseVoucherList on ExpenseVoucherList.Vid=ExpenseVoucher.Vid where ExpenseVoucherList.Vid='" + voucher + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetReceiveVoucherListByDate(string fromdate, string todate)
    {
        con();
        string id = @"select * from Recive_Payment where  VoucherNo like 'INC%' and Date>='" + fromdate + "' and Date<='" + todate + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetReceiveVoucherReport(string fromdate, string todate)
    {
        con();
        string id = @"select * from Recive_Payment where  VoucherNo like 'INC%' and Date>='" + fromdate + "' and Date<='" + todate + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetExpenseVoucherReport(string fromdate, string todate)
    {
        con();
        string id = @"Select * from ExpenseVoucher inner join ExpenseVoucherList on ExpenseVoucherList.Vid=ExpenseVoucher.Vid where date>='" + fromdate + "' and date<='" + todate + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetExpenseVoucherReportByVoucherNo(string vno)
    {
        con();
        string id = @"Select * from ExpenseVoucher inner join ExpenseVoucherList on ExpenseVoucherList.Vid=ExpenseVoucher.Vid inner join ChartOfAcc on ChartOfAcc.AccCode=ExpenseVoucher.AccID where ExpenseVoucherList.Vid='" + vno + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetReceiveVoucherReportByVoucherNo(string vno)
    {
        con();
        string id = @"Select * from IncomeVoucher inner join IncomeVoucherList on IncomeVoucherList.Vid=IncomeVoucher.Vid inner join ChartOfAcc on ChartOfAcc.AccCode=IncomeVoucher.AccID where IncomeVoucherList.Vid='" + vno + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetOfficer()
    {
        con();
        string id = @"select * from TBL_OFFICER_TYPE";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetOfficerId()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 from TBL_OFFICERINFO";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool InsertOfficer(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO TBL_OFFICERINFO(Officer_Type,Name,Address,Mobile,Guaranter_Name,Guaranter_Mobile,Guaranter_Add,MIC_Check_No,BasicSalary,Date_of_Birth,Date_of_Marriage,Number_of_Children,Previous_Company,OfficerId,relation,NID)values(@Officer_Type,@Name,@Address,@Mobile,@Guaranter_Name,@Guaranter_Mobile,@Guaranter_Add,@MIC_Check_No,@BasicSalary,@Date_of_Birth,@Date_of_Marriage,@Number_of_Children,@Previous_Company,@OfficerId,@relation,@NID)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Name", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Mobile", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Name", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Mobile", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Add", insert[6]);
            sqlcmd.Parameters.AddWithValue("@MIC_Check_No", insert[7]);
            sqlcmd.Parameters.AddWithValue("@BasicSalary", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Date_of_Birth", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Date_of_Marriage", insert[10]);
            sqlcmd.Parameters.AddWithValue("@Number_of_Children", insert[11]);
            sqlcmd.Parameters.AddWithValue("@Previous_Company", insert[12]);
            sqlcmd.Parameters.AddWithValue("@OfficerId", insert[15]);
            sqlcmd.Parameters.AddWithValue("@relation", insert[16]);
            sqlcmd.Parameters.AddWithValue("@NID", insert[17]);
            sqlcmd.Parameters.AddWithValue("@Officer_Type", insert[18]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetDeignation()
    {
        con();
        sqlcmd = new SqlCommand("select * from TBL_OFFICER_TYPE", cn);
        SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    public DataTable GetAllOfficer()
    {
        con();
        sqlcmd = new SqlCommand(@"select * from TBL_OFFICERINFO inner join TBL_OFFICER_TYPE on TBL_OFFICER_TYPE.OFF_TYPE_NAME= TBL_OFFICERINFO.officer_type ", cn);
        SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }

    public bool UpdateEmployee(string Employeeid, string Project)
    {
        con();
        string sql = " Update TBL_OFFICERINFO set ProjcetName='" + Project + "' where  OfficerId='" + Employeeid + "' ";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }
    public DataTable GetOfficerById(string dId)
    {
        con();
        string id = @"Select * from TBL_OFFICERINFO inner join TBL_OFFICER_TYPE on TBL_OFFICER_TYPE.id=TBL_OFFICERINFO.Officer_Type where OfficerId='" + dId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateOfficer(string[] insert)
    {
        try
        {
            con();
            string Update = "Update TBL_OFFICERINFO set OfficerId='" + insert[0] + "', Name='" + insert[1] + "',Address='" + insert[11] + "',Mobile='" + insert[2] + "',Guaranter_Name='" + insert[3] + "',Guaranter_Mobile='" + insert[4] + "',Guaranter_Add='" + insert[5] + "',MIC_Check_No='" + insert[6] + "',Date_of_Birth='" + insert[7] + "',Date_of_Marriage='" + insert[8] + "',Number_of_Children='" + insert[9] + "',Previous_Company='" + insert[10] + "',OfficerId='" + insert[0] + "', Officer_Type='" + insert[12] + "' where OfficerId='" + insert[16] + "'";

            sqlcmd = new SqlCommand(Update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetAllOfficerbyDesignation(string desig)
    {
        con();
        sqlcmd = new SqlCommand(@"select * from TBL_OFFICERINFO join TBL_OFFICER_TYPE on TBL_OFFICER_TYPE.OFF_TYPE_NAME= TBL_OFFICERINFO.officer_type   where TBL_OFFICERINFO.Officer_Type='" + desig + "'", cn);
        SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }

    public bool UpdateAccessoriesPrice(string itemname, string Model, string price)
    {
        try
        {
            con();
            string Update = "Update AccessoriesName set Price='" + Convert.ToDecimal(price) + "' where AccessoriesName='" + itemname + "' and Model='" + Model + "'";

            sqlcmd = new SqlCommand(Update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertOrdertoFactory(string voucher, string productname, string Model, string productid, string productquantity, string date, string unit, string DeliveryDate, string comments)
    {
        con();
        string insert = "INSERT INTO OrderToFactory (OrderID,ProductName,Model,ProductID,Quantity,Unit,Date,Status,DeliverDate,Comments)values('" + voucher + "','" + productname + "','" + Model + "', '" + productid + "','" + productquantity + "','" + unit + "','" + date + "','Not Delivered','" + DeliveryDate + "','" + comments + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable GetOrderVoucher()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(ID),0)+1 from OrderToFactory";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }
    public bool UpdateAmountForlabourBySelect(string lbldate, string lblLabourName, string txtAmount, string txtDueAmount, string LabourID, string ID, string MonthFor)
    {
        con();
        string sql = " Update SalarySheet set Date='" + lbldate + "',Payment='" + txtAmount + "',Due='" + txtDueAmount + "',MonthFor='" + MonthFor + "'  where ID='" + ID + "' ";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }

    public bool SaveAmountForlabourBySelect(string lbldate, string lblLabourName, string txtAmount, string DueAmount, string LabourID, string Basicsalary, string MonthFor)
    {
        con();
        string sql = " Insert into SalarySheet (Date,LabourName,Payment,Due,LabourID,BasicSalary,MonthFor)Values('" + lbldate + "','" + lblLabourName + "','" + txtAmount + "','" + DueAmount + "','" + LabourID + "','" + Basicsalary + "','"+Convert.ToDateTime(MonthFor)+"') ";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }

    public DataTable getEmployee()
    {
        con();
        string id = @"Select * from TBL_OFFICERINFO";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool EmployeeDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from TBL_OFFICERINFO where id=@id";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getEmployeebyid(long id)
    {
        con();
        string query = @" select  * from TBL_OFFICERINFO where id='" + id + "'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateEmployee(long id, string[] insert)
    {
        try
        {
            con();
            string Save = "Update TBL_OFFICERINFO set Officer_Type=@Officer_Type,Name=@Name,Address=@Address,Mobile=@Mobile,Guaranter_Name=@Guaranter_Name,Guaranter_Mobile=@Guaranter_Mobile,Guaranter_Add=@Guaranter_Add,Number_of_Children=@Number_of_Children,BasicSalary=@BasicSalary where id=@id ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@Officer_Type", insert[18]);
            sqlcmd.Parameters.AddWithValue("@Name", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Mobile", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Name", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Add", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Guaranter_Mobile", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Number_of_Children", insert[11]);
            sqlcmd.Parameters.AddWithValue("@BasicSalary", insert[8]);


            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertProductCosting(string productname, string productID, string Accessoriesname, string quantity, string price, string totalprice, string costingprice, string date)
    {
        con();
        string insert = "INSERT INTO ProductCosting (ProductName,ProductID,AccessoriesName,Quantity,Price,AccessoriesTotal,TotalProductCosting,Date)values('" + productname + "','" + productID + "', '" + Accessoriesname + "','" + quantity + "','" + price + "','" + totalprice + "','" + costingprice + "','" + date + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdatePPrice(string productname, string totalprice)
    {
        con();
        string insert = "Update ProductName set CostingPrice='" + totalprice + "' where ProductName='" + productname + "'";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable GetSalesCostReport()
    {
        con();
        string id = @"Select * from ProductCosting";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBasicSalary(string p)
    {
        con();
        string id = @"Select * from TBL_OFFICERINFO   where TBL_OFFICERINFO.OfficerId='" + p + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetDueSalary(string p)
    {
        con();
        string id = @"Select SUM(Due) as Due from SalarySheet  where SalarySheet.LabourID='" + p + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable SamedateCheck(string Labourname, string labourID, string todate)
    {
        con();
        string id = @"Select * from SalarySheet where SalarySheet.LabourName='" + Labourname + "' and LabourID='" + labourID + "' and Date='" + todate + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetEmployeeIdForAccounts()
    {
        con();
        string id = @"Select * from TBL_OFFICERINFO where AccCode is null ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetEmployeeId()
    {
        con();
        string id = @"Select * from TBL_OFFICERINFO ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getAllOrdersFromfactory()
    {
        con();
        string id = @"Select * from OrderToFactory inner join ProductImages on OrderToFactory.ProductID=ProductImages.ProId and OrderToFactory.Model=ProductImages.MId  where Status='Not Delivered' order by OrderID";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getAllOrdersFromByOrderId(string orderNo)
    {
        con();
        string id = @"Select * from OrderToFactory inner join ProductImages on OrderToFactory.ProductID=ProductImages.ProId and OrderToFactory.Model=ProductImages.MId  where Status='Not Delivered' and OrderId='" + orderNo + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getAllOrdersAccList()
    {
        con();
        string id = @"Select * from ItemForProduction where status is null";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool OrderDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from OrderToFactory where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool OrderListDeletebyid(string ID)
    {
        try
        {
            con();
            string Save = "Delete from ItemForProduction where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateOrderSatatus(string lbldate, string OrderID, string Invoiceno)
    {
        try
        {
            con();
            string Save = "Update OrderToFactory set Status=@Status,DeliverDate=@DeliverDate,InvoiceNo=@InvoiceNo where id=@OrderID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@OrderID", OrderID);
            sqlcmd.Parameters.AddWithValue("@Status", "Delivered");
            sqlcmd.Parameters.AddWithValue("@DeliverDate", lbldate);
            sqlcmd.Parameters.AddWithValue("@InvoiceNo", Invoiceno);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateOrderListSatatus(string lbldate, string OrderID)
    {
        try
        {
            con();
            string Save = "Update ItemForProduction set status=@Status,Date=@DeliverDate where ID=@OrderID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@OrderID", OrderID);
            sqlcmd.Parameters.AddWithValue("@Status", "Received");
            sqlcmd.Parameters.AddWithValue("@DeliverDate", lbldate);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateProductName(string[] insert)
    {
        try
        {
            con();
            string Save = "Update ProductName set ProductName=@ProductName,Model=@Model,CostingPrice=@CostingPrice,PDescription=@PDescription where PNID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ProductName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Model", insert[2]);
            sqlcmd.Parameters.AddWithValue("@CostingPrice", insert[3]);
            sqlcmd.Parameters.AddWithValue("@PDescription", insert[4]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool updatephoto(string PID, string Pname, string Extention, string lblPIMGID)
    {
        try
        {
            con();
            string Save = "update AccessoriesImages set PID='" + PID + "', Name = '" + Pname.ToString().Trim() + "',Extention='" + Extention + "' where PIMGID='" + lblPIMGID + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable SelectProductMaxID()
    {
        con();
        string id = @"select ISNULL(Max(PNID),0) as PID from ProductName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool deletefromProductImage(string ProductID)
    {
        con();
        string insertreginfo = "Delete from ProductImages where PID='" + ProductID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool deletefromAccessoriesImage(string ProductID)
    {
        con();
        string insertreginfo = "Delete from AccessoriesImages where PID='" + ProductID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateAccessoriesName(string[] insert)
    {
        try
        {
            con();
            string Save = "Update AccessoriesName set AccessoriesName=@AccessoriesName,CategoryName=@CategoryName,Model=@Model,Price=@Price where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@AccessoriesName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@CategoryName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Model", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[4]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable SelectAccessoriesMaxID()
    {
        con();
        string id = @"select ISNULL(Max(ID),0) as PID from AccessoriesName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetPriceFromAccessories(string itemname, string model)
    {
        con();
        string query = @" select * from AccessoriesName where AccessoriesName='" + itemname + "' and Model='" + model + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProductSalesPrice(string itemname, string model)
    {
        con();
        string query = @" select * from ProductName where ProductName='" + itemname + "' and Model='" + model + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public bool InsertSalesItem(string clientid, string voucher, string itemname, string Model, string price, string unit, string quantity, string total, string Itemname, string date)
    {
        try
        {
            con();
            string insert = "INSERT INTO SalesVoucherItem (ClientId,VoucherNo,Item,Model,Price,Unit,Quantity,amount,ItemName,Date)values(@ClientId,@VoucherNo,@Item,@Model,@Price,@Unit,@Quantity,@amount,@ItemName,@Date)";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.Parameters.AddWithValue("@ClientId", clientid);
            sqlcmd.Parameters.AddWithValue("@VoucherNo", voucher);
            sqlcmd.Parameters.AddWithValue("@Item", itemname);
            sqlcmd.Parameters.AddWithValue("@Model", Model);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.Parameters.AddWithValue("@Unit", unit);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@amount", total);
            sqlcmd.Parameters.AddWithValue("@ItemName", Itemname);
            sqlcmd.Parameters.AddWithValue("@Date", date);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetSalesAccessories()
    {
        con();
        string sql = @"select * from SalesVoucherItem where ItemName='ACC'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetdatefilterSalesProduct(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from SalesVoucherItem  where Date >= '" + date1 + "' and Date <= '" + date2 + "' and ItemName='Product'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSalesProduct()
    {
        con();
        string sql = @"select * from SalesVoucherItem where ItemName='Product'";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetRecieveAmountbydateandclient(string clientid, DateTime date1, DateTime date2)
    {
        con();
        string sql = @" select * from Recive_Payment where ClientId='" + clientid + "' and Date >='" + date1 + "' and Date <= '" + date2 + "' and Trans_Type='Cash' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetdatefilterSalesAccessories(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from SalesVoucherItem  where Date >= '" + date1 + "' and Date <= '" + date2 + "' and ItemName='ACC'   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetClientname()
    {
        con();
        string id = @"Select * from ClientInformation where AccCode like '010101%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool insertpaymentreceive(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Debit,Debitstatus)values('" + vname + "','" + name + "', '" + clientid + "','" + date + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','Ok')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable GetVandorById(string clId)
    {
        con();
        string id = @"Select * from VendorName where AccCode='" + clId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetdatefilterSalary(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select LabourName,LabourID,BasicSalary,MonthFor,Date, SUM(Payment) as Payment ,SUM(Due) as Due from SalarySheet  where Date >= '" + date1 + "' and Date <= '" + date2 + "' group by LabourName,LabourID,BasicSalary,BasicSalary,MonthFor,Date ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetSalesbydateandclient(string clientid, DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select SalesVoucherItem.VoucherNo,SalesVoucherItem.ClientId,SalesVoucherItem.date,SalesVoucherList.ClientName, SUM(amount) as Totalsum  from SalesVoucherItem inner join  SalesVoucherList on SalesVoucherList.VoucherNo=SalesVoucherItem.VoucherNo where SalesVoucherItem.ClientId='" + clientid + "' and SalesVoucherItem.date >='" + date1 + "' and SalesVoucherItem.date <= '" + date2 + "' group by SalesVoucherItem.VoucherNo,SalesVoucherItem.ClientId,SalesVoucherItem.date,SalesVoucherList.ClientName ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetpurchasedbydateandVendor(string clientid, DateTime date1, DateTime date2)
    {
        con();
        string sql = @" select PurchaseAccessories.VoucherNo,productItem,quantity,unit,Price,ProductCost,Total , SUM(Total) as Totalsum from PurchaseAccessories inner join PurchaseAccessoriesSupplier on PurchaseAccessoriesSupplier.VoucherNo=PurchaseAccessories.VoucherNo where SupplierID='" + clientid + "' and CREATE_DATE >='" + date1 + "' and CREATE_DATE <= '" + date2 + "' group by PurchaseAccessories.VoucherNo,productItem,quantity,unit,Price,ProductCost,Total  ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPriceFromAccessories(string productid)
    {
        con();
        string query = @" select  * from AccessoriesName where AccessoriesName='" + productid + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateToProductPrice(string ProductId, string Price)
    {
        try
        {
            con();
            string Save = "Update ProductName set CostingPricing=@CostingPricing  where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ProductId);
            sqlcmd.Parameters.AddWithValue("@CostingPricing", Price);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetProductdetailsbyid(string ProductID)
    {
        con();
        string sql = @"select * from ProductName where PNID='" + ProductID + "' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetProductcostingbyid(string ProductID)
    {
        con();
        string sql = @"select * from ProductCosting where ProductID='" + ProductID + "' ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool EditProductsellprice(string[] insert)
    {
        try
        {
            con();
            string Save = "Update ProductName set SellPrice=@SellPrice where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@SellPrice", insert[1]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateExistingProduct(string Itemname, double qty, DateTime dateTime)
    {
        try
        {
            con();
            string Save = "Update PresentStockItems set PresentStock=@PresentStock,LastUpdateDate=@LastUpdateDate where ItemName=@ItemName ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ItemName", Itemname);
            sqlcmd.Parameters.AddWithValue("@PresentStock", qty);

            sqlcmd.Parameters.AddWithValue("@LastUpdateDate", dateTime);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable LoadBalanceReportByAcc(string accountId)
    {
        con();
        string id = @"select ca.Id,ca.AccCode,ca.AccDec, ca.AccName,sum(rp.Credit) as crAmount, sum(rp.Debit) drAmount from ChartOfAcc ca left join [Recive_Payment] rp on  rp.ChartofAccountId=ca.AccCode  where ca.AccCode ='" + accountId + "' group by ca.AccCode,ca.AccDec, ca.AccName,ca.Id order by ca.Id";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProductionReportByDay(DateTime date1, DateTime date2)
    {
        con();
        string sql = @"select * from OrderToFactory where OrderToFactory.DeliverDate >= '" + date1 + "' and OrderToFactory.DeliverDate <= '" + date2 + "' and InvoiceNo!=''   ";

        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetProductiondetailsbyProductName(string selectedValue, DateTime date1, DateTime date2)
    {
        con();
        string sql = @" select * from OrderToFactory where OrderToFactory.ProductID='" + selectedValue + "' and OrderToFactory.DeliverDate >= '" + date1 + "' and OrderToFactory.DeliverDate <= '" + date2 + "' and InvoiceNo!=''   ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetFactoryorderInvoiceNo()
    {
        con();
        string id = @"Select ISNULL(Max(InvoiceNo),0)+1 as ID from OrderToFactory";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetImage(string Pid, string p_2)
    {
        con();
        string id = @"Select * from ProductImages inner join ProductName on ProductName.PNID=ProductImages.PID  where  ProId='" + Pid + "' and MId='" + p_2 + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateClientAcc(string AccCode, string ClientName)
    {
        con();
        string insert = "Update ClientInformation set AccCode='" + AccCode + "' where ClientName='" + ClientName + "'";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdateVendorAcc(string AccCode, string ClientName)
    {
        con();
        string insert = "Update VendorName set AccCode='" + AccCode + "' where VendorName='" + ClientName + "'";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdateEmployeeAcc(string AccCode, string ClientName)
    {
        con();
        string insert = "Update TBL_OFFICERINFO set AccCode='" + AccCode + "' where Name='" + ClientName + "'";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    public DataTable GetAccountsPayable()
    {
        con();
        string id = @"select * from ChartOfAcc where ParentAccId like '01020%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable Purchasetotal(string SupplierID)
    {
        con();
        string sql = "select SUM(Debit) as TotalPurchased from  Recive_Payment where ChartofAccountId='" + SupplierID + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable totalPaidamount(string SupplierID)
    {
        con();
        string sql = "select SUM(Credit) as PaidAmount from  Recive_Payment where ChartofAccountId='" + SupplierID + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool insertRecivevoucher(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string COAname, string COAID)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Debit,Debitstatus,Client_Name,ChartofAccount,ChartofAccountId,DrCr,VoucherType)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','Ok','" + name + "','" + COAname + "','" + COAID + "','0','Receive')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertIncomeVoucherList(string voucher, string comment, string date, string amount)
    {
        con();
        string insert = "INSERT INTO IncomeVoucherList (Vid,Date,Comment,TotalAmount)values('" + voucher + "', '" + date + "','" + comment + "','" + amount + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool insertpaymentvoucher(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string COAname, string COAID)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,Payment_Client,ClientId,date,BankName,BranchName,Trans_Type,Credit,Creditstatus,Client_Name,ChartofAccount,ChartofAccountId,DrCr,VoucherType)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','Ok','" + name + "','" + COAname + "','" + COAID + "','0','Payment')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertExpenseVoucher(string vendorid, string voucher, string description, string date, string amount)
    {
        con();
        string insert = "INSERT INTO ExpenseVoucher (Vid,AccID,ExpDescription,Date,ExpAmount)values('" + voucher + "','" + vendorid + "', '" + description + "','" + Convert.ToDateTime(date) + "','" + amount + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable GetAccountsReciveable()
    {
        con();
        string id = @"select * from ChartOfAcc where ParentAccId like '010101%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool InsertExpenseVoucherList(string TrRype, string voucher, string comment, string date, string amount)
    {
        con();
        string insert = "INSERT INTO ExpenseVoucherList (Vid,Date,Comment,TotalAmount,TRType)values('" + voucher + "', '" + date + "','" + comment + "','" + amount + "','" + TrRype + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertIncomeVoucher(string vendorid, string voucher, string description, string date, string amount)
    {
        con();
        string insert = "INSERT INTO IncomeVoucher (Vid,AccID,IncDescription,Date,IncAmount)values('" + voucher + "','" + vendorid + "', '" + description + "','" + Convert.ToDateTime(date) + "','" + amount + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    public bool InsertRecive_PaymentFromSales(string COAID,string ProductName,string ClientName, string voucherno, string date, string amount)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (Trans_Type,VoucherNo,Receive_Client,ClientId,Client_Name,date,Credit,ChartofAccount,ChartofAccountId,DrCr,VoucherType)values('Sales','" + voucherno + "','" + ProductName + "', '" + COAID + "','" + ClientName + "','" + Convert.ToDateTime(date) + "','" + amount + "','From Acc Sales','" + COAID + "','Cr','Sales')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    
    public bool InsertRecive_PaymentFromPurchase(string COAID,string ProductName, string SupplierName, string voucherno, string date, string amount)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (Trans_Type,VoucherNo,ClientId,Payment_Client,Client_Name,date,Debit,ChartofAccount,ChartofAccountId,DrCr,VoucherType)values('Purchase','" + voucherno + "', '" + COAID + "','" + ProductName + "','"+SupplierName+"','" + Convert.ToDateTime(date) + "','" + amount + "','From Purchase','" + COAID + "','Dr','Purchase')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertRecive_PaymentFromSalary(string COAID, string voucherno, string date, string amount)
    {
        con();
        string insert = "INSERT INTO Recive_Payment (VoucherNo,ClientId,date,Credit,ChartofAccount,ChartofAccountId)values('" + voucherno + "', '" + COAID + "','" + Convert.ToDateTime(date) + "','" + amount + "','From Salary','" + COAID + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }

    public DataTable GetCahBalance()
    {
        con();
        string id = @"select SUM(Credit) as Credit, SUM(Debit) as Debit, (SUM(Debit)-SUM(Credit)) as Balance from Recive_Payment where Trans_Type='Cash'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBankBalance()
    {
        con();
        string id = @"select SUM(Credit) as Credit, SUM(Debit) as Debit, (SUM(Debit)-SUM(Credit)) as Balance from Recive_Payment where Trans_Type='Bank'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetTRType()
    {
        con();
        string id = @"SELECT *  FROM ChartOfAcc where AccCode like'0101070%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCahBalanceCr(string TRTypr)
    {
        con();
        string id = @"select ISNULL(SUM(Credit),0) as CrAmount from Recive_Payment where Trans_Type='" + TRTypr + "' and DrCr='0' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCahBalanceDr(string TRTypr)
    {
        con();
        string id = @"select ISNULL(SUM(Debit),0) as CrAmount from Recive_Payment where Trans_Type='" + TRTypr + "' and DrCr='0' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    //Bank Transfer Start
    public bool insertTransfervoucherCR(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string COAname, string COAID)
    {
        con();
        string insertDr = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Credit,Creditstatus,Client_Name,ChartofAccount,ChartofAccountId,DrCr)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','Ok','" + name + "','" + COAname + "','" + COAID + "','0')";
        SqlCommand com = new SqlCommand(insertDr, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool insertTransfervoucherDR(string trttype, string bank, string branch, string name, string clientid, string vname, string date, string txtPayAmount, string COAname, string COAID)
    {
        con();
        string insertDr = "INSERT INTO Recive_Payment (VoucherNo,Receive_Client,ClientId,date,BankName,BranchName,Trans_Type,Debit,Creditstatus,Client_Name,ChartofAccount,ChartofAccountId,DrCr)values('" + vname + "','" + name + "', '" + clientid + "','" + Convert.ToDateTime(date) + "','" + bank + "','" + branch + "','" + trttype + "','" + txtPayAmount + "','Ok','" + name + "','" + COAname + "','" + COAID + "','0')";
        SqlCommand com = new SqlCommand(insertDr, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable GetPaymetReceiveId()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from Recive_Payment";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    //Bank Transfer End


    ///////////////////////////////
    public DataTable getFirstSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='1'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getSecondSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='2'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getThirdSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='3'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getFourthSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='4'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getFifthSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='5'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getTitleSetList()
    {
        con();
        string id = @"select * from TitleSet";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetMenuData()
    {
        con();
        string id = @"Select *  from Menu where MenuLevel=0";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetMenuData(string Category)
    {
        con();
        string id = @"Select *  from Menu where ParentId='" + Category + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatFoodandcipboard()
    {
        con();
        string id = @"Select *  from Menu where ParentId=1";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSubcatFresh()
    {
        con();
        string id = @"Select *  from Menu where ParentId=2";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatdrinkandbreverage()
    {
        con();
        string id = @"Select *  from Menu where ParentId=4";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatdairyandchese()
    {
        con();
        string id = @"Select *  from Menu where ParentId=8";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatFrozenfood()
    {
        con();
        string id = @"Select *  from Menu where ParentId=9";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatPackaginganddisposal()
    {
        con();
        string id = @"Select *  from Menu where ParentId=11";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetFoodcupboardNewArrival()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='2' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetFoodAndCupbordBestsellers()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFoodAndCupbordDeal()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }


    public DataTable GetFreshNewArrival()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='3' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFreshBestSellers()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetFreshDeal()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFrozenDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='9' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable selectinfocustomer(string[] loginfo)
    {
        con();
        string id = @"select * from CustomerRegistration   where Email='" + loginfo[0] + "' and Password='" + loginfo[1] + "'  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertRegistrationInfo(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into CustomerRegistration (FirstName,MiddleName,LastName,Country,PostCode,Phone,Landline,Email,Password) values (@FirstName,@MiddleName,@LastName,@Country,@PostCode,@Phone,@Landline,@Email,@Password)";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@FirstName", insert[0]);
            sqlcmd.Parameters.AddWithValue("@MiddleName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@LastName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Country", insert[3]);
            sqlcmd.Parameters.AddWithValue("@PostCode", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Landline", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[7]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[8]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetProductByPIDsingleimage(string PID)
    {
        con();
        string sql = @"select top 1 * from ProductImages where ProductImages.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetProductByPIDthreeimage(string PID)
    {
        con();
        string sql = @"select  * from ProductImages where ProductImages.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetProductInfoByPID(string PID)
    {
        con();
        string sql = @"select  * from ProductImages inner join ProductName on  ProductImages.PID=ProductName.PNID where  ProductImages.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetOrderid()
    {
        con();
        string sql = @"select id from TblOrder order by id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool SaveToCusReg(string orderid, string customerid, string txtAddress, string txtPhone, string txtemail, string txtFullName)
    {
        try
        {
            con();
            string Save = "INSERT INTO CustomerReg(Cusid,FullName,Address,Phone,Orderid,OrderDate,Email)values(@Cusid,@FullName,@Address,@Phone,@Orderid,@OrderDate,@Email)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Cusid", customerid);
            sqlcmd.Parameters.AddWithValue("@FullName", txtFullName);
            sqlcmd.Parameters.AddWithValue("@Address", txtAddress);
            sqlcmd.Parameters.AddWithValue("@Phone", txtPhone);
            sqlcmd.Parameters.AddWithValue("@Orderid", orderid);
            sqlcmd.Parameters.AddWithValue("@Email", txtemail);
            sqlcmd.Parameters.AddWithValue("@OrderDate", Convert.ToDateTime(DateTime.Now).Date.ToString("d"));

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool SaveOrder(string orderid, string pid, string pname, string quantity, string price, string lbltotal, string customerid, string txtFullName, string txtPhone, string date)
    {
        try
        {
            con();
            string Save = "INSERT INTO TblOrder(orderid,Customerid,Pid,Pname,Quantity,Total,Price,Status,Date,CustomerName,CustomerPhone)values(@orderid,@Customerid,@Pid,@Pname,@Quantity,@Total,@Price,@Status,@Date,@CustomerName,@CustomerPhone)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@orderid", orderid);
            sqlcmd.Parameters.AddWithValue("@Customerid", customerid);
            sqlcmd.Parameters.AddWithValue("@Pid", pid);
            sqlcmd.Parameters.AddWithValue("@Pname", pname);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@Total", lbltotal);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.Parameters.AddWithValue("@Status", "Not Delivered");
            sqlcmd.Parameters.AddWithValue("@Date", date);
            sqlcmd.Parameters.AddWithValue("@CustomerName", txtFullName);
            sqlcmd.Parameters.AddWithValue("@CustomerPhone", txtPhone);
       
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getOrders()
    {
        string id = "select * from TblOrder where Status='Not Delivered'";
        // string id = "select Id,MenuText,MenuLevel,ParentId,(select MenuText from Menu where Id='2' ) as new  from Menu where MenuLevel !='0'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool updateStatus(string ID)
    {
        try
        {
            con();
            string update = "Update TblOrder set Status='Done' where ID='" + ID + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetallCategories()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from Menu where MenuLevel='0'";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable getSubCategoryByCategort(string ID)
    {
        con();
        string id = @"select * from Menu where ParentId='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetProductByCategoryname(string CatID)
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='"+ CatID + "' order by C.PID desc ) C";
        string sql = @"Select * from ProductName B cross apply(select top 1 * from ProductImages C where C.PID = B.PNID  order by C.PID desc ) C where B.Category='" + CatID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetProductByCategorynameandSubcategory(string CatID, string Subcat)
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='"+ CatID + "' order by C.PID desc ) C";
        string sql = @"Select * from ProductName B cross apply(select top 1 * from ProductImages C where C.PID = B.PNID  order by C.PID desc ) C  where B.Category='" + CatID + "' and SubCategory='"+Subcat+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool UpdateSubCategoryname(string SubCategoryId, string SubCategoryName, string Menulevel, string ParentID)
    {
        try
        {
            con();
            string update = "Update Menu set MenuText='" + SubCategoryName + "',MenuLevel='" + Menulevel + "',ParentId='" + ParentID + "'  where Id='" + SubCategoryId + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertSubCategory(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Menu(MenuText,MenuLevel,ParentId)values(@MenuText,@MenuLevel,@ParentId)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@MenuText", insert[1]);
            sqlcmd.Parameters.AddWithValue("@MenuLevel", insert[2]);
            sqlcmd.Parameters.AddWithValue("@ParentId", insert[3]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool InsertCategory(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Menu(MenuText,MenuLevel)values(@MenuText,@MenuLevel)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@MenuText", insert[1]);
            sqlcmd.Parameters.AddWithValue("@MenuLevel", '0');

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable SelectMaxCatID()
    {
        con();
        string id = @"select ISNULL(Max(Id),0) as CatID from Menu";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable LoadCategoryname()
    {
        string id = "select * from Menu where MenuLevel='0'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getSubCategoryid(long ID)
    {
        con();
        string id = @"select * from Menu where Id='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateCategoryname(string[] insert)
    {
        try
        {
            con();
            string update = "Update Menu set MenuText='" + insert[1] + "' where Id='" + insert[0] + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable getCategory()
    {
        string id = "select * from Menu where MenuLevel ='0'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getSubCategory()
    {
        string id = "select * from Menu where MenuLevel !='0'";
        // string id = "select Id,MenuText,MenuLevel,ParentId,(select MenuText from Menu where Id='2' ) as new  from Menu where MenuLevel !='0'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool save_Type(string div, string uid)
    {
        con();
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "insert into TBL_OFFICER_TYPE(OFF_TYPE_NAME,CREATE_BY,CREATE_DATE) values('" + div + "','" + uid + "','" + date + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }
    public bool update_OffType(string div, string uid, string p_2)
    {
        con();
        string date = DateTime.Today.ToString("dd/MMM/yyyy");
        string sql = "UPDATE TBL_OFFICER_TYPE SET OFF_TYPE_NAME='" + div + "',CREATE_BY='" + uid + "',CREATE_DATE='" + date + "' WHERE ID='" + p_2 + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        return true;
    }
    public void grid_Off_Type(GridView gvUnit)
    {
        con();
        SqlDataAdapter da = new SqlDataAdapter("select * from TBL_OFFICER_TYPE", cn);
        DataTable ds = new DataTable();
        da.Fill(ds);
        gvUnit.DataSource = ds;

        gvUnit.DataBind();
    }
    public bool UpdateRecivevoucher(string IncomeType, string Voucher, string Payment)
    {
        con();
        string insertCr = "Update Recive_Payment set Trans_Type='" + IncomeType + "',Debit='" + Payment + "' where  VoucherNo='" + Voucher + "'  ";
        //string insertCr = "Update Recive_Payment set Trans_Type='" + IncomeType + "',Debit='" + Payment + "' where DrCr='Dr' and VoucherNo='" + Voucher + "'  ";
        SqlCommand com = new SqlCommand(insertCr, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdateIncomeVoucher(string inctype, string voucher, string payment, string Desc, string rownumber)
    {
        con();
        string insert = "Update  IncomeVoucher set IncDescription='" + Desc + "',IncAmount='" + payment + "' where  Vid='" + voucher + "'  and  id='" + rownumber + "' ";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdateIncomeVoucherList(string inctype, string voucher, string payment, string Desc, string rownumber)
    {
        con();
        string insert = "Update  IncomeVoucherList set TotalAmount='" + payment + "' where  Vid='" + voucher + "' ";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool UpdateIncomeVoucherList(string voucher, string comment, string date, string Totalamount)
    {
        con();
        string insert = "Update  IncomeVoucherList set TotalAmount='" + Totalamount + "',Comment='" + comment + "' where Vid='" + voucher + "' ";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool IncomeVoucherDeletebyvoucherfromexpence(string Vid)
    {
        try
        {
            con();
            string Save = "Delete from IncomeVoucher where Vid=@Vid";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Vid", Vid);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool IncomeVoucherListDeletebyvoucherfromexpenceList(string Vid)
    {
        try
        {
            con();
            string Save = "Delete from IncomeVoucherList where Vid=@Vid";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Vid", Vid);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool PaymentVoucherDeletebyvoucherfromRecivePayment(string Vid)
    {
        try
        {
            con();
            string Save = "Delete from Recive_Payment where VoucherNo=@VoucherNo";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@VoucherNo", Vid);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable getAllVouchername()
    {
        con();
        string id = @"Select distinct VoucherNo from Recive_Payment where VoucherNo like 'INC%' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetRecivedetailsbyclient(string voucherno)
    {
        con();
        string query = "select  distinct IncomeVoucherList.*, IncomeVoucher.id as RowNumber, IncomeVoucher.IncAmount as Column1, Recive_Payment.Trans_Type as Column2, IncomeVoucher.IncDescription as Column3,IncomeVoucher.id as Column4 from IncomeVoucher inner join IncomeVoucherList on IncomeVoucherList.Vid = IncomeVoucher.Vid inner join Recive_Payment on IncomeVoucherList.Vid = Recive_Payment.VoucherNo where  IncomeVoucher.Vid='" + voucherno + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAccountsPayableForCashBook()
    {
        con();
        string id = @"select * from ChartOfAcc where ParentAccId like '010201%' order by AccName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool PaymentVoucherDeletebyvoucherfromexpence(string Vid)
    {
        try
        {
            con();
            string Save = "Delete from ExpenseVoucher where Vid=@Vid";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Vid", Vid);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool PaymentVoucherDeletebyvoucherfromexpenceList(string Vid)
    {
        try
        {
            con();
            string Save = "Delete from ExpenseVoucherList where Vid=@Vid";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Vid", Vid);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdatePaymentvoucher( string Vendor, string VendorId, string Voucher, string Payment, string date, string rownumber)
    {
        con();
        string insertCr = "Update Recive_Payment set Credit='" + Payment + "', Date='" + Convert.ToDateTime(date) + "',Payment_Client='" + Vendor + "', Client_Name='" + Vendor + "', ClientId='" + VendorId + "' where  ID='" + rownumber + "' ";
        SqlCommand com = new SqlCommand(insertCr, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertExpenseVoucher1(string vendorid, string voucher, string description, string date, string amount)
    {
        con();
        string insert = "INSERT INTO ExpenseVoucher (Vid,AccID,ExpDescription,Date,ExpAmount)values('" + voucher + "','" + vendorid + "', '" + description + "','" + Convert.ToDateTime(date) + "','" + amount + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public bool InsertExpenseVoucherList1(string TrRype, string voucher, string comment, string date, string amount)
    {
        con();
        string insert = "INSERT INTO ExpenseVoucherList (Vid,Date,Comment,TotalAmount,TRType)values('" + voucher + "', '" + date + "','" + comment + "','" + amount + "','" + TrRype + "')";
        SqlCommand com = new SqlCommand(insert, cn);
        com.ExecuteNonQuery();
        return true;
    }
    public DataTable getAllPaymentVoucher()
    {
        con();
        string id = @"Select distinct VoucherNo from Recive_Payment where VoucherNo like 'EXP%' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetPaymentdetailsbyclient(string voucherno)
    {
        con();
        string query = "select Recive_Payment.*, ExpenseVoucherList.Comment, ExpenseVoucher.ExpDescription  from Recive_Payment join ExpenseVoucherList on Recive_Payment.VoucherNo = ExpenseVoucherList.vid join ExpenseVoucher on Recive_Payment.VoucherNo = ExpenseVoucher.vid where Recive_Payment.VoucherNo= '" + voucherno + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSaleVoucherList()
    {
        con();
        string id = @"select * from SalesVoucherList";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSaleVoucherList(string fromdate, string todate)
    {
        con();
        string id = @"select * from SalesVoucherList where  Date>='" + fromdate + "' and Date<='" + todate + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSaleVoucherList(string voucher)
    {
        con();
        string id = @"select * from SalesVoucherList Where VoucherNo='" + voucher + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetPurchaseVoucherList()
    {
        con();
        string id = @"select * from PurchaseAccessoriesSupplier";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetPurchaseVoucherList(string fromdate, string todate)
    {
        con();
        string id = @"select * from PurchaseAccessoriesSupplier where Date>='" + fromdate + "' and Date<='" + todate + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetPurchaseVoucherList(string voucher)
    {
        con();
        string id = @"select * from PurchaseAccessoriesSupplier where VoucherNo='" + voucher + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProductPurchaseList()
    {
        con();
        string id = @"select * from FinishedGoodsVoucher";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSalesVoucherList1(string voucher)
    {
        con();
        string id = @"Select * from SalesVoucherList Where VoucherNo='" + voucher + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSalesVoucherList2(string voucher)
    {
        con();
        string id = @"select Salesid RowNumber, item Column1,model Column2,Unit Column3,price Column4,Quantity Column5, amount Column6 from SalesVoucherItem Where VoucherNo='" + voucher + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool DeleteSaleVoucher(string voucher)
    {
        con();
        string Save1 = "Delete from SalesVoucherList where voucherNo='" + voucher+"'";
        sqlcmd = new SqlCommand(Save1, cn);
        sqlcmd.ExecuteNonQuery();

        string Save2 = "Delete from SalesVoucherItem where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save2, cn);
        sqlcmd.ExecuteNonQuery();

        string Save3 = "Delete from Recive_Payment where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save3, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public DataTable GetPurchaseAcc1(string voucher)
    {
        con();
        string id = @"Select * from PurchaseAccessoriesSupplier Where VoucherNo='" + voucher + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetPurchaseAcc2(string voucher)
    {
        con();
        string id = @"select Id RowNumber, productItem Column1,quantity Column2,unit Column3,Price Column4,Total Column6,model Column7  from PurchaseAccessories Where VoucherNo='" + voucher + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool DeletePurchaseAccessories(string voucher)
    {
        con();
        string Save1 = "Delete from PurchaseAccessoriesSupplier where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save1, cn);
        sqlcmd.ExecuteNonQuery();

        string Save2 = "Delete from PurchaseAccessories where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save2, cn);
        sqlcmd.ExecuteNonQuery();

        string Save3 = "Delete from Recive_Payment where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save3, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteReciveVoucher(string voucher)
    {
        con();
        string Save1 = "Delete from IncomeVoucher where Vid='" + voucher + "'";
        sqlcmd = new SqlCommand(Save1, cn);
        sqlcmd.ExecuteNonQuery();

        string Save2 = "Delete from IncomeVoucherList where Vid='" + voucher + "'";
        sqlcmd = new SqlCommand(Save2, cn);
        sqlcmd.ExecuteNonQuery();

        string Save3 = "Delete from Recive_Payment where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save3, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeletePaymentVoucher(string voucher)
    {
        con();
        string Save1 = "Delete from ExpenseVoucher where Vid='" + voucher + "'";
        sqlcmd = new SqlCommand(Save1, cn);
        sqlcmd.ExecuteNonQuery();

        string Save2 = "Delete from ExpenseVoucherList where Vid='" + voucher + "'";
        sqlcmd = new SqlCommand(Save2, cn);
        sqlcmd.ExecuteNonQuery();

        string Save3 = "Delete from Recive_Payment where voucherNo='" + voucher + "'";
        sqlcmd = new SqlCommand(Save3, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }


    public DataTable GetDayBook(DateTime Date, DateTime Date2)
    {
        con();
        string sql = "select * from Recive_Payment where Date>='" + Date + "' and Date<='" + Date2 + "' and Client_Name!='Cash' order by Date desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool DeleteReceivePaymentandSalesPurchsase(string vno, string vType)
    {
        try
        {
            con();
            string Deletep = "delete from Recive_Payment where VoucherNo='" + vno + "'";
            sqlcmd = new SqlCommand(Deletep, cn);
            sqlcmd.ExecuteNonQuery();

            if (vType == "Sales")
            {
                string DeleteSV = "delete from SalesVoucherItem where VoucherNo='" + vno + "'";
                sqlcmd = new SqlCommand(DeleteSV, cn);
                sqlcmd.ExecuteNonQuery();

                string DelSVL = "delete from SalesVoucherList where VoucherNo='" + vno + "'";
                sqlcmd = new SqlCommand(DelSVL, cn);
                sqlcmd.ExecuteNonQuery();
            }
            if (vType == "Purchase")
            {
                string DeletePV = "delete from PurchaseBulk where VoucherNo='" + vno + "'";
                sqlcmd = new SqlCommand(DeletePV, cn);
                sqlcmd.ExecuteNonQuery();

                string DelPVL = "delete from PurchaseBulkSupplier where VoucherNo='" + vno + "'";
                sqlcmd = new SqlCommand(DelPVL, cn);
                sqlcmd.ExecuteNonQuery();
            }
            if (vType == "Payment")
            {
                string DeletePV = "delete from ExpenseVoucher where Vid='" + vno + "'";
                sqlcmd = new SqlCommand(DeletePV, cn);
                sqlcmd.ExecuteNonQuery();

                string DelPVL = "delete from ExpenseVoucherList where Vid='" + vno + "'";
                sqlcmd = new SqlCommand(DelPVL, cn);
                sqlcmd.ExecuteNonQuery();
            }
            if (vType == "Receive")
            {
                string DeleteRV = "delete from IncomeVoucher where Vid='" + vno + "'";
                sqlcmd = new SqlCommand(DeleteRV, cn);
                sqlcmd.ExecuteNonQuery();

                string DelRVL = "delete from InconeVoucherList where Vid='" + vno + "'";
                sqlcmd = new SqlCommand(DelRVL, cn);
                sqlcmd.ExecuteNonQuery();
            }

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetChartOfAcc()
    {
        con();
        string id = @"Select * from ChartOfAcc ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getOpeningBalanceForCash(string distId, DateTime FromDate)
    {
        con();
        string sql = "select ISNULL((Sum(Credit)-SUM(Debit)),0) from Recive_Payment where ClientId='" + distId + "'and Date<='" + FromDate + "' and ChartofAccount='Client Account'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getOpeningBalance(string distId, DateTime FromDate)
    {
        con();
        string sql = "select ABS(ISNULL(Sum(Credit)-(SUM(Debit)),0)) from Recive_Payment where ChartofAccountId='" + distId + "'and Date<'" + FromDate + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();

        da.Fill(dt);
        return dt;
    }
    public DataTable getClosingBalanceForCash(string ChartofAccountId, DateTime ToDate)
    {
        con();
        string sql = "select ISNULL((ISNULL(SUM(Debit),0)-ISNULL(Sum(Credit),0)),0) from Recive_Payment where ChartofAccountId='" + ChartofAccountId + "'and Date<='" + ToDate + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAccountsLedger(string ChartofAccountId, DateTime FromDate, DateTime ToDate)
    {
        con();
        string sql = @"Select *, 0 as Balance from  Recive_Payment where VoucherNo in (SELECT VoucherNo FROM Recive_Payment where ChartofAccountId='" + ChartofAccountId + "') and ChartofAccountId='" + ChartofAccountId + "' and Date>='" + FromDate + "' and Date<='" + ToDate + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getClosingBalance(string ChartofAccountId, DateTime ToDate)
    {
        con();
        string sql = "select ISNULL((ISNULL(Sum(Credit),0)-ISNULL(SUM(Debit),0)),0) from Recive_Payment where ChartofAccountId='" + ChartofAccountId + "'and Date<='" + ToDate + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAccountsAll()
    {
        con();
        string id = @"select * from ChartOfAcc where ParentAccId like '01%'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getVendorListForAcc()
    {
        con();
        string id = @"Select * from VendorName where AccCode is null";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetNodeIdLevel(string NodeId)
    {
        con();
        string id = @"SELECT AccLevel  FROM ChartOfAcc where AccCode='" + NodeId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool DeleteAccLedger(string Id)
    {
        con();
        string sql = "delete from ChartOfAcc where Id='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        return true;
    }
    // Journal Voucher 
    public DataTable journalList()
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "Select Sum(Debit) as Debit, SUM(Credit) as Credit, JournalNo,date  from JournalEntries group by JournalNo,date  ";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;

    }
    public void getjournalList(GridView gv)
    {
        con();
        SqlDataAdapter da = new SqlDataAdapter("select * from AddJournal", cn);
        DataTable ds = new DataTable();
        da.Fill(ds);
        gv.DataSource = ds;

        gv.DataBind();
    }

    public DataTable journalListByDate(DateTime date1, DateTime date2)
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "Select Sum(Debit) as Debit, SUM(Credit) as Credit, JournalNo,date  from JournalEntries where date>='" + date1 + "' and date<='" + date2 + "' group by JournalNo,date   ";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;

    }
    public bool DeleteJournalFromJournalList(string joirnalno)
    {
        try
        {
            con();
            string Delete = "Delete from JournalEntries where JournalNo=@JournalNo";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@JournalNo", joirnalno);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool DeleteJournalFromRecivePayment(string joirnalno)
    {
        try
        {
            con();
            string Delete = "Delete from Recive_Payment where VoucherNo=@VoucherNo";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@VoucherNo", joirnalno);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool JournalEntriesLine(string Journo, string refe, string uid, string coaccount, string debit, string credit, string remarks, DateTime dt)
    {
        //string qty,
        try
        {
            con();
            string insert = "INSERT INTO JournalEntries(JournalNo,reference,entryby,accountname,debit,credit,remarks,date)values('" + Journo + "','" + refe + "','" + uid + "','" + coaccount + "','" + debit + "','" + credit + "','" + remarks + "','" + dt + "')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool RecivePaymentReport(string Journo, string jtype, string uid, string coaccount, string client, string coaccountId, string debit, string credit, string remarks, string clientid, DateTime dt, string DrCr)
    {
        //string qty,
        try
        {
            con();
            string insert = "INSERT INTO Recive_Payment(VoucherNo,Client_Name,date,ChartofAccount,ChartofAccountId,Trans_Type,BankName,Debit,Credit,Debitstatus,Creditstatus,ClientId,DrCr,VoucherType) values('" + Journo + "','" + coaccount + "','" + dt + "','" + client + "','" + coaccountId + "','" + client + "','" + client + "','" + debit + "','" + credit + "','Ok','Ok','" + clientid + "','" + DrCr + "','Journal')";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetJournalNo()
    {
        con();
        string id = @"Select ISNULL(Max(id),0)+1 from JournalEntries";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetDistributorBydId(string disid)
    {
        con();
        string id = @"Select * from TBL_DISTRIBUTOR where Dist_Id='" + disid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getjournalVoucherUnfo(string VoucherNo)
    {
        SqlCommand sqlcmd = null;
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select distinct Recive_Payment.ID as RowNumber,JournalEntries.id as journalid, ChartofAccountId as Column1, Recive_Payment.Credit as Column2, Recive_Payment.Debit as Column3 from Recive_Payment inner join dbo.JournalEntries on dbo.JournalEntries.JournalNo = Recive_Payment.VoucherNo and JournalEntries.accountname = Recive_Payment.ChartofAccount where VoucherNo='" + VoucherNo + "'";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;

    }
    public DataTable GetJournalValue(string journalNo)
    {
        con();
        string id = @"select * from JournalEntries where JournalNo='" + journalNo + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateJournalEntriesLine(string Journo, string refe, string uid, string coaccount, string debit, string credit, string remarks, DateTime dt, string rownumber)
    {
        //string qty,
        try
        {
            con();
            string insert = "UPDATE JournalEntries set reference='" + refe + "',accountname='" + coaccount + "',debit='" + debit + "',credit='" + credit + "',remarks='" + remarks + "',date='" + dt + "' where JournalNo='" + Journo + "' and id='" + rownumber + "' ";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateFromJournalentryRecivePaymentReport(string Journo, string jtype, string uid, string coaccount, string client, string coaccountId, string debit, string credit, string remarks, string clientid, DateTime dt, string DrCr, string rownumber)
    {
        //string qty,
        try
        {
            con();
            string insert = "UPDATE Recive_Payment  set Client_Name='" + client + "',date='" + dt + "',ChartofAccount='" + client + "',ChartofAccountId='" + coaccountId + "',Trans_Type='" + jtype + "',Debit='" + debit + "',Credit='" + credit + "',ClientId='" + coaccountId + "',DrCr='" + DrCr + "'  where VoucherNo='" + Journo + "' and ID='" + rownumber + "'";
            sqlcmd = new SqlCommand(insert, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetOnlineOrderList()
    {
        con();
        string id = @"Select OrderId, Customerid,Total, Status,Date from TblOrder group by OrderId, Customerid,Total, Status,Date Order by Date Desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetOnlineOrderDetails(string orderId)
    {
        con();
        string id = @"Select * from TblOrder Where OrderId='"+orderId+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool DeleteOnlineOrder(string Id)
    {
        con();
        string sql = "delete from TblOrder where OrderId='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        return true;
    }
}
