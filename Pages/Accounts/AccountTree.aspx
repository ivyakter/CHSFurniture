<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeFile="AccountTree.aspx.cs" Inherits="Pages_Accounts_AccountTree" %>
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="table" width="100%">
        <tr>
            <td style="width:50%">
                <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" ShowCheckBoxes="All" onselectednodechanged="TreeView1_SelectedNodeChanged"
                    ImageSet="Arrows" CssClass="style194" align="left" Font-Names="Courier New">
                    <ParentNodeStyle Font-Bold="False" CssClass="style194" />
                    <LevelStyles>
                        <asp:TreeNodeStyle CssClass="style194" Font-Underline="False" />
                    </LevelStyles>
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" BackColor="#CCCCCC" />
                    <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" />
                    <DataBindings>
                        <asp:TreeNodeBinding DataMember="MenuItem" TextField="text" ValueField="id" />
                    </DataBindings>
                    <RootNodeStyle CssClass="style194" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" ChildNodesPadding="0px" CssClass="style194" />
                    <LeafNodeStyle CssClass="style194" NodeSpacing="0px" />
                </asp:TreeView>
            </td>
            <td style="width:50%">
                <table class="table" width="100%">
                    <tr>
                    <td></td>
                        <td>Account Name</td>     
                        <td>Account Code</td>                                       
                    </tr>
                    <tr>
                     <td> <asp:DropDownList ID="ddlClientname" Visible="false" OnSelectedIndexChanged="ddlClientname_SelectedIndexChanged" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <br /> <asp:DropDownList ID="ddlsuppliername"  Visible="false" OnSelectedIndexChanged="ddlsuppliername_SelectedIndexChanged" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" runat="server"></asp:DropDownList>
                     <br /> <asp:DropDownList ID="ddllabour" Visible="false" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddllabour_SelectedIndexChanged" runat="server"> </asp:DropDownList>
                    </td>
                     <td><asp:TextBox runat="server" CssClass="form-control" ID="txtAccName" ></asp:TextBox> </td> 
                     <td><asp:TextBox runat="server" CssClass="form-control" Enabled="false" ID="txtAccCode" ></asp:TextBox> </td>
                      <asp:Label ID="lblLevel" runat="server" Visible="false"></asp:Label>                      
                    </tr>
                    <tr>
                    <td colspan="2" align="center"><asp:Button runat="Server" ID="btnSave" Text="Save"  CssClass="btn-success" Width="150px"
                            onclick="btnSave_Click" /> </td><td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
   <center>
    <asp:DropDownList ID="ddlSearchAccount"  Width="300px" 
        CssClass="form-control js-example-placeholder-single" AutoPostBack="true" 
        runat="server" onselectedindexchanged="ddlSearchAccount_SelectedIndexChanged"></asp:DropDownList>
    <br /><br />

        <asp:GridView ID="gvAccountTree" AutoGenerateColumns="False" ShowFooter="True" runat="server" 
            OnRowCommand="gvAccountTree_RowCommand" Width="100%" OnRowCancelingEdit="gvAccountTree_RowCancelingEdit"
            OnRowEditing="gvAccountTree_RowEditing" OnRowUpdating="gvAccountTree_RowUpdating">
            <Columns>
            <asp:TemplateField HeaderText="S/N" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Delete">
                    <HeaderTemplate>                     
                        <asp:Label ID="label5" runat="server" Text="Delete" Width="70px"
                             ForeColor="#000" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("Id")%>'
                             Text="Delete" />
                              <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btndelete" ConfirmText="Do You Realy Want To Delete This Information !!!" runat="server">
                              </cc1:ConfirmButtonExtender>   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                 <asp:TemplateField HeaderText="Account Id">                   
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>                       
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtId" runat="server" Text='<%#Eval("Id") %>'></asp:TextBox>                    
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Code">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountCode" runat="server" Text='<%#Eval("AccCode") %>'></asp:Label>                       
                    </ItemTemplate>
                    <EditItemTemplate>                      
                        <asp:TextBox ID="txtAccountCode" runat="server" Text='<%#Eval("AccCode") %>'></asp:TextBox>                                          
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountName" runat="server" Text='<%#Eval("AccName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAccountName" runat="server" Text='<%#Eval("AccName") %>'></asp:TextBox>  
                         <asp:Label ID="lblAccountNameOld" Visible="false" runat="server" Text='<%#Eval("AccName") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>              
              
         </Columns>
        </asp:GridView>

    </center>
      <%--For Auto complete dropdown--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    
    <script type="text/javascript">
        $(function () {
            $(".js-example-placeholder-single").select2({
                placeholder: "Select",
                allowClear: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

 