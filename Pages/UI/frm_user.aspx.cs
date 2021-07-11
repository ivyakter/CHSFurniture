using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
public partial class frm_user : System.Web.UI.Page
{
    DAL mydal = new DAL();
      
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Uid"] == null)
        {
            Response.Redirect("~/login.aspx", false);
            return;
        } 
        if (!IsPostBack)
        {
           // mydal.dropdown(drroleid, "tbl_role_master", 1, 0, "role_name");
            LoadRole();
            bind();
        }
    }
    protected void LoadRole()
    {
        DataTable dt = mydal.LoadRole();
        drroleid.DataSource = dt;
        drroleid.DataTextField = "role_name";
        drroleid.DataValueField = "id";
        drroleid.DataBind();
        drroleid.Items.Insert(0, "--select--");
    }
    protected void bind()
    {
        string uid = Session["Uid"].ToString();
        if (uid == "admin")
        {
            gvBank.Visible = true;
        }
        else
        {
            gvBank.Visible = false;
        }

        mydal.grid_PasswordShow(gvBank);
    }
    protected void chkstatus_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox lnkbtn = sender as CheckBox;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;

            Label lblid = (Label)row.Cells[0].FindControl("lblid");
            CheckBox chkstatus = (CheckBox)row.Cells[0].FindControl("chkstatus");
            Label userid = (Label)row.Cells[0].FindControl("Label2");
            Label pass = (Label)row.Cells[0].FindControl("Label3");
            Label mob = (Label)row.Cells[0].FindControl("Label4");
                 

            if (chkstatus.Checked)
            {
               

                string mess = "Your User Id is:"+ "'" + userid.Text + "'" + "and Password is:" + "'" + pass.Text + "'"+"For any query call 01684131302" ;
                //  send sms
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://66.45.237.70/api.php?username=scpsc&password=D56W8BPM&number=" + mob + "&sender=SCPSC &type=0&message=" + mess + "");

                HttpWebResponse myResp = (HttpWebResponse)req.GetResponse();
                System.IO.
        StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());

                string responseString = respStreamReader.ReadToEnd();

                respStreamReader.Close();

                myResp.Close();

                chkstatus.Checked = false;
            }
            else
            {
           
            }
        }
        catch (Exception ex)
        { }
     
    }
    protected void gvBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lblrole = ((Label) gvBank.SelectedRow.FindControl("lblrole"));
        Label1.Text = gvBank.SelectedRow.Cells[0].Text;

        txtlog_id.Text = gvBank.SelectedRow.Cells[1].Text;
        txtuser_name.Text = gvBank.SelectedRow.Cells[2].Text;
        txtPassword.Text = gvBank.SelectedRow.Cells[3].Text;
        txtrepassword.Text = gvBank.SelectedRow.Cells[3].Text;
        txtmobile.Text = gvBank.SelectedRow.Cells[4].Text;
        drroleid.SelectedValue = lblrole.Text;

        btSave.Text = "Update";

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Button lnkbtn = sender as Button;
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            Label lblid = (Label)row.Cells[0].FindControl("lblid");

            mydal.deleteUser(lblid.Text);

            string strconfirm = "<script>if(window.confirm('Delete Ok')){window.location.href='frm_user.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
        }
        catch (Exception ex)
        { }
        bind();
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPassword.Text != txtrepassword.Text)
            {
                //laMeg.Text = "Password not Matched";
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Password not Matched !');", true);
                return;
            }
            txtlog_id.ReadOnly = false;
            if (btSave.Text == "Save")
            {
                //USERID,USER_NAME,USER_PASSWORD, ADDRESS,MOBILE
                string[] fivalue = new string[9];
                fivalue[0] = txtlog_id.Text.Trim();
                fivalue[1] = txtuser_name.Text.Trim();                
                fivalue[2] = txtPassword.Text.Trim();
                fivalue[3] = txtaddress .Text;
                fivalue[4] = txtmobile .Text;               
               
                fivalue[5] = drroleid.SelectedValue;            
             
                bool success = mydal.save_user(fivalue);
                if (success == true)
                {
                    //laMeg.Text = "Save Successfully";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Save Successfully !');", true);
                    Response.Redirect(Request.Url.PathAndQuery, true);

                    string strconfirm = "<script>if(window.confirm('Save Successfully !')){window.location.href='frm_user.aspx'}</script>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
                }
                else
                    //laMeg.Text = "your data already exist";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Your data already exist');", true);
            }
            else
            {
                string[] fivalue = new string[10];
                fivalue[0] = txtlog_id.Text.Trim();
                fivalue[1] = txtuser_name.Text.Trim();

                fivalue[2] = txtPassword.Text.Trim();
                fivalue[3] = txtaddress.Text;
                fivalue[4] = txtmobile.Text;

               

                fivalue[5] = drroleid.SelectedValue;
                fivalue[6] = Label1.Text;

            
                bool success = mydal.update_user(fivalue);
                if (success == true)
                    //laMeg.Text = "Update Successfully";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Update Successfully !');", true);
                else
                    //laMeg.Text = "your data already exist but sub field changed";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Your data already exist but sub field changed');", true);
                btSave.Text = "Save";
                bind();
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
       
        txtlog_id.Text = null;
        txtuser_name.Text = null;
        txtPassword.Text = null;
        txtmobile.Text = null;
        txtaddress.Text = null;
        btSave.Text = "Save";
    }
   
    protected void AllDDSelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlCircleSelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddDept_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}
