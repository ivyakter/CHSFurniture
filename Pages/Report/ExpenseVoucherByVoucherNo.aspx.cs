using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CrystalDecisions.Shared;

public partial class Pages_Report_ExpenseVoucherByVoucherNo : System.Web.UI.Page
{
    DAL mydal = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        reportLoad();
    }
    public void reportLoad()
    {
        CrystalReportViewer1.Visible = true;

        ReportDocument objreportdoc = new ReportDocument();
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

      
     
        try
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
            sqlcon.Open();

            DataTable dt = mydal.GetExpenseVoucherReportByVoucherNo(Session["VoucherNo"].ToString());

            objreportdoc.Load(Server.MapPath("../Report/ExpenseVoucherReport.rpt"));
            objreportdoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = objreportdoc;

            string strRptPath = System.Web.HttpContext.Current.Server.MapPath("../Report/ExpenseVoucherReport.rpt");
            objreportdoc.Load(strRptPath);
            objreportdoc.SetDataSource(dt);
            objreportdoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
    }
}