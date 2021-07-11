﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="PaymentVoucherEdit.aspx.cs" Inherits="Pages_Accounts_PaymentVoucherEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <asp:Label ID="lblhiddentotal" runat="server" Visible="false"></asp:Label>

    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12 text-center h3 text-danger">
                    Payment Voucher Edit
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label>
                            </div>
                            <div class="col-md-8">
                             <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false" Visible="false" ></asp:TextBox>
                             <asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>
                                <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                                    Format="yyyy/MM/dd">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                    CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label3" runat="server" Text="Trans Type"></asp:Label>
                            </div>
                            <div class="col-md-8">
                              <asp:DropDownList ID="ddlIncomeType" runat="server" CssClass="form-control Textbox">                              
                            </asp:DropDownList>
                            </div>
                        </div>
                        <br />                       
                       
                    </div>

                    <div class="col-md-6">
                   
                         <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="Invoice No:"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control js-example-placeholder-single" OnSelectedIndexChanged="ddlvoucherno_SelectedIndexChanged" Width="65%" ID="ddlvoucherno"></asp:DropDownList>
                                <%-- <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false" Height="20px" class="form-controls"></asp:TextBox>--%>
                            </div>
                        </div>


                        <div class="row" style="visibility:hidden">
                            <div class="col-md-3">
                                <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="lblratesum" Text="0" runat="server" ></asp:Label>
                    </div>

                </div>
            </div>
          
             <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                        OnRowCommand="Gridview1_RowCommand" OnRowDataBound="Gridview1_RowDataBound" BackColor="White"
                        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Row No." />
                            
                            <asp:TemplateField HeaderText="&nbsp;Name of Legder">
                                <ItemTemplate>
                                <asp:HiddenField ID="hfvendorname" runat="server" Value='<%#Eval("Client_Name") %>' />
                                    <asp:DropDownList Width="95%" ID="ddlvendorname"  CssClass="form-control js-example-placeholder-single" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                        
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdescription" Text='<%#Eval("ExpDescription") %>' Width="70%" Height="20px" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" Visible="false" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                                </FooterTemplate>
                            </asp:TemplateField>
              
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                     <asp:HiddenField ID="DbRownumber" runat="server" Value='<%#Eval("ID") %>' />
                                     <asp:TextBox ID="txtamount" OnTextChanged="txtamount_TextChanged" AutoPostBack="true" Text='<%#Eval("Credit") %>' Width="70%" Height="20px" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                Total <asp:Label ID="lblAlltotal" Font-Size="Larger" Font-Bold="true" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" Font-Size="Larger" Font-Bold="True"></FooterStyle>
                            </asp:TemplateField>

                          <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                     
                                    <asp:Button ID="delete" runat="server" Text="Del" OnClick="delete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </div>
            </div>


            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-10">
                    <table width="100%">
                        <tr>
                            <br />
                            <asp:Label ID="label6" runat="server" Text="Comment"></asp:Label>
                            <td align="left">
                                <asp:TextBox ID="txtComment" Width="85%" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>



            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-11" style="float: initial;">
                    <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" />
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

