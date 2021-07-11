<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ReciveVoucher.aspx.cs" Inherits="Pages_Accounts_ReciveVoucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .Textbox {
            height: 22px;
        }

        .form-control {
            padding: 0px;
        }

        span {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <asp:Panel ID="Panel1" runat="server">

        <div class="col-md-12">
            <div class="row">
                <div class="col-md-6">
                    <div class="row form-group">
                        <div class="col-md-4">
                            <asp:Label ID="label" runat="server" Text="Voucher No"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false" CssClass="form-control Textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtVoucherName"
                                CssClass="failureNotification" ErrorMessage="Client Name is required." ToolTip="Client Name is required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row form-group">
                        <div class="col-md-4" style="padding-left: 0px;">
                            <asp:Label ID="label5" runat="server" Text="Date"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control Textbox"></asp:TextBox>
                            <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                                Format="yyyy/MM/dd">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12">
            <div class="row">
                <div class="col-md-6">
                    <div class="row form-group">
                        <div class="col-md-4">
                            <asp:Label ID="label8" runat="server" Text="Transaction Type"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlIncomeType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIncomeType_SelectedIndexChanged" CssClass="form-control Textbox">
                                <asp:ListItem Value="3">--Select--</asp:ListItem>
                                <asp:ListItem Value="0">Cash</asp:ListItem>
                                <asp:ListItem Value="1">Bank</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblBablance" runat="server"></asp:Label>
                        </div>
                    </div>

                </div>
                <div class="col-md-6">
                   <div class="row">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label1" runat="server" Visible="false" Text="Bank Name"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlBank" Visible="false" runat="server" class="form-control Textbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label3" runat="server" Visible="false" Text="Check/Receipt No"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                              <asp:TextBox ID="txtCheck" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>  
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <%--////////////////////////////////////--%>

    <div class="row">

        <div class="col-md-12">
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                OnRowCommand="Gridview1_RowCommand" OnRowDataBound="Gridview1_RowDataBound" BackColor="White"
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Row No." />

                    <asp:TemplateField HeaderText="&nbsp;Client Name">
                        <ItemTemplate>
                            <asp:DropDownList Width="95%" ID="ddlclientname" AutoPostBack="true" CssClass="form-control js-example-placeholder-single" OnSelectedIndexChanged="ddlclientname_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Vendor COAID" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCOA" Height="20px" runat="server" Width="95%" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdescription" TextMode="MultiLine" Height="20px" runat="server" Width="120%" />
                        </ItemTemplate>
                        <ControlStyle Width="300" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Total Received">
                        <ItemTemplate>
                            <asp:TextBox ID="txtpayableamount" Enabled="false" Width="95%" Height="20px" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Received Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtpayment" OnTextChanged="txtpayment_TextChanged" AutoPostBack="true" Height="20px" runat="server" Width="95%" />
                        </ItemTemplate>
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
        <div class="col-md-12">
            <div class="col-md-2 col-md-offset-7">
                <asp:Label runat="server" ID="lblalltotal" Font-Size="Larger" Text="All Total"></asp:Label>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox runat="server" ID="txtalltotal" BorderColor="#ff0000" ForeColor="#ff3300" Font-Size="Larger"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-1">
        </div>
        <div class="col-md-10">
            <table width="100%">
                <tr>
                    <br />
                    <asp:Label ID="label12" runat="server" Text="Comment"></asp:Label>
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
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

