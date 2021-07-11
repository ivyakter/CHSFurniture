<%@ Page Title="Role Details" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="frm_role_detail.aspx.cs" Inherits="frm_role_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="overflow: scroll; height: 100%;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <center>
                    <div style="width: 75%; border: solid black 1px; margin-top: 20px;">
                        <div class="Tidiv">
                            <h3>
                                Role Details</h3>
                        </div>
                        <table class="style1">
                            <tr>
                                <td class="style192" colspan="2">
                                    <asp:Label ID="lameg" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style192">
                                    Role Name &nbsp;&nbsp;
                                </td>
                                <td class="style193">
                                    <asp:DropDownList ID="drroleid" runat="server" Width="150px" Height="30px" AutoPostBack="True"
                                        OnSelectedIndexChanged="drroleid_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Role Nme"
                                        ControlToValidate="drroleid" ValidationGroup="sv">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style192" valign="top">
                                    Task Name
                                </td>
                                <td class="style195" align="left">
                                    <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" ShowCheckBoxes="All"
                                        ImageSet="Arrows" CssClass="style194" align="left" Font-Names="Courier New">
                                        <ParentNodeStyle Font-Bold="False" CssClass="style194" />
                                        <LevelStyles>
                                            <asp:TreeNodeStyle CssClass="style194" Font-Underline="False" />
                                        </LevelStyles>
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" BackColor="#CCCCCC" />
                                        <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" />
                                        <DataBindings>
                                            <asp:TreeNodeBinding DataMember="MenuItem" TextField="text" ValueField="id" />
                                        </DataBindings>
                                        <RootNodeStyle CssClass="style194" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                            NodeSpacing="0px" VerticalPadding="0px" ChildNodesPadding="0px" CssClass="style194" />
                                        <LeafNodeStyle CssClass="style194" NodeSpacing="0px" />
                                    </asp:TreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="style192">
                                </td>
                                <td class="style193" align="center">
                                    <asp:Button ID="btnsaveCom" runat="server" Text="Save" Width="70px" OnClick="btnsaveCom_Click"
                                        ValidationGroup="sv" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Do you want to Save?"
                                        TargetControlID="btnsaveCom">
                                    </cc1:ConfirmButtonExtender>
                                    &nbsp;
                                    <asp:Button ID="btnClearcom" runat="server" Text="Clear" Width="70px" OnClick="btnClearcom_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style192" colspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="text-align: left"
                                        ValidationGroup="sv" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
