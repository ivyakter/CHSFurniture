<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewPurchaseProduct.aspx.cs" Inherits="Pages_Procurement_ViewPurchaseProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h2 text-red text-center">
       Purchase Product List
    </div>
    <div class="row" style="display:none">
        <div class="col-md-4">
            From
            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"
                Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
        <div class="col-md-4">
            To
            <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"
                Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-success" OnClick="btnShow_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-success"
                OnClick="btnPrint_Click" />
        </div>
    </div>



    <asp:GridView ID="Gridview1" runat="server" PageSize="15" AllowPaging="true" OnPageIndexChanging="Gridview1_PageIndexChanging" AutoGenerateColumns="False"
        SkinID="skinGridList">
        <Columns>
            <asp:TemplateField HeaderText="SL">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No" />
            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-success"
                PostBackUrl='<%# String.Concat("PurchaseAccessoriesEdit.aspx?Id=", Eval("VoucherNo").ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

