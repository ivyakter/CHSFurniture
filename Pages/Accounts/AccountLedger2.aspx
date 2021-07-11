<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="AccountLedger2.aspx.cs" Inherits="Pages_Accounts_AccountTree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="container">
  <div class="row">           
        <div class="col-md-3">
         <table width="80%">
        <tr>
            <td style="width:80%">
                <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" ShowCheckBoxes="All"
                    ImageSet="Arrows" CssClass="style194" align="left" 
                    Font-Names="Courier New" onselectednodechanged="TreeView1_SelectedNodeChanged">
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
            
        </tr>
    </table>
       <asp:DropDownList ID="ddlChartofAccounts" runat="server"  AutoPostBack="true" 
                                CssClass="form-control js-example-placeholder-single" 
                                onselectedindexchanged="ddlChartofAccounts_SelectedIndexChanged">
                            </asp:DropDownList>
        </div>
        <div class="col-md-8">

        <asp:GridView ID="gvAccountTree" AutoGenerateColumns="False" CssClass="table table-hover table-bordered" ShowFooter="True" runat="server"  Width="80%">
            <Columns>
            <asp:TemplateField HeaderText="S/N" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Id">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountCode" runat="server" Text='<%#Eval("AccCode") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAccountCode" runat="server" Text='<%#Eval("AccCode") %>'></asp:TextBox>
                        <asp:TextBox ID="txtId" runat="server" Visible="false" Text='<%#Eval("Id") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountName" runat="server" Text='<%#Eval("AccName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAccountName" runat="server" Text='<%#Eval("AccName") %>'></asp:TextBox>  
                    </EditItemTemplate>
                </asp:TemplateField>   
                <asp:TemplateField HeaderText="Dr Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountNamde" runat="server" Text='<%#Eval("drAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   
                <asp:TemplateField HeaderText="cr Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccountNdsame" runat="server" Text='<%#Eval("crAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>              
              
         </Columns>
        </asp:GridView>


        </div>
</div>
</div>
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
