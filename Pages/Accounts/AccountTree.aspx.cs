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
            LoadChartOfAccount();
            LoadSuppliername();
            LoadEmployee();
            LoadVendorName();
        }
    }
    public void LoadChartOfAccount()
    {
        DataTable dt = mydal.GetAccountsAll();
        ddlSearchAccount.DataSource = dt;
        ddlSearchAccount.DataTextField = "AccName";
        ddlSearchAccount.DataValueField = "AccCode";
        ddlSearchAccount.DataBind();
        ddlSearchAccount.Items.Insert(0,new ListItem("--Select Account--","0"));
    }
    protected void LoadSuppliername()
    {
        DataTable dt = mydal.getClientList();
        ddlsuppliername.DataSource = dt;
        ddlsuppliername.DataTextField = "ClientName";
        ddlsuppliername.DataValueField = "ClientId";
        ddlsuppliername.DataBind();
        ddlsuppliername.Items.Insert(0, new ListItem("-Select Client-", "0"));
    }
    protected void ddlClientname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAccName.Text = ddlClientname.SelectedItem.ToString();
    }
    protected void LoadVendorName()
    {
        DataTable dt = mydal.getVendorListForAcc();
        ddlClientname.DataSource = dt;
        ddlClientname.DataTextField = "VendorName";
        ddlClientname.DataValueField = "VendorId";
        ddlClientname.DataBind();
        ddlClientname.Items.Insert(0, new ListItem("-Select Vendor-", "0"));
    }
    protected void LoadEmployee()
    {
        DataTable dt = mydal.GetEmployeeId();
        ddllabour.DataSource = dt;
        ddllabour.DataValueField = "OfficerId";
        ddllabour.DataTextField = "Name";
        ddllabour.DataBind();
        ddllabour.Items.Insert(0, new ListItem("-Select Employee-", "0"));
    }

    protected void ddllabour_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAccName.Text = ddllabour.SelectedItem.ToString();
    }
    protected void ddlsuppliername_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAccName.Text = ddlsuppliername.SelectedItem.ToString();
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
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string NodeId = TreeView1.SelectedValue;
        DataTable dtLastCode = mydal.GetLastAccCode(NodeId);
        if (dtLastCode.Rows.Count == 0)
        {
            txtAccCode.Text = "0"+ NodeId + "01";
            DataTable dt = mydal.GetNodeIdLevel(NodeId);
            lblLevel.Text = (Convert.ToInt32(dt.Rows[0][0].ToString())+1).ToString();
        }
        else
        {
            int rowcount =Convert.ToInt32(dtLastCode.Rows[0][0].ToString());
            int lastAccCode = rowcount + 1;
            txtAccCode.Text = "0" + lastAccCode;
            lblLevel.Text = dtLastCode.Rows[0][1].ToString();

            if (NodeId == "010101")
            {
                ddlClientname.Visible = false;
                ddlsuppliername.Visible = true;
                ddllabour.Visible = false;
                LoadSuppliername();
            }
            else if (NodeId == "010201")
            {
                ddlClientname.Visible = true;
                ddlsuppliername.Visible = false;
                ddllabour.Visible = true;                ;
                LoadVendorName();
                LoadEmployee();
            }
            else
            {
              
            }
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int prntid = 0;
        TreeNodeCollection nodes = this.TreeView1.Nodes;
        foreach (TreeNode n in nodes)
        {
            if (prntid == 0)
                prntid = GetNodeRecursive(n);

        }
        if (prntid > 0)
            if (txtAccCode.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Please Select Account Head !');", true);
            }
            else
            {
                mydal.SaveAcc(txtAccCode.Text, txtAccName.Text, "0" + prntid.ToString(),lblLevel.Text);

                if (ddlClientname.SelectedItem.ToString() != "-Select Client-")
                {
                    bool updateVendor = mydal.UpdateVendorAcc(txtAccCode.Text, ddlClientname.SelectedItem.ToString());
                   
                }
                if (ddlsuppliername.SelectedItem.ToString() != "-Select Vendor-")
                {
                    bool updateclientAcc = mydal.UpdateClientAcc(txtAccCode.Text, ddlsuppliername.SelectedValue);
                }
                if (ddllabour.SelectedItem.ToString() != "-Select Employee-")
                {
                    bool UpdateEmp = mydal.UpdateEmployeeAcc(txtAccCode.Text, ddllabour.SelectedItem.ToString());
                }
                txtAccName.Text = "";
                txtAccCode.Text = "";
                LoadAccountTree();
                LoadGrid();
               
            }      
    }


    int value = 0;
    private int GetNodeRecursive(TreeNode treeNode)
    {
        if (treeNode.Checked == true)
        {
            value = int.Parse(treeNode.Value);
            return value;
        }

        foreach (TreeNode tn in treeNode.ChildNodes)
        {
            if (value == 0)
            {
                GetNodeRecursive(tn);
            }
            else
            {
                return value;
            }
        }
        return value;

    }
    protected void ddlSearchAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrid();
    }
    public void LoadGrid()
    {

        DataTable dt = new DataTable();
        try
        {
            dt = mydal.LoadAccountTree(ddlSearchAccount.SelectedValue);
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

    protected void gvAccountTree_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdDelete")
            {
                string Id = e.CommandArgument.ToString();

                bool detete = mydal.DeleteAccLedger(Id);
                LoadGrid();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvAccountTree_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string Id = ((TextBox)gvAccountTree.Rows[e.RowIndex].FindControl("txtId")).Text;

            string lblAccountCode = ((TextBox)gvAccountTree.Rows[e.RowIndex].FindControl("txtAccountCode")).Text;
            string AccName = ((TextBox)gvAccountTree.Rows[e.RowIndex].FindControl("txtAccountName")).Text;
            string AccNameOld = ((Label)gvAccountTree.Rows[e.RowIndex].FindControl("lblAccountNameOld")).Text;

            bool update = mydal.EditAccountTree(lblAccountCode, AccName,AccNameOld, Id);

            gvAccountTree.EditIndex = -1;
            LoadGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void gvAccountTree_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAccountTree.EditIndex = e.NewEditIndex;
        LoadGrid();
    }

    protected void gvAccountTree_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAccountTree.EditIndex = -1;
        LoadGrid();
    }
    
}