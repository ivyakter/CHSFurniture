using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Accounts_AccountTree : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAccountTree();
            LoadChartofAcc();
        }

    }
    public void LoadChartofAcc()
    {
        DataTable dt2 = mydal.getChartofAccounts();       
        ddlChartofAccounts.DataSource = dt2;
        ddlChartofAccounts.DataTextField = "AccName";
        ddlChartofAccounts.DataValueField = "AccCode";
        ddlChartofAccounts.DataBind();
        ddlChartofAccounts.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void LoadAccountTree()
    {
        DataTable PrSet = mydal.GetAccountHeads("0");

        TreeView1.Nodes.Clear();

        foreach (DataRow dr in PrSet.Rows)
        {
            TreeNode tnParent = new TreeNode();
            tnParent.Text = dr["AccName"].ToString();
            tnParent.Value = dr["AccCode"].ToString();
            //  tnParent.PopulateOnDemand = true;
            tnParent.ToolTip = "Click to get Child";
            tnParent.SelectAction = TreeNodeSelectAction.SelectExpand;
            tnParent.CollapseAll();
            tnParent.Selected = true;
            TreeView1.Nodes.Add(tnParent);
            FillChild2(tnParent, tnParent.Value);

        }
    }
    public void FillChild2(TreeNode parent, string ParentId)
    {

        DataTable ds = mydal.GetAccountHeads(ParentId);
        parent.ChildNodes.Clear();
        foreach (DataRow dr in ds.Rows)
        {
            //parent.ShowCheckBox = false;
            TreeNode child = new TreeNode();
            child.Text = dr["AccName"].ToString().Trim();
            child.Value = dr["AccCode"].ToString().Trim();
            child.SelectAction = TreeNodeSelectAction.SelectExpand;
            child.Selected = false;
            child.CollapseAll();
            //child.ShowCheckBox = true;
            parent.ChildNodes.Add(child);

            FillChild2(child, child.Value);
        }
    }

   
    
    int value = 0;
    private int GetNodeRecursive(TreeNode treeNode)
    {
        if (treeNode.Checked == true)
        {
           value= int.Parse(treeNode.Value);
           return value;
        }
        
        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            if (value == 0)
            {
                GetNodeRecursive(tn);
            }
            else {
                return value;
            }
        }
        return value;

    }
    public void LoadGrid(string accountId)
    {

        DataTable dt = new DataTable();
        try
        {
            dt = mydal.LoadBalanceReport(accountId);
            if (dt.Rows.Count > 0)
            {
                gvAccountTree.DataSource = dt;
                gvAccountTree.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvAccountTree.DataSource = dt;
                gvAccountTree.DataBind();
                gvAccountTree.Rows[0].Visible = false;

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string NodeId = TreeView1.SelectedValue;
        LoadGrid(NodeId);
    }
    protected void ddlChartofAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGridByAccount(ddlChartofAccounts.SelectedValue);
    }
    public void LoadGridByAccount(string accountId)
    {

        DataTable dt = new DataTable();
        try
        {
            dt = mydal.LoadBalanceReportByAcc(accountId);
            if (dt.Rows.Count > 0)
            {
                gvAccountTree.DataSource = dt;
                gvAccountTree.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvAccountTree.DataSource = dt;
                gvAccountTree.DataBind();
                gvAccountTree.Rows[0].Visible = false;

            }
        }
        catch (Exception ex)
        {

        }
    }
}