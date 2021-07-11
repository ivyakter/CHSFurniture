<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AccountsLedger.aspx.cs" Inherits="Pages_NewFolder1_AccountsLedger" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="clearfix">
      <center> <h3>Ledger Report</h3></center>
        <div class="row form-group">
          <div class="col-md-1">
        Date:
        </div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtFromDate" runat="server" placeholder="dd-MM-yyyy"
                    CssClass="form-control" Style="width: 80%; height:20px;" autocomplete="off"></asp:TextBox>
                <asp:CalendarExtender ID="FromDateClanaderExtender" runat="server" TargetControlID="txtFromDate"
                    Format="dd-MM-yyyy">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvtxtFromDate" runat="server" ControlToValidate="txtFromDate"
                    CssClass="failureNotification" ErrorMessage="required" ToolTip="Date required"
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-1">
                To
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtToDate" runat="server" autocomplete="off"
                    CssClass="form-control" Style="width: 80%; height:20px;" placeholder="dd-MM-yyyy"></asp:TextBox>
                <asp:CalendarExtender ID="ToDateClanaderExtender" runat="server" TargetControlID="txtToDate"
                    Format="dd-MM-yyyy">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvtxtToDate" runat="server" ControlToValidate="txtToDate"
                    CssClass="failureNotification" ErrorMessage="required" ToolTip="Date required"
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-1">
                <asp:Label ID="Label1" runat="server" Text="Ledger:- "></asp:Label>
            </div>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlLedger" runat="server"
                    OnSelectedIndexChanged="ddlLedger_SelectedIndexChanged" AutoPostBack="true"
                    CssClass="form-control js-example-placeholder-single" Style="width: 80%; height:20px;">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlLedger" runat="server" ControlToValidate="ddlLedger"
                    CssClass="failureNotification" ErrorMessage="required" ToolTip="Choose an option"
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row form-group">
            <div class="col-md-6">
              <h4>  Ledger Name: <asp:Label ID="lblLedgerName" runat="server" Text=""></asp:Label> </h4>
            </div>
            <div class="col-md-3">
                 <h4>  <asp:Label ID="Label2" runat="server" Text="Opening Balance: "></asp:Label>
                     <asp:Label ID="lblOpeningBalance" Text="0" runat="server"></asp:Label> </h4>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="gridViewLedger" runat="server" 
            OnPageIndexChanging="gridViewLedger_PageIndexChanging" OnRowDataBound="gridViewLedger_RowDataBound"
            OnRowCommand="gridViewLedger_RowCommand"
            EmptyDataText="No records to show" ShowFooter="True" GridLines="None"
            AutoGenerateColumns="false" CssClass="table  table-responsive table-striped table-hover"
            SkinID="SampleGridView" Width="100%">
            <Columns>
             <asp:TemplateField HeaderText="&nbsp;&nbsp; S/L">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Date">
                    <ItemTemplate>
                        &nbsp;&nbsp; <%# Eval("Date", "{0:dd/MM/yyyy}")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField Visible="false" HeaderText="&nbsp;&nbsp; Links">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblExternalLinks" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Particular">
                    <ItemTemplate>
                        <%# Eval("Client_Name")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Voucher Type">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblVoucherType" Text='<%# Eval("VoucherType")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Voucher No." FooterText="Total" FooterStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblVoucherNo" Text='<%# Eval("VoucherNo")%>'></asp:Label>
                        &nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Debit">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                    <asp:Label ID="lblDebit" runat="server" Text='<%# Eval("Credit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Credit">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                    <asp:Label ID="lblCredit" runat="server" Text='<%# Eval("Debit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                
                <asp:TemplateField HeaderText="&nbsp;&nbsp; Balance">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                    <asp:Label ID="lblBalance" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="&nbsp;&nbsp; Insert">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplinkNavigateInsert" CssClass="glyphicon glyphicon-plus" Style="color: green" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

             
                <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hplinkNavigateEdit" CssClass="glyphicon glyphicon-edit" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Remove">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteRow"
                            OnClientClick="return confirm('Are you sure you want to delete this record?');">
                        <span aria-hidden="true" class="glyphicon glyphicon-remove" style="color:red"></span>
                        </asp:LinkButton>
                         <asp:Label runat="server" ID="lblVoucher" Visible="false" Text='<%# Eval("VoucherNo")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="row form-group">
        <asp:Panel ID="panelBalance" Visible="false" runat="server">
            <div class="row form-group">
                <div class="col-sm-3">
                  <h4>   <asp:Label ID="Label20" runat="server" Text="Closing Balance: "></asp:Label>
                     <asp:Label ID="lblClosingBalance" Text="0" runat="server"></asp:Label> </h4>
                </div>
                <div class="col-sm-3">
                   
                </div>
            </div>           
        </asp:Panel>
    </div>
    <div class="mx-auto">
        <asp:LinkButton runat="server" ID="btnPrint" Width="100px" 
            CssClass="btn btn-success" onclick="btnPrint_Click">Print</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
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

