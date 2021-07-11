<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="JournalEntriesList.aspx.cs" Inherits="Pages_Accounts_JournalEntriesList" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
        .table table tbody tr td a,
        .table table tbody tr td span
        {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .table table > tbody > tr > td > span
        {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #4484F1;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span
        {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span
        {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:hover
        {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix">
        <asp:Button ID="addbtn" runat="server" Text="Create New" PostBackUrl="JournalEntries.aspx">
        </asp:Button>
    </div>
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
            <div class="col-sm-1">
               
            </div>
            <div class="col-sm-3">
              
            </div>
        </div>
    <asp:GridView ID="journalgv" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="journalgv_PageIndexChanging" CssClass="table table-striped table-bordered table-hover"
        SkinID="SampleGridView"  Width="100%" OnSelectedIndexChanged="gv_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; S/L">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Voucher No">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbljournalId" Text='<%# Eval("JournalNo")%>'></asp:Label>                   
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Debit">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Debit")%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="&nbsp;&nbsp; Credit">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("Credit")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Date">
                <ItemTemplate>
                    &nbsp;&nbsp; <%# Eval("date", "{0:dd/MM/yyyy}")%>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="Edit" PostBackUrl='<%# String.Concat("JournalVoucherEdit.aspx?ID=", Eval("JournalNo").ToString()) %>' 
                        meta:resourcekey="btnEditResource1" />
                
                </ItemTemplate>
                 <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&nbsp;&nbsp; Edit">
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btndelete" runat="server" Text="Delete" 
                   OnClick="btndelete_Click"  meta:resourcekey="btnEditResource1" />
                 <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btndelete" ConfirmText="Do You Realy Want To Delete This Information !!!" runat="server">
                  </asp:ConfirmButtonExtender> 
                </ItemTemplate>
                 <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
     
        </Columns>
    </asp:GridView>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>
