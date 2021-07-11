<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ListAccessories.aspx.cs" Inherits="Pages_InformationSetup_ListAccessories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Add New" PostBackUrl="AddAccessories.aspx"></asp:Button>
    </div>

    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" OnRowDataBound="gv_RowDataBound" OnRowCancelingEdit="gv_RowCancelingEdit" OnRowEditing="gv_RowEditing" OnRowCommand="gv_RowCommand" OnRowUpdating="gv_RowUpdating" PageSize="50" CssClass="table table-striped table-bordered table-hover" Width="100%" OnPageIndexChanging="gv_PageIndexChanging">
        <Columns>

            <asp:TemplateField HeaderText="Delete" HeaderStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btndelete" runat="server" CausesValidation="false" CssClass="btn btn-danger btn-xs" Font-Size="Small" CommandName="cmdDelete" CommandArgument='<%#Eval("ID")%>'
                        Text="Delete"  />
                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btndelete"
                        ConfirmText="Do You Realy Want To Delete This Information !!!" runat="server">
                    </asp:ConfirmButtonExtender>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" ForeColor="Black"></HeaderStyle>
            </asp:TemplateField>

            <asp:CommandField HeaderText="Edit" CausesValidation="false" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-ForeColor="Black" ShowEditButton="true">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:CommandField>            
            <asp:TemplateField HeaderText="&nbsp;&nbsp;  Product Id">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("ID")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Product Name">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("AccessoriesName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAccessoriesName" Enabled="false" runat="server" Text='<%#Eval("AccessoriesName")%>'></asp:TextBox>
                    <asp:TextBox ID="txtPID" runat="server" Visible="false" Text='<%#Eval("ID") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                   <asp:Label ID="lblCategory" runat="server" Visible="true" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                   <asp:DropDownList Width="95%" ID="ddlCategory" runat="server">
                    </asp:DropDownList>                  
                     <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Eval("CategoryName") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Model">
                <ItemTemplate>
                   <asp:Label ID="lblModel" runat="server" Visible="true" Text='<%# Eval("Model") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                   <asp:DropDownList Width="95%" ID="ddlModel" runat="server" CssClass="form-control js-example-placeholder-single">
                    </asp:DropDownList>                  
                     <asp:Label ID="lblModel" runat="server" Visible="false" Text='<%# Eval("Model") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                      <asp:Label ID="lblCostingPrice" runat="server" Visible="true" Text='<%# Eval("Price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="txtCostingPrice" runat="server" Text='<%#Eval("Price")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Namefromtblproductimage" Visible="false" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblNamefromtblimage" runat="server" Visible="true" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle  Width="100px" />
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <img width="40px" src="../../AccessoriesImage/<%#Eval("PID") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='images/noimage.jpg'">
                    <%-- <ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center">--%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                      <asp:Label ID="lblPIMGID" runat="server" Visible="false" Text='<%# Eval("PIMGID") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

