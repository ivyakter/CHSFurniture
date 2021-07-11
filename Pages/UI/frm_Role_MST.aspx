<%@ Page Title="Role Setup" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="frm_Role_MST.aspx.cs" Inherits="frm_Role_MST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 500px;
        }
        .style2
        {
            background-color: #EAEAEA;
            padding-left: 40px;
        }
        .style189
        {
            width: 300px;
            background-color: #EAEAEA;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 800px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <br />
                    <div style="width: 75%; border: solid black 1px; margin-top: 20px;">
                        <div align="center" class="Tidiv">
                            <h3>
                                <asp:Label ID="latitle" runat="server" Text="Role setup"></asp:Label></h3>
                        </div>
                        <table class="style1">
                            <tr>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="laMeg" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Role Name <span style="color: Red">*</span>
                                </td>
                                <td class="style189">
                                    <asp:TextBox ID="txtRoleName" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Role Name Required"
                                        ControlToValidate="txtRoleName" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Description
                                </td>
                                <td class="style189">
                                    <asp:TextBox ID="txtRoleDesc" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td class="style189">
                                    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" Width="70px"
                                        ValidationGroup="sv" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Do you want to Save?"
                                        TargetControlID="btSave">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;<asp:Button ID="btClear" runat="server" Text="Clear" Width="70px" OnClick="btnClear_Click" />
                                </td>
                            </tr>
                        </table>
                        <br/>
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    </asp:UpdatePanel>
                    <asp:GridView ID="gvRoleMST" runat="server" DataKeyNames="id" OnSelectedIndexChanged="gvRoleMST_SelectedIndexChanged"
                        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnPageIndexChanging="gvRoleMST_PageIndexChanging" Width="75%">
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="ROLE_NAME" HeaderText="Role Name" ItemStyle-Width="120px">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description">
                                <ItemStyle Width="220px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CREATEBY" HeaderText="Create By" ItemStyle-Width="100px">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/Untitled.png" ShowSelectButton="True">
                                <ItemStyle Width="20px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                    <asp:Button ID="btnprint" runat="server" Text="Delete" OnClick="btnprint_Click" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btnprint"
                                        ConfirmText="Do You Realy Want To Delete This Information !!!" runat="server">
                                    </cc1:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
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
