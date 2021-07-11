<%@ Page Title="Add Bank" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="frm_BankSetup.aspx.cs" Inherits="frm_BankSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 595px;
            background-color: #EAEAEA;
        }
        .style2
        {
        }
        .style189
        {
            width: 300px;
            background-color: #EAEAEA;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 800px; width: 100%;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div align="center">
                    <div style="width: 75%; border: solid black 1px; margin-top: 20px;">
                        <div align="center" class="Tidiv">
                            <h3>
                                <asp:Label ID="latitle" runat="server" Text="Bank setup"></asp:Label></h3>
                        </div>
                        <div class="style1">
                            <div class="style2">
                                <asp:Label ID="laMeg" runat="server" ForeColor="Red"></asp:Label>
                                &nbsp;
                            </div>
                            <div class="row">
                                <div class="col-md-3" style="padding-top: 5px;">
                                    <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label></div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtBankName" CssClass="form-control" runat="server"></asp:TextBox></div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bank Name Required"
                                    ControlToValidate="txtBankName" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <div class="style2">
                                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                </div>
                                <div class="style189">
                                    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" Width="70px"
                                        ValidationGroup="sv" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Do you want to Save?"
                                        TargetControlID="btSave">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;<asp:Button ID="btClear" runat="server" Text="Clear" Width="70px" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    </asp:UpdatePanel>
                    <asp:GridView ID="gvBank" runat="server" DataKeyNames="id" Width="75%" OnSelectedIndexChanged="gvDocMST_SelectedIndexChanged"
                        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnPageIndexChanging="gvDocMST_PageIndexChanging">
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="BANK_NAME" HeaderText="Bank Name" ItemStyle-Width="120px">
                            </asp:BoundField>
                            <asp:BoundField DataField="create_by" HeaderText="Create By"></asp:BoundField>
                            <asp:BoundField DataField="create_date" HeaderText="Create Date" ItemStyle-Width="100px"
                                DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/Untitled.png" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
