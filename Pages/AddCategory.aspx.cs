using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Set_AddCategory : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    SqlConnection con = new SqlConnection();
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetNumber();
            btnSave.Visible = true;
        }

    }


    public void GetNumber()
    {
        DataTable CategoryID = mydal.GetCategoryNo();
        txtcatid.Text = CategoryID.Rows[0][0].ToString();
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtcatid.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Please Give CategoryID');", true);
        }
        else
        {
            string[] insert = new string[20];

            insert[0] = txtcatid.Text;
            insert[1] = txtcategoryname.Text;



            bool Save = mydal.InsertCategory(insert);

            ///Image//
            ///

            if (Save == true)
            {

                string CatID = "0";
                DataTable PIDsearch = mydal.SelectMaxCatID();
                if (PIDsearch.Rows.Count > 0)
                {
                    CatID = PIDsearch.Rows[0]["CatID"].ToString();
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //Insert and upload Images

                    if (fuImg01.HasFile)
                    {
                        string SavePath = Server.MapPath("~/CategoryImage/") + CatID;
                        if (!Directory.Exists(SavePath))
                        {
                            Directory.CreateDirectory(SavePath);
                        }
                        string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                        fuImg01.SaveAs(SavePath + "\\" + txtcategoryname.Text.ToString().Trim() + "Big" + Extention);
                        SqlCommand cmd3 = new SqlCommand("insert into CategoryImages values('" + CatID + "',N'" + txtcategoryname.Text.ToString().Trim() + "Big" + "','" + Extention + "','680x300')", con);
                        cmd3.ExecuteNonQuery();
                    }

                    if (fuImg02.HasFile)
                    {
                        string SavePath = Server.MapPath("~/CategoryImage/") + CatID;
                        if (!Directory.Exists(SavePath))
                        {
                            Directory.CreateDirectory(SavePath);
                        }
                        string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
                        fuImg02.SaveAs(SavePath + "\\" + txtcategoryname.Text.ToString().Trim() + "Small" + Extention);


                        SqlCommand cmd4 = new SqlCommand("insert into CategoryImages values('" + CatID + "',N'" + txtcategoryname.Text.ToString().Trim() + "Small" + "','" + Extention + "','180x195')", con);
                        cmd4.ExecuteNonQuery();
                    }

                }

                string strconfirmd = "<script>if(window.confirm('Save Successfull')){window.location.href='AddCategory.aspx'}</script>";
                ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirmd, false);
                txtcategoryname.Text = null;
            }



            //if (fuImg01.HasFile)
            //{

            //    string filejpg = System.IO.Path.GetExtension(fuImg01.FileName);
            //    if (filejpg == ".jpg" || filejpg == ".jpeg" || filejpg == ".png")
            //    {

            //        fuImg01.PostedFile.SaveAs(Server.MapPath("~\\CategoryImage\\" + txtcategoryname.Text + "Big" + filejpg));
            //    }
            //}

            //if (fuImg02.HasFile)
            //{

            //    string filejpg2 = System.IO.Path.GetExtension(fuImg02.FileName);
            //    if (filejpg2 == ".jpg" || filejpg2 == ".jpeg" || filejpg2 == ".png")
            //    {

            //        fuImg02.PostedFile.SaveAs(Server.MapPath("~\\CategoryImage\\" + txtcategoryname.Text + "Small" + filejpg2));
            //    }
            //}




            //ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('Something wrong please try again');", true);
            }
        }
    }




}