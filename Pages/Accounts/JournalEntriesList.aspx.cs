using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_JournalEntriesList : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getjournalList();
        }
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void getjournalList()
    {
     DataTable dt =   mydal.journalList();
        if (dt.Rows.Count>0)
        {
            journalgv.DataSource = dt;
            journalgv.DataBind();
        }
    }
    protected void journalgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        journalgv.PageIndex = e.NewPageIndex;
        journalgv.DataBind();
        getjournalList();
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        DateTime date1 = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

        journalgv.DataSource = null;
        journalgv.DataBind();

        DataTable dt = mydal.journalListByDate(date1, date2);
        journalgv.DataSource = dt;
        journalgv.DataBind();
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["RoleId"].ToString() == "1")
            {
                Button lnkbtn = sender as Button;
                GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
                Label lblid = (Label)row.Cells[1].FindControl("lbljournalId");

                bool delete = mydal.DeleteJournalFromJournalList(lblid.Text);

                bool delete2 = mydal.DeleteJournalFromRecivePayment(lblid.Text);

                getjournalList();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('You are not valid user to delete this record!!');", true);
            }
           
        }
        catch (Exception ex)
        {
        }
    }
}