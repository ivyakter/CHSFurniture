<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="EditOfficerInfo.aspx.cs" Inherits="Pages_HumanResource_EditOfficerInfo" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
        .Initial
        {
            display: block;
            padding: 4px 4px 4px 18px;
            float: left;
            background: url("../../Images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }
        .Initial:hover
        {
            color: White;
            background: url("../../Images/SelectedButton.png") no-repeat right top;
        }
        .Clicked
        {
            float: left;
            display: block;
            background: url("../../Images/SelectedButton.png") no-repeat right top;
            padding: 4px 4px 4px 18px;
            color: Black;
            font-weight: bold;
            color: White;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:UpdatePanel ID="UpdatePnl1" runat="server">
        <ContentTemplate>
            <div style="width: 80%">
                <br />
                <br />
                <table class="table">
                    <tr>
                        <td align="right" style="width: 250px">
                            <asp:Label ID="label2" runat="server" Width="100px" Text="Officer Type:"></asp:Label>
                        </td>
                        <td align="left" style="width: 100%">
                            <%-- <asp:DropDownList ID="ddlOffficer" runat="server" Height="30px" Width="165px" class="form-control"
                                AutoPostBack="true">
                            </asp:DropDownList>--%>
                            <asp:DropDownList ID="ddlOfficer" runat="server" class="form-control" Height="30px"
                                Width="150px" AutoPostBack="true">
                                <asp:ListItem Value="0">--Select Officer Type--</asp:ListItem>
                                <asp:ListItem Value="1">Officer</asp:ListItem>
                                <asp:ListItem Value="2">Division Officer</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 150px">
                            <asp:Label ID="label01" runat="server" Width="150px" Text="Officer Name:"></asp:Label>
                        </td>
                        <td align="left" style="width: 250px">
                            <asp:TextBox ID="txtOffName" runat="server" Height="30px" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                         <asp:Label ID="label12" runat="server" Text="Area Name" Width="150px"></asp:Label>
                        </td>                      
                        <td align="right" style="width: 150px">
                         <asp:Label ID="label15" runat="server" Text="Territory:" Width="150px"></asp:Label>                          
                        </td>                        
                        <td>
                          <asp:TextBox ID="txtOfficerId" runat="server" Visible="false" Height="30px" Width="150px" Enabled="false"></asp:TextBox>
                           <asp:TextBox ID="txtOfficerIdOld" runat="server" Visible="false" Height="30px" Width="150px" Enabled="false"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label7" runat="server" Text="Address:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtAddress" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label4" runat="server" Text="Mobile No:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtMobile" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label3" runat="server" Text="Guaranter Name:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtGN" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label8" runat="server" Text="Guaranter Mobile:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtGMob" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label9" runat="server" Text="Guaranter Address:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtGAdd" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 250px">
                                <asp:Label ID="label5" runat="server" Text="Security MIC Check:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCheck" runat="server" Height="30px" placeholder="Check No." 
                                    Width="150px"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>                            
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label10" runat="server" Text="Date of Birth:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtDofBirth" runat="server" Height="30px" 
                                    placeholder="dd/MM/yyyy" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                    Format="yyyy/MM/dd" TargetControlID="txtDofBirth">
                                </cc1:CalendarExtender>
                            </td>
                           
                        </tr>
                        <tr>
                             <td align="right" style="width: 150px">
                                <asp:Label ID="label11" runat="server" Text="Date of Marriage:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtDofMar" runat="server" Height="30px" 
                                    placeholder="dd/MM/yyyy" Width="150px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                    Format="yyyy/MM/dd" TargetControlID="txtDofMar">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label13" runat="server" Text="Number of Children:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtChil" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="label14" runat="server" Text="Previous Company:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtCompany" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                             <td align="right" style="width: 150px">
                                <asp:Label ID="label16" runat="server" Text="Sales Target:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:TextBox ID="txtSalesTarget" runat="server" Height="30px" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Update" Height="25px" 
                    Width="100px" ValidationGroup="sv" onclick="btnSave_Click"/>
                 <asp:Button ID="lnkEdit" runat="server" Text="Cancle" PostBackUrl='~/Pages/HumanResource/OffcierList.aspx' />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

