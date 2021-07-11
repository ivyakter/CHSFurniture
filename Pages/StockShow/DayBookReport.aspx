<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="DayBookReport.aspx.cs" Inherits="Pages_Reports_DayBookReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<center> <h3>Day Book Report</h3></center>
    <div class="clearfix">      
        <div class="row form-group">
        <div class="col-md-1">
        Date:
        </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtDate" runat="server" 
                    CssClass="form-control" Style="width: 60%; height:20px;" placeholder="dd-MM-yyyy" autocomplete="off">
                </asp:TextBox>
                <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                    Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtToDate" runat="server" autocomplete="off" AutoPostBack="true"
                    CssClass="form-control" Style="width: 80%; height:20px;" 
                    placeholder="dd-MM-yyyy" ontextchanged="txtToDate_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="ToDateClanaderExtender" runat="server" TargetControlID="txtToDate"
                    Format="dd-MM-yyyy">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvtxtToDate" runat="server" ControlToValidate="txtToDate"
                    CssClass="failureNotification" ErrorMessage="required" ToolTip="Date required"
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
    </div>
    <div class="row">
        <asp:GridView ID="gridViewDayBook" runat="server" AllowPaging="true" PageSize="100"
            EmptyDataText="No records to show" AutoGenerateColumns="false" ShowFooter="True"
            OnRowDataBound="gridViewDayBook_RowDataBound" OnRowCommand="gridViewDayBook_RowCommand" GridLines="None"
            CssClass="table table-responsive table-striped table-hover"
            SkinID="SampleGridView" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="&nbsp;&nbsp; Date">
                    <ItemTemplate>
                        &nbsp;&nbsp; <%# Eval("Date", "{0:dd/MM/yyyy}")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Particular">
                    <ItemTemplate>
                        <%# Eval("Client_Name")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="false" HeaderText="&nbsp;&nbsp; Links">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblExternalLinks" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Voucher Type">
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

                <asp:TemplateField HeaderText="Debit">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                    <asp:Label ID="lblDebit" runat="server" Text='<%# Eval("Debit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Credit">
                    <ItemTemplate>
                        &nbsp;&nbsp;
                    <asp:Label ID="lblCredit" runat="server" Text='<%# Eval("Credit")%>'></asp:Label>
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

                <asp:TemplateField HeaderText="&nbsp;&nbsp; Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteRow" CommandArgument="<%# Container.DataItemIndex %>"
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
    <asp:Label runat="server" Visible="false" ID="lblTransactionTypeHidden"></asp:Label>
    <div class="mx-auto">
        <asp:LinkButton runat="server" ID="btnPrint" Width="100px" CssClass="btn btn-success" 
            onclick="btnPrint_Click">Print</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
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

