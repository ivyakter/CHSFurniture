using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public class census
{
    //BPDBConnectionString
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["schoolConnection"].ConnectionString);
    SqlCommand cmd;
    DataSet ds;
    DataTable dt;
    SqlDataAdapter adp;

    public census()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region common execution code

    //Getting Max ID from Any Table
    public int getMaxID(string sql, Label message)
    {
        int maxValue = 0;
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand(sql, cn);
            maxValue = Convert.ToInt32(cmd.ExecuteScalar());
            return maxValue;
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
            return maxValue;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    //Getting ID from Any Table
    public int getID(string sql, Label message)
    {
        int value = 0;
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand(sql, cn);
            value = Convert.ToInt32(cmd.ExecuteScalar());
            return value;
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
            return value;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    public string getIDL(string sql, Label message)
    {
        string value = "0";
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand(sql, cn);
            value = cmd.ExecuteScalar().ToString();
            return value;
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
            return value;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    //method query execution code
    public string executeQuery(string sql)
    {

        string message = string.Empty;
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                message = "S";
            }
            else
            {
                message = "N";
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        return message;
    }

    //method query execution code without return
    public void executeQuery(string sql, Label message)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                message.Text = "Success";
            }
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    //Method for Return DataTable 
    public string returnCourseId(string sql)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            return dt.Rows[0]["stdid"].ToString();
        }
        catch (Exception )
        {
            return dt.Rows[0]["stdid"].ToString();
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
    public string returnedit(string sql)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            return dt.Rows[0]["NAMEENG"].ToString();
        }
        catch (Exception)
        {
            return dt.Rows[0]["NAMEENG"].ToString();
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    public DataTable returnTable(string sql, Label message)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
            return dt;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
    public DataTable returnTableedit(string sql)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        catch (Exception )
        {
            // message.Text = ex.Message;
            return dt;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
    //Method for viewing date to any gridView    
    public void viewData(GridView gridView, string sql, Label message)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            adp = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adp.Fill(dt);
            gridView.DataSource = dt;
            gridView.DataBind();
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
    //Method for viewing date to any DetailView    
    public void viewDatas(DetailsView DetailView, string sql, Label message)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            adp = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            adp.Fill(dt);
            DetailView.DataSource = dt;
            DetailView.DataBind();
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    //Method for populating any dropdownList 
    public void DropPopulating(DropDownList drop, string sql, string ITEM_ID, string ITEM_NAME, Label message)
    {
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            drop.DataTextField = dt.Columns[ITEM_NAME].ToString();
            drop.DataValueField = dt.Columns[ITEM_ID].ToString();
            drop.DataSource = dt;
            drop.DataBind();
            drop.Items.Insert(0, new ListItem("Select Here Items", ""));

        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }

    //Method for populating any Combo Box 
    //public void CombooPopulating(ComboBox drop, string sql, string ITEM_ID, string ITEM_NAME, Label message)
    //{
    //    try
    //    {
    //        if (cn.State == ConnectionState.Closed)
    //        {
    //            cn.Open();
    //        }
    //        SqlCommand cmd = new SqlCommand(sql, cn);
    //        cmd.CommandType = CommandType.Text;
    //        DataTable dt = new DataTable();

    //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //        adp.Fill(dt);

    //        drop.DataTextField = dt.Columns[ITEM_NAME].ToString();
    //        drop.DataValueField = dt.Columns[ITEM_ID].ToString();
    //        drop.DataSource = dt;
    //        drop.DataBind();
    //        drop.Items.Insert(0, new ListItem("", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        message.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (cn.State == ConnectionState.Open)
    //        {
    //            cn.Close();
    //        }
    //    }
    //}
    //    public DataTable get_bandil(int tr)
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter(@"SELECT        BC_METER_READING_CARD_HDR.READING_ID, BC_METER_READING_CARD_HDR.BILL_CYCLE_CODE, BC_METER_READING_CARD_HDR.ENTRY_DATE, 
    //                         BC_METER_READING_CARD_HDR.AREA_CODE, BC_AREA_CODE.BILL_GRP_DESCR, BC_LOCATION_MASTER.DESCR
    //FROM            BC_BILL_CYCLE_CODE INNER JOIN
    //                         BC_METER_READING_CARD_HDR ON BC_BILL_CYCLE_CODE.BILL_CYCLE_CODE = BC_METER_READING_CARD_HDR.BILL_CYCLE_CODE INNER JOIN
    //                         BC_AREA_CODE ON BC_BILL_CYCLE_CODE.LOCATION_CODE = BC_AREA_CODE.LOCATION_CODE AND 
    //                         BC_BILL_CYCLE_CODE.AREA_CODE = BC_AREA_CODE.AREA_CODE AND 
    //                         BC_METER_READING_CARD_HDR.LOCATION_CODE = BC_AREA_CODE.LOCATION_CODE AND 
    //                         BC_METER_READING_CARD_HDR.AREA_CODE = BC_AREA_CODE.AREA_CODE INNER JOIN
    //                         BC_LOCATION_MASTER ON BC_AREA_CODE.LOCATION_CODE = BC_LOCATION_MASTER.LOCATION_CODE AND 
    //                         BC_METER_READING_CARD_HDR.LOCATION_CODE = BC_LOCATION_MASTER.LOCATION_CODE
    //WHERE        (BC_METER_READING_CARD_HDR.READING_ID = '" + tr + "')", cn);
    //        if (cn.State == ConnectionState.Closed)
    //        {
    //            cn.Open();
    //        }
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        cn.Close();
    //        return dt;
    //    }
    #endregion common execution code

    #region Division Entry

    #endregion End Division Entry

}
