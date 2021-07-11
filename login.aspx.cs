using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

public partial class frmlogin : System.Web.UI.Page
{

    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    SqlCommand cmd = null;

    DAL mydal = new DAL();
    dataobj obj = new dataobj();
    public string MyDomain { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.RemoveAll();
            txtusername.Focus();
            string x = Request.QueryString["x"];
            if (x == "1")
            {
                laMeg.Text = "JavaScript Disabled.Please Enable JavaScript first";
            }
            else
            {
                laMeg.Text = "";
            }
        }

        // For Server IP Address
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        label1.Text = addr[addr.Length - 1].ToString();

        // For Client IP Address
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                label.Text = addresses[0];
            }
        }
        label.Text = context.Request.ServerVariables["REMOTE_ADDR"];

        // For Server MAC Address
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }
        label2.Text = sMacAddress;



        //string currentUserLoginName = Request.LogonUserIdentity.Name.Replace(MyDomain, string.Empty); // Get the current Windows authenticated user  
        string myCommandToRun = "/c nbtstat -a " + Request.UserHostName + @" >> " + AppDomain.CurrentDomain.BaseDirectory + ".txt"; //     Command line to run, I am creating my text file in the web application folder on the server.   

        //Execute the command  
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = myCommandToRun;
        process.Start();
        process.WaitForExit();
        //Start parsing the file created on disk  
        StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + ".txt");
        string MyLine = null;
        MyLine = sr.ReadToEnd();
        string[] MyStrings = MyLine.Trim().Split('\n'); //Array of strings from text file split by the return char  
        foreach (string item in MyStrings)
        {
            if (item.Trim().Contains("MAC Address"))
            {
                //Get the MAC Address  
                label3.Text = item.ToString().Remove(0, item.IndexOf('=') + 1).Trim();
            }
        }
    }
       
    protected void lbtnForgotPass_Click(object sender, EventArgs e)
    {
        if (txtusername.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Please Enter User ID to get Password');", true);
        }
        else
        {
            string mobno = "";
            string pass = "";
            DataTable dt = new DataTable();
            dt = DtList();
            foreach (DataRow dr in dt.Rows)
            {
                mobno = dr["MOBILE"].ToString();
                pass = dr["USER_PASSWORD"].ToString();

            }           
        }
    }
    public DataTable DtList()
    {
        DataTable dt = new DataTable();
        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
            string SQL = "select USERID,USER_PASSWORD,MOBILE from TBL_USER where USERID='"+txtusername.Text+"'";
          
            SqlCommand cmd = new SqlCommand(SQL, cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);           
        }
        catch (Exception ex)
        {
            
        }
        return dt;
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        
        laMeg.Text = "";
        string[] sql = { txtusername.Text, txtpassword.Text };
        DataTable dt = mydal.get_user_id(sql);
        if (dt.Rows.Count > 0)
        {
            laMeg.Text = null;

            Session["Uid"] = txtusername.Text;
            Session["Pwd"] = txtpassword.Text;
            Session["UName"] = dt.Rows[0]["user_name"].ToString();
            Session["idss"] = dt.Rows[0]["USERID"].ToString();
            obj.department = dt.Rows[0]["DIVISION_ID"].ToString();
            Session["roleid"] = dt.Rows[0]["role_id"].ToString();


            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            mydal.LoginDetails(date.ToString(), txtusername.Text, label1.Text, label2.Text);


            Response.Redirect("Pages/Admin/Dashboard.aspx");
        }
        else
        {
            Session["Uid"] = null;
            Session["Pwd"] = null;
            laMeg.Text = "Invalid or Inactive user";
        }
       
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
