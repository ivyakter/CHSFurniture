<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewExpenseVoucher.aspx.cs" EnableEventValidation="false" Inherits="Pages_Accounts_ViewExpenseVoucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-3">
From <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>  
<asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
</div>
<div class="col-md-3">
To <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>  
<asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
</div>
<div class="col-md-3">
    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-success" onclick="btnShow_Click" />
     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-success" 
        onclick="btnPrint_Click" />
</div>
    <div class="col-md-3">
            <br />
            <asp:TextBox ID="txtSearch" OnTextChanged="txtSearch_TextChanged" placeholder="Search By Voucher No"  CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
        </div>
</div>

<asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" OnRowCommand="Gridview1_RowCommand" OnPageIndexChanging="Gridview1_PageIndexChanging"   
        SkinID="skinGridList">
    <Columns>
        <asp:BoundField DataField="Vid" HeaderText="Voucher Id" />
        <%--<asp:BoundField DataField="ExpName" HeaderText="Expense Type" />--%>
        <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
         <asp:BoundField DataField="date" HeaderText="Date"  DataFormatString="{0:dd/MM/yyyy}" />
         <%-- <asp:BoundField DataField="ClientId" HeaderText="ClientId" />--%>
          <asp:BoundField DataField="TRType" HeaderText="Transection by" />
        <asp:TemplateField HeaderText="Edit/Delete">
                <ItemTemplate>
                    <br />
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DeleteRow" PostBackUrl='<%# String.Concat("PaymentVoucherEdit.aspx?Id=", Eval("Vid").ToString()) %>'>
                        <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>
                        </asp:LinkButton>
                    <%--<asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-success"
                PostBackUrl='<%# String.Concat("PaymentVoucherEdit.aspx?Id=", Eval("Vid").ToString()) %>' />--%>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteRow" CommandArgument="<%# Container.DataItemIndex %>" 
                            OnClientClick="return confirm('Are you sure you want to delete this record?');">
                        <span aria-hidden="true" class="glyphicon glyphicon-remove" style="color:red"></span>
                        </asp:LinkButton>
                    <asp:Label runat="server" ID="lblVoucher" Visible="false" Text='<%# Eval("Vid")%>'></asp:Label>
                    <br /><br />
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

