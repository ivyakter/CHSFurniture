<%@ Page Title="Branch Setup" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="True" CodeFile="frm_BankBranchSetup.aspx.cs" Inherits="frm_BankBranchSetup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 500px;
            padding: 10px;
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
    <div style="height: 500px">
        <center>
            <br />
            <div style="width: 75%; border: solid black 1px;">
                <div align="center" class="Tidiv">
                    <h3>
                        <asp:Label ID="latitle" runat="server" Text="Branch Setup"></asp:Label>
                    </h3>
                </div>
                <table  width="50%">
                    <tr>
                        <td class="style2" colspan="2">
                            <asp:Label ID="laMeg" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Bank <span style="color: Red">*</span>
                        </td>
                        <td class="style189">
                            <asp:DropDownList ID="ddBankname" runat="server" CssClass="from-control" OnSelectedIndexChanged="AllDDSelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Bank"
                                ControlToValidate="ddBankname" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Branch Name <span style="color: Red">*</span>
                        </td>
                        <td class="style189">
                            <asp:TextBox ID="txtBranchName" runat="server" CssClass="from-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Branch Name required"
                                ControlToValidate="txtBranchName" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
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
                <br />
                <br />
            </div>
        </center>
        <br />
        <div>
            <center>
                <asp:GridView ID="gvBranchSetup" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table"
                    AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" Width="75%"
                    DataKeyNames="ID,BANK_ID">
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField DataField="BRANCH" HeaderText="Branch Name">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank" ItemStyle-Width="120px">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATE_BY" HeaderText="Create By" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATE_DATE" HeaderText="Create Date" ItemStyle-Width="100px"
                            DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/Untitled.png" ShowSelectButton="True"
                            ItemStyle-Width="25px">
                            <ItemStyle Width="25px"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </center>
        </div>
    </div>
</asp:Content>
