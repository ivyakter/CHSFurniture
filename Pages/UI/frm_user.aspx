<%@ Page Title="User Create" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="frm_user.aspx.cs" Inherits="frm_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 75%;
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
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div style="overflow:scroll; height:100%;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <center>
                <div style="width:75%; border: solid black 1px; margin-top: 20px;">
                    <div align="center" class="Tidiv">
                        <h3>
                            <asp:Label ID="latitle" runat="server" Text="User Entry"></asp:Label></h3>
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
                                User Full Name <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtuser_name" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                                    ControlToValidate="txtuser_name" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                User ID <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtlog_id" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                                    ControlToValidate="txtlog_id" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Password <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtPassword" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
                                    ControlToValidate="txtPassword" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Confirm Password <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtrepassword" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"
                                    ControlToValidate="txtrepassword" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                                    ControlToValidate="txtPassword" ControlToCompare="txtrepassword" ValidationGroup="sv">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Address
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Mobile <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:TextBox ID="txtmobile" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator"
                                    ControlToValidate="txtmobile" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                User Role <span style="color: Red">*</span>
                            </td>
                            <td class="style189">
                                <asp:DropDownList ID="drroleid" runat="server" Width="255px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drroleid"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="sv">*</asp:RequiredFieldValidator>
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
                    <br />
                    <br />
                </div>
                <div>
                    <asp:GridView ID="gvBank" runat="server"  Width="75%" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvBank_SelectedIndexChanged">
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-Width="20px">
                                <ItemStyle Width="20px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="USERID" HeaderText="User ID" ItemStyle-Width="120px">
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_NAME" HeaderText="Uer Name" ItemStyle-Width="120px">
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_PASSWORD" HeaderText="Password" ItemStyle-Width="120px">
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="MOBILE" HeaderText="Mobile" ItemStyle-Width="120px">
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ROLE_ID" HeaderText="Role ID" ItemStyle-Width="120px">
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/Untitled.png" ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblrole" runat="server" Text='<%#Eval("ROLE_ID") %>' Visible="false"></asp:Label>
                                     <asp:Label ID="Label2" runat="server" Text='<%#Eval("USERID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("USER_PASSWORD") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("MOBILE") %>' Visible="false"></asp:Label>
                                    <asp:Button ID="btnprint" runat="server" Text="Delete" OnClick="btnprint_Click" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" TargetControlID="btnprint"
                                        ConfirmText="Do You Realy Want To Delete This Information !!!" runat="server">
                                    </cc1:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="SMS">
                                <ItemTemplate>     
                                  <asp:CheckBox ID="chkstatus" runat="server" AutoPostBack="true" Checked='<%# Eval("status").ToString() == "Active" ? true : false %>'
                                    OnCheckedChanged="chkstatus_CheckedChanged" />
                                                                     
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
                </div>
            </center>
            
            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="sv" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
  </div>
</asp:Content>
