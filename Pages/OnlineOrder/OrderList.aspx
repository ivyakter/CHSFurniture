<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" EnableEventValidation="false"  Inherits="Pages_OnlineOrder_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class=" col-md-10">
        <asp:GridView ID="gvOrderList" AutoGenerateColumns="False" ShowFooter="True" runat="server" CssClass="table table-striped table-bordered table-hover"  OnRowCommand="gvOrderList_RowCommand"
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="S/N" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("OrderId")%>' CausesValidation="false"
                            Text="Delete" Height="30px" />

                        <asp:Button ID="btnViewDetails" runat="server" CausesValidation="false"
                            Text="View Details" PostBackUrl='<%# String.Concat("OrderDetails.aspx?Id=", Eval("OrderId").ToString()) %>' Height="30px" />

                    </ItemTemplate>
                </asp:TemplateField>     
                <asp:TemplateField HeaderText="Order Id">
                    <ItemTemplate>
                        <asp:Label ID="lblClientId" runat="server" Text='<%#Eval("OrderId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer id">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Customerid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label ID="lblBusinessName" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

