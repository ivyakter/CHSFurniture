using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Procurement_ReceiveBulk : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPrimaryGrid();
        }
    }
    private void BindPrimaryGrid()
    {
        DataTable dt = mydal.getBulkStock();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnReceive_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow gr = btn.NamingContainer as GridViewRow;
        string[] fiva = new string[20];

        fiva[0] = gr.Cells[0].Text;
        fiva[1] = gr.Cells[1].Text;
        fiva[2] = gr.Cells[2].Text;
        fiva[3] = gr.Cells[3].Text;
        fiva[4] = gr.Cells[4].Text;
        //fiva[5] = gr.Cells[5].Text;
        fiva[6] = DateTime.Now.ToString();
        fiva[7] = Session["Uid"].ToString();

        bool save = mydal.SaveBulkReceive(fiva);
        //int LastInsertedId = 0;
        if (save==true)
        {
            //LastInsertedId = mydal.GetLastBulkReceivedId();
            lblMessage.Text = "Bulk Successfully Received ";
            bool update = mydal.UpdateBulk(gr.Cells[1].Text);
        }

        BindPrimaryGrid();
    }
}