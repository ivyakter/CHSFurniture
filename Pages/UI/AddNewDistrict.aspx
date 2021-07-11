<%@ Page Title="Add District" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AddNewDistrict.aspx.cs" Inherits="UI_AddNewThana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <center>
            <br />
            <div style="width: 500px; border: solid black 1px;">
                <div align="center" class="Tidiv">
                    <h3>
                        <asp:Label ID="latitle" runat="server" Text="District Setup"></asp:Label>
                    </h3>
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
                            &nbsp;
                        </td>
                        <td class="style189">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            District Name <span style="color: Red">*</span>
                        </td>
                        <td class="style189">
                            <asp:TextBox ID="txtArea" runat="server" Width="245px"  MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                        </td>
                        <td class="style189">
                            <asp:Button ID="btSave" runat="server" Text="Add" OnClick="btSave_Click" Width="70px"
                                ValidationGroup="sv" />
                            &nbsp;<asp:Button ID="btClear" runat="server" Text="Clear" Width="70px" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </p>
</asp:Content>
