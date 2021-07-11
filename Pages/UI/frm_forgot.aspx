<%@ Page Title="Bangladesh Power Development Board." Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="frm_forgot.aspx.cs" Inherits="frm_forgot" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 500px;
        }
        .style2
        {
            background-color :#EAEAEA;
            padding-right :20px;
             }
        .style189
        {
            width: 300px;
               background-color :#EAEAEA;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" DynamicLayout ="true">
        <ProgressTemplate>
        <center><img id="Img1" src="~/CSS/bar-circle.gif"  runat="server" /><br />
        Processing Please wait ...
        </center>
        </ProgressTemplate>
        </asp:UpdateProgress>
   <as    
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
       <table align="center" > <tr ><td>
       <br />
    <div style="width :500px; border: solid black 1px; padding-left :20px; padding-right :20px;  ">
      
       <h1>Identify Your PIN Code</h1>
       <hr />
                 Before we can reset your PIN Code, you need to enter the information below to help identify your PIN Code:<br />
 <asp:Label ID="laMeg" runat="server" ForeColor="Red"></asp:Label>
<br />
    Enter Your Tracking Number <span style="color :Red">*</span><br />
     <asp:TextBox ID="txt_userid" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txt_userid" ErrorMessage="Enter your tracking number" 
                    ValidationGroup="sv">*</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
        </cc1:ValidatorCalloutExtender>
        <br />
                    <div align="right" >
                         <asp:Button ID="btSave" runat="server" Text="Submit" onclick="btSave_Click"  ValidationGroup ="sv"/>
                        <asp:Button ID="Button1" runat="server" Text="Cancel" 
                             PostBackUrl="~/Default.aspx" />
                         </div>
<br />
               
       </div> 
    </td> </tr> </table> 
</ContentTemplate>
    </asp:UpdatePanel>    
    
</asp:Content>

