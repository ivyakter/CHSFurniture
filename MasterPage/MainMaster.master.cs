using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_MainMaster : System.Web.UI.MasterPage
{

    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMenu();
            //LoadOccation();
            Loadheadermenu();
            Loadheadermenuheadertop();


        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string[] loginfo = new string[15];
        loginfo[0] = txtemaillog.Text;
        loginfo[1] = txtpasslog.Text;

        //if (txtemaillog.Text == "admin" && txtpasslog.Text == "123")
        //{

          

        //    Response.Redirect("Pages/Set/SetDateforegion.aspx");

          

        //}
        //else
        //{
            //bool Checklogin = mydal.checkloginfo(loginfo);
            DataTable dt = mydal.selectinfocustomer(loginfo);

            if (dt.Rows.Count > 0)
            {
                Page pg = new System.Web.UI.Page();
                Session["Email"] = dt.Rows[0]["Email"].ToString();
                Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                Session["Password"] = dt.Rows[0]["Password"].ToString();

              

                Label labellogin = (Label)ContentPlaceHolder1.FindControl("lblloigin");
               
                
                if (labellogin.Text == "")
                {
                    labellogin.Text = "LoggedIn";
                 

                }

               
                Response.Redirect("~/Pages/MyAccount/MyAccount.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
            //}
        }
    }
    protected void btnsaveconti_Click(object sender, EventArgs e)
    {
        if (chkagree.Checked)
        {
            string[] insert = new string[15];
            insert[0] = txtfirstname.Text;
            insert[1] = txtmiddlename.Text;
            insert[2] = txtlastname.Text;
            insert[3] = ddlcountry.SelectedItem.Text;
            insert[4] = txtpostcode.Text;
            insert[5] = txtmobile.Text;
            insert[6] = txtlandline.Text;
            insert[7] = txtemail.Text;
            insert[8] = txtpassword.Text;
            bool Insert = mydal.InsertRegistrationInfo(insert);
            if (Insert == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Something Went Wrong');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Yoy Need to check the Checkbox');", true);
        }
    }


    //protected void btnneedhelp_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Pages/Help.aspx");
    //}

    private void LoadMenu()
    {
        DataTable dt = new DAL().GetMenuData();
        rptrcategory.DataSource = dt;
        rptrcategory.DataBind();

    }

    //private void LoadOccation()
    //{
    //    DataTable dt = mydal.checkOccation();
    //    if (dt.Rows.Count > 0)
    //    {
    //        lblcategory.Text = dt.Rows[0]["MenuText"].ToString();
    //        lbloccation.Text = dt.Rows[0]["Occation"].ToString();
    //        lbloccationdesc.Text = dt.Rows[0]["OccationDesc"].ToString();
    //        lbloccationremain.Text = dt.Rows[0]["OccationRemain"].ToString();
    //    }

    //}

    private void Loadheadermenu()
    {
       
        SubcatFoodcupboars();
        SubcatFresh();
        //SubcatDrinkandbreverage();
        //SubcatFrozenfood();
    
    }
    private void Loadheadermenuheadertop()
    {
    
        SubcatFoodcupboars2();
        SubcatFresh2();
        //SubcatDrinkandbreverage2();
        //SubcatFrozenfood2();
      
    }




    private void SubcatFoodcupboars()
    {
        DataTable dt = mydal.GetSubcatFoodandcipboard();
        if (dt.Rows.Count > 0)
        {
            rptrSubCateFoodcupboard.DataSource = dt;
            rptrSubCateFoodcupboard.DataBind();
        }

    }

    private void SubcatFresh()
    {
        DataTable dt = mydal.GetSubcatFresh();
        if (dt.Rows.Count > 0)
        {
            rptrforFresh.DataSource = dt;
            rptrforFresh.DataBind();
        }

    }

    private void SubcatDrinkandbreverage()
    {
        DataTable dt = mydal.GetSubcatdrinkandbreverage();
        if (dt.Rows.Count > 0)
        {
            rptrdrinkandbreverage.DataSource = dt;
            rptrdrinkandbreverage.DataBind();
        }
    }

    //private void SubcatFrozenfood()
    //{
    //    DataTable dt = mydal.GetSubcatFrozenfood();
    //    if (dt.Rows.Count > 0)
    //    {
    //        rptrfrozenfood.DataSource = dt;
    //        rptrfrozenfood.DataBind();
    //    }
    //}



    private void SubcatFoodcupboars2()
    {
        DataTable dt = mydal.GetSubcatFoodandcipboard();
        if (dt.Rows.Count > 0)
        {
            rptrfoodcupboard2.DataSource = dt;
            rptrfoodcupboard2.DataBind();
        }

    }

    private void SubcatFresh2()
    {
        DataTable dt = mydal.GetSubcatFresh();
        if (dt.Rows.Count > 0)
        {
            rptrfresh2.DataSource = dt;
            rptrfresh2.DataBind();
        }

    }

    private void SubcatDrinkandbreverage2()
    {
        DataTable dt = mydal.GetSubcatdrinkandbreverage();
        if (dt.Rows.Count > 0)
        {
            rptrdrink2.DataSource = dt;
            rptrdrink2.DataBind();
        }
    }

    //private void SubcatFrozenfood2()
    //{
    //    DataTable dt = mydal.GetSubcatFrozenfood();
    //    if (dt.Rows.Count > 0)
    //    {
    //        rptrfrozen2.DataSource = dt;
    //        rptrfrozen2.DataBind();
    //    }
    //}


    protected void txtemail_TextChanged(object sender, EventArgs e)
    {
        string[] loginfo = new string[15];
        loginfo[0] = txtemaillog.Text;
        loginfo[1] = txtpasslog.Text;
   
        DataTable dt = mydal.selectinfocustomer(loginfo);

        string Email = dt.Rows[0]["Email"].ToString();

        if(txtemaillog.Text==Email)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Yoy Need to Use A Different Email');", true);

        }
    }
}
