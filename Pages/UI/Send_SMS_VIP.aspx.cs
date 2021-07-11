using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;
using System.IO;

public partial class UI_Send_SMS_VIP : System.Web.UI.Page
{
    private string pass = "";
    private string uid = "";

    string sql, sql1, sql2, sql3;
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        }
        else
        {
            uid = Session["Uid"].ToString();
            pass = Session["Pwd"].ToString();

        }

        if (!IsPostBack)
        {
            SMSCount();
            bind();            
        }
    }
    protected void SMSCount()
    {
        sql2 = "Select Count(MOBILE_NO) from TBL_SMSLOG where STATUS='Success'";
        DataTable dt = DataAccess.GetDataTable(sql2);
        lblTotal.Text = dt.Rows[0][0].ToString();

    }
    protected void bind()
    {
        try
        {
            sql2 = "SELECT * FROM Vip_Person ";
            DataTable dtforgv = DataAccess.GetDataTable(sql2);

            GridView1.Visible = true;
            GridView1.DataSource = dtforgv;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chkatt = ((CheckBox)gr.Cells[3].FindControl("chkAttend"));
                chkatt.Checked = true;
            }

            btnsubmit.Visible = true;

        }
        catch (Exception ex)
        {
            //lblmgs.Text = "There is no student";
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int counter = 0;
            string sms = txtsms.Text;
            foreach (GridViewRow gr in GridView1.Rows)
            {               
                string mblno = gr.Cells[4].Text;
                CheckBox chkatt = ((CheckBox)gr.Cells[5].FindControl("chkAttend"));
                if (chkatt.Checked)
                {
                    counter++;
                    //send message 
                    if (mblno.Trim().Length >= 11)
                    {
                        send_sms(mblno, sms);
                        counter++;
                    }

                    String insertsql = "insert into SMS_COUNT(MOBILE_NO,STATUS,INSERT_TIME) VALUES('" + mblno + "','Success',getdate())";
                    DataAccess.ExecuteSQL(insertsql);
                }

            }
            //send_sms("8801684095518", "This is Test SMS");
            if (counter == 0)
            {
                lblmgs.Text = "Chcekbox could not be blank";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnsubmit, GetType(), "", "alert(' " + counter + " Message Send');", true);
                txtsms.Text = "";
                lblmgs.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblmgs.Text = "Sorry !  " + ex.Message;
        }
    }
    protected void send_sms(string mobile, string msg)
    {
        string webTarget = "http://66.45.237.70/api.php?username=scpsc-15&password=BHR3NG2X&number=" + mobile + "&sender=SCPSC &type=0&message=" + msg;

        // Parameters to send with API request.
        string webPost = webTarget;//"address={0}&message={1}";

        // SMSified credentials.
        string userName = "scpsc-15";
        string password = "BHR3NG2X";
     
        // Create new HTTP request.
        string url = webTarget;//String.Format(webTarget, senderNumber);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(webTarget);
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] postData = Encoding.ASCII.GetBytes(String.Format(webPost));//, "14075551212", "This is a test from C#"));
        req.ContentLength = postData.Length;

        // Set HTTP authorization header.
        string authInfo = userName + ":" + password;
        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
        req.Headers["Authorization"] = "Basic " + authInfo;

        // Send HTTP request.
        Stream PostStream = req.GetRequestStream();
        PostStream.Write(postData, 0, postData.Length);
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();

    }
}