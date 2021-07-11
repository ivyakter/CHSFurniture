using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data.SqlClient;
public partial class frm_role_detail : System.Web.UI.Page
{
    DAL mydal = new DAL();
    string uid = "";
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
       }

        if (!IsPostBack)
        {
            mydal.dd_role(drroleid);
            //DataSet ds = new DataSet();
            //string cnstr = ConfigurationManager.ConnectionStrings["schoolConnection"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(cnstr))
            //{
            //    string sql = "Select * from TBL_TASK_MASTER";
            //    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //    da.Fill(ds);
            //    da.Dispose();
            //}
            //ds.DataSetName = "Menus";
            //ds.Tables[0].TableName = "Menu";
            //DataRelation relation = new DataRelation("ParentChild",
            //        ds.Tables["Menu"].Columns["ID"],
            //        ds.Tables["Menu"].Columns["PARENTID"],
            //        true);

            //relation.Nested = true;
            //ds.Relations.Add(relation);
            //ds.WriteXmlSchema("d:\\a.xml");
            //xmlDataSource1.Data = ds.GetXml();
            //xmlDataSource1.DataBind();

            fill_Tree2();
        }
    }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    void fill_Tree2()
    {



        DataSet PrSet = PDataset("Select * from TBL_TASK_MASTER where PARENTID is null AND FOR_ALL='N' ORDER BY ID ASC");

        TreeView1.Nodes.Clear();

        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {

            TreeNode tnParent = new TreeNode();

            tnParent.Text = dr["TEXT"].ToString();

            tnParent.Value = dr["ID"].ToString();

          //  tnParent.PopulateOnDemand = true;

            tnParent.ToolTip = "Click to get Child";

            tnParent.SelectAction = TreeNodeSelectAction.SelectExpand;

            tnParent.CollapseAll();

            tnParent.Selected = true;           

            TreeView1.Nodes.Add(tnParent);

            FillChild(tnParent, tnParent.Value);

        }



    }

    public void FillChild(TreeNode parent, string ParentId)
    {

        DataSet ds = PDataset("Select * from TBL_TASK_MASTER where FOR_ALL='N' AND PARENTID =" + ParentId+" ORDER BY ID ASC");

        parent.ChildNodes.Clear();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            parent.ShowCheckBox = false;
            TreeNode child = new TreeNode();

            child.Text = dr["TEXT"].ToString().Trim();

            child.Value = dr["ID"].ToString().Trim();

            if (child.ChildNodes.Count == 0)
            {

                child.PopulateOnDemand = true;

            }
            else
            {
                parent.Checked = false;
                
            }

            child.SelectAction = TreeNodeSelectAction.SelectExpand;
            child.Selected = false;
            child.CollapseAll();
            //child.ShowCheckBox = true;
            parent.ChildNodes.Add(child);

        }

    }



    protected DataSet PDataset(string Select_Statement)
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        SqlDataAdapter ad = new SqlDataAdapter(Select_Statement, cn);

        DataSet ds = new DataSet();

        ad.Fill(ds);

        return ds;



    }
    /////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnsaveCom_Click(object sender, EventArgs e)
    {

        mydal.deleteprevious(drroleid.SelectedValue.ToString());
        for(int i=0;i<TreeView1 .Nodes.Count ;i++)
        {
            if (TreeView1.Nodes[i].Checked == true || TreeView1.Nodes[i].ChildNodes.Count > 0)
            {
                string[] fivalue = new string[2];
                fivalue[0] = drroleid.SelectedValue;
                fivalue[1] = TreeView1.Nodes[i].Value;
                mydal.save_role_detail(fivalue, uid);
                //   ListBox1.Items.Add(TreeView1.Nodes[i].Text);
                for (int ii = 0; ii < TreeView1.Nodes[i].ChildNodes.Count; ii++)
                {
                    if (TreeView1.Nodes[i].ChildNodes[ii].Checked == true)
                    {
                        string[] fival = new string[2];
                        fival[0] = drroleid.SelectedValue;
                        fival[1] = TreeView1.Nodes[i].ChildNodes[ii].Value;
                        mydal.save_role_detail(fival, uid);
                    }
                    //ListBox1.Items.Add(TreeView1.Nodes[i].ChildNodes [ii] .Text);
                }
            }
        }
        //lameg.Text = "Save Successful";
        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Successfully Saved !');", true);
    }
    protected void btnClearcom_Click(object sender, EventArgs e)
    {
        drroleid.SelectedIndex = 0;
        Clear();
       
    }

    protected void drroleid_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        DataSet ds=new DataSet(); 
        DataTable dt = mydal.selectusertask(drroleid.SelectedValue.ToString());
        ds.Tables.Add(dt);
        foreach (DataRow mrow in dt.Rows)
        {
            string task = mrow["id"].ToString();
            for (int i = 0; i < TreeView1.Nodes.Count; i++)
            {
                if (TreeView1.Nodes[i].Value == task)
                {
                    TreeView1.Nodes[i].Checked = true;
                    goto brk;
                }

                else
                {
                    for (int ii = 0; ii < TreeView1.Nodes[i].ChildNodes.Count; ii++)
                    {
                        if (TreeView1.Nodes[i].ChildNodes[ii].Value == task)
                        {
                            TreeView1.Nodes[i].ChildNodes[ii].Checked = true;
                            goto brk;
                        }

                    }
                }
            }
        brk: continue;
        }
    }

    private void Clear()
    {
        for (int i = 0; i < TreeView1.Nodes.Count; i++)
        {
            TreeView1.Nodes[i].Checked = false;


            for (int ii = 0; ii < TreeView1.Nodes[i].ChildNodes.Count; ii++)
            {
                TreeView1.Nodes[i].ChildNodes[ii].Checked = false;

            }

        }
    }
}
