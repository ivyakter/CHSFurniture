using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CategoryPage : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProductbyCategory();
           
            //LoadCategoryImagebycatis();
        }
    }


    //protected void LoadCategoryImagebycatis()
    //{
    //    var CatID = Request.QueryString["CatID"];
    //    DataTable LoadBigImageinCategorypage = mydal.LoadBigImageinCategorypage(CatID);
    //    if (LoadBigImageinCategorypage.Rows.Count > 0)
    //    {
    //        LoadBigImageinCategory.DataSource = LoadBigImageinCategorypage;
    //        LoadBigImageinCategory.DataBind();
    //        LoadBigImageinCategory.Visible = true;
    //    }
    //}


    protected void LoadProductbyCategory()
    {

        if (Request.QueryString["Subcatid"] != null && Request.QueryString["ParentId"] != null)
        {
            string subcatid = Request.QueryString["Subcatid"].ToString();
            string ParentId = Request.QueryString["ParentId"].ToString();

            lblSubcatid.Text = subcatid;
            lblParentid.Text = ParentId;

            if (Request.QueryString["CatID"]!="" && Request.QueryString["Subcatid"] == "" && Request.QueryString["ParentId"] == "")
            {
                var CatID = Request.QueryString["CatID"];
                lblcatid.Text = CatID.ToString();

                DataTable dt = mydal.GetProductByCategoryname(CatID);
                if (dt.Rows.Count > 0)
                {
                    rptrFoodcupboardnewarrivals.DataSource = dt;
                    rptrFoodcupboardnewarrivals.DataBind();
                    rptrFoodcupboardnewarrivals.Visible = true;
                }

            }
            else
            {

                DataTable dtfromsubcat = mydal.GetProductByCategorynameandSubcategory(ParentId, subcatid);
                if (dtfromsubcat.Rows.Count > 0)
                {
                    rptrFoodcupboardnewarrivals.DataSource = dtfromsubcat;
                    rptrFoodcupboardnewarrivals.DataBind();
                    rptrFoodcupboardnewarrivals.Visible = true;
                }
                else
                {
                    lblproduct.Visible = true;
                }
            }
        }

        else
        {

            var CatID = Request.QueryString["CatID"];
            lblcatid.Text = CatID.ToString();

            DataTable dt = mydal.GetProductByCategoryname(CatID);
            if (dt.Rows.Count > 0)
            {
                rptrFoodcupboardnewarrivals.DataSource = dt;
                rptrFoodcupboardnewarrivals.DataBind();
                rptrFoodcupboardnewarrivals.Visible = true;
            }
            else
            {
                lblproduct.Visible = true;
            }
        }
    }



    protected void addtocart_Click(object sender, EventArgs e)
    {
        //if (Session["Loginfo"] != null)
        //{
            LinkButton btbag = sender as LinkButton;
            RepeaterItem repeaterval = btbag.NamingContainer as RepeaterItem;

            string pid = ((HiddenField)repeaterval.FindControl("hfPId")).Value;
            string pname = ((HiddenField)repeaterval.FindControl("hfname")).Value;
            string price = ((HiddenField)repeaterval.FindControl("hfprice")).Value;
          
            string Imagename = ((HiddenField)repeaterval.FindControl("hfimagename")).Value;
            string Imageextension = ((HiddenField)repeaterval.FindControl("hfimageExtesion")).Value;

            int quantity = 1;
            double sum = 0;

            DataTable dt = (DataTable)Session["shoppingcart"];

            if (Session["shoppingcart"] == null)
            {
                //create the datatable
                DataTable createdt = new DataTable();
                createdt.Columns.Add("pid", typeof(string));

                createdt.Columns.Add("pname", typeof(string));
                createdt.Columns.Add("quantity", typeof(int));
                createdt.Columns.Add("price", typeof(double));
              
                createdt.Columns.Add("Imagename", typeof(string));
                createdt.Columns.Add("Imageextension", typeof(string));
                createdt.Columns.Add("total", typeof(double));

                //Store first row
                DataRow row = createdt.NewRow();
                row["pid"] = pid;
                row["pname"] = pname;
                row["quantity"] = quantity;
                row["price"] = price;
             
                row["Imagename"] = Imagename;
                row["Imageextension"] = Imageextension;
                row["total"] = quantity * double.Parse(price);

                createdt.Rows.Add(row);
                Session["shoppingcart"] = createdt;
                sum = Convert.ToDouble(row["total"]);

                MasterPage ms = new MasterPage();
                Label count = Page.Master.FindControl("lblcount") as Label;
                Label countsmall = Page.Master.FindControl("lblcountinside") as Label;
                Label count2 = Page.Master.FindControl("countproduct") as Label;
                Label counttext = Page.Master.FindControl("lblcounttext") as Label;

                count.Text = "(" + createdt.Rows.Count + ")";
                countsmall.Text = "(" + createdt.Rows.Count + ")";
                count2.Text = "(" + createdt.Rows.Count + ")";
                counttext.Text = "(" + createdt.Rows.Count + ")";
            }
            else
            {
                bool exist = false;
                int a = 0;
                DataRow foundProductId = dt.Select("pid ='" + pid + "'").FirstOrDefault();
                if (foundProductId != null)
                {
                    a = Convert.ToInt32(foundProductId["quantity"].ToString());
                    foundProductId["quantity"] = a + 1;
                    foundProductId["total"] = (a + 1) * double.Parse(price);
                    exist = true;
                }
                if (exist != true)
                {
                    DataRow row = dt.NewRow();
                    row["pid"] = pid;
                    row["pname"] = pname;
                    row["quantity"] = a + quantity;
                    row["price"] = price;
                  
                    row["Imagename"] = Imagename;
                    row["Imageextension"] = Imageextension;
                    row["total"] = (a + quantity) * double.Parse(price);
                    dt.Rows.Add(row);
                }
                Session["shoppingcart"] = dt;

                foreach (DataRow dr in dt.Rows)
                {
                    sum += Convert.ToDouble(dr["total"]);
                }
                MasterPage ms = new MasterPage();
                Label count = Page.Master.FindControl("lblcount") as Label;
                Label countsmall = Page.Master.FindControl("lblcountinside") as Label;
                Label count2 = Page.Master.FindControl("countproduct") as Label;
                Label counttext = Page.Master.FindControl("lblcounttext") as Label;


                count.Text = "(" + dt.Rows.Count + ")";
                countsmall.Text = "(" + dt.Rows.Count + ")";
                count2.Text = "(" + dt.Rows.Count + ")";
                counttext.Text = "(" + dt.Rows.Count + ")";


            }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('You Need To Login First');", true);
        //}
    }

   


}