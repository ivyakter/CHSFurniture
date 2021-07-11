using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Accounts_CostingReport : System.Web.UI.Page
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

            DataTable dt = mydal.GetSalesCostReport();

            objreportdoc.Load(Server.MapPath("~/Pages/Accounts/CostingReport.rpt"));
            objreportdoc.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = objreportdoc;

            string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/Pages/Accounts/CostingReport.rpt");
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
    protected void CrystalReportViewer1_Load(object sender, EventArgs e)
    {

    }

    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}