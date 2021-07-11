<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddModel.aspx.cs" Inherits="Pages_InformationSetup_AddModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="form-horizontal">
        <div class="form-group">
            <label class="col-md-2">
                Model Id:
            </label>
            <div class="col-md-4">
                <asp:TextBox CssClass="form-control" ID="txtModelid" Width="80%" Enabled="false" runat="server"></asp:TextBox>
            </div>
        </div>

         <div class="form-group">
            <label class="col-md-2">
                Product Name:
            </label>
            <div class="col-md-4">
               <asp:DropDownList Width="80%" ID="ddlPName" runat="server"> 
                                    </asp:DropDownList>
            </div>
        </div>       

        <div class="form-group">
            <label class="col-md-2">
                Model Name:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtModelName" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>
       
        <div class="form-group">
            <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                    OnClick="btnSave_Click" />
                <asp:Button CssClass="Button" ID="btnupdate" Text="Update" runat="server" CausesValidation="False"
                    OnClick="btnupdate_Click" />
                <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListModel.aspx"
                    CausesValidation="False" meta:resourcekey="hlkBackResource1" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

