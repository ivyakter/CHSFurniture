<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddClientName.aspx.cs" Inherits="Pages_InformationSetup_AddClientName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-md-2">
                Client Id:
            </label>
            <div class="col-md-4">
                <asp:TextBox CssClass="form-control" ID="txtclientid" Width="80%" Enabled="false" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2">
                Client Name:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtclientname" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
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
            <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                    OnClick="btnSave_Click" />
                <asp:Button CssClass="Button" ID="btnupdate" Text="Update" runat="server" CausesValidation="False"
                    OnClick="btnupdate_Click" />
                <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListClient.aspx"
                    CausesValidation="False" meta:resourcekey="hlkBackResource1" />
            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

