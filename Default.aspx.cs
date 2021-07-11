using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Session.RemoveAll();
            LoadMenu();
            LoadSubcategory();
            LoadHotProducts();
            LoadProductbySubCategory();
            //loadSuperDeals();
            //LoadOfferTitle();
            LoadSliderdetails();
          

            //if (Request.QueryString["Loggenin"] != null)
            //{
            //    lblloigin.Text = Request.QueryString["Loggenin"];

            //    Session["Loginfo"] = Request.QueryString["Loggenin"];
            //}
        }
    }

    protected void LoadSliderdetails()
    {

        DataTable Firstslider = mydal.getFirstSliderdetails();
        if (Firstslider.Rows.Count > 0)
        {
            firstslidertitle.Text = Firstslider.Rows[0]["Title"].ToString();
            firstsliderdetails.Text = Firstslider.Rows[0]["Description"].ToString();
        }

        DataTable Secondslider = mydal.getSecondSliderdetails();
        if (Secondslider.Rows.Count > 0)
        {
            secondslidertitle.Text = Secondslider.Rows[0]["Title"].ToString();
            secondsliderdetails.Text = Secondslider.Rows[0]["Description"].ToString();
        }

        DataTable thirdslider = mydal.getThirdSliderdetails();
        if (thirdslider.Rows.Count > 0)
        {
            thirdslidertitle.Text = thirdslider.Rows[0]["Title"].ToString();
            thirdsliderdetails.Text = thirdslider.Rows[0]["Description"].ToString();
        }

        DataTable Fourthslider = mydal.getFourthSliderdetails();
        if (thirdslider.Rows.Count > 0)
        {
            fourthslidertitle.Text = Fourthslider.Rows[0]["Title"].ToString();
            fourthsliderdetails.Text = Fourthslider.Rows[0]["Description"].ToString();
        }

        DataTable Fifthslider = mydal.getFifthSliderdetails();
        if (thirdslider.Rows.Count > 0)
        {
            fifthslidertitle.Text = Fifthslider.Rows[0]["Title"].ToString();
            fifthsliderdetails.Text = Fifthslider.Rows[0]["Description"].ToString();
        }

    }


    protected void LoadOfferTitle()
    {

        DataTable dt = mydal.getTitleSetList();
        if (dt.Rows.Count > 0)
        {

            //lblOffer.Text = dt.Rows[0]["Title"].ToString();
        }

    }

    public void LoadSubcategory()
    {
        SubcatFoodcupboars();
        SubcatFresh();      
    }

    public void LoadHotProducts()
    {
        loadHotNewArrival();
        loadHotBestsellers();
        loadHotDeals();
    }

    private void LoadMenu()
    {
        DataTable dt = new DAL().GetMenuData();
        rptrMain.DataSource = dt;
        rptrMain.DataBind();

    }


    protected void rptrMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptrSubCate = (Repeater)e.Item.FindControl("rptrSubCate");
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCateId");
            DataTable dt = new DAL().GetMenuData(hfCateId.Value);
            if (dt.Rows.Count > 0)
            {
                rptrSubCate.DataSource = dt;
                rptrSubCate.DataBind();
            }

        }
    }

    private void SubcatFoodcupboars()
    {
        DataTable dt = mydal.GetSubcatFoodandcipboard();
        if (dt.Rows.Count > 0)
        {
            rptrSubChair.DataSource = dt;
            rptrSubChair.DataBind();
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




    public void loadHotNewArrival()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrHotnewarrivalProducts.DataSource = dt;
            rptrHotnewarrivalProducts.DataBind();
            rptrHotnewarrivalProducts.Visible = true;
        }
    }

    public void loadSuperDeals()
    {
        //DataTable dt = mydal.GetSuperDeals();
        //if (dt.Rows.Count > 0)
        //{
          
        //}
    }

    public void loadHotBestsellers()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrHotbestsellersProducts.DataSource = dt;
            rptrHotbestsellersProducts.DataBind();
            rptrHotbestsellersProducts.Visible = true;
        }
    }

    public void loadHotDeals()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrHotdealsProducts.DataSource = dt;
            rptrHotdealsProducts.DataBind();
            rptrHotdealsProducts.Visible = true;
        }
    }

    public void LoadProductbySubCategory()
    {
        LoadChair();
        loadFreshNewArrival();
        loadFreshBestsellers();
        loadFreshDeals();

    }

    /// <summary>
    /// ///////Food And Cupboard
    /// </summary>

    public void LoadChair()
    {
        string cat = "Chair";
        DataTable dt = mydal.GetProductList(cat);
        if (dt.Rows.Count > 0)
        {
            rptChairNewArrivals.DataSource = dt;
            rptChairNewArrivals.DataBind();
            rptChairNewArrivals.Visible = true;
        }

        DataTable dt2 = mydal.GetProductList(cat);
        if (dt2.Rows.Count > 0)
        {
            rptChairBestSellers.DataSource = dt2;
            rptChairBestSellers.DataBind();
            rptChairBestSellers.Visible = true;
        }

        DataTable dt3 = mydal.GetProductList(cat);
        if (dt3.Rows.Count > 0)
        {
            rptChairDeals.DataSource = dt3;
            rptChairDeals.DataBind();
            rptChairDeals.Visible = true;
        }
    }

    public void LoadTable()
    {
        string cat = "Chair";
        DataTable dt = mydal.GetProductList(cat);
        if (dt.Rows.Count > 0)
        {
            rptChairNewArrivals.DataSource = dt;
            rptChairNewArrivals.DataBind();
            rptChairNewArrivals.Visible = true;
        }

        DataTable dt2 = mydal.GetProductList(cat);
        if (dt2.Rows.Count > 0)
        {
            rptChairBestSellers.DataSource = dt2;
            rptChairBestSellers.DataBind();
            rptChairBestSellers.Visible = true;
        }

        DataTable dt3 = mydal.GetProductList(cat);
        if (dt3.Rows.Count > 0)
        {
            rptChairDeals.DataSource = dt3;
            rptChairDeals.DataBind();
            rptChairDeals.Visible = true;
        }
    }

    /// <summary>
    /// ///Fresh Food ///
    /// </summary>
    public void loadFreshNewArrival()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrFreshnewarrivalproduct.DataSource = dt;
            rptrFreshnewarrivalproduct.DataBind();
            rptrFreshnewarrivalproduct.Visible = true;
        }

    }

    public void loadFreshBestsellers()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrFreshbestsellersproduct.DataSource = dt;
            rptrFreshbestsellersproduct.DataBind();
            rptrFreshbestsellersproduct.Visible = true;
        }
    }

    public void loadFreshDeals()
    {
        DataTable dt = mydal.getProductList();
        if (dt.Rows.Count > 0)
        {
            rptrFreshdealsproduct.DataSource = dt;
            rptrFreshdealsproduct.DataBind();
            rptrFreshdealsproduct.Visible = true;
        }
    }





    protected void btnaddtocart_Click1(object sender, EventArgs e)
    {

        //if (lblloigin.Text != "")
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
                //createdt.Columns.Add("size", typeof(string));
              
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

    //private void LoadSliderImage()
    //{

    //    DataTable dt = mydal.SelectImagesSlider();
    //    if (dt.Rows.Count > 0)
    //    {
    //        rptrslider.DataSource = dt;
    //        rptrslider.DataBind();

    //    }

    //}

}