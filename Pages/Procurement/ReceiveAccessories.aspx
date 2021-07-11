<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ReceiveAccessories.aspx.cs" Inherits="Pages_Procurement_ReceiveBulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>

            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"
                SkinID="SampleGridView" AllowPaging="True" PageSize="8" CssClass="table table-striped table-bordered table-hover" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="&nbsp;&nbsp; Action">
                        <ItemTemplate>
                            <asp:Button ID="btnReceive" runat="server" Text="Received" OnClick="btnReceive_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="id" HeaderText="Row Id" />
                    <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No" />
                    <asp:BoundField DataField="productItem" HeaderText="Product Item" HtmlEncode="false" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" HtmlEncode="false" />

                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="Larger"></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

