using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Cart_Cart : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //sessionuser.Text = Session["Uid"].ToString();
            LoadGrid();

        }
    }

    protected void LoadGrid()
    {
        DataTable dt = (DataTable)Session["shoppingcart"];
        if (dt != null)
        {
            Label lbl_TitlePage = Page.Master.FindControl("lblcount") as Label;
            lbl_TitlePage.Text = dt.Rows.Count.ToString();
            // for main user 
            //lblmainusername.Text = Session["mainitemserrler"].ToString();

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Visible = true;

    }


    double total = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "total"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblamount = (Label)e.Row.FindControl("lbltt");
            lblamount.Text = total.ToString();
            //Label lbl_TitlePage = Page.Master.FindControl("lbltotal") as Label;
            //lbl_TitlePage.Text = lblamount.Text;
        }
    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
        LoadGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["shoppingcart"];
        if (dt.Rows.Count > 0)
        {
            dt.Rows[e.RowIndex].Delete();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label count = Page.Master.FindControl("lblcount") as Label;
            count.Text = dt.Rows.Count.ToString();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument.ToString());
        GridViewRow gvRow = GridView1.Rows[index];
        Label txtq = (Label)gvRow.FindControl("LblQ");
        Label price = (Label)gvRow.FindControl("lblprice");
        Label txtto = (Label)gvRow.FindControl("lbltotal");
        Label footertotal = (Label)GridView1.FooterRow.FindControl("lbltt");

        Label productname = (Label)gvRow.FindControl("lblpname");
        Label Barcode = (Label)gvRow.FindControl("lblBarcode");


        Button bt = (Button)gvRow.FindControl("btdcre");

        if (e.CommandName == "decrement")
        {
            int q = Convert.ToInt32(txtq.Text) - 1;
            txtq.Text = q.ToString();
            if (q > 0)
            {
                txtto.Text = (Convert.ToDouble(txtto.Text) - Convert.ToDouble(price.Text)).ToString();
                footertotal.Text = (Convert.ToDouble(footertotal.Text) - Convert.ToDouble(price.Text)).ToString();

                //txtDollarto.Text = (Convert.ToDouble(txtDollarto.Text) - Convert.ToDouble(Dollarprice.Text)).ToString();
                //footerDollartotal.Text = (Convert.ToDouble(footerDollartotal.Text) - Convert.ToDouble(Dollarprice.Text)).ToString();

                //Label t = Page.Master.FindControl("lbltotal") as Label;
                //t.Text = footertotal.Text;
                Label lbl = Page.Master.FindControl("lblcount") as Label;
                lbl.Text = (Convert.ToInt32(lbl.Text) - 1).ToString();

            }
            else
            {
                bt.Visible = false;
                txtq.Text = "1";
            }
        }
        if (e.CommandName == "increment")
        {
            //DataTable searchproductinstock = mydal.searchproductinstockProduct(productname.Text, Barcode.Text);

            //if (searchproductinstock.Rows.Count > 0)
            //{
                //string Quantity = searchproductinstock.Rows[0]["PresentStock"].ToString();
                //double Qty2 = double.Parse(Quantity);


                //if (Qty2 >= double.Parse(txtq.Text))
                //{
                    int q = Convert.ToInt32(txtq.Text) + 1;
                    txtq.Text = q.ToString();
                    txtto.Text = (q * Convert.ToDouble(price.Text)).ToString();
                    footertotal.Text = (Convert.ToDouble(footertotal.Text) + Convert.ToDouble(price.Text)).ToString();

                    Label lbl = Page.Master.FindControl("lblcount") as Label;
                    lbl.Text = (Convert.ToInt32(lbl.Text) + 1).ToString();
                    bt.Visible = true;
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('There Is No Enough Product');", true);

                //}






            //}
        }
    }



    protected void btOrder_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
    }

    protected void bkashtransaction_Click(object sender, EventArgs e)
    {

        Panel2.Visible = false;
    }


    protected void btncod_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btOrder.Visible = false;
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        string orderid = "";
        string customerid = "";
        //string que = "select id from TblOrder order by id DESC";
        //SqlCommand cm = new SqlCommand(que, con);
        //SqlDataAdapter adpter = new SqlDataAdapter(cm);
        //DataTable dt = new DataTable();
        //adpter.Fill(dt);
        DataTable dt = mydal.GetOrderid();
        if (dt.Rows.Count > 0)
        {
            orderid = "OSN" + dt.Rows[0]["id"].ToString();
            customerid = "CSN" + dt.Rows[0]["id"].ToString();
        }
        else
        {
            orderid = "VSN1";
            customerid = "CSN1";
        }

        bool SaveToCusRegister = mydal.SaveToCusReg(orderid, customerid, txtAddress.Text, txtPhone.Text, txtemail.Text, txtFullName.Text);

        foreach (GridViewRow row in GridView1.Rows)
        {
            Label pid = (Label)row.FindControl("lblid");
            //Label Barcode = (Label)row.FindControl("lblBarcode");
            Label pname = (Label)row.FindControl("lblpname");
            Label quantity = (Label)row.FindControl("LblQ");
            Label price = (Label)row.FindControl("lblprice");
            Label lbltotal = (Label)row.FindControl("lbltotal");
            string date = Convert.ToDateTime(DateTime.Now).Date.ToString("d");

            //string Reference = "";
            //if (Session["Uid"] == null)
            //{
            //    Reference = "Admin";
            //}
            //else
            //{
            //    Reference = Session["Uid"].ToString();
            //}


            bool SaveOrder = mydal.SaveOrder(orderid, pid.Text, pname.Text, quantity.Text, price.Text, lbltotal.Text, customerid, txtFullName.Text, txtPhone.Text, date);
            
        }
        //SendEmail();
        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly');", true);
    }


    private void SendEmail()
    {
        using (MailMessage mm = new MailMessage("torekul002@gmail.com", txtemail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " + txtFullName.Text + ",";
            body += "<br /><br />Please click the following link to activate your account";

            body += "<br /><br />Thanks";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("torekul002@gmail.com", "Tk@#123ht");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

    }


    protected void btnrocket_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void btndbbl_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void btncard_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }


    protected void bkashtransaction_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
}