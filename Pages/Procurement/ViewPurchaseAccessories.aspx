<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewPurchaseAccessories.aspx.cs" Inherits="Pages_Procurement_ViewPurchaseAccessories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h2 text-red text-center">
       Accessories Purchase List
    </div>
    <div class="row">
        <div class="col-md-3">
            From
            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"
                Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
        <div class="col-md-3">
            To
            <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"
                Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-success" OnClick="btnShow_Click" />
        </div>
        <div class="col-md-3">
            <br />
            <asp:TextBox ID="txtSearch" OnTextChanged="txtSearch_TextChanged" placeholder="Search By Voucher No"  CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
        </div>
    </div>



    <asp:GridView ID="Gridview1" runat="server" PageSize="15" AllowPaging="true" OnRowCommand="Gridview1_RowCommand" OnPageIndexChanging="Gridview1_PageIndexChanging" AutoGenerateColumns="False"
        SkinID="skinGridList">
        <Columns>
            <asp:TemplateField HeaderText="SL">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" />
            
            <asp:TemplateField HeaderText="Edit/Delete">
                <ItemTemplate>
                    <br />
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DeleteRow" PostBackUrl='<%# String.Concat("PurchaseAccessoriesEdit.aspx?Id=", Eval("VoucherNo").ToString()) %>'>
                        <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>
                        </asp:LinkButton>
                    <%--<asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-success"
                PostBackUrl='<%# String.Concat("PurchaseAccessoriesEdit.aspx?Id=", Eval("VoucherNo").ToString()) %>' />--%>
                    &nbsp; &nbsp; &nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteRow" CommandArgument="<%# Container.DataItemIndex %>" 
                            OnClientClick="return confirm('Are you sure you want to delete this record?');">
                        <span aria-hidden="true" class="glyphicon glyphicon-remove" style="color:red"></span>
                        </asp:LinkButton>
                    <asp:Label runat="server" ID="lblVoucher" Visible="false" Text='<%# Eval("VoucherNo")%>'></asp:Label>
                    <br /><br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

