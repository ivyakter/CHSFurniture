<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" EnableEventValidation="false"  Inherits="Pages_OnlineOrder_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class=" col-md-5">
        <table style="width:100%">
            <tr>
                <td>Order Id:</td>
                <td><asp:Label ID="lvlOrderId" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Customer Name:</td>
                <td><asp:Label ID="lvlName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td><asp:Label ID="lvlPhone" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Date</td>
                <td><asp:Label ID="lvlDate" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br/>
        </div>
    <div class=" col-md-10">
        <asp:GridView ID="gvOrderDetails" AutoGenerateColumns="False" ShowFooter="True" runat="server" CssClass="table table-striped table-bordered table-hover"  OnRowCommand="gvOrderList_RowCommand"
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="S/N" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pid">
                    <ItemTemplate>
                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("Pid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                     
                <asp:TemplateField HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="lblClientId" runat="server" Text='<%#Eval("Pname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblBusinessName" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
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

