<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddVendorName.aspx.cs" Inherits="Pages_InformationSetup_VendorName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-md-2">
                Vendor Id:
            </label>
            <div class="col-md-4">
                <asp:TextBox CssClass="form-control" ID="txtvendorid" Width="80%" Enabled="false" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2">
                Vendor Name:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtvendorname" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2">
                Business Name:
            </label>
            <div class="col-md-4">
                 <asp:TextBox ID="txtBusinessName" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
         
            <div class="form-group">
            <label class="col-md-2">
                Contact Number:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtcontact" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>
           <div class="form-group">
            <label class="col-md-2">
                Email Address:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>

            <div class="form-group">
            <label class="col-md-2">
                Address :
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtaddress" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="form-group">
            <label class="col-md-2">
                Chart Of Account :
            </label>
            <div class="col-md-4">
                 <asp:DropDownList ID="ddlChartofAccounts" runat="server" Width="80%" CssClass="form-control js-example-placeholder-single">
                            </asp:DropDownList>
            </div>
        </div>
                 
        <div class="form-group">
            <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                    OnClick="btnSave_Click" />
                <asp:Button CssClass="Button" ID="btnupdate" Text="Update" runat="server" CausesValidation="False"
                    OnClick="btnupdate_Click" />
                <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListVendor.aspx"
                    CausesValidation="False" meta:resourcekey="hlkBackResource1" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

