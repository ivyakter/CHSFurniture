<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="PaymentReceive.aspx.cs" Inherits="Pages_Accounts_PaymentReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Textbox {
            height: 30px;
        }

        .form-control {
            padding: 0px;
        }

        span {
            text-align: left;
        }
    </style>
</asp:Content>

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">

     <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label> 
    <div style="height: 100%;">
       
        <asp:Panel ID="Panel1" runat="server">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label" runat="server" Text="Receive Voucher No"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false" CssClass="form-control Textbox" style="height: 18px;"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6" ">
                        <div class="row form-group">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <asp:Label ID="label5" runat="server" Text="Date"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" style="width: 245px;margin-left: -5px;" ></asp:TextBox>
                                <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                                    Format="MM/dd/yyyy">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                    CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlIncome" runat="server">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label7" runat="server" Text="Select Received Client"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" CssClass="form-control Textbox"
                                    OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label1" runat="server" Text="Name of Reciver"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control Textbox" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                         <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label10" runat="server" Text="Client Id"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtClientId" runat="server" CssClass="form-control Textbox" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label4" runat="server" Text="Address"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control Textbox" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label2" runat="server" Text="Phone"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtphone" runat="server" CssClass="form-control Textbox" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                     <div class="row">
                    
                         <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label8" runat="server" Text="Transaction Type"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" CssClass="form-control Textbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Bank</asp:ListItem>
                                    <asp:ListItem Value="1">Cash</asp:ListItem>
                                    <asp:ListItem Value="2">Credit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label3" runat="server" Text="Bank Name"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control Textbox"  AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label9" runat="server" Text="Branch Name"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlBranch" runat="server" class="form-control Textbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label6" runat="server" Text="Account Info"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control Textbox" placeholder=" e.g.:- Mr. karim, A/C No.1234565678789"></asp:TextBox>
                            </div>
                        </div>

                              <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label11" runat="server" Text="Payment Amount"></asp:Label>
                               
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtPayAmount" runat="server" CssClass="form-control Textbox" placeholder=" e.g.:- 10000"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPayAmount"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
      </asp:Panel> 



       
         <div class="">
            <div class="">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:content>
<asp:content id="Content3" contentplaceholderid="script" runat="Server">
</asp:content>
