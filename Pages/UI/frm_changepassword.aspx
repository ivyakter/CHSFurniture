<%@ Page Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="frm_changepassword.aspx.cs" Inherits="frm_changepassword" Title="Change Password" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">

      
   
        .style191
        {
            background-color :#EAEAEA;
        }
        .style192
        {
        	text-align:center;
            background-color :#EAEAEA;
        }
                
        .style194
        {
            text-align: center;
            background-color : #EAEAEA;
            height: 21px;
            width: 247px;
        }
        
        .style195
        {
            width: 500px;
        }
        .style196
        {
            text-align: center;
            background-color : #EAEAEA;
            height: 21px;
            width: 139px;
        }
        .style199
        {
            background-color : #EAEAEA;
            padding-left: 40px;
        }
        .style200
        {
            text-align: center;
            background-color : #EAEAEA;
            width: 247px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style="overflow:scroll; height:800px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <center><br />
    <div>
       <table style="background-color: #EAEAEA; " class="style195" width="500px">
               <tr>
                   <td align="center" style="background-color: #628BD7" colspan="2"> 
                       &nbsp;<asp:Label ID="latitle" runat="server" Font-Size="Medium" 
                           Text="Password Change"></asp:Label>
                      
                   </td>
               </tr>
               <tr>
                   <td class="style191" colspan="2">
                       <asp:Label ID="laMeg" runat="server" ForeColor="#FF3300"></asp:Label>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="style196">
                       User ID</td>
                   <td class="style194">
                       <asp:Label ID="lalogid" runat="server"></asp:Label>
                       &nbsp;
                   </td>
               </tr>
               <tr>
                   <td class="style199">
                       Current Password <span style="color :Red">*</span></td>
                   <td class="style200">
                       <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password" 
                           Width="200px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtoldpassword" ErrorMessage="RequiredFieldValidator" 
                           ValidationGroup="sa">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style199">
                       New Password <span style="color :Red">*</span></td>
                   <td class="style200">
                       <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" 
                           Width="200px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ControlToValidate="txtnewpassword" ErrorMessage="RequiredFieldValidator" 
                           ValidationGroup="sa">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style199">
                       Retype New Password <span style="color :Red">*</span></td>
                   <td class="style200">
                       <asp:TextBox ID="txtrepassword" runat="server" TextMode="Password" 
                           Width="200px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="txtrepassword" ErrorMessage="RequiredFieldValidator" 
                           ValidationGroup="sa">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style192" colspan="2">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td align="center" colspan="2">
                       <asp:Button ID="btSave" runat="server" CssClass="btn btn-primary" onclick="btSave_Click" Text="Save" 
                           ValidationGroup="sa" Width="70px" />
                       <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                           ConfirmText="Do you want to Save?" TargetControlID="btSave">
                       </cc1:ConfirmButtonExtender>
                   </td>
               </tr>
        </table> </div>
        <br />
        </center>
</ContentTemplate>
    </asp:UpdatePanel>
  </div>
</asp:Content>

