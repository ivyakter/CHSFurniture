<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddOfficerType.aspx.cs" Inherits="Pages_UI_AddOfficerType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="height: 800px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center">
                    <tr>
                        <td>
                            <div style="width: 600px; border: solid black 1px; margin-top: 20px;">
                                <div align="center" class="Tidiv">
                                    <h3>
                                        <asp:Label ID="latitle" runat="server" Text="Add Employee Type"></asp:Label></h3>
                                </div>
                                <table width="595px">
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:Label ID="laMeg" runat="server" ForeColor="Red"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            Division Name : <span style="color: Red">*</span>
                                        </td>
                                        <td class="style189">
                                            <asp:TextBox ID="txtType" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Godown Name Required"
                                                ControlToValidate="txtType" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr />
        <div align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    </asp:UpdatePanel>
                    <asp:GridView ID="gvUnit" runat="server" DataKeyNames="id" Width="600px" OnSelectedIndexChanged="gvUnit_SelectedIndexChanged"
                        AllowPaging="True" PageSize="20" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnPageIndexChanging="gvUnit_PageIndexChanging">
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="OFF_TYPE_NAME" HeaderText="Division Name"></asp:BoundField>
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

