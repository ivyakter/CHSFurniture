using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;

public partial class frm_forgot : System.Web.UI.Page
{
    DAL mydal = new DAL();
   // DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = txt_userid.Text;
            DataTable dt = mydal.get_user_forgot_code(sql);
        //    DataTable dt = mydal.get_user_code_by_mobile(sql);
        
            if (dt.Rows.Count > 0)
            {
                //   Response.Redirect("Default2.aspx");
                string v_code = dt.Rows[0]["v_code"].ToString();
                // fivalue[1] = txt_password.Text.Trim(); MOBILE_NO
                MessageGateway messgate = new MessageGateway();
                messgate.SetCustId("");
                messgate.getmobile(dt.Rows[0]["MAIL_MOBILE_NO"].ToString().Trim ());

                messgate.custMessage("\"Forgot PIN\"Your Tracking Number is : " + dt.Rows[0]["TRACKING_NUMBER"].ToString() + " and PIN number is : " + v_code);
                bool succ = messgate.SendMessage();

                if (succ == true)
                {
                      laMeg.Text = "Message Delivered";
                    // Button2_ModalPopupExtender.Show();
                    //  mydal.update_status(dt.Rows[i]["TRACKING_NUMBER"].ToString().Trim());
                }
                else
                {
                    laMeg.Text = "Message not Delivered";
                    //Button2_ModalPopupExtender.Show();
                }
               
                
                //  bind();
            }
            else
            {
                laMeg.Text = "Invalid Tracking Number";
            }
        }
        catch (Exception ex)
        {
            laMeg.Text = ex.Message.ToString();
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        laMeg.Text = null;
        clear();
    }
    protected void clear()
    {

      //  txtCode.Text = null;
        txt_userid.Text = null;
        
       // btSave.Text = "Save";
    }
  }
