using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Home_ProductsByCategory : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProductsbySubcat();
        }
    }

    private void LoadProductsbySubcat()
    {
        string subcatid = Request.QueryString["Subcatid"].ToString();
        string catid = Request.QueryString["catid"].ToString();

        //DataTable dt = mydal.Getsubcatidbyname(SubcatText);

        //if (dt.Rows.Count > 0)

        //{
            //string subcatid = dt.Rows[0]["Id"].ToString();

        DataTable getproductbysubcat = mydal.GetProductByCategorynameandSubcategory(catid,subcatid );
            if (getproductbysubcat.Rows.Count > 0)
            {
                rptrproductsbysubcat.DataSource = getproductbysubcat;
                rptrproductsbysubcat.DataBind();
            }
            else
            {

                lblemptydate.Text = "No Item Binded";
            
            }
        //}
    
    }

  
}