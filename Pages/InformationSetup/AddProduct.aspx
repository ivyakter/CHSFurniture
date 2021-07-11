<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Pages_InformationSetup_AccessoriesCategory" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-md-2">
                Product Id:
            </label>
            <div class="col-md-4">
                <asp:TextBox CssClass="form-control" ID="txtproductId" Width="80%" Enabled="false" runat="server"></asp:TextBox>
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
                <asp:DropDownList Width="80%" ID="ddlModel" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row form-group">
            <label class="col-md-2">
                Category
            </label>
            <div class="col-md-4">

                <asp:DropDownList ID="ddlCategory" Width="80%" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control category" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div class="row form-group">
             <label class="col-md-2">
                Sub Category
            </label>
            
            <div class="col-md-4">
                <asp:DropDownList ID="ddlSubCategory" Width="80%" CssClass="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-2">
                Price:
            </label>
            <div class="col-md-4">
                <asp:TextBox ID="txtCostingPrice" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-2">
                Picture :
            </label>
            <div class="col-md-4">
                <asp:FileUpload ID="fuImg01" Width="80%" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorfuImg01" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg01"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-2">
                Description :
            </label>
            <div class="col-md-8">
                <CKEditor:CKEditorControl ID="txtPDetails" BasePath="../../ckeditor/" runat="server">
                </CKEditor:CKEditorControl>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPDetails"></asp:RequiredFieldValidator>--%>
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                    OnClick="btnSave_Click" />

                <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListProduct.aspx"
                    CausesValidation="False" meta:resourcekey="hlkBackResource1" />
            </div>
        </div>
    </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

