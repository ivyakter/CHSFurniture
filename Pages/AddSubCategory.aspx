<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSubCategory.aspx.cs" Inherits="Pages_Set_AddSubCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />

 


            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-10 col-md-offset-2">


                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-md-2">
                                    Category ID :
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtsubcatid" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">
                                   SubCategory Name:
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtsubcategoryname" runat="server"></asp:TextBox>
                                </div>
                            </div>

                             <div class="form-group">
                                <label class="col-md-2">
                                    Menu Level:
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlmenulevel" >
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2">
                                    Category Name:
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control" ></asp:DropDownList>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                                    <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                                        OnClick="btnSave_Click" />
                                    <asp:Button CssClass="Button" ID="btnupdate" Text="Update" runat="server" CausesValidation="False"
                                        OnClick="btnupdate_Click" />
                                    <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListSubCategory.aspx"
                                        CausesValidation="False" meta:resourcekey="hlkBackResource1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
   


</asp:Content>

